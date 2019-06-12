using System;
using Newtonsoft.Json;

namespace DDDCms.Infrastructure.Json
{
    public class JsonSubtypesConverterBuilder
    {
        private Type _baseType;
        private string _discriminatorProperty;
        private readonly NullableDictionary<object, Type> _subTypeMapping = new NullableDictionary<object, Type>();
        private bool _serializeDiscriminatorProperty;
        private bool _addDiscriminatorFirst;
        private Type _fallbackSubtype;

        public static JsonSubtypesConverterBuilder Of(Type baseType, string discriminatorProperty)
        {
            var customConverterBuilder = new JsonSubtypesConverterBuilder
            {
                _baseType = baseType,
                _discriminatorProperty = discriminatorProperty
            };
            return customConverterBuilder;
        }

        public JsonSubtypesConverterBuilder SerializeDiscriminatorProperty()
        {
            return SerializeDiscriminatorProperty(false);
        }

        public JsonSubtypesConverterBuilder SerializeDiscriminatorProperty(bool addDiscriminatorFirst)
        {
            _serializeDiscriminatorProperty = true;
            _addDiscriminatorFirst = addDiscriminatorFirst;
            return this;
        }

        public JsonSubtypesConverterBuilder RegisterSubtype(Type subtype, object value)
        {
            _subTypeMapping.Add(value, subtype);
            return this;
        }

        public JsonSubtypesConverterBuilder SetFallbackSubtype(Type fallbackSubtype)
        {
            _fallbackSubtype = fallbackSubtype;
            return this;
        }

        public JsonConverter Build()
        {
            return new JsonSubtypesConverter(_baseType, _discriminatorProperty, _subTypeMapping, _serializeDiscriminatorProperty, _addDiscriminatorFirst, _fallbackSubtype);
        }
    }
}