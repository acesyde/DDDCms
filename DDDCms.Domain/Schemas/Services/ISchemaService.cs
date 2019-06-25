using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DDDCms.Domain.Schemas.Entities;

namespace DDDCms.Domain.Schemas.Services
{
    public interface ISchemaService
    {
        Task<SchemaId> CreateAsync(List<FieldEntity> fields, CancellationToken cancellationToken);
    }
}