using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Example.Application.Tests.Helpers
{
    public static class DbContextHelper
    {
        public static ExampleContext GetExampleContextInstance()
        {
            var builder = new DbContextOptionsBuilder<ExampleContext>();
            builder.UseInMemoryDatabase("ExampleTestDb");

            return new ExampleContext(builder.Options);
        }
    }
}
