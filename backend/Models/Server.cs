namespace ItServiceDashboard.Models;

public class Server
{
    public int Id { get; set; }

    public string Hostname { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string OperatingSystem { get; set; } = string.Empty;
    public string Status { get; set; } = "OK"; // OK / Warning / Down

    public int ClientId { get; set; }
    public Client? Client { get; set; }
}
