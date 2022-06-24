using Abp.Domain.Repositories;
using Abp.Domain.Services;
using BP.API.Dto;
using BP.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BP.Notification.Business
{
    public class AuditLogBusiness: DomainService
    {
        private readonly IRepository<AuditLog, long> repositoryAuditLog;
        private readonly IRepository<AuditDescription, long> _repositoryAuditDes;

        public AuditLogBusiness(IRepository<AuditLog, long> irepositoryAuditLog, IRepository<AuditDescription, long> desAudit)
        {
            repositoryAuditLog = irepositoryAuditLog;
            _repositoryAuditDes = desAudit;
        }
        /// <summary>
        /// Get the object IQueryable of filter
        /// </summary>
        /// <param name="input">Filters</param>
        /// <returns>IQueryable<User></returns>

        public IQueryable<AuditLog> GetObjectFiltro(PagedAuditLogFilterResultRequestDto input)
        {
            if (!string.IsNullOrEmpty(input.ServiceName))
                return repositoryAuditLog.GetAll().Where(a => (a.ExecutionTime >= input.DateTimeStart && a.ExecutionTime <= input.DateTimeEnd)
                                                                && a.ServiceName.Contains(input.ServiceName));
            else if (!string.IsNullOrEmpty(input.MethodName))
                return repositoryAuditLog.GetAll().Where(a => (a.ExecutionTime >= input.DateTimeStart && a.ExecutionTime <= input.DateTimeEnd)
                                                                && a.MethodName.Contains(input.MethodName));

            return repositoryAuditLog.GetAll().Where(a => a.ExecutionTime >= input.DateTimeStart && a.ExecutionTime <= input.DateTimeEnd);
        }
        public List<AuditLogDto> GetAuditList(IQueryable<AuditLog> audit)
        {
            List<AuditLogDto> result = audit.Select(y => new AuditLogDto
            {
                ServiceName = y.ServiceName,
                MethodName = y.MethodName,
                Parameters = y.Parameters,
                ReturnValue = y.ReturnValue,
                ExecutionTime = y.ExecutionTime,
                ExecutionDuration = y.ExecutionDuration,
                ClientIpAddress = y.ClientIpAddress,
                ClientName = y.ClientName,
                BrowserInfo = y.BrowserInfo,
                Exception = y.Exception,
                ImpersonatorUserId = y.ImpersonatorUserId,
                CustomData = y.CustomData,
                DescriptionServiceName = _repositoryAuditDes.GetAll().Where(x => x.NameService == y.ServiceName).Select(y => y.Value).FirstOrDefault(),
                UserId = y.UserId,
            }).ToList();
            return result;
        }
    }
}
