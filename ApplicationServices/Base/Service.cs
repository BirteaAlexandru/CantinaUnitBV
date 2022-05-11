using Microsoft.Extensions.Logging;
namespace ApplicationServices.Base
{
    public abstract class Service
    {
        protected Service(ILogger<Service> logger)
        {
            Logger = logger;
        }

        public ILogger<Service> Logger { get; }
    }
}
