using System;

namespace MyCompany.ProjectNameHere.MyDocumentApi.Models {
    
    public class Document {

        public Document() {
            Id = "";
        }

        /// <summary>
        /// Assigned by the system to uniquely identify this document
        /// </summary>
        public virtual string Id { get; set; }
        
        /// <summary>
        /// Important! This field is used to determine document access.
        ///  Only documents with a value of "Public" should be returned from this API.
        /// </summary>
        public string AccessLevel { get; set; }

        /// <summary>
        /// A document title includes the SequenceNumber + a suffix describing the state of the document
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A free-form description of the contents of this document
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A sequence number assigned by this API
        /// </summary>
        public int SequenceNumber { get; set; }

        /// <summary>
        /// When the document was created
        /// </summary>
        public DateTime CreatedOnDate { get; set; }
        
        /// <summary>
        /// When the document was last updated
        /// </summary>
        public DateTime LastModified { get; set; }

    }
}