using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories;

public class ContainerHealthRecordRepository : BaseRepository<ContainerHealthRecord>, IContainerHealthRecordRepository
{
    public ContainerHealthRecordRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
	}

    public async Task<ICollection<ContainerHealthRecord>> GetLatestReportsByTime(int containerId, DateTime from, DateTime? to = null)
    {
        if (to == null)
        {
            to = DateTime.Now;
        }

        return await context.ContainerHealthRecords
            .Where(x => x.ContainerId == containerId && x.SavedAt >= from && x.SavedAt <= to)
            .OrderByDescending(x => x.SavedAt)
            .ToListAsync();
    }
}