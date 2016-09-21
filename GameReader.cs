using System;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;
using System.IO;
using System.Drawing;
using System.Xml;

using Newtonsoft.Json;

using Scrapcenter.Util;
using Scrapcenter.GameObjects;

namespace Scrapcenter
{
    class GameReader
    {

        string GameDir;

        public GameReader(string gameDirectory)
        {
            this.GameDir = gameDirectory;
        }

        public Dictionary<string, Material> ReadPhysicsMaterials()
        {
            string materialsJson = File.ReadAllText(Path.Combine(this.GameDir, "Data", "Objects", "Database", "physicsmaterials.json"));
            return Material.ReadFromJson(materialsJson);
        }

        public Dictionary<Guid, Block> ReadBlocks(Dictionary<string, Material> materials)
        {
            string blocksJson = File.ReadAllText(Path.Combine(this.GameDir, "Data", "Objects", "Database", "basicmaterials.json"));
            return Block.ReadFromJson(blocksJson, materials);
        }

        public Dictionary<string, RotationSet> ReadRotationSets()
        {
            string rotationSetsJson = File.ReadAllText(Path.Combine(this.GameDir, "Data", "Objects", "Database", "rotationsets.json"));
            return RotationSet.ReadFromJson(rotationSetsJson);
        }

        public Dictionary<string, ShapeSet> ReadShapesets(Dictionary<string, RotationSet> rotationSets, Dictionary<string, Material> physicsMaterials)
        {
            Dictionary<string, ShapeSet> shapeSets = new Dictionary<string, ShapeSet>();
            string shapeSetsListJson = File.ReadAllText(Path.Combine(this.GameDir, "Data", "Objects", "Database", "shapesets.json"));
            IDictionary<string, object> shapeSetsDict = JsonConvert.DeserializeObject<ExpandoObject>(shapeSetsListJson);
            if (shapeSetsDict.ContainsKey("shapeSetList"))
            {
                foreach (object lObj in (List<object>)shapeSetsDict["shapeSetList"])
                {
                    string shapeSetJson = File.ReadAllText(Path.Combine(this.GameDir, "Data", "Objects", "Database", "ShapeSets", lObj.ToString()));
                    if (!shapeSets.ContainsKey(lObj.ToString()))
                        shapeSets[lObj.ToString()] = new ShapeSet(lObj.ToString(), shapeSetJson, rotationSets, physicsMaterials);
                }
            }
            return shapeSets;
        }


        public Dictionary<Guid, InventoryItemDescription> ReadInventoryItemDescriptions()
        {
            Dictionary<Guid, InventoryItemDescription> descriptions = new Dictionary<Guid, InventoryItemDescription>();
            string jsonText = File.ReadAllText(Path.Combine(this.GameDir, "Data", "Gui", "InventoryItemDescriptions.json"));
            return InventoryItemDescription.ReadFromJson(jsonText);
        }

        public Dictionary<Guid, Image> ReadIconMap()
        {
            Dictionary<Guid, string> iconPoints = new Dictionary<Guid, string>();
            using (XmlReader reader = XmlReader.Create(Path.Combine(this.GameDir, "Data", "Gui", "IconMap.xml")))
            {
                

                bool readingIndex = false, readingFrame = false;

                Guid currentUuid = Guid.Empty;
                string currentPoint = String.Empty;

                while (reader.Read())
                {
                    if (reader.NodeType.Equals(XmlNodeType.Element))
                    {
                        string elementName = reader.Name;
                        string firstAttribute = reader.AttributeCount == 0 ? null : reader.GetAttribute(0);

                        if (elementName == "Index")
                        {
                            readingIndex = true;
                            if (!Guid.TryParse(firstAttribute, out currentUuid))
                                currentUuid = Guid.Empty;
                        }
                        else if (readingIndex && elementName == "Frame")
                        {
                            readingFrame = true;
                            if (firstAttribute != null)
                                currentPoint = firstAttribute;
                        }
                    }
                    else if (reader.NodeType.Equals(XmlNodeType.EndElement))
                    {
                        if (readingFrame)
                        {
                            readingFrame = false;
                            readingIndex = false;

                            if (currentUuid != Guid.Empty && currentPoint != string.Empty)
                                iconPoints.Add(currentUuid, currentPoint);

                            currentUuid = Guid.Empty;
                            currentPoint = string.Empty;
                        }
                    }
                }
            }
            Dictionary<Guid, Image> icons = new Dictionary<Guid, Image>();
            using (Image iconMapImage = Image.FromFile(Path.Combine(this.GameDir, "Data", "Gui", "IconMap.png")))
            {
                using (Bitmap iconMapImg = new Bitmap(iconMapImage))
                {
                    foreach (KeyValuePair<Guid, string> kvp in iconPoints)
                    {
                        string[] parts = kvp.Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length == 2)
                        {
                            int x, y;
                            if (int.TryParse(parts[0], out x) && int.TryParse(parts[1], out y))
                            {
                                Bitmap newIcon = iconMapImg.Clone(new Rectangle(x, y, Math.Min(80, iconMapImg.Width - x), Math.Min(80, iconMapImg.Height- y)), iconMapImg.PixelFormat);
                                icons.Add(kvp.Key, newIcon);
                            }
                        }
                    }
                }
            }
            return icons;
        }
    }
}
