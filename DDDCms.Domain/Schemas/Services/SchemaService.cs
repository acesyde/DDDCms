using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DDDCms.Domain.Schemas.Commands;
using DDDCms.Domain.Schemas.Entities;
using EventFlow;
using Microsoft.Extensions.Logging;

namespace DDDCms.Domain.Schemas.Services
{
    public class SchemaService : ISchemaService
    {
        private readonly ILogger<SchemaService> _logger;
        private readonly ICommandBus _commandBus;

        public SchemaService(ILogger<SchemaService> logger, ICommandBus commandBus)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
        }

        public async Task<SchemaId> CreateAsync(List<FieldEntity> fields, CancellationToken cancellationToken)
        {
            var id = SchemaId.New;

            await _commandBus.PublishAsync(new CreateSchema(id, fields), cancellationToken);

            return id;
        }
    }
}