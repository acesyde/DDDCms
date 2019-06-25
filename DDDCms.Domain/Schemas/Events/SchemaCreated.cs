using System.Collections.Generic;
using DDDCms.Domain.Schemas.Entities;
using EventFlow.Aggregates;

namespace DDDCms.Domain.Schemas.Events
{
    public class SchemaCreated : AggregateEvent<SchemaAggregate, SchemaId>
    {
        public List<FieldEntity> Fields { get; set; }
    }
}