using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
	protected readonly ApplicationDbContext _dbContext;

	public BaseRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public virtual async Task<T?> GetByIdAsync(Guid id)
	{
		return await _dbContext.Set<T>().FindAsync(id);
	}

	public virtual async Task<IEnumerable<T>> GetAllAsync()
	{
		return await _dbContext.Set<T>().ToListAsync();
	}

	public virtual async Task AddAsync(T entity)
	{
		await _dbContext.Set<T>().AddAsync(entity);
		await _dbContext.SaveChangesAsync();
	}

	public virtual async Task UpdateAsync(T entity)
	{
		_dbContext.Set<T>().Update(entity);
		await _dbContext.SaveChangesAsync();
	}

	public virtual async Task DeleteAsync(T entity)
	{
		_dbContext.Set<T>().Remove(entity);
		await _dbContext.SaveChangesAsync();
	}
}