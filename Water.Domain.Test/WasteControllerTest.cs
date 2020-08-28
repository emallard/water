using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Water.Domain.Test
{

    public class WasteControllerTest
    {
        [Fact]
        public async Task Test()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<WasteController>();
            //serviceCollection.AddEntityFrameworkInMemoryDatabase();
            serviceCollection.AddDbContext<WaterContext>(builder => builder.UseInMemoryDatabase("test"));


            var serviceProvider = serviceCollection.BuildServiceProvider();


            var dbContext = serviceProvider.GetService<WaterContext>();

            var area = new Area();
            area.ID = Guid.NewGuid();
            area.Name = "London";
            await dbContext.Set<Area>().AddAsync(area);
            await dbContext.SaveChangesAsync();


            var controller = serviceProvider.GetService<WasteController>();
            var summary = await controller.GetSummaryAsync();

            summary.Should().HaveCount(1);
            summary[0].Area.Should().Be("London");

        }
    }
}
