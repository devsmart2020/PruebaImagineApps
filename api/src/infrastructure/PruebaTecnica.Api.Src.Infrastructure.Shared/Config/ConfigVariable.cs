namespace PruebaTecnica.Api.Src.Infrastructure.Shared.Config
{
    public sealed class ConfigVariable
    {
        public static bool DEBUG { get { return (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "") == "Development"; } }
        public static string AZURE_CONNECTION { get { return ConfigHelper.GetParam("AZUREDB", false) ?? ""; } }


    }
}
