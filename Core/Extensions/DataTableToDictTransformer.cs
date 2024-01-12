namespace Agai.Extensions
{
    using System.Data;

    internal static class DataTableToDictTransformer
    {
        public static Dictionary<string, T> ToDictionary<T>(this DataTable dt, Func<string, T> convert)
        {
            return dt.AsEnumerable()
              .ToDictionary(
                row => row.Field<string>(0)!,
                row => convert(row.Field<string>(1)!));
        }
    }
}