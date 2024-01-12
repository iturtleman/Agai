namespace Agai.Extensions
{
    using System.Data;
    using JsonDiffPatchDotNet;
    using JsonDiffPatchDotNet.Formatters.JsonPatch;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// json helpers
    /// </summary>
    public static class JsonComparisonHelpers
    {
        internal static readonly JsonSerializerSettings OrderedFieldSettings = new JsonSerializerSettings()
        {
            ContractResolver = new OrderedCaseInsensitiveContractResolver(),
        };

        /// <summary>
        /// Compares objects with case sensitive keys with the keys sorted for consistent comparison.
        /// Convenient for different classes that share the same general shape but are not of the same type
        /// If there is a difference, the diff-patch is output <see cref="JsonDiffPatch"/>
        /// </summary>
        /// <typeparam name="TExpected">anything that can be json serialized</typeparam>
        /// <typeparam name="TActual">anything that can be json serialized!</typeparam>
        /// <param name="expected">arbitrary expected object that must be JSON->serializable</param>
        /// <param name="actual">arbitrary actual object that must be JSON->serializable</param>
        /// <returns>true when equal and the diff <see cref="JsonDiffPatch.Diff(JToken, JToken)"/></returns>
        public static (bool AreEqual, IList<Operation> Diff) AreEqualByJson<TExpected, TActual>(TExpected? expected, TActual? actual)
        {
            if (expected?.Equals(actual) ?? false)
            {
                return (true, new List<Operation>());
            }

            var expect = expected.ResolveJToken();
            var act = actual.ResolveJToken();

            var jdp = new JsonDiffPatch();
            var formatter = new JsonDeltaFormatter();

            var diff = jdp.Diff(expect, act);
            try
            {
                var diffResult = formatter.Format(diff);

                bool areTheyEqual = JToken.DeepEquals(expect, act);
                return (areTheyEqual, diffResult);
            }
            catch (Exception ex)
            {
                return (false, new List<Operation>
                {
                    new Operation
                    {
                        From = "no clue, figure it out",
                        Op = "?????",
                        Path = JsonConvert.SerializeObject(diff),
                        Value = ex.Message,
                    },
                });
            }
        }

        /// <summary>
        /// Standardizes Json shape by ordering and case insensitively parsing
        /// </summary>
        /// <typeparam name="T">Anything that can be JSON Converted</typeparam>
        /// <param name="obj">your stuff</param>
        /// <returns>prettier</returns>
        public static JToken ResolveJToken<T>(this T obj)
        {
            /*
            * do not try to optimize this by just returning the jtoken... this causes some failures in comparing some lists that contain objects
            * JToken.FromObject instead of JToken.Parse(JsonConvert.SerializeObject(obj)) also fails with the same error
            */
            return JToken.Parse(JsonConvert.SerializeObject(obj, OrderedFieldSettings));
        }

        /// <summary>
        /// So you want to have your stuff be ordered and the same casing!? this is your happy place
        /// </summary>
        public class OrderedCaseInsensitiveContractResolver : DefaultContractResolver
        {
            /// <inheritdoc/>
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                return base.CreateProperties(type, memberSerialization).OrderBy(p => (p.PropertyName ?? throw new InvalidOperationException("property name is null")).ToLowerInvariant()).ToList();
            }
        }
    }
}