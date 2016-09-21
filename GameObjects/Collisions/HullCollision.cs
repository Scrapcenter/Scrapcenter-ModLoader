using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrapcenter.GameObjects.Collisions
{
    class HullCollision : PartCollision
    {
        int X = 1;
        int Y = 1;
        int Z = 1;
        float Margin = 0;

        List<float[]> PointList = new List<float[]>();

        public HullCollision(int x, int y, int z, List<float[]> pointList, float margin)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.PointList = pointList;
            this.Margin = margin;
        }

        public HullCollision(IDictionary<string, object> jsonDict)
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

            if (jsonDict.ContainsKey("margin"))
                float.TryParse(jsonDict["margin"].ToString(), out this.Margin);

            if (jsonDict.ContainsKey("pointlist"))
            {
                foreach(object pointObj in (List<object>)jsonDict["pointlist"])
                {
                    IDictionary<string, object> pointDict = (IDictionary<string, object>)pointObj;
                    float x = 1, y = 1, z = 1;
                    if (pointDict.ContainsKey("x"))
                        if (!float.TryParse(pointDict["x"].ToString(), out x))
                            x = 1;
                    if (pointDict.ContainsKey("y"))
                        if (!float.TryParse(pointDict["y"].ToString(), out y))
                            y = 1;
                    if (pointDict.ContainsKey("z"))
                        if (!float.TryParse(pointDict["z"].ToString(), out z))
                            z = 1;
                    this.PointList.Add(new float[3] { x, y, z });
                }
            }
        }

        public string GetFieldName()
        {
            return "hull";
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
            if (this.Margin != 0)
            {
                writer.WritePropertyName("margin");
                writer.WriteValue(this.Margin);
            }
            writer.WritePropertyName("pointlist");
            writer.WriteStartArray();

            foreach (float[] points in this.PointList)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("x");
                writer.WriteValue(points[0]);
                writer.WritePropertyName("y");
                writer.WriteValue(points[1]);
                writer.WritePropertyName("z");
                writer.WriteValue(points[2]);                
                writer.WriteEndObject();
            }

            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
