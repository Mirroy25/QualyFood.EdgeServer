using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories
{
	public class ContainerStatusRecordRepository : BaseRepository<ContainerStatusRecord>, IContainerStatusRecordRepository
	{
		public ContainerStatusRecordRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

        public async Task<ICollection<ContainerStatusRecord>> GetLatestReportsByTime(int containerId, DateTime from, DateTime? to)
        {
            if (to == null)
            {
                to = DateTime.Now;
            }

            return await context.ContainerStatusRecords
                .Where(x => x.ContainerId == containerId && x.SavedAt >= from && x.SavedAt <= to)
                .OrderByDescending(x => x.SavedAt).ToListAsync();
        }


    }
}