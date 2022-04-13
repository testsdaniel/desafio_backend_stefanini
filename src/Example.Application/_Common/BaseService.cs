using Microsoft.Extensions.Logging;

namespace Example.Application.Common
{
    public abstract class BaseService<T>
    {
        protected readonly ILogger<T> Logger;

        public BaseService(ILogger<T> logger)
        {
            Logger = logger;
        }
    }
}
