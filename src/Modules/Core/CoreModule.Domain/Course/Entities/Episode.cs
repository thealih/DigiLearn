using Common.Domain;

namespace CoreModule.Domain.Course.Entities;

public class Episode:BaseEntity
{
    public Episode(string title, Guid token, TimeSpan timeSpan, string videoName, string attachmentName, bool isActive)
    {
        Title = title;
        Token = token;
        TimeSpan = timeSpan;
        VideoName = videoName;
        AttachmentName = attachmentName;
        IsActive = isActive;
    }

    public string Title { get;private set; }
    public Guid Token { get;private set; }
    public TimeSpan TimeSpan { get;private set; }
    public string VideoName { get;private set; }
    public string AttachmentName { get;private set; }
    public bool IsActive { get;private set; }
}