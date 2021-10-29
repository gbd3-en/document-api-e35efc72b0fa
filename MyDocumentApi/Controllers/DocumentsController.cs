using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCompany.ProjectNameHere.MyDocumentApi.Models;
using MyDocumentApi.Services;

namespace MyCompany.ProjectNameHere.MyDocumentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase {

        private readonly DocumentManagementService _service;
        
        public DocumentsController() {
            _service = new DocumentManagementService();
        }

        [HttpGet("all")]
        public IEnumerable<Document> Get() {
            
            Response.Headers.Add("X-MyApplication-Identifier", "my-api-v1.0");
            return _service.GetAll();
        }
        
        [HttpGet("single")]
        public Document Get([Required][FromQuery]string id) {
            
            Response.Headers.Add("X-MyApplication-Identifier", "my-api-v1.0");
            return _service.GetById(id);
        }
        
        [HttpPost]
        public async Task<ActionResult> Create() {

            var doc = await JsonSerializer.DeserializeAsync<Document>(Request.Body, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            });

            _service.Create(doc);

            Response.Headers.Add("X-MyApplication-Identifier", "my-api-v1.0");
            return Ok(doc);
        }
        
        [HttpPut]
        public ActionResult Update([FromBody]Document doc) {

            _service.Update(doc);

            Response.Headers.Add("X-MyApplication-Identifier", "my-api-v1.0");
            return Ok(doc);
        }
    }
}
