using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories
{
	public interface IContainerStatusRecordRepository : IBaseRepository<ContainerStatusRecord>
	{
        public Task<ICollection<ContainerStatusRecord>> GetLatestReportsByTime(int containerId, DateTime from, DateTime? to = null);
    }
}