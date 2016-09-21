using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrapcenter.GameObjects.Features
{
    class Spring : PartFeature
    {
        int Length;
        float Stiffness;

        public Spring(int length, float stiffness)
        {
            this.Length = length;
            this.Stiffness = stiffness;
        }

        public Spring(IDictionary<string, object> jsonDict)
        {
            if (jsonDict.ContainsKey("length"))
                int.TryParse(jsonDict["length"].ToString(), out this.Length);
            if (jsonDict.ContainsKey("stiffness"))
                float.TryParse(jsonDict["stiffness"].ToString(), out this.Stiffness);
        }

        public string GetFieldName()
        {
            return "spring";
        }

        public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("length");
            writer.WriteValue(this.Length);
            writer.WritePropertyName("stiffness");
            writer.WriteValue(this.Stiffness);
            writer.WriteEndObject();
        }
    }
}
