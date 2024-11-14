namespace DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<Container> Containers { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
	}
}