using System.Collections.Generic;
using System.Threading.Tasks;
using MyCompany.ProjectNameHere.MyDocumentApi.Models;

namespace MyCompany.ProjectNameHere.MyDocumentApi.Storage {
    
    public interface IDocumentRepository {
        
        /// <summary>
        /// Return all documents
        /// </summary>
        Task<IEnumerable<Document>> GetAllAsync();

        /// <summary>
        /// Return a document by id.  Returns null if the document doesn't exist.
        /// </summary>
        Task<Document> GetByIdAsync(string id);

        /// <summary>
        /// Create a new document and return the id of the newly created document
        /// </summary>
        Task<string> CreateAsync(Document doc);

        /// <summary>
        /// Update an existing document.  Returns null if the document did not exist.
        /// </summary>
        Task<string> UpdateAsync(Document doc);
    }
}