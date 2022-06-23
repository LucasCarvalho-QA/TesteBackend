using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestBackend.Utils
{
    public static class StringFormatter
    {
        public static string JsonPrettify(string json)
        {
            using var stringReader = new StringReader(json);
            using var stringWriter = new StringWriter();
            var jsonReader = new JsonTextReader(stringReader);
            var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
            jsonWriter.WriteToken(jsonReader);
            return stringWriter.ToString();
        }

        [Obsolete]
        public static string HeaderFormatter(IEnumerable<Parameter> parameters)
        {
            string parametersList = null;

            foreach (var parameter in parameters)
            {
                parametersList += parameter + "\n";
            }

            if (!string.IsNullOrEmpty(parametersList))
                return parametersList.Replace("=", ":");

            return null;
        }

        public static string JsonIndent(string json)
        {
            try
            {
                return JObject.Parse(json).ToString();
            }
            catch (Exception)
            {
                return json;
            }
        }

        public static string ListToString(List<string> list)
        {
            string paragrafos = string.Empty;

            foreach (var item in list)
            {
                paragrafos += item;
            }
            return paragrafos;
        }
    }
}
