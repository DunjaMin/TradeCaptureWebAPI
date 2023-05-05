using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using TradeCaptureWebAPI.Models;

namespace TradeCaptureWebAPI
{
    internal sealed class SContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(Security).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null;
            return base.ResolveContractConverter(objectType);
        }
    }
    public class CustomConverter : JsonConverter
    {
        private static readonly IContractResolver ContractResolver = new SContractResolver();
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = ContractResolver,
            NullValueHandling = NullValueHandling.Ignore

        };
        private static readonly JsonSerializer Serializer = JsonSerializer.Create(SerializerSettings);

        public override bool CanConvert(Type objectType)
        {
            return typeof(Security).IsAssignableFrom(objectType);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            bool isOption = false;

            foreach (var r in jObject)
                if (r.Key == "sideId")
                    isOption = true;

            if (isOption == true)
            {
                var option = new Option();
                serializer.Populate(jObject.CreateReader(), option);
                return option;
            }
            else
            {
                var security = new Security();
                serializer.Populate(jObject.CreateReader(), security);
                return security;
            }
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
                throw new Exception();

            JToken t = JToken.FromObject(value, Serializer);
            t.WriteTo(writer);
        }
    }
}
