using AutoMapper;
using CodeService.DTOs.CodeSkeleton;
using CodeService.Models;

namespace CodeService.Mappers
{
    public class CodeSkeletonProfile : Profile
    {
        public CodeSkeletonProfile()
        {
            CreateMap<QuestionSkeleton, CodeSkeletonDTO>().ReverseMap();
            CreateMap<QuestionSkeleton, CodeSkeletonCreationDTO>().ReverseMap();
        }
    }
}
