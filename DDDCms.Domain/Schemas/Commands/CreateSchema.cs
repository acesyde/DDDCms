using System.Collections.Generic;
using DDDCms.Domain.Schemas.Entities;
using EventFlow.Commands;

namespace DDDCms.Domain.Schemas.Commands
{
    public class CreateSchema : Command<SchemaAggregate, SchemaId>
    {
        public List<FieldEntity> FieldEntities { get; }
        
        public CreateSchema(SchemaId aggregateId, List<FieldEntity> fieldEntities) : base(aggregateId)
        {
            FieldEntities = fieldEntities;
        }
    }
}