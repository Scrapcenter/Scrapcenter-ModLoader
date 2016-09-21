using System;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;

using Newtonsoft.Json;

using Scrapcenter.Util;

namespace Scrapcenter.GameObjects
{
    class Block : JsonRepresentable
    {
        // LegacyID -1 means there is no legacy id
        public int LegacyId = -1;

        public Guid ItemUuid;

        public string RenderMaterial;

        public string TextureDif;
        public string TextureAsg;
        public string TextureNor;

        public Material PhysicsMaterial;
        public float Density;

        bool Transparent = false;

        RgbColor TextureColor;

        InventoryItemDescription InvItemDesc;

        public void SetInvItemDesc(InventoryItemDescription item)
        {
            this.InvItemDesc = item;
        }

        public Block(Guid itemUuid, string txtrDif, string txtrAsg, string txtrNor, RgbColor color, Material physicsMaterial, float density = -1, string renderMaterial = "", int legacyId = -1, bool transparent = false)
        {
            this.ItemUuid = itemUuid;
            
            this.TextureDif = txtrDif;
            this.TextureAsg = txtrAsg;
            this.TextureNor = txtrNor;
            this.Transparent = transparent;
            
            this.Density = density;
            this.PhysicsMaterial = physicsMaterial;
            this.TextureColor = color;
            this.RenderMaterial = renderMaterial;
            
            this.LegacyId = legacyId;
        }


        public void WriteToJson(JsonWriter writer)
        {
            writer.WriteStartObject();
            {
                if (this.LegacyId != -1)
                {
                    writer.WritePropertyName("legacy_id");
                    writer.WriteValue(this.LegacyId);
                }

                writer.WritePropertyName("uuid");
                writer.WriteValue(ItemUuid.ToString("D"));

                if (this.RenderMaterial != "")
                {
                    writer.WritePropertyName("mat");
                    writer.WriteValue(this.RenderMaterial);
                }

                writer.WritePropertyName("dif");
                writer.WriteValue(this.TextureDif);

                if (this.TextureAsg != "")
                {
                    writer.WritePropertyName("asg");
                    writer.WriteValue(this.TextureAsg);
                }

                if (this.Transparent)
                {
                    writer.WritePropertyName("transparent");
                    writer.WriteValue(true);
                }

                writer.WritePropertyName("nor");
                writer.WriteValue(this.TextureNor);

                writer.WritePropertyName("color");
                writer.WriteValue(this.TextureColor.GetHex());

                if (this.Density != -1)
                {
                    writer.WritePropertyName("density");
                    writer.WriteValue(this.Density);
                }

                writer.WritePropertyName("physics_material");
                writer.WriteValue(this.PhysicsMaterial.Name);

            }
            writer.WriteEndObject();
        }

        public static Dictionary<Guid, Block> ReadFromJson(string jsonText, Dictionary<string, Material> materials)
        {
            Dictionary<Guid, Block> blocks = new Dictionary<Guid, Block>();
            IDictionary<string, object> doc = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
            if (doc.ContainsKey("basicMaterialList"))
            {
                foreach (object blockObj in (List<object>)doc["basicMaterialList"])
                {  
                    IDictionary<string, object> block = (IDictionary<string, object>)blockObj;
                    int legacyId = -1;
                    Guid itemUuid;
                    string renderMaterial = "";
                    bool transparent = false;
                    string textureDif = "";
                    string textureAsg = "";
                    string textureNor = "nonor_nor.tga";
                    RgbColor textureColor = new RgbColor(255, 255, 255);
                    float density = -1;

                    if (block.ContainsKey("legacy_id"))
                        if(!int.TryParse(block["legacy_id"].ToString(), out legacyId))
                            legacyId = -1;

                    if (block.ContainsKey("uuid"))
                    {
                        itemUuid = new Guid(block["uuid"].ToString());

                        if (!blocks.ContainsKey(itemUuid))
                        {
                            if (block.ContainsKey("dif"))
                                textureDif = block["dif"].ToString();

                            if (block.ContainsKey("asg"))
                                textureAsg = block["asg"].ToString();

                            if (block.ContainsKey("nor"))
                                textureNor = block["nor"].ToString();

                            if (block.ContainsKey("color"))
                            {
                                RgbColor c = RgbColor.FromHtmlNotation(block["color"].ToString());
                                if (c != null)
                                    textureColor = c;
                            }

                            if (block.ContainsKey("density"))
                            {
                                if (!float.TryParse(block["density"].ToString(), out density))
                                    density = -1;
                            }

                            if (block.ContainsKey("transparent"))
                                bool.TryParse(block["transparent"].ToString(), out transparent);

                            if (block.ContainsKey("mat"))
                                renderMaterial = block["mat"].ToString();

                            if (block.ContainsKey("physics_material"))
                            {
                                string pMat = block["physics_material"].ToString();
                                if (materials.ContainsKey(pMat))
                                    blocks.Add(itemUuid, new Block(itemUuid, textureDif, textureAsg, textureNor, textureColor, materials[pMat], density, renderMaterial, legacyId, transparent));
                                else
                                    throw new Exception("basicmaterial physics_material invalid");
                            }
                            else
                                throw new Exception("basicmaterial doesn't have physics_material.");
                        }
                    }
                    else
                        throw new Exception("basicmaterial doesn't have uuid.");
                }
            }
            return blocks;
        }

    }
}
