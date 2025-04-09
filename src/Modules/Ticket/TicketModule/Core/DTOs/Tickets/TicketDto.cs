using TicketModule.Data.Entities;

namespace TicketModule.Core.DTOs.Tickets;

public class TicketDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string OwnerFullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public TicketStatus TicketStatus { get; set; }
    public List<TicketMessageDto> Messages { get; set; }
}