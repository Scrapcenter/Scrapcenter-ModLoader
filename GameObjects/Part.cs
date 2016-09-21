using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

using Scrapcenter.Util;
using Scrapcenter.GameObjects.Features;
using Scrapcenter.GameObjects.Collisions;

namespace Scrapcenter.GameObjects
{
    class Part : JsonRepresentable
    {

        int LegacyId = -1;
        public Guid ItemUuid;
        string MeshFileName = "";
        List<string> RenderMaterial = new List<string>();
        string TextureDif = "";
        string TextureAsg = "";
        string TextureNor = "";
        RotationSet RotationSet = null;
        List<Axis> PositiveStickyAxes = new List<Axis>();
        List<Axis> NegativeStickyAxes = new List<Axis>();
        RgbColor Color = null;
        float Density = -1;
        PartCollision Colision = new BoxCollision(1, 1, 1);
        Material PhysicsMaterial = null;
        PartFeature Feature = null;
        string CustomType = null;
        List<string> Script = new List<string>();

        InventoryItemDescription InvItemDesc;
        public void SetInvItemDesc(InventoryItemDescription item)
        {
            this.InvItemDesc = item;
        }

        public Part(IDictionary<string, object> jsonDict, Dictionary<string, RotationSet> rotationSets, Dictionary<string, Material> physicsMaterials)
        {
            if (jsonDict.ContainsKey("uuid"))
            {
                this.ItemUuid = Guid.Parse(jsonDict["uuid"].ToString());

                if (jsonDict.ContainsKey("legacy_id"))
                    if (!int.TryParse(jsonDict["legacy_id"].ToString(), out this.LegacyId))
                        this.LegacyId = -1;

                if (jsonDict.ContainsKey("mat"))
                {
                    try
                    {
                        Console.WriteLine(((List<object>)jsonDict["mat"]).Count);
                    }
                    catch { }
                    if (jsonDict["mat"] is string)
                    {
                        this.RenderMaterial.Add(jsonDict["mat"].ToString());
                    }
                    else
                    {
                        foreach (object q in (List<object>)jsonDict["mat"])
                        {
                            this.RenderMaterial.Add(q.ToString());
                        }
                    }
                }
                if (jsonDict.ContainsKey("mesh"))
                    this.MeshFileName = jsonDict["mesh"].ToString();

                // Texture
                if (jsonDict.ContainsKey("asg"))
                    this.TextureAsg = jsonDict["asg"].ToString();
                if (jsonDict.ContainsKey("dif"))
                    this.TextureDif = jsonDict["dif"].ToString();
                if (jsonDict.ContainsKey("nor"))
                    this.TextureNor = jsonDict["nor"].ToString();

                if (jsonDict.ContainsKey("color"))
                {
                    this.Color = RgbColor.FromHtmlNotation(jsonDict["color"].ToString());
                    if (this.Color == null)
                        throw new Exception("");
                }
                
                // Collision
                if (jsonDict.ContainsKey("cylinder"))
                    this.Colision = new CylinderCollision(
                        (IDictionary<string, object>)jsonDict["cylinder"]);
                if (jsonDict.ContainsKey("box"))
                    this.Colision = new BoxCollision(
                        (IDictionary<string, object>)jsonDict["box"]);
                if (jsonDict.ContainsKey("hull"))
                    this.Colision = new HullCollision(
                        (IDictionary<string, object>)jsonDict["hull"]);

                // Rotationset
                if (jsonDict.ContainsKey("rotationSet"))
                {
                    string rotSetName = jsonDict["rotationSet"].ToString();
                    if (rotationSets.ContainsKey(rotSetName))
                        this.RotationSet = rotationSets[rotSetName];
                    else
                        throw new Exception("Part has invalid rotation set: " + rotSetName);
                }

                if (jsonDict.ContainsKey("density"))
                {
                    if (!float.TryParse(jsonDict["density"].ToString(), out this.Density))
                        this.Density = -1;
                }

                if (jsonDict.ContainsKey("type"))
                {
                    this.CustomType = jsonDict["type"].ToString();
                }

                // Feature
                if (jsonDict.ContainsKey("bearing"))
                    this.Feature = new Features.Bearing();
                if (jsonDict.ContainsKey("sensor"))
                    this.Feature = new Features.Sensor();
                if (jsonDict.ContainsKey("radio"))
                    this.Feature = new Features.Radio();
                if (jsonDict.ContainsKey("horn"))
                    this.Feature = new Features.Horn();
                if (jsonDict.ContainsKey("timedjoint"))
                    this.Feature = new Features.Controller();
                if (jsonDict.ContainsKey("logic"))
                    this.Feature = new Features.LogicGate();
                if (jsonDict.ContainsKey("timer"))
                    this.Feature = new Features.Timer();
                if (jsonDict.ContainsKey("tone"))
                    this.Feature = new Features.Tone((IDictionary<string, object>)jsonDict["tone"]);
                if (jsonDict.ContainsKey("lever"))
                    this.Feature = new Features.Lever();
                if (jsonDict.ContainsKey("button"))
                    this.Feature = new Features.Button();
                if (jsonDict.ContainsKey("spring"))
                    this.Feature = new Features.Spring((IDictionary<string, object>)jsonDict["spring"]);
                if (jsonDict.ContainsKey("steering"))
                    this.Feature = new Features.Steering((IDictionary<string, object>)jsonDict["steering"]);
                if (jsonDict.ContainsKey("seat"))
                    this.Feature = new Features.Seat((IDictionary<string, object>)jsonDict["seat"]);
                if (jsonDict.ContainsKey("engine"))
                    this.Feature = new Features.Engine((IDictionary<string, object>)jsonDict["engine"]);
                if (jsonDict.ContainsKey("thruster"))
                    this.Feature = new Features.Thruster((IDictionary<string, object>)jsonDict["thruster"]);

                if (jsonDict.ContainsKey("script"))
                {
                    foreach(object q in (List<object>)jsonDict["script"]) {
                        this.Script.Add(q.ToString());
                    }
                }

                if (jsonDict.ContainsKey("sticky"))
                {
                    string sticky = jsonDict["sticky"].ToString();
                    for (int i = 0; i < sticky.Length; i += 2)
                    {
                        // -
                        if (sticky[i] == '-')
                        {
                            if (sticky[i + 1] == 'X')
                                this.NegativeStickyAxes.Add(Axis.X);
                            else if (sticky[i + 1] == 'Y')
                                this.NegativeStickyAxes.Add(Axis.Y);
                            else
                                this.NegativeStickyAxes.Add(Axis.Z);
                        }
                        // +
                        else
                        {
                            if (sticky[i + 1] == 'X')
                                this.PositiveStickyAxes.Add(Axis.X);
                            else if (sticky[i + 1] == 'Y')
                                this.PositiveStickyAxes.Add(Axis.Y);
                            else
                                this.PositiveStickyAxes.Add(Axis.Z);
                        }
                    }
                }

                if (jsonDict.ContainsKey("physicsMaterial"))
                {
                    string phyMat = jsonDict["physicsMaterial"].ToString();
                    if (physicsMaterials.ContainsKey(phyMat))
                        this.PhysicsMaterial = physicsMaterials[phyMat];
                }
            }
            else
            {
                throw new Exception("Part doesn't have UUID");
            }
        }

        public void WriteToJson(JsonWriter writer)
        {
            writer.WriteStartObject();

            if (this.LegacyId != -1)
            {
                writer.WritePropertyName("legacy_id");
                writer.WriteValue(this.LegacyId);
            }

            writer.WritePropertyName("uuid");
            writer.WriteValue(this.ItemUuid.ToString("D"));

            writer.WritePropertyName("mesh");
            writer.WriteValue(this.MeshFileName);

            if (this.RenderMaterial.Count != 0)
            {
                writer.WritePropertyName("mat");
                if (this.RenderMaterial.Count == 1)
                    writer.WriteValue(this.RenderMaterial[0]);
                else
                {
                    writer.WriteStartArray();
                    foreach (string m in this.RenderMaterial)
                        writer.WriteValue(m);
                    writer.WriteEndArray();
                }
            }
            
            writer.WritePropertyName("dif");
            writer.WriteValue(this.TextureDif);

            if (this.TextureAsg != "")
            {
                writer.WritePropertyName("asg");
                writer.WriteValue(this.TextureAsg);
            }

            if (this.TextureNor != "")
            {
                writer.WritePropertyName("nor");
                writer.WriteValue(this.TextureNor);
            }

            writer.WritePropertyName("rotationSet");
            writer.WriteValue(this.RotationSet.Name);

            if (this.Density != -1)
            {
                writer.WritePropertyName("density");
                writer.WriteValue(this.Density);
            }

            writer.WritePropertyName("color");
            writer.WriteValue(this.Color.GetHex());

            if (this.Feature != null)
            {
                writer.WritePropertyName(this.Feature.GetFieldName());
                this.Feature.WriteToJson(writer);
            }

            if (this.CustomType != null)
            {
                writer.WritePropertyName("type");
                writer.WriteValue(this.CustomType);
            }
           
            writer.WritePropertyName(this.Colision.GetFieldName());
            this.Colision.WriteToJson(writer);

            if (this.PhysicsMaterial != null)
            {
                writer.WritePropertyName("physicsMaterial");
                writer.WriteValue(this.PhysicsMaterial.Name);
            }

            if (this.Script.Count != 0)
            {
                writer.WritePropertyName("script");
                writer.WriteStartArray();
                foreach (string script in this.Script)
                    writer.WriteValue(script);
                writer.WriteEndArray();
            }

            if (this.PositiveStickyAxes.Count != 0 || this.NegativeStickyAxes.Count != 0)
            {
                writer.WritePropertyName("sticky");
                StringBuilder b = new StringBuilder(6);

                foreach (Axis ax in new Axis[] { Axis.X, Axis.Z, Axis.Y })
                {
                    if (this.NegativeStickyAxes.Contains(ax))
                        b.Append("-" + ax.ToString());
                    if (this.PositiveStickyAxes.Contains(ax))
                        b.Append("+" + ax.ToString());
                }

                writer.WriteValue(b.ToString());
                b = null;
            }

            writer.WriteEndObject();
        }
    }
}
