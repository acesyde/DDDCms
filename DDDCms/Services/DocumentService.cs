using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DDDCms.Domain.Document;
using DDDCms.Domain.Document.Commands;
using DDDCms.Domain.Document.Entities;
using EventFlow;
using Microsoft.Extensions.Logging;

namespace DDDCms.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly ILogger<DocumentService> _logger;
        private readonly ICommandBus _commandBus;

        public DocumentService(ILogger<DocumentService> logger, ICommandBus commandBus)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
        }

        public async Task<DocumentId> CreateAsync(string title, List<FieldEntity> fields, CancellationToken cancellationToken)
        {
            var id = DocumentId.New;

            await _commandBus.PublishAsync(new CreateDocument(id, title, fields), cancellationToken);

            return id;
        }
    }
}
