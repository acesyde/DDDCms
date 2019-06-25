using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DDDCms.Controllers.Schema.Models;
using DDDCms.Controllers.Schema.Models.Fields;
using DDDCms.Domain.Schemas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DDDCms.Controllers.Schema
{
    [ApiController]
    [Route("api/schemas")]
    public class SchemaController : Controller
    {
        private readonly ILogger<SchemaController> _logger;
        private readonly ISchemaService _schemaService;

        public SchemaController(ILogger<SchemaController> logger, ISchemaService schemaService)
        {
            _logger = logger;
            _schemaService = schemaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateSchemaDto dto, CancellationToken cancellationToken)
        {
            var id = await _schemaService.CreateAsync(dto.Fields.ToEntities().ToList(), cancellationToken);
            return AcceptedAtAction(nameof(Get), new { id = id }, null);
        }
    }
}