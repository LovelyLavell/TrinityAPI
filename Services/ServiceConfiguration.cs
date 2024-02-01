namespace TrinityAPI.Services
{
    public class ServiceConfiguration
    {
        public string[] ConnectionStrings { get; private set; }
        public readonly string GenericContextFactoryError;
        public readonly int retryCount;
        public ServiceConfiguration(string[] ConnectionStrings) { 
            this.ConnectionStrings = ConnectionStrings;
            retryCount = 5;
            GenericContextFactoryError = "Error";
        }
    }
}
