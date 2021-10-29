using MyCompany.ProjectNameHere.MyDocumentApi.Services;
using MyDocumentApi.Services;
using Xunit;

namespace MyCompany.ProjectNameHere.MyDocumentApi.Tests.Services {
    
    public class FieldTemplatingHelperTests {
        
        [Fact]
        public async void CanAppendTemplate() {

            var helper = new FieldTemplatingHelper();
            string result = await helper.ApplySuffixAsync(1234, "suffix");
                
            Assert.Equal("1234-suffix", result);
        }
        
    }
}