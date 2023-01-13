using Newtonsoft.Json;

namespace Karami.Common.ClassExtensions;

public static class ObjectExtension
{
    public static string Serialize<T>(this T Input) => JsonConvert.SerializeObject(Input);
}