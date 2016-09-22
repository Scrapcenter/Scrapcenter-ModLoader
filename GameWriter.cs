using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using Newtonsoft.Json;

using Scrapcenter.GameObjects;

namespace Scrapcenter
{
    class GameWriter
    {

        string GameDir;

        public GameWriter(string destinationPath)
        {
            this.GameDir = destinationPath;
            Directory.CreateDirectory(Path.Combine(this.GameDir, "Data", "Gui"));
            Directory.CreateDirectory(Path.Combine(this.GameDir, "Data", "Objects", "Database"));
            Directory.CreateDirectory(Path.Combine(this.GameDir, "Data", "Objects", "Database", "ShapeSets"));
        }

        public void WriteInventoryItemDescriptions(Dictionary<Guid, InventoryItemDescription> items)
        {
            StreamWriter wr = new StreamWriter(Path.Combine(this.GameDir, "Data", "Gui", "InventoryItemDescriptions.json"));
            JsonWriter writer = new JsonTextWriter(wr);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();

            foreach (KeyValuePair<Guid, InventoryItemDescription> desc in items) {
                writer.WritePropertyName(desc.Key.ToString());
                desc.Value.WriteToJson(writer);
            }

            writer.WriteEndObject();

            writer.Close();
        }

        public void WriteIcons(Dictionary<Guid, Image> icons)
        {
            // Write IconMap.png
            int colCount = 12;
            int rowCount = (int)Math.Ceiling((double)icons.Count / 12);
            using (Bitmap iconMap = new Bitmap(1024, rowCount * 80, PixelFormat.Format32bppArgb))
            {
                int index = 1;
                using (Graphics g = Graphics.FromImage(iconMap))
                {
                    foreach (Image i in icons.Values)
                    {
                        int x = (index % colCount) * 80;
                        int y = (int)Math.Floor(index / (double)colCount) * 80;
                        g.DrawImage(i, x, y);

                        index++;
                    }
                }

                iconMap.Save(Path.Combine(this.GameDir, "Data", "Gui", "IconMap.png"), ImageFormat.Png);
            }

            // Write IconMap.xml
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.AppendLine("<MyGUI type=\"Resource\" version=\"1.1\">");
            xmlBuilder.AppendLine("    <Resource type=\"ResourceImageSet\" name=\"ItemIconsSet0\">");
            xmlBuilder.AppendLine("        <Group name=\"ItemIcons\" texture=\"IconMap.png\" size=\"80 80\">");
            xmlBuilder.AppendLine("            <Index name=\"Empty\">");
            xmlBuilder.AppendLine("                <Frame point=\"0 0\"/>");
            xmlBuilder.AppendLine("            </Index>");

            int index2 = 1;
            foreach (Guid g in icons.Keys)
            {
                int x = (index2 % colCount) * 80;
                int y = (int)Math.Floor(index2 / (double)colCount) * 80;
                xmlBuilder.AppendLine("            <Index name=\"" + g.ToString() + "\">");
                xmlBuilder.AppendLine("                <Frame point=\"" + x + " " + y + "\"/>");
                xmlBuilder.AppendLine("            </Index>");
                index2++;
            }

            xmlBuilder.AppendLine("        </Group>");
            xmlBuilder.AppendLine("   </Resource>");
            xmlBuilder.AppendLine("</MyGUI>");

            File.WriteAllText(Path.Combine(this.GameDir, "Data", "Gui", "IconMap.xml"), xmlBuilder.ToString());
            xmlBuilder = null;
        }


        public void WriteResources(Dictionary<string, byte[]> resources)
        {
            foreach (KeyValuePair<string, byte[]> kvp in resources)
            {
                string path = kvp.Key.Replace('/', Path.DirectorySeparatorChar);
                string destDir = Path.Combine(this.GameDir, "Data", path.Substring(0, path.LastIndexOf(Path.DirectorySeparatorChar)));
                if (!Directory.Exists(destDir))
                    Directory.CreateDirectory(destDir);

                using (FileStream stream = File.OpenWrite(Path.Combine(this.GameDir, "Data", kvp.Key)))
                    using (BinaryWriter writer = new BinaryWriter(stream))
                        writer.Write(kvp.Value);
            }
        }

        public void WriteBlocks(Dictionary<Guid, Block> blocks)
        {
            using (StreamWriter wr = new StreamWriter(Path.Combine(this.GameDir, "Data", "Objects", "Database", "basicmaterials.json")))
            {
                using (JsonWriter writer = new JsonTextWriter(wr))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartObject();
                    writer.WritePropertyName("basicMaterialList");
                    writer.WriteStartArray();
                    foreach (Block b in blocks.Values)
                        b.WriteToJson(writer);
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                }
            }
        }

        public void WriteShapesets(Dictionary<string, ShapeSet> shapeSets)
        {
            Dictionary<Guid, ShapeSet> definedParts = new Dictionary<Guid, ShapeSet>();
            
            // Check for overwrites and overwrite violations
            foreach (ShapeSet s in shapeSets.Values)
            {
                foreach (Part p in s.Parts.Values)
                {
                    if (definedParts.ContainsKey(p.ItemUuid))
                    {
                        ShapeSet overwrites = definedParts[p.ItemUuid];
                        if (s.Overwrites.Contains(overwrites.Name))
                        {
                            overwrites.Parts[p.ItemUuid] = p;
                            s.Parts.Remove(p.ItemUuid);
                        }
                        else
                            throw new Exception("Part from ShapeSet " + s.Name + " overwrites part from " + overwrites.Name + " without specifying an 'overwrites' declaration for it.");
                    }
                }
            }

            using (StreamWriter wr = new StreamWriter(Path.Combine(this.GameDir, "Data", "Objects", "Database", "shapesets.json")))
            {
                using (JsonWriter writer = new JsonTextWriter(wr))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartObject();
                    writer.WritePropertyName("shapeSetList");
                    writer.WriteStartArray();
                    foreach (ShapeSet s in shapeSets.Values)
                        writer.WriteValue(s.Name);
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                }
            }

            foreach (ShapeSet s in shapeSets.Values)
            {
                using (StreamWriter wr = new StreamWriter(Path.Combine(this.GameDir, "Data", "Objects", "Database", "ShapeSets", s.Name)))
                {
                    using (JsonWriter writer = new JsonTextWriter(wr))
                    {
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartObject();
                        writer.WritePropertyName("itemlist");
                        writer.WriteStartArray();
                        foreach (Part p in s.Parts.Values)
                            p.WriteToJson(writer);
                        writer.WriteEndArray();
                        writer.WriteEndObject();
                    }
                }
            }
        }

        public void WritePhysicsMaterials(Dictionary<string, Material> materials)
        {
            using (StreamWriter wr = new StreamWriter(Path.Combine(this.GameDir, "Data", "Objects", "Database", "physicsmaterials.json")))
            {
                using (JsonWriter writer = new JsonTextWriter(wr))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartObject();
                    writer.WritePropertyName("materials");
                    writer.WriteStartArray();
                    foreach (Material m in materials.Values)
                        m.WriteToJson(writer);
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                }
            }
        }

        public void WriteRotationSets(Dictionary<string, RotationSet> rotationSets)
        {
            using(StreamWriter wr = new StreamWriter(Path.Combine(this.GameDir, "Data", "Objects", "Database", "rotationsets.json")))
            {
                using(JsonWriter writer = new JsonTextWriter(wr)) {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartObject();
                    writer.WritePropertyName("rotationSet");
                    writer.WriteStartArray();
                    foreach (RotationSet r in rotationSets.Values)
                        r.WriteToJson(writer);
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                }
            }
        }
    }
}
