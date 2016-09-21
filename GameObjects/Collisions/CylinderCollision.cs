using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Scrapcenter.GameObjects.Collisions
{
    class CylinderCollision : PartCollision
    {

        int Diameter = 1;
        int Depth = 1;
        float Margin = 0f;
        Axis Axis = Axis.Z;

        public CylinderCollision(int diameter, int depth, int margin, Axis axis)
        {
            this.Diameter = diameter;
            this.Depth = depth;
            this.Margin = margin;
            this.Axis = axis;
        }

        public CylinderCollision(IDictionary<string, object> jsonDict)
        {
            if (jsonDict.ContainsKey("diameter"))
                if (!int.TryParse(jsonDict["diameter"].ToString(), out this.Diameter))
                    this.Diameter = 1;
            
            if (jsonDict.ContainsKey("depth"))
                if (!int.TryParse(jsonDict["depth"].ToString(), out this.Depth))
                    this.Depth = 1;

            if (jsonDict.ContainsKey("margin"))
                if (!float.TryParse(jsonDict["margin"].ToString(), out this.Margin))
                    this.Margin = 0f;

            if (jsonDict.ContainsKey("axis"))
            {
                string axis = jsonDict["axis"].ToString();
                if (axis == "X")
                    this.Axis = Axis.X;
                if (axis == "Y")
                    this.Axis = Axis.Y;
            }
        }

        public string GetFieldName()
        {
            return "cylinder";
        }

        public void WriteToJson(JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("diameter");
            writer.WriteValue(this.Diameter);
            writer.WritePropertyName("depth");
            writer.WriteValue(this.Depth);
            if (this.Margin != 0)
            {
                writer.WritePropertyName("margin");
                writer.WriteValue(this.Margin);
            }
            writer.WritePropertyName("axis");
            writer.WriteValue(this.Axis.ToString());
            writer.WriteEndObject();
        }

    }
}
