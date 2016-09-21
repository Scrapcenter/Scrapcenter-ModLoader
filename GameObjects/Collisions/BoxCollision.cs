using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrapcenter.GameObjects.Collisions
{
    class BoxCollision : PartCollision
    {
        int X = 1;
        int Y = 1;
        int Z = 1;

        public BoxCollision(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public BoxCollision(IDictionary<string, object> jsonDict)
        {
            if (jsonDict.ContainsKey("x"))
                if (!int.TryParse(jsonDict["x"].ToString(), out this.X))
                    this.X = 1;
            if (jsonDict.ContainsKey("y"))
                if (!int.TryParse(jsonDict["y"].ToString(), out this.Y))
                    this.Y = 1;
            if (jsonDict.ContainsKey("z"))
                if (!int.TryParse(jsonDict["z"].ToString(), out this.Z))
                    this.Z = 1;
        }

        public string GetFieldName()
        {
            return "box";
        }

        public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            writer.WriteValue(this.X);
            writer.WritePropertyName("y");
            writer.WriteValue(this.Y);
            writer.WritePropertyName("z");
            writer.WriteValue(this.Z);
            writer.WriteEndObject();
        }
    }
}
