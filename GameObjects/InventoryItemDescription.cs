using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Dynamic;

using Newtonsoft.Json;

using Scrapcenter.Util;

namespace Scrapcenter.GameObjects
{
    class InventoryItemDescription : JsonRepresentable
    {
        const string WEIGHT_LIGHT = "Light Weight";
        const string WEIGHT_MEDIUM = "Medium Weight";
        const string WEIGHT_HEAVY = "Heavy Weight";

        public static readonly float[] NoOffset = new float[3] { 0f, 0f, 0f };

        Guid ItemUuid;

        // Indices: 0, 1
        string[] Title;

        string Weight;

        RgbColor Color;
        
        // Indices: 0, ..., 9
        string[] Description;

        float PreviewScale;
        
        // Indices: 0, 1, 2
        float[] PreviewOffset;

        public InventoryItemDescription(Guid uuid, string[] title, RgbColor color, string weight, string[] description, float previewScale = 1.0f, float[] previewOffset = null)
        {
            this.ItemUuid = uuid;
            this.Title = title;
            this.Color = color;
            this.Weight = weight;
            this.Description = description;
            this.PreviewScale = previewScale;
            this.PreviewOffset = previewOffset;
        }

        public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("title_1");
            writer.WriteValue(Title.Length > 0 ? Title[0] : "");

            writer.WritePropertyName("title_2");
            writer.WriteValue(Title.Length > 1 ? Title[1] : "");

            writer.WritePropertyName("colour");
            if (Color == null)
                new RgbColor(255, 255, 255).WriteToJson(writer);
            else
                Color.WriteToJson(writer);

            writer.WritePropertyName("weight");
            writer.WriteValue(Weight);

            // Write descriptions
            for (int i = 0; i < Description.Length; i++)
            {
                writer.WritePropertyName("description_" + (i + 1));
                writer.WriteValue(Description[i]);
            }
            for (int i = Description.Length; i < 10; i++)
            {
                writer.WritePropertyName("description_" + (i + 1));
                writer.WriteValue("");
            }

            writer.WritePropertyName("preview_scale");
            writer.WriteValue(PreviewScale);
            
            // Write preview offset if not default
            if (PreviewOffset != NoOffset && (PreviewOffset != null && PreviewOffset.Length == 3))
            {
                writer.WritePropertyName("preview_offset");
                writer.WriteStartObject();
                writer.WritePropertyName("x");
                writer.WriteValue(PreviewOffset[0]);
                writer.WritePropertyName("y");
                writer.WriteValue(PreviewOffset[1]);
                writer.WritePropertyName("z");
                writer.WriteValue(PreviewOffset[2]);
                writer.WriteEndObject();
            }

            writer.WriteEndObject();
        }

        public static Dictionary<Guid, InventoryItemDescription> ReadFromJson(string jsonText)
        {
            Dictionary<Guid, InventoryItemDescription> descriptions = new Dictionary<Guid, InventoryItemDescription>();
            
            // Read all items in the JSON main object
            IDictionary<string, object> descDict = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
            foreach (KeyValuePair<string, object> kvp in descDict)
            {
                try
                {
                    // Take the key as Guid
                    Guid itemUuid = Guid.Parse(kvp.Key);

                    // Default variable values
                    string[] title = new string[1] { "" };
                    RgbColor color = new RgbColor(105, 166, 215);
                    string weight = "Medium Weight";
                    string[] description = new string[10];
                    float previewScale = 1.0f;
                    float[] previewOffset = null;

                    // Read the title lines
                    IDictionary<string, object> invItemDict = kvp.Value as IDictionary<string, object>;
                    if (invItemDict.ContainsKey("title_1"))
                    {
                        if (invItemDict.ContainsKey("title_2"))
                            title = new string[2] { invItemDict["title_1"].ToString(), invItemDict["title_2"].ToString() };
                        else
                            title[1] = invItemDict["title_1"].ToString();
                    }
                    
                    // Read the color
                    if (invItemDict.ContainsKey("colour"))
                    {
                        IDictionary<string, object> colObj = (IDictionary<string, object>)invItemDict["colour"];
                        int r = 0, g = 0, b = 0;
                        if (colObj.ContainsKey("r"))
                            int.TryParse(colObj["r"].ToString(), out r);
                        if (colObj.ContainsKey("g"))
                            int.TryParse(colObj["g"].ToString(), out g);
                        if (colObj.ContainsKey("b"))
                            int.TryParse(colObj["b"].ToString(), out b);
                        color = new RgbColor(r, g, b);
                    }
                        
                    // Read the weight
                    if (invItemDict.ContainsKey("weight"))
                        weight = invItemDict["weight"].ToString();

                    // Read the description lines
                    for (int i = 1; i < 11; i++)
                    {
                        if (invItemDict.ContainsKey("description_" + i))
                            description[i - 1] = invItemDict["description_" + i].ToString();
                        else
                            description[i - 1] = "";
                    }

                    // Read the optional preview scale
                    if (invItemDict.ContainsKey("preview_scale"))
                        if (!float.TryParse(invItemDict["preview_scale"].ToString(), out previewScale))
                            previewScale = 1f;

                    // Read the optional preview fofset
                    if (invItemDict.ContainsKey("preview_offset"))
                    {
                        IDictionary<string, object> offsetObj = invItemDict["preview_offset"] as IDictionary<string, object>;
                        float x = 0f, y = 0f, z = 0f;
                        if (offsetObj.ContainsKey("x"))
                            float.TryParse(offsetObj["x"].ToString(), out x);
                        if (offsetObj.ContainsKey("y"))
                            float.TryParse(offsetObj["y"].ToString(), out y);
                        if (offsetObj.ContainsKey("z"))
                            float.TryParse(offsetObj["z"].ToString(), out z);
                        previewOffset = new float[3] { x, y, z };
                    }
                    
                    // Add the description to the dictionary
                    descriptions.Add(itemUuid, new InventoryItemDescription(itemUuid, title, color, weight, description, previewScale, previewOffset));
                }
                catch
                { }
            }
            return descriptions;
        }
    }
}
