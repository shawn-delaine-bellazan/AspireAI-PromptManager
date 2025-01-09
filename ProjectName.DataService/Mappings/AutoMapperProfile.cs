using AutoMapper;
using ProjectName.DataService.Models.Dtos;
using ProjectName.DataService.Models;

namespace ProjectName.DataService.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Prompt, PromptDto>().ReverseMap();
            CreateMap<PromptDesign, PromptDesignDto>().ReverseMap();
            CreateMap<PromptDesign, AddPromptDesignDto>().ReverseMap();
        }
    }
}
