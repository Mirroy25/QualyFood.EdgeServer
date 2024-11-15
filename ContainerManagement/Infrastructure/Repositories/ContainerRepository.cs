using DittoBox.EdgeServer.ContainerManagement.Application.Services;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;

namespace DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories
{
	public class ContainerRepository : BaseRepository<Container>, IContainerRepository
	{
		public ContainerRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

	}
}