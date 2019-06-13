using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DDDCms.Domain.Document;
using DDDCms.Domain.Document.Entities;

namespace DDDCms.Services
{
    public interface IDocumentService
    {
        Task<DocumentId> CreateAsync(string title, List<FieldEntity> fields, CancellationToken cancellationToken);
    }
}