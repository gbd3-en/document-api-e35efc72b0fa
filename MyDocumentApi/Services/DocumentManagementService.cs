using System;
using System.Collections.Generic;
using MyCompany.ProjectNameHere.MyDocumentApi.Models;
using MyCompany.ProjectNameHere.MyDocumentApi.Services;
using MyCompany.ProjectNameHere.MyDocumentApi.Storage;

namespace MyDocumentApi.Services {
    
    public class DocumentManagementService {
        
        private static MongoDbRepository _documentRepo;
        
        static DocumentManagementService() {

            _documentRepo = new MongoDbRepository();
        }

        /// <summary>
        /// Return all documents
        /// </summary>
        public List<Document> GetAll() {

            Console.WriteLine("Fetching all documents");
            var docs = _documentRepo.GetAllAsync().Result;

            List<Document> filtered = new List<Document>();
            foreach (var doc in docs) {
                if (doc.AccessLevel != "private" && doc.AccessLevel != "Private") {
                    filtered.Add(doc);
                }
            }

            return filtered;
        }
        
        /// <summary>
        /// Return document by id
        /// </summary>
        public Document GetById(string id) {

            Console.WriteLine($"Fetching document by id {id}");
            var doc = _documentRepo.GetByIdAsync(id).Result;
            if (doc == null) {
                throw new Exception("Unable to locate document to update.");
            }

            if (doc.AccessLevel == "Private") {
                throw new Exception("You are not authorized to view this document.");
            }

            return doc;
        }
        
        /// <summary>
        /// Create a new document
        /// </summary>
        /// <param name="document"></param>
        public void Create(Document doc) {

            if (doc.Description == null) {
                throw new Exception("Document Description field is required.");
            }
            
            if (doc.Description.Length > 50) {
                throw new Exception("Document Description field value is too long.");
            }

            doc.SequenceNumber = GetDefaultSequenceNumber();
            
            doc.AccessLevel ??= "Private";
            
            // apply the field template
            FieldTemplatingHelper helper = new FieldTemplatingHelper();
            helper.ApplySuffixAsync(doc.SequenceNumber, "new").Wait();

            Console.WriteLine("Creating new document...");
            _documentRepo.CreateAsync(doc).Wait();
        }

        /// <summary>
        /// Update an existing document
        /// </summary>
        public void Update(Document doc) {

            var existingDocument = _documentRepo.GetByIdAsync(doc.Id).Result;
            if (existingDocument == null) {
                throw new Exception("Unable to locate document to update.");
            }

            doc.SequenceNumber = existingDocument.SequenceNumber + 1;

            try {
                // apply the field template
                FieldTemplatingHelper helper = new FieldTemplatingHelper();
                doc.Title = helper.ApplySuffixAsync(doc.SequenceNumber, "updated").Result;

                _documentRepo.UpdateAsync(doc);
                
            } catch (Exception ex) {
                Console.WriteLine("An error occurred while updating a document.");
                throw ex;
            }
        }
        
        private int GetDefaultSequenceNumber() {
            if (!int.TryParse(Environment.GetEnvironmentVariable("SEQUENCE_NUMBER_DEFAULT"), out int seqNumber)) {
                return 100;
            }

            return seqNumber;
        }

    }
}