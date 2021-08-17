using DocumentsService.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test_API.Models;

namespace Test_API.Controllers
{
    [Route("api/v1/documents")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        public DocumentService dService;

        public DocumentController(DocumentService dservice)
        {
            this.dService = dservice;
        }

        // GET: api/Document
        [DisableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documentitem>>> GetDocument()
        {
            return dService.Get();
        }

        // GET: api/Document/5
        [DisableCors]
        [HttpGet("{id}")]
        public async Task<ActionResult<Documentitem>> GetDocumentItem(long id)
        {
            var returnValue = dService.Get(id);
            return returnValue;
        }

        // PUT: api/Document/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [DisableCors]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentItem(long id, Documentitem document)
        {
            dService.Update(document);
            return StatusCode(StatusCodes.Status200OK, "Document was updated");
        }

        // POST: api/Document
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [DisableCors]
        [HttpPost]
        public async Task<ActionResult<Documentitem>> PostDocumentItem(Documentitem document)
        {
            dService.Create(document);
            return StatusCode(StatusCodes.Status201Created, "Document was created");
        }

        // DELETE: api/Document/5
        [DisableCors]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentItem(long id)
        {
            dService.Remove(id);
            return StatusCode(StatusCodes.Status200OK, "Document was deleted");
        }

    }
}
