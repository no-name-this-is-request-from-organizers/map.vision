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
    public class Sensors : ISensors, IAdmin, ISensorGeocoding
    {
        private readonly IMapper _mapper;
        private readonly ServiceDbContext _context;

        public Sensors(IMapper mapper, ServiceDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> CreateSensor(SensorInputDto sensor)
        {
            var entity = _mapper.Map<Sensor>(sensor);
            await _context.AddAsync(entity);

            if (await _context.SaveChangesAsync() > 0)
                return true;

            return false;
        }

        public async Task<bool> RemoveSensor(int id)
        {
            var entity = await GetSensors.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
                return false;

            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateSensor(SensorInputDto sensor)
        {
            throw new NotImplementedException();
        }

        public async Task<SensorOutputDto> Get(int id)
        {
            var entity = await GetSensors.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null)
                return null;
            return _mapper.Map<SensorOutputDto>(entity);
        }

        public async Task<IList<Sensor>> Get(int[] ids)
        {
            var entities = await GetSensors.Where(x => ids.Contains(x.Id)).ToListAsync();
            if (entities is null || entities.Count == 0)
                return null;
            return entities;
        }

        public async Task<IList<SensorSmallDto>> GetAll(SensorFilter filter)
        {
            var entity = GetSensors.Filter(filter);

            return _mapper.Map<List<Sensor>, List<SensorSmallDto>>(await entity.ToListAsync());
        }

        public async Task<IList<SensorOutputDto>> GetAllFull(SensorFilter filter)
        {
            var entity = GetSensors.Filter(filter);

            return _mapper.Map<List<Sensor>, List<SensorOutputDto>>(await entity.ToListAsync());
        }

        public async Task<Dictionary<int, Data.Base.Coordinates>> GetSensorsGeocords(Data.Base.Coordinates coornates)
        {
            var entity = await GetSensors.Where(x => Math.Abs((x.Coordinates.Lat - (coornates.Lat + Data.Base.Coordinates._100MetrosForLat))) <= Data.Base.Coordinates._100MetrosForLat &&
                                                            Math.Abs(x.Coordinates.Lng - (coornates.Lng + Data.Base.Coordinates._100MetrosForLng)) <= Data.Base.Coordinates._100MetrosForLng).ToDictionaryAsync(x => x.Id, s => _mapper.Map<Data.Base.Coordinates>(s.Coordinates));

            return entity;
        }

        #region GetSensors

        private IQueryable<Sensor> GetSensors =>
                 _context.Sensors
                            .Include(x => x.Coordinates);

        #endregion
    }
}
