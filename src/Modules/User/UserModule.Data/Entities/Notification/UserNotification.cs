using System.ComponentModel.DataAnnotations;
using Common.Domain;

namespace UserModule.Data.Entities.Notification;

public class UserNotification : BaseEntity
{
    public Guid UserId { get; set; }
    [MaxLength(2000)]
    public string Text { get; set; }
    [MaxLength(300)]
    public string Title { get; set; }
    public bool IsSeen { get; set; }
}