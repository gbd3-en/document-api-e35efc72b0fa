using System;

namespace MyCompany.ProjectNameHere.MyDocumentApi.Models {
    
    public class Document {

        public Document() {
            Id = "";
        }
        
        public virtual string Id { get; set; }
        
        public string AccessLevel { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int SequenceNumber { get; set; }
        
        public DateTime CreatedOnDate { get; set; }
        
        public DateTime LastModified { get; set; }

    }
}