using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace DDDCms.Domain.Schemas.Commands.Handlers
{
    public class CreateSchemaHandler : CommandHandler<SchemaAggregate, SchemaId, IExecutionResult, CreateSchema>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(SchemaAggregate aggregate, CreateSchema command, CancellationToken cancellationToken)
        {
            var result = aggregate.CreateDocument(command.FieldEntities);
            return Task.FromResult(result);
        }
    }
}