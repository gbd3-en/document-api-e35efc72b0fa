using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCompany.ProjectNameHere.MyDocumentApi.Models;

namespace MyCompany.ProjectNameHere.MyDocumentApi.Storage {
    
    /// <summary>
    /// Ignore the details of this class -- used as a stand in for a proper MongoDb-backed implementation
    /// </summary>
    /// <remarks>Should be instantiated as a singleton.</remarks>
    public class MongoDbRepository : IDocumentRepository {

        private readonly List<Document> _data = new List<Document>() {
            new Document {
                Id = "001",
                Title = "500-updated",
                SequenceNumber = 500,
                Description = "A first step for a document, a giant leap for document-kind.",
                AccessLevel = "Public",
                CreatedOnDate = new DateTime(1969, 7, 20),
                LastModified = new DateTime(2021, 10, 13),
            },
            new Document {
                Id = "002",
                Title = "600-updated",
                SequenceNumber = 600,
                Description = "Super secret document.  Do not let anyone see this.",
                AccessLevel = "Private",
                CreatedOnDate = new DateTime(2021, 02, 23),
                LastModified = new DateTime(2021, 02, 23),
            },
        };

        /// <summary>
        /// Return all documents
        /// </summary>
        /// <remarks>Ignore the details of this method -- it is a stand in for a proper MongoDb-backed implementation</remarks>
        public Task<IEnumerable<Document>> GetAllAsync() {
            
            return Task.FromResult<IEnumerable<Document>>(_data);
        }
        
        /// <summary>
        /// Return a document by id.  Returns null if the document doesn't exist.
        /// </summary>
        /// <remarks>Ignore the details of this method -- it is a stand in for a proper MongoDb-backed implementation</remarks>
        public Task<Document> GetByIdAsync(string id) {
    
            var doc = _data.SingleOrDefault(d => d.Id == id);
            return Task.FromResult(doc);
        }
        
        /// <summary>
        /// Create a new document and return the id of the newly created document
        /// </summary>
        /// <remarks>Ignore the details of this method -- it is a stand in for a proper MongoDb-backed implementation</remarks>
        public Task<string> CreateAsync(Document doc) {

            string newId = $"{_data.Count + 1:000}";
            doc.Id = newId;

            doc.CreatedOnDate = DateTime.Now;
            doc.LastModified = DateTime.Now;

            _data.Add(doc);

            return Task.FromResult(newId);
        }
        
        /// <summary>
        /// Update an existing document.  Returns null if the document did not exist.
        /// </summary>
        /// <remarks>Ignore the details of this method -- it is a stand in for a proper MongoDb-backed implementation</remarks>
        public Task<string> UpdateAsync(Document doc) {

            int index = _data.FindIndex(x => x.Id == doc.Id);
            if (index > -1) {
                doc.LastModified = DateTime.Now;
                
                _data[index] = doc;
            } else {

                return Task.FromResult<string>(null);
            }

            return Task.FromResult(doc.Id);
        }

    }
}