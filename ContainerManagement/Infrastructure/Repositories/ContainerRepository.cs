using DittoBox.EdgeServer.ContainerManagement.Application.Services;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories
{
	public class ContainerRepository(ApplicationDbContext dbContext) : BaseRepository<Container>(dbContext), IContainerRepository
	{
        public Task<Container?> GetContainerByUIID(string uiid)
        {
            return context.Containers.FirstOrDefaultAsync(c => c.UIID == uiid);
        }
    }
}