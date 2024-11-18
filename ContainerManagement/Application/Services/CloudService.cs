using DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;
using DittoBox.EdgeServer.ContainerManagement.Domain.Services;
using DittoBox.EdgeServer.ContainerManagement.Application.Resources;

namespace DittoBox.EdgeServer.ContainerManagement.Application.Services
{
	public class CloudService(
		IContainerService containerService
	) : BaseService, ICloudService
	{
		public Task SendContainerStatusReport(ContainerStatusRecord record)
		{
			throw new NotImplementedException();
		}

		public async Task<ContainerRegistrationResource> RegisterContainer(string uiid)
		{
			var resource = new { uiid = uiid };
			var client = new HttpClient();
			var response = await client.PostAsJsonAsync(Path.Combine(BaseUrl, "group/register-container"), resource);
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<ContainerRegistrationResource>();
				await containerService.CreateContainer(result.Uiid, result.Id);
				return result;
			}
			else
			{
				Console.WriteLine($"Failed to register container: {response.StatusCode}. {response.Content}. \n\n {resource} ");
				throw new Exception("Failed to register container");
			}
		}
	}
}
