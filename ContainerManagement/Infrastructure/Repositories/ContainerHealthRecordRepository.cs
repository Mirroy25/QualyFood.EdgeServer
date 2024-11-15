using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;

namespace DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories;

public class ContainerHealthRecordRepository : BaseRepository<ContainerHealthRecord>, IContainerHealthRecordRepository
{
	public ContainerHealthRecordRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
	}
}