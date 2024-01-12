namespace Agai.Extensions
{
    using JsonDiffPatchDotNet;
    using JsonDiffPatchDotNet.Formatters.JsonPatch;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    public static class JsonComparisonExtensions
    {
        /// <summary>
        /// Compares objects with case sensitive keys with the keys sorted for consistent comparison.
        /// Convenient for different classes that share the same general shape but are not of the same type
        /// If there is a difference, the diff-patch is output <see cref="JsonDiffPatch"/>
        /// </summary>
        /// <typeparam name="TExpected">t</typeparam>
        /// <typeparam name="TActual">u</typeparam>
        /// <param name="assert">this</param>
        /// <param name="expected">expected</param>
        /// <param name="actual">actual</param>
        /// <param name="debugInfo">info</param>
        public static void AreEqualByJson<TExpected, TActual>(this Assert assert, TExpected? expected, TActual? actual, object? debugInfo = default)
        {
            var (areEqual, diff) = JsonComparisonHelpers.AreEqualByJson(expected, actual);
            if (!areEqual)
                new
                {
                    diff,
                    expected,
                    actual,
                    debugInfo,
                }.Dumps();
        }

        /// <summary>
        /// Not of <see cref="AreEqualByJson{T, U}(T, U, object, bool)"/>
        /// </summary>
        /// <typeparam name="TExpected">t</typeparam>
        /// <typeparam name="TActual">u</typeparam>
        /// <param name="assert">this</param>
        /// <param name="expected">expected</param>
        /// <param name="actual">actual</param>
        /// <param name="debugInfo">info</param>
        public static void AreNotEqualByJson<TExpected, TActual>(this Assert assert, TExpected? expected, TActual? actual, object? debugInfo = default)
        {
            var (areEqual, diff) = JsonComparisonHelpers.AreEqualByJson(expected, actual);
            Assert.IsFalse(
                areEqual,
                GenerateMessage(expected, actual, debugInfo, diff));
        }

        private static string GenerateMessage<TExpected, TActual>(TExpected? expected, TActual? actual, object? debugInfo, IList<Operation> diff)
        {
            return $@"Values do not match!
diff:{JsonConvert.SerializeObject(diff, Formatting.Indented)}
expected:
{JsonConvert.SerializeObject(expected, Formatting.Indented)}
actual:
{JsonConvert.SerializeObject(actual, Formatting.Indented)}

Debug info:{JsonConvert.SerializeObject(debugInfo, Formatting.Indented)}";
        }
    }
}