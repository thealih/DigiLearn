using TicketModule.Data.Entities;

namespace TicketModule.Core.DTOs.Tickets;

public class SendTicketCommand
{
    public Guid UserId { get; set; }
    public Guid TicketId { get; set; }
    public string OwnerFullName { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}