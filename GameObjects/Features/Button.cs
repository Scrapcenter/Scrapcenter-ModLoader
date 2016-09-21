using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrapcenter.GameObjects.Features
{
    class Button : PartFeature
    {
        public string GetFieldName()
        {
            return "button";
        }

        public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
}
