using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Scrapcenter.Util
{
    public class RgbColor : JsonRepresentable
    {

        int R;
        int G;
        int B;

        public RgbColor(int r, int g, int b) {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        public RgbColor(Color c)
        {
            this.R = c.R;
            this.G = c.G;
            this.B = c.B;
        }

        public static RgbColor FromHtmlNotation(string htmlNotation)
        {
            // Remove first #
            if (htmlNotation.Length == 6 || htmlNotation.Length == 3)
                htmlNotation = '#' + htmlNotation;

            if (htmlNotation.Length == 7 || htmlNotation.Length == 4)
                return new RgbColor(ColorTranslator.FromHtml(htmlNotation));
            else
                Console.WriteLine("Color HTML " + htmlNotation + " is incorrect");
            return null;
        }

        /// <summary>
        /// Gets the System.Drawing.Color of this color
        /// </summary>
        /// <returns></returns>
        Color GetColor()
        {
            return Color.FromArgb(255, R, G, B);
        }


        public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("r");
            writer.WriteValue(this.R);
            writer.WritePropertyName("g");
            writer.WriteValue(this.G);
            writer.WritePropertyName("b");
            writer.WriteValue(this.B);
            writer.WriteEndObject();
        }

        public string GetHex()
        {
            return R.ToString("X2").ToLower() + G.ToString("X2").ToLower() + B.ToString("X2").ToLower();
        }

    }
}
