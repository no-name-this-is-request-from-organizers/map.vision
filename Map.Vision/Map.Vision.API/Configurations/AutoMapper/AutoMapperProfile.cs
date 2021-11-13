using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Map.Vision.Data;
using Map.Vision.Data.Entity;
using System;
using System.Linq;
using Map.Vision.Data.Base;
using Map.Vision.Data.Dto;
using Map.Vision.Data.ViewModels.Input;
using Map.Vision.General.Expansions;

namespace Map.Vision.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PlaceCreate, PlaceInputDto>()
                .ForMember(x => x.AudioGuide, s => s.MapFrom(x => x.AudioGuide != null ? new Data.Base.Attachment()
                {
                    Stream = x.AudioGuide.OpenReadStream(),
                    Name = x.AudioGuide.FileName
                } : null))
                .ForMember(x => x.Avatar, s => s.MapFrom(x => x.Avatar != null ? new Data.Base.Attachment()
                {
                    Stream = x.Avatar.OpenReadStream(),
                    Name = x.Avatar.FileName
                } : null))
                .ForMember(x => x.AudioHistory, s => s.MapFrom(x => x.AudioHistory != null ? new Data.Base.Attachment()
                {
                    Stream = x.AudioHistory.OpenReadStream(),
                    Name = x.AudioHistory.FileName
                } : null))
                .ForMember(x => x.Pictures, s => s.MapFrom(x => x.Pictures.Where(y => y != null).Select(y => new Data.Base.Attachment()
                {
                    Stream = y.OpenReadStream(),
                    Name = y.FileName
                }).ToListOrNull()));

            CreateMap<PlaceUpdate, PlaceInputDto>()
                .ForMember(x => x.AudioGuide, s => s.MapFrom(x => x.AudioGuide != null ? new Data.Base.Attachment()
                {
                    Stream =  x.AudioGuide.OpenReadStream(),
                    Name = x.AudioGuide.FileName
                } : null))
                .ForMember(x => x.Avatar, s => s.MapFrom(x => x.Avatar != null ? new Data.Base.Attachment()
                {
                    Stream = x.Avatar.OpenReadStream(),
                    Name = x.Avatar.FileName
                } : null))
                .ForMember(x => x.AudioHistory, s => s.MapFrom(x => x.AudioHistory != null ? new Data.Base.Attachment()
                {
                    Stream = x.AudioHistory.OpenReadStream(),
                    Name = x.AudioHistory.FileName
                } : null))
                .ForMember(x => x.Pictures, s => s.MapFrom(x => x.Pictures.Where(y => y != null).Select(y => new Data.Base.Attachment()
                {
                    Stream = y.OpenReadStream(),
                    Name = y.FileName
                }).ToListOrNull()));

            CreateMap<TourCreate, TourInputDto>()
                .ForMember(x => x.Avatar, s => s.MapFrom(x => x.Avatar != null ? new Data.Base.Attachment()
                {
                    Stream = x.Avatar.OpenReadStream(),
                    Name = x.Avatar.FileName
                } : null))
                .ForMember(x => x.Pictures, s => s.MapFrom(x => x.Pictures.Where(y => y != null).Select(y => new Data.Base.Attachment()
                {
                    Stream = y.OpenReadStream(),
                    Name = y.FileName
                }).ToListOrNull()));

            CreateMap<TourUpdate, TourInputDto>()
                .ForMember(x => x.Avatar, s => s.MapFrom(x => x.Avatar != null ? new Data.Base.Attachment()
                {
                    Stream = x.Avatar.OpenReadStream(),
                    Name = x.Avatar.FileName
                } : null))
                .ForMember(x => x.Pictures, s => s.MapFrom(x => x.Pictures.Where(y => y != null).Select(y => new Data.Base.Attachment()
                {
                    Stream = y.OpenReadStream(),
                    Name = y.FileName
                }).ToListOrNull()));

            CreateMap<Tour, TourOutputDto>()
                .ForMember(x => x.Avatar, s => s.MapFrom(x => x.Avatar.Url))
                .ForMember(x => x.PlacesIds, s => s.MapFrom(x => x.Places.Select(y => y.Id).ToArray()))
                .ForMember(x => x.Pictures, s => s.MapFrom(x => x.Pictures.Select(y => y.Url).ToList()));

            CreateMap<TourInputDto, Tour>()
                .ForMember(x => x.Places, s => s.MapFrom<FormatterPlaceIdToPlace>());

            CreateMap<PlaceInputDto, Place>();

            CreateMap<Place, PlaceOutputDto>()
                .ForMember(x => x.Avatar, s => s.MapFrom(x => x.Avatar.Url))
                .ForMember(x => x.AudioHistory, s => s.MapFrom(x => x.AudioHistory.Url))
                .ForMember(x => x.AudioGuide, s => s.MapFrom(x => x.AudioGuide.Url))
                .ForMember(x => x.Pictures, s => s.MapFrom(x => x.Pictures.Select(y => y.Url).ToList()));

            CreateMap<Place, PlaceSmallDto>()
                .ForMember(x => x.Avatar, s => s.MapFrom(x => x.Avatar.Url));

            CreateMap<Data.Base.Attachment, Data.Entity.Attachment>()
                .ForMember(x => x.Url, s => s.MapFrom<FormatterFileToAttachment>());

            CreateMap<Data.Base.Coordinates, Data.Entity.Coordinates>();

            CreateMap<Data.Entity.Coordinates, Data.Base.Coordinates>();
        }
    }
}
