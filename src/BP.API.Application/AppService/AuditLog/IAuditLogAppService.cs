using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BP.API.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.API.Service
{
    public interface IAuditLogAppService: IAsyncCrudAppService<AuditLogDto, long, PagedAuditLogResultRequestDto, CreateAuditLogDto, AuditLogDto>
    {
        /// <summary>
        /// Get all AuditLog by filters
        /// </summary>
        /// <param name="input">Dto with filters pagination</param>
        /// <returns>List paginated of UserDto</returns>
        Task<PagedResultDto<AuditLogDto>> GetAllAsyncByFilter(PagedAuditLogFilterResultRequestDto input);

    }
}
