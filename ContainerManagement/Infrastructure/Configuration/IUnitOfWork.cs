namespace DittoBox.EdgeServer.ContainerManagement.Infrastructure.Configuration;

public interface IUnitOfWork {
	Task CommitAsync();
}