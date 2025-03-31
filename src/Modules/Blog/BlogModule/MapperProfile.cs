using AutoMapper;
using BlogModule.Domain;
using BlogModule.Services.DTOs.Command;
using BlogModule.Services.DTOs.Query;

namespace BlogModule;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Category, BlogCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();

        CreateMap<Category, BlogPostDto>().ReverseMap();
        CreateMap<Category, CreatePostCommand>().ReverseMap();
    }
}