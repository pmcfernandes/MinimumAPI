using System.Text.Json;

namespace MinimumAPI.Filters;

internal class LowerCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToLowerInvariant();
}