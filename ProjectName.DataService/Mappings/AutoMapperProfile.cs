using AutoMapper;
using ProjectName.DataService.Models;
using ProjectName.DataService.Dtos;

namespace ProjectName.DataService.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreatePromptDto, Prompt>();
            CreateMap<Prompt, PromptDto>().ReverseMap();

            CreateMap<CreatePromptDesignDto, PromptDesign>();
            CreateMap<PromptDesign, PromptDesignDto>();
        }
    }
}
