using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;

namespace DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories
{
	public class ContainerStatusRecordRepository : BaseRepository<ContainerStatusRecord>, IContainerStatusRecordRepository
	{
		public ContainerStatusRecordRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}