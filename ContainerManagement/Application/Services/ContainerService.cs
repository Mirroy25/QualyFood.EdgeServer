using System.ComponentModel;
using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;
using DittoBox.EdgeServer.ContainerManagement.Infrastructure.Repositories;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Services
{
	public class ContainerService(
		IContainerHealthRecordRepository containerHealthRecordRepository,
		IContainerStatusRecordRepository containerStatusRecordRepository
	) : BaseService, IContainerService
	{
		public Task ForwardNewTemplateSettings()
		{
			throw new NotImplementedException();
		}

		public Task<bool> IsReportToCloudRequired()
		{
			throw new NotImplementedException();
		}

		public Task SaveHealthReport(ContainerHealthRecord healthReport)
		{
			throw new NotImplementedException();
		}

		public Task SaveStatusReport(ContainerStatusRecord statusReport)
		{
			throw new NotImplementedException();
		}
	}
}
