using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using CoreModule.Domain.Course.Enums;

namespace CoreModule.Domain.Course.Entities;

public class Course : BaseEntity
{
    public Course(Guid teacherId, string title, string description, string imageName, string videoName, decimal price,
        SeoData seoData, CourseLevel courseLevel)
    {
        Guard(title, description, imageName);
        TeacherId = teacherId;
        Title = title;
        Description = description;
        ImageName = imageName;
        VideoName = videoName;
        Price = price;
        LastUpdate = DateTime.Now;
        SeoData = seoData;
        CourseLevel = courseLevel;
        CourseStatus = CourseStatus.Upcoming;
        Sections = new List<Section>();
    }

    public Guid TeacherId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string ImageName { get; private set; }
    public string? VideoName { get; private set; }
    public decimal Price { get; private set; }
    public DateTime LastUpdate { get; private set; }
    public SeoData SeoData { get; private set; }
    public CourseLevel CourseLevel { get; private set; }
    public CourseStatus CourseStatus { get; set; }
    public List<Section> Sections { get; }

    public void AddSection(int displayOrder, string title)
    {
        if (Sections.Any(f=>f.Title == title))
        {
            throw new InvalidDomainDataException("title is exist");
        }
        Sections.Add(new Section(title,displayOrder , Id));
    }

    public void EditSection(Guid sectionId,int displayOrder, string title ,string englishTitle)
    {
        var section = Sections.FirstOrDefault(f => f.Id == sectionId);
        if (section == null)
        {
            throw new InvalidDomainDataException("Section NotFound");
        }

        section.Edit(title, displayOrder);
    }

    public void RemoveSection(Guid sectionId)
    {
        var section = Sections.FirstOrDefault(f => f.Id == sectionId);
        if (section == null)
        {
            throw new InvalidDomainDataException("Section NotFound");
        }
        Sections.Remove(section);
    }

    public void AddEpisode( Guid sectionId,string title, Guid token, TimeSpan timeSpan, string videoExtension, string? attachmentExtension,
        bool isActive , string englishTitle)
    {
        
        var section = Sections.FirstOrDefault(f => f.Id == sectionId);
        if (section == null)
        {
            throw new InvalidDomainDataException("Section NotFound");
        }

        var episodeCount = Sections.Sum(s => s.Episodes.Count());
        var episodeTitle = $"{episodeCount + 1}_{englishTitle}";

        string attName = null;
        if (string.IsNullOrWhiteSpace(attachmentExtension) == false)
        {
            attName = $"{episodeTitle}.{attachmentExtension}";
        }

        var vidName = $"{episodeTitle}.{videoExtension}";

        if (isActive)
        {
            LastUpdate = DateTime.Now;
            if (CourseStatus == CourseStatus.Upcoming)
            {
                CourseStatus = CourseStatus.InProgress;
            }
        }

        section.AddEpisode(title , token , timeSpan , vidName , attName , isActive, englishTitle);

    }

    public void AcceptEpisode(Guid episodeId)
    {
        var section = Sections.FirstOrDefault(f => f.Episodes.Any(f => f.Id == episodeId));

        if (section == null)
        {
            throw new InvalidDomainDataException();
        }
        LastUpdate = DateTime.Now;
    }
    private void Guard(string title, string description, string imageName)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        NullOrEmptyDomainDataException.CheckString(description, nameof(description));
        NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
    }
}