using System;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;

using Newtonsoft.Json;

using Scrapcenter.Util;

namespace Scrapcenter.GameObjects
{
    class RotationSet : JsonRepresentable
    {

        public string Name;
        bool Prop;
        List<Rotation> Rotations;

        public RotationSet(string name, bool prop, List<Rotation> rotations)
        {
            this.Name = name;
            this.Prop = prop;
            this.Rotations = rotations;
        }

        public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteValue(this.Name);
            writer.WritePropertyName("prop");
            writer.WriteValue(this.Prop);
            writer.WritePropertyName("rotation");
            writer.WriteStartArray();
            foreach (Rotation r in this.Rotations)
                r.WriteToJson(writer);
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        public static Dictionary<string, RotationSet> ReadFromJson(string jsonText)
        {
            Dictionary<string, RotationSet> rotationSets = new Dictionary<string, RotationSet>();

            IDictionary<string, object> doc = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
            if (doc.ContainsKey("rotationSet"))
            {
                foreach (object rotationSetObj in (List<object>)doc["rotationSet"])
                {
                    string name;
                    bool prop;
                    List<Rotation> rotations = new List<Rotation>();
                    IDictionary<string, object> dict = (IDictionary<string, object>)rotationSetObj;
                    if (dict.ContainsKey("name"))
                    {
                        name = dict["name"].ToString();
                        if (!rotationSets.ContainsKey(name))
                        {
                            if (dict.ContainsKey("prop"))
                            {
                                if (!bool.TryParse(dict["prop"].ToString(), out prop))
                                    prop = true;

                                if (dict.ContainsKey("rotation"))
                                {
                                    foreach (object rot in (List<object>)dict["rotation"])
                                    {
                                        IDictionary<string, object> rotation = (IDictionary<string, object>)rot;
                                        Axis eastAxis = Axis.Z, southAxis = Axis.Z;
                                        bool eastPositive = true, southPositive = true;

                                        if (rotation.ContainsKey("south") && rotation["south"].ToString() != "")
                                        {
                                            string south = rotation["south"].ToString();
                                            if (south.Length == 2)
                                            {
                                                if (south[0] == '-')
                                                    southPositive = false;

                                                south = south.Substring(1);
                                            }

                                            if (south == "X")
                                                southAxis = Axis.X;
                                            if (south == "Y")
                                                southAxis = Axis.Y;

                                            if (rotation.ContainsKey("east") && rotation["east"].ToString() != "")
                                            {
                                                string east = rotation["east"].ToString();
                                                if (east.Length == 2)
                                                {
                                                    if (east[0] == '-')
                                                        eastPositive = false;
                                                    east = east.Substring(1);
                                                }

                                                if (east == "X")
                                                    eastAxis = Axis.X;
                                                else if (east == "Y")
                                                    eastAxis = Axis.Y;

                                                rotations.Add(new Rotation(southAxis, southPositive, eastAxis, eastPositive));
                                            }
                                            else
                                                throw new Exception("rotation from set " + name + " doesn't have south");
                                        }
                                        else
                                            throw new Exception("rotation from set " + name + " doesn't have south");
                                    }

                                    rotationSets.Add(name, new RotationSet(name, prop, rotations));
                                }
                                else
                                    throw new Exception("rotationset " + name + " doesn't have rotations");
                            }
                            else
                                throw new Exception("rotationset " + name + " doesn't have a prop");
                        }
                    }
                    else
                        throw new Exception("rotationset doesn't have a name");
                }
            }

            return rotationSets;
        }
    }
}
