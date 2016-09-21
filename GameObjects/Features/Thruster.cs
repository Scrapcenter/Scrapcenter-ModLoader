using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Scrapcenter.Util;

namespace Scrapcenter.GameObjects.Features
{
    class Thruster : PartFeature
    {
        public class ThrusterLevel : JsonRepresentable
        {
            float AverageForce;
            float ForceVariation;

            public ThrusterLevel(float averageForce, float forceVariation)
            {
                this.AverageForce = averageForce;
                this.ForceVariation = forceVariation;
            }

            public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("averageForce");
                writer.WriteValue(this.AverageForce);
                writer.WritePropertyName("forceVariation");
                writer.WriteValue(this.ForceVariation);
                writer.WriteEndObject();
            }
        }

        List<ThrusterLevel> Levels;

        public Thruster(List<ThrusterLevel> levels)
        {
            if (levels.Count > 10)
                throw new Exception("Thruster can only have 10 levels");

            this.Levels = levels;
        }

        public Thruster(IDictionary<string, object> jsonDict)
        {
            this.Levels = new List<ThrusterLevel>();

            if (jsonDict.ContainsKey("levels"))
            {
                foreach(object levelObj in (List<object>)jsonDict["levels"])
                {
                    IDictionary<string, object> levelDict = (IDictionary<string, object>)levelObj;

                    float avgF = 0;
                    float fVar = 0;

                    if (levelDict.ContainsKey("averageForce"))
                        if (!float.TryParse(levelDict["averageForce"].ToString(), out avgF))
                            avgF = 0;
                    if (levelDict.ContainsKey("forceVariation"))
                        if (!float.TryParse(levelDict["forceVariation"].ToString(), out fVar))
                            fVar = 0;

                    Levels.Add(new ThrusterLevel(avgF, fVar));
                }
            }
        }

        public string GetFieldName()
        {
            return "thruster";
        }

        public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("levels");
            writer.WriteStartArray();
            foreach (ThrusterLevel l in this.Levels)
                l.WriteToJson(writer);
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
