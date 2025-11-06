namespace ItServiceDashboard.Models;

public class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Industry { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public List<Server> Servers { get; set; } = new();
    public List<Ticket> Tickets { get; set; } = new();
}
