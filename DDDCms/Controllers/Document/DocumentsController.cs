using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DDDCms.Controllers.Document.Models;
using DDDCms.Controllers.Document.Models.Fields;
using DDDCms.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DDDCms.Controllers.Document
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentController : Controller
    {
        private readonly ILogger<DocumentController> _logger;
        private readonly IDocumentService _documentService;

        public DocumentController(ILogger<DocumentController> logger, IDocumentService documentService)
        {
            _logger = logger;
            _documentService = documentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDocumentDto dto, CancellationToken cancellationToken)
        {
            var id = await _documentService.CreateAsync(dto.Title, dto.Fields.ToEntities().ToList(), cancellationToken);
            return AcceptedAtAction(nameof(Get), new { id = id }, null);
        }
    }
}