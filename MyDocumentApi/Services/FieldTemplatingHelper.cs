using System.Threading.Tasks;

namespace MyCompany.ProjectNameHere.MyDocumentApi.Services {

    public class FieldTemplatingHelper {

        public async Task<string> ApplySuffixAsync(int input, string suffix) {

            return input + "-" + suffix;
        }

    }
}