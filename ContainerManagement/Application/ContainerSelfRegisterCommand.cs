using System.ComponentModel.DataAnnotations;

namespace DittoBox.EdgeServer.ContainerManagement.Application
{
    public record ContainerSelfRegisterCommand
    {
		[Required]
		public string Uiid { get; set; }
    }
}
