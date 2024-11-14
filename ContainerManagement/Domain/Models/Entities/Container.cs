namespace DittoBox.EdgeServer.ContainerManagement.Domain.Models.Entities;

public class Container
{
    public int Id { get; set; }
    public string UIID { get; set; } // Unique internal identifier. Hardcoded value on each container microcontroller.
    public string? MACAddress { get; set; } // MAC address of the container microcontroller.
    public DateTime LastReport { get; set; } // Last time the container microcontroller reported to the cloud.
    public string? Name { get; set; } // Name of the container.
}