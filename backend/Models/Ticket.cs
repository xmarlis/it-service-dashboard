namespace ItServiceDashboard.Models;

public class Ticket
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string Priority { get; set; } = "Medium"; // Low / Medium / High
    public string Status { get; set; } = "Open";     // Open / InProgress / Done

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public int? ServerId { get; set; }
    public Server? Server { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
