using TicketModule.Data.Entities;

namespace TicketModule.Core.DTOs.Tickets;

public class SendTicketMessageCommand
{
    public Guid UserId { get; set; }
    public Guid TicketId { get; set; }
    public string OwnerFullName { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string Text { get; set; } = string.Empty;
}