using Abp.Auditing;
using Abp.Dependency;
using Abp.Domain.Repositories;
using BP.API.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.API.Auditing
{
    public class AuditingStore : IAuditingStore, ITransientDependency
    {
        private readonly IRepository<AuditLog, long> _auditLogRepository;

        /// <summary>
        /// Creates  a new <see cref="AuditingStore"/>.
        /// </summary>
        public AuditingStore(IRepository<AuditLog, long> auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public virtual Task SaveAsync(AuditInfo auditInfo)
        {
            return _auditLogRepository.InsertAsync(AuditLog.CreateFromAuditInfo(auditInfo));
        }

        public virtual void Save(AuditInfo auditInfo)
        {
            _auditLogRepository.Insert(AuditLog.CreateFromAuditInfo(auditInfo));
        }
    }
}
