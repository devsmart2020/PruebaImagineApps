using Microsoft.Extensions.Configuration;

namespace PruebaTecnica.Api.Src.Infrastructure.Shared.Config
{
    public class ConfigHelper
    {
        public static IConfiguration Configuration { get; set; } = null!;
        public static readonly string NameInit = "AppSettings:";
        public static string ValidateNom(string Key) => !Key.Contains(NameInit) ? $"{NameInit}{Key}" : Key;

        public static string GetParam(string key, bool includeNameConfiguration = true)
        {
            key = includeNameConfiguration ? ValidateNom(key) : key;
            return Configuration?.GetValue<string>(key.Trim()) ?? throw new ArgumentNullException($"Is null {key}");
        }

        public async Task<string> GetParamAsync(string key)
        {
            return await Task.FromResult(GetParam(key));
        }
    }
}
