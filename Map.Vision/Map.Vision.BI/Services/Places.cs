using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map.Vision.BI.Interfaces;
using Map.Vision.Data.Base;
using Map.Vision.Data.Dto;
using Map.Vision.Data.Enums;
using Map.Vision.EF;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Map.Vision.Data.Entity;
using Map.Vision.Data.Filters;
using Map.Vision.General.Expansions;

namespace Map.Vision.BI.Services
{
    public class Places : IPlaces, IAdmin, IPlaceGeocoding
    {
        private readonly IMapper _mapper;
        private readonly ServiceDbContext _context;

        public Places(IMapper mapper, ServiceDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> CreatePlace(PlaceInputDto place)
        {
            var entity = _mapper.Map<Place>(place);
            await _context.AddAsync(entity);

            if (await _context.SaveChangesAsync() > 0)
                return true;

            return false;
        }

        public async Task<bool> RemovePlace(int id)
        {
            var entity = await GetPlaces.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
                return false;

            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdatePlace(PlaceInputDto place)
        {
            throw new NotImplementedException();
        }

        public async Task<PlaceOutputDto> Get(int id)
        {
            var entity = await GetPlaces.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null)
                return null;
            return _mapper.Map<PlaceOutputDto>(entity);
        }

        public async Task<IList<Place>> Get(int[] ids)
        {
            var entities = await GetPlaces.Where(x => ids.Contains(x.Id)).ToListAsync();
            if (entities is null || entities.Count == 0)
                return null;
            return entities;
        }

        public async Task<IList<PlaceSmallDto>> GetAll(PlaceFilter filter)
        {
            var entity = GetPlaces.Filter(filter);

            return _mapper.Map<List<Place>, List<PlaceSmallDto>>(await entity.ToListAsync());
        }

        public async Task<IList<PlaceOutputDto>> GetAllFull(PlaceFilter filter)
        {
            var entity = GetPlaces.Filter(filter);

            return _mapper.Map<List<Place>, List<PlaceOutputDto>>(await entity.ToListAsync());
        }

        public async Task<Dictionary<int, Data.Base.Coordinates>> GetPlacesGeocords(Data.Base.Coordinates coornates)
        {
            var entity = await GetPlaces.Where(x => Math.Abs((x.Coordinates.Lat - (coornates.Lat + Data.Base.Coordinates._100MetrosForLat))) <= Data.Base.Coordinates._100MetrosForLat &&
                                                            Math.Abs(x.Coordinates.Lng - (coornates.Lng + Data.Base.Coordinates._100MetrosForLng)) <= Data.Base.Coordinates._100MetrosForLng).ToDictionaryAsync(x => x.Id, s => _mapper.Map<Data.Base.Coordinates>(s.Coordinates));

            return entity;
        }

        #region GetPlaces

        private IQueryable<Place> GetPlaces =>
                 _context.Places
                            .Include(x => x.AudioGuide)
                            .Include(x => x.AudioHistory)
                            .Include(x => x.Avatar)
                            .Include(x => x.Pictures)
                            .Include(x => x.Coordinates);

        #endregion
    }
}
