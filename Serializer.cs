using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    /// <summary> Serializer </summary>
    public static class Serializer
    {

        const char seporator = ';';

        /// <summary> Serialize from object to CSV </summary>
        /// <param name="obj">any object</param>
        /// <returns>CSV</returns>
        public static string SerializeFromObjectToCSV(object obj)
        {

            var type = obj.GetType();
            var properties = type.GetProperties();
            var values = new List<string>();

            foreach(var property in properties)
            {
                values.Add($"{property.Name}:{property.GetValue(obj)}");
            }

            return string.Join(seporator, values);
        }

        /// <summary> Deserialize from CSV to object</summary>
        /// <param name="csv">string in CSV format</param>
        /// <returns>object</returns>
        public static T DeserializeFromCSVToObject<T>(string csv)
        {
            var obj = Activator.CreateInstance<T>();
            var memberArray = obj.GetType().GetProperties().ToArray();
            var data = csv.Split(seporator);

            foreach (var item in data)
            {
                var serializeData = item.Split(":");
                var member = memberArray.FirstOrDefault(x => x.Name.Equals(serializeData[0]));
                ((PropertyInfo)member).SetValue(obj, int.Parse(serializeData[1]));
            }

            return obj;
        }

        private static void SetMemberValue<T>(T value, MemberInfo member, object obj)
        {
            if (member.MemberType == MemberTypes.Field)
            {
                ((FieldInfo)member).SetValue(obj, value);
            }
            else
            {
                ((PropertyInfo)member).SetValue(obj, value);
            }
        }
    }
}
