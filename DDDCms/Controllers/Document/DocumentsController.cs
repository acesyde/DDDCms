using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DDDCms.Controllers.Document.Models;
using DDDCms.Controllers.Document.Models.Fields;
using DDDCms.Domain.Document;
using DDDCms.Domain.Document.Commands;
using EventFlow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DDDCms.Controllers.Document
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentController : Controller
    {
        private readonly ILogger<DocumentController> _logger;
        private readonly ICommandBus _commandBus;

        public DocumentController(ILogger<DocumentController> logger, ICommandBus commandBus)
        {
            _logger = logger;
            _commandBus = commandBus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDocumentDto dto, CancellationToken cancellationToken)
        {
            var result = await _commandBus.PublishAsync(new CreateDocument(DocumentId.New, dto.Title, dto.Fields.ToEntities().ToList()), cancellationToken);
            if (!result.IsSuccess)
                return BadRequest();

            return Ok();
        }
    }
}