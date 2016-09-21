using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrapcenter.Util;

namespace Scrapcenter.GameObjects
{
    class Rotation : JsonRepresentable
    {
        Axis EastAxis;
        bool EastPositive;

        Axis SouthAxis;
        bool SouthPositive;

        public Rotation(Axis southAxis, bool southPositive, Axis eastAxis, bool eastPositive)
        {
            this.SouthAxis = southAxis;
            this.SouthPositive = southPositive;
            this.EastAxis = eastAxis;
            this.EastPositive = eastPositive;
        }

        public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("south");
            writer.WriteValue(this.SouthPositive ? this.SouthAxis.ToString() : '-' + this.SouthAxis.ToString());
            writer.WritePropertyName("east");
            writer.WriteValue(this.EastPositive ? this.EastAxis.ToString() : '-' + this.EastAxis.ToString());
            writer.WriteEndObject();
        }
    }
}
