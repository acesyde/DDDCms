using System.Collections.Generic;
using System.Linq;
using DDDCms.Domain.Document.Entities;
using DDDCms.Domain.Document.Events;
using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;

namespace DDDCms.Domain.Document
{
    public class DocumentAggregate : AggregateRoot<DocumentAggregate, DocumentId>,
        IApply<DocumentCreated>
    {
        public string Title { get; private set; }
        public List<FieldEntity> Fields { get; private set; }
        
        public DocumentAggregate(DocumentId id) : base(id)
        {
        }

        public IExecutionResult CreateDocument(string title, List<FieldEntity> commandFieldEntities)
        {
            if(!IsNew)
                return ExecutionResult.Failed(new []{"Cannot use an existing document"});
            
            Emit(new DocumentCreated
            {
                Title = title,
                Fields = commandFieldEntities
            });
            
            return ExecutionResult.Success();
        }

        public void Apply(DocumentCreated aggregateEvent)
        {
            Title = aggregateEvent.Title;
            Fields = aggregateEvent.Fields ?? new List<FieldEntity>();
        }
    }
}