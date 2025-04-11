using Common.Domain;
using Common.Domain.ValueObjects;
using CoreModule.Domain.Course.Enums;

namespace CoreModule.Domain.Course.Entities;

public class Course:BaseEntity
{
    public Course(Guid teacherId, string title, string description, string imageName, string videoName, decimal price, DateTime lastUpdate, SeoData seoData, CourseLevel courseLevel)
    {
        TeacherId = teacherId;
        Title = title;
        Description = description;
        ImageName = imageName;
        VideoName = videoName;
        Price = price;
        LastUpdate = lastUpdate;
        SeoData = seoData;
        CourseLevel = courseLevel;
        CourseStatus = CourseStatus.Upcoming;
    }

    public Guid TeacherId { get;private set; }
    public string Title { get;private set; }
    public string Description { get;private set; }
    public string ImageName { get;private set; }
    public string VideoName { get;private set; }
    public decimal Price { get;private set; }
    public DateTime LastUpdate { get;private set; }
    public SeoData SeoData { get;private set; }
    public CourseLevel CourseLevel { get; private set; }
    public CourseStatus CourseStatus { get; set; }
    public IEnumerable<Section> Sections { get; }
}