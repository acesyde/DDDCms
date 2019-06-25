using System.Collections.Generic;
using DDDCms.Domain.Schemas.Entities;
using DDDCms.Domain.Schemas.Events;
using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;

namespace DDDCms.Domain.Schemas
{
    public class SchemaAggregate : AggregateRoot<SchemaAggregate, SchemaId>
    {
        public List<FieldEntity> Fields { get; private set; }

        public SchemaAggregate(SchemaId id) : base(id)
        {
        }

        public IExecutionResult CreateDocument(List<FieldEntity> commandFieldEntities)
        {
            if (!IsNew)
                return ExecutionResult.Failed(new[] {"Aggregate already exist"});
            
            Emit(new SchemaCreated
            {
                Fields = commandFieldEntities
            });

            return ExecutionResult.Success();
        }
    }
}