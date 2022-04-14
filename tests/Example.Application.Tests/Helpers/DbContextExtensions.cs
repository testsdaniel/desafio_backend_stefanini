using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Example.Application.Tests.Helpers
{
    public static class DbContextExtensions
    {
        public static async Task ClearDbSetAsync<TEntity>(this ExampleContext context) where TEntity : class
        {
            var entities = await context.Set<TEntity>().ToListAsync();
            context.RemoveRange(entities);
            await context.SaveChangesAsync();
        }
    }
}
