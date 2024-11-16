using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories;

namespace DittoBox.EdgeServer.ContainerManagement.Domain.Services
{
	public interface IContainerHealthRecordRepository : IBaseRepository<ContainerHealthRecord>
	{
		public Task<ICollection<ContainerHealthRecord>> GetLatestReportsByTime(int containerId, DateTime from, DateTime? to = null);
    }
}