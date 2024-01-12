namespace Agai.Extensions
{
    using System.Diagnostics;
    using Newtonsoft.Json;

    public static class Dumper
    {
        public static T Dumps<T>(this T a)
        {
            Trace.WriteLine(JsonConvert.SerializeObject(a));
            return a;
        }
    }
}