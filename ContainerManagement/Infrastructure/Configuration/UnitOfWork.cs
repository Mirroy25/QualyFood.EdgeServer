
namespace DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
	private readonly ApplicationDbContext context = context;

	public async Task CommitAsync()
	{
		await context.SaveChangesAsync();
	}
}