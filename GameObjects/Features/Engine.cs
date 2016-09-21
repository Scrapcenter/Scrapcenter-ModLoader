using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Scrapcenter.Util;

namespace Scrapcenter.GameObjects.Features
{
    class Engine : PartFeature
    {
        public enum EngineType
        {
            Petrol,
            Electric
        }

        public class EngineGear : JsonRepresentable
        {
            double Velocity;
            double Power;

            public EngineGear(double velocity, double power)
            {
                this.Velocity = velocity;
                this.Power = power;
            }

            public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("velocity");
                writer.WriteValue(this.Velocity);
                writer.WritePropertyName("power");
                writer.WriteValue(this.Power);
                writer.WriteEndObject();
            }
        }

        EngineType Type;
        List<EngineGear> Gears;

        public string GetFieldName()
        {
            return "engine";
        }

        public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteValue(this.Type.ToString());
            writer.WritePropertyName("gears");
            writer.WriteStartArray();
            foreach (EngineGear g in this.Gears)
                g.WriteToJson(writer);
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        public Engine(IDictionary<string, object> jsonDict)
        {
            if (jsonDict.ContainsKey("type"))
            {
                if ("Electric" == jsonDict["type"].ToString())
                    this.Type = EngineType.Electric;
                else
                    this.Type = EngineType.Petrol;
            }

            this.Gears = new List<EngineGear>();

            if (jsonDict.ContainsKey("gears"))
            {
                if (((List<object>)jsonDict["gears"]).Count > 10)
                    throw new Exception("Engine can only have 10 gears");
                
                foreach (object gearObj in (List<object>)jsonDict["gears"])
                {
                    double velocity = 0;
                    double power = 0;
                    IDictionary<string, object> gearDict = (IDictionary<string, object>)gearObj;
                    if (gearDict.ContainsKey("velocity"))
                        if (!double.TryParse(gearDict["velocity"].ToString(), out velocity))
                            velocity = 0;
                    if (gearDict.ContainsKey("power"))
                        if (!double.TryParse(gearDict["power"].ToString(), out power))
                            power = 0;

                    this.Gears.Add(new EngineGear(velocity, power));
                }
            }
        }
    }
}
