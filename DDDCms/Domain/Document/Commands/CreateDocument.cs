using System.Collections.Generic;
using DDDCms.Domain.Document.Entities;
using EventFlow.Commands;

namespace DDDCms.Domain.Document.Commands
{
    public class CreateDocument : Command<DocumentAggregate, DocumentId>
    {
        public string Title { get; }
        public List<FieldEntity> FieldEntities { get; }

        public CreateDocument(DocumentId aggregateId, string title, List<FieldEntity> fieldEntities) : base(aggregateId)
        {
            Title = title;
            FieldEntities = fieldEntities;
        }
    }
}