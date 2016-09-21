using System;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;

using Newtonsoft.Json;

using Scrapcenter.Util;

namespace Scrapcenter.GameObjects
{
    class ShapeSet : JsonRepresentable
    {
        public Dictionary<Guid, Part> Parts;
        public string Name;
        public string[] Overwrites;


        public ShapeSet(string name, string jsonText, Dictionary<string,RotationSet> rotationSets, Dictionary<string,Material> physicsMaterials, string[] overwrites = null)
        {
            this.Name = name;
            this.Parts = new Dictionary<Guid, Part>();
            this.Overwrites = overwrites;

            IDictionary<string, object> jsonDict = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
            if (jsonDict.ContainsKey("itemlist"))
            {
                foreach (object q in (List<object>)jsonDict["itemlist"])
                {
                    Part p = new Part((IDictionary<string,object>)q, rotationSets, physicsMaterials);
                    Parts.Add(p.ItemUuid, p);
                }
            }
        }

        public void WriteToJson(JsonWriter writer)
        {
            writer.WriteStartObject();
            if (this.Overwrites != null && this.Overwrites.Length != 0)
            {
                writer.WritePropertyName("overwrites");
                writer.WriteStartArray();
                foreach (string s in this.Overwrites)
                    writer.WriteValue(s);
                writer.WriteEndArray();
            }
            writer.WritePropertyName("itemlist");
            writer.WriteStartArray();
            foreach(Part p in this.Parts.Values) {
                p.WriteToJson(writer);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
