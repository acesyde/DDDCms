using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace DDDCms.Domain.Document.Commands.Handlers
{
    public class CreateDocumentHandler : CommandHandler<DocumentAggregate, DocumentId, IExecutionResult, CreateDocument>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(DocumentAggregate aggregate, CreateDocument command, CancellationToken cancellationToken)
        {
            var result = aggregate.CreateDocument(command.Title, command.FieldEntities);
            return Task.FromResult(result);
        }
    }
}