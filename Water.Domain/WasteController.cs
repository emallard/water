using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Water.Domain
{

    public class WasteController
    {
        private readonly WaterContext _dbContext;

        public WasteController(WaterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WasteControllerSummaryItem[]> GetSummaryAsync()
        {
            var areas = await _dbContext.Set<Area>().ToArrayAsync();
            return areas.Select(x => new WasteControllerSummaryItem()
            {
                Area = x.Name,
            }).ToArray();
        }
    }
}
