using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Water.Domain
{
    public class AreaController
    {
        private readonly WaterContext _dbContext;

        public AreaController(WaterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(string name)
        {
            var area = new Area();
            area.ID = Guid.NewGuid();
            area.Name = name;
            await _dbContext.Set<Area>().AddAsync(area);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string[]> AllAsync()
        {
            return await _dbContext.Set<Area>().AsQueryable().Select(x => x.Name).ToArrayAsync();
        }
    }
}
