using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DDDCms.Infrastructure.Json
{
    internal class JsonSubtypesConverter : JsonSubtypes
    {
        private readonly bool _serializeDiscriminatorProperty;
        private readonly Dictionary<Type, object> _supportedTypes = new Dictionary<Type, object>();
        private readonly Type _baseType;
        private readonly NullableDictionary<object, Type> _subTypeMapping;

        [ThreadStatic] private static bool _isInsideWrite;
        [ThreadStatic] private static bool _allowNextWrite;
        private readonly bool _addDiscriminatorFirst;
        private readonly Type _fallbackType;

        internal JsonSubtypesConverter(Type baseType, string discriminatorProperty,
            NullableDictionary<object, Type> subTypeMapping, bool serializeDiscriminatorProperty, bool addDiscriminatorFirst, Type fallbackType) : base(discriminatorProperty)
        {
            _serializeDiscriminatorProperty = serializeDiscriminatorProperty;
            _baseType = baseType;
            _subTypeMapping = subTypeMapping;
            _addDiscriminatorFirst = addDiscriminatorFirst;
            _fallbackType = fallbackType;
            foreach (var type in subTypeMapping.Entries())
            {
                if (_supportedTypes.ContainsKey(type.Value))
                {
                    if (_serializeDiscriminatorProperty)
                    {
                        throw new InvalidOperationException(
                            "Multiple discriminators on single type are not supported " +
                            "when discriminator serialization is enabled");
                    }
                }
                else
                {
                    _supportedTypes.Add(type.Value, type.Key);
                }
            }
        }

        internal override NullableDictionary<object, Type> GetSubTypeMapping(Type type)
        {
            return _subTypeMapping;
        }

        internal override Type GetFallbackSubType(Type type)
        {
            return _fallbackType;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == _baseType || _supportedTypes.ContainsKey(objectType);
        }

        public override bool CanWrite
        {
            get
            {
                if (!_serializeDiscriminatorProperty)
                    return false;

                if (!_isInsideWrite)
                    return true;

                if (_allowNextWrite)
                {
                    _allowNextWrite = false;
                    return true;
                }

                _allowNextWrite = true;
                return false;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jsonObj;
            _isInsideWrite = true;
            _allowNextWrite = false;
            try
            {
                jsonObj = JObject.FromObject(value, serializer);
            }
            finally
            {
                _isInsideWrite = false;
            }

            var supportedType = _supportedTypes[value.GetType()];
            var typeMappingPropertyValue = JToken.FromObject(supportedType, serializer);
            if (_addDiscriminatorFirst)
            {
                jsonObj.AddFirst(new JProperty(JsonDiscriminatorPropertyName, typeMappingPropertyValue));
            }
            else
            {
                jsonObj.Add(JsonDiscriminatorPropertyName, typeMappingPropertyValue);
            }
            jsonObj.WriteTo(writer);
        }
    }
}