namespace DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
	public DbSet<Container> Containers { get; set; }
	public DbSet<ContainerStatusRecord> ContainerStatusRecords { get; set; }
	public DbSet<ContainerHealthRecord> ContainerHealthRecords { get; set; }
}