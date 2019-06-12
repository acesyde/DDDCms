using System.Collections.Generic;
using DDDCms.Domain.Document.Entities;
using EventFlow.Aggregates;

namespace DDDCms.Domain.Document.Events
{
    public class DocumentCreated : AggregateEvent<DocumentAggregate, DocumentId>
    {
        public string Title { get; set; }
        public List<FieldEntity> Fields { get; set; }
    }
}