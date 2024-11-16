
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Services
{
	public interface IContainerRepository : IBaseRepository<Container>
	{
		public Task<Container?> GetContainerByUIID(string uiid);
    }
}