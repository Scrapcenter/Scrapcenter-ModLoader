using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Dynamic;

using Newtonsoft.Json;

using Scrapcenter.Util;

namespace Scrapcenter.GameObjects
{
    class Material : JsonRepresentable
    {

        public string Name;
        public int AudioID;

        public Material(string name, int audioID)
        {
            this.Name = name;
            this.AudioID = audioID;
        }

        public void WriteToJson(JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteValue(this.Name);
            writer.WritePropertyName("audio id");
            writer.WriteValue(this.AudioID);
            writer.WriteEndObject();
        }

        public static Dictionary<string, Material> ReadFromJson(string jsonText)
        {
            Dictionary<string, Material> materials = new Dictionary<string, Material>();
            IDictionary<string, object> dict = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
            if (dict.ContainsKey("materials"))
            {
                foreach(object materialObj in (List<object>)dict["materials"]) {
                    IDictionary<string, object> materialDict = (IDictionary<string, object>)materialObj;
                    string name;
                    int audioID;
                    if (materialDict.ContainsKey("name"))
                    {
                        name = (string)materialDict["name"];
                        if (!materials.ContainsKey(name))
                        {
                            if (materialDict.ContainsKey("audio id"))
                            {
                                if (int.TryParse(materialDict["audio id"].ToString(), out audioID))
                                    materials.Add(name, new Material(name, audioID));
                                else
                                    throw new Exception("Error in physicsmaterials: audio ID not an integer");
                            }
                            else
                                throw new Exception("Error in physicsmaterials: no audio ID specified");
                        }
                    }
                    else
                        throw new Exception("Error in physicsmaterials: no name specified");
                }
            }
            return materials;
        }
    }
}
