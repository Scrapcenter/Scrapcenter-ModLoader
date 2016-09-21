using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrapcenter.GameObjects.Features
{
    class Tone : PartFeature
    {
        List<string> AudioEvents;
        string GuiLayout = "ToneGui.layout";

        public Tone(List<string> audioEvents, string guiLayout = "ToneGui.layout")
        {
            this.AudioEvents = audioEvents;
            this.GuiLayout = guiLayout;
        }

        public Tone(IDictionary<string, object> jsonDict)
        {
            this.AudioEvents = new List<string>();
            if (jsonDict.ContainsKey("audio"))
            {
                foreach (object audioObj in (List<object>)jsonDict["audio"])
                {
                    IDictionary<string, object> audioDict = (IDictionary<string, object>)audioObj;
                    if (audioDict.ContainsKey("event"))
                        this.AudioEvents.Add(audioDict["event"].ToString());
                }
            }

            if (jsonDict.ContainsKey("guiLayout"))
                this.GuiLayout = jsonDict["guiLayout"].ToString();
        }

        public string GetFieldName()
        {
            return "tone";
        }

        public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("audio");
            writer.WriteStartArray();
            foreach (string audioEvent in this.AudioEvents)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("event");
                writer.WriteValue(audioEvent);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            writer.WritePropertyName("guiLayout");
            writer.WriteValue(this.GuiLayout);
            writer.WriteEndObject();
        }
    }
}
