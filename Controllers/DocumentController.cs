using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using DocumentsService.Services;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documentitem>>> GetDocument()
        {
            return dService.Get();
        }

        // GET: api/Document/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Documentitem>> GetDocumentItem(long id)
        {
            var returnValue = dService.Get(id);
            return returnValue;
        }

        // PUT: api/Document/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentItem(long id, Documentitem document)
        {
            dService.Update(document);
            return null;
        }

        // POST: api/Document
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Documentitem>> PostDocumentItem(Documentitem document)
        {
            dService.Create(document);
            return null;
        }

        // DELETE: api/Document/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentItem(long id)
        {
            dService.Remove(id);
            return null;
        }

    }
}
