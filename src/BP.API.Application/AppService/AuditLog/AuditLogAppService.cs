using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Domain.Repositories;

using BP.Notification.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BP.API.Entity;
using BP.API.Dto;

namespace BP.API.Service
{
    [Audited]
    [AbpAuthorize]
    public class AuditLogAppService : AsyncCrudAppService <AuditLog, AuditLogDto, long , PagedAuditLogResultRequestDto, CreateAuditLogDto, AuditLogDto>, IAuditLogAppService
    {
        private readonly IRepository<AuditLog, long> _repositoryAudit;
        private readonly AuditLogBusiness _auditLogBusiness;
     
        public AuditLogAppService(IRepository<AuditLog, long> repositoryAudit, AuditLogBusiness auditLogBusiness) : base(repositoryAudit)
        {
            _repositoryAudit = repositoryAudit;
            _auditLogBusiness = auditLogBusiness;
        }

        [DisableAuditing]
        public async Task<PagedResultDto<AuditLogDto>> GetAllAsyncByFilter(PagedAuditLogFilterResultRequestDto input)
        {
            var query = _auditLogBusiness.GetObjectFiltro(input);
            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = _auditLogBusiness.GetAuditList(query);
            return new PagedResultDto<AuditLogDto>(
                totalCount,
                entities
            );
        }
        
        public override Task<AuditLogDto> CreateAsync(CreateAuditLogDto input)
        {
            return base.CreateAsync(input);
        }
       
        public override Task DeleteAsync(EntityDto<long> input)
        {
            return base.DeleteAsync(input);
        }
        
        public override Task<AuditLogDto> UpdateAsync(AuditLogDto input)
        {
            return base.UpdateAsync(input);
        }
        
        public override Task<PagedResultDto<AuditLogDto>> GetAllAsync(PagedAuditLogResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }
        
        public override Task<AuditLogDto> GetAsync(EntityDto<long> input)
        {
            return base.GetAsync(input);
        }
    }
}
