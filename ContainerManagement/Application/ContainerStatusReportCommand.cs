using System.ComponentModel.DataAnnotations;

namespace DittoBox.EdgeServer.ContainerManagement.Application
{
    public record ContainerStatusReportCommand
    {
        [Required]
        public int ContainerId;
        [Required]
        public double? Temperature { get; set; }
        [Required]
        public double? Humidity { get; set; }
        [Required]
        public double? Oxygen { get; set; }
        [Required]
        public double? Dioxide { get; set; }
        [Required]
        public double? Ethylene { get; set; }
        [Required]
        public double? Ammonia { get; set; }
        [Required]
        public double? SulfurDioxide { get; set; }
    }
}
