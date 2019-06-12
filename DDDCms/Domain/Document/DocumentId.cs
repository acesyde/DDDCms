using EventFlow.Core;

namespace DDDCms.Domain.Document
{
    public class DocumentId : Identity<DocumentId>
    {
        public DocumentId(string value) : base(value)
        {
        }
    }
}