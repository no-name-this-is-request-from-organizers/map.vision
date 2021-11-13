using AutoMapper;
using Map.Vision.BI.Options;
using Map.Vision.Data.Entity;
using Map.Vision.General.Expansions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Map.Vision.BI.Interfaces;
using Map.Vision.Data.Base;
using Map.Vision.Data.Dto;
using Map.Vision.Data.Entity;

namespace Map.Vision.API.Configurations.AutoMapper
{
    public class FormatterObjectToString : IValueResolver<object, object, string>
    {
        private readonly IMapper _mapper;

        public FormatterObjectToString(IMapper mapper)
        {
            _mapper = mapper;
        }

        public string Resolve(object source, object destination, string result, ResolutionContext context)
        {
            return result;
        }
    }

    public class FormatterFileToAttachment : IValueResolver<Data.Base.Attachment, Data.Entity.Attachment, string>
    {
        private readonly IAttachments _attachments;
        private readonly IMapper _mapper;

        public FormatterFileToAttachment(IAttachments attachments, IMapper mapper)
        {
            _attachments = attachments;
            _mapper = mapper;
        }

        public string Resolve(Data.Base.Attachment source, Data.Entity.Attachment destination, string result, ResolutionContext context)
        {
            return DownloadFile(source).GetAwaiter().GetResult();
        }

        private async Task<string> DownloadFile(Data.Base.Attachment source) =>
            await _attachments.Upload(source);
    }

    public class FormatterPlaceIdToPlace : IValueResolver<TourInputDto, Tour, IList<Place>>
    {
        private readonly IPlaces _places;
        private readonly IMapper _mapper;

        public FormatterPlaceIdToPlace(IPlaces places, IMapper mapper)
        {
            _places = places;
            _mapper = mapper;
        }

        public IList<Place> Resolve(TourInputDto source, Tour destination, IList<Place> result, ResolutionContext context)
        {
            return GetPlaces(source.PlacesIds).GetAwaiter().GetResult();
        }

        private async Task<IList<Place>> GetPlaces(int[] ids) =>
            await _places.Get(ids);
    }
}

//FormatterPlaceIdToPlace