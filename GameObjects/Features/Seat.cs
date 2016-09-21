using System;
using System.Collections.Generic;
using System.Text;

using Scrapcenter.Util;

namespace Scrapcenter.GameObjects.Features
{
    class Seat : PartFeature
    {
        public class Bone : JsonRepresentable
        {
            string Name;
            float[] Offset;
            bool FreeRotation;

            public Bone(string name, float[] offset, bool freeRotation = false)
            {
                if (offset.Length != 3)
                    throw new Exception("Seat bone offset must contain an X, Y and Z");

                this.Name = name;
                this.Offset = offset;
                this.FreeRotation = freeRotation;
            }

            public Bone(IDictionary<string, object> jsonDict)
            {
                if (jsonDict.ContainsKey("name"))
                {
                    this.Name = jsonDict["name"].ToString();
                    this.Offset = new float[3] { 0f, 0f, 0f };
                    if (jsonDict.ContainsKey("offset"))
                    {
                        IDictionary<string, object> offsetDict = (IDictionary<string, object>)jsonDict["offset"];
                        if (offsetDict.ContainsKey("x"))
                            float.TryParse(offsetDict["x"].ToString(), out this.Offset[0]);
                        if (offsetDict.ContainsKey("y"))
                            float.TryParse(offsetDict["y"].ToString(), out this.Offset[1]);
                        if (offsetDict.ContainsKey("z"))
                            float.TryParse(offsetDict["z"].ToString(), out this.Offset[2]);
                    }

                    this.FreeRotation = false;
                    if (jsonDict.ContainsKey("freeRotation"))
                        bool.TryParse(jsonDict["freeRotation"].ToString(), out this.FreeRotation);
                }
                else
                {
                    throw new Exception("Steering bone has no name");
                }
            }

            public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("name");
                writer.WriteValue(this.Name);
                writer.WritePropertyName("offset");
                writer.WriteStartObject();
                writer.WritePropertyName("x");
                writer.WriteValue(this.Offset[0]);
                writer.WritePropertyName("y");
                writer.WriteValue(this.Offset[1]);
                writer.WritePropertyName("z");
                writer.WriteValue(this.Offset[2]);
                writer.WriteEndObject();
                if (this.FreeRotation)
                {
                    writer.WritePropertyName("freeRotation");
                    writer.WriteValue(true);
                }
                writer.WriteEndObject();
            }
        }

        List<Bone> Bones;
        string RagdollPose;
        string EnterAudio;
        string ExitAudio;
        
        public Seat(List<Bone> bones, string ragdollPose = "seat", string enterAudio = "Seat seated", string exitAudio = "Seat unseated")
        {
            this.Bones = bones;
            this.RagdollPose = ragdollPose;
            this.EnterAudio = enterAudio;
            this.ExitAudio = exitAudio;
        }

        public Seat(IDictionary<string, object> jsonDict)
        {
            this.Bones = new List<Bone>();
            if (jsonDict.ContainsKey("bones"))
                foreach (object boneObj in (List<object>)jsonDict["bones"])
                    this.Bones.Add(new Bone((IDictionary<string, object>)boneObj));

            if (jsonDict.ContainsKey("ragdollPose"))
                this.RagdollPose = jsonDict["ragdollPose"].ToString();
            else
                this.RagdollPose = "seat";

            if (jsonDict.ContainsKey("enterAudio"))
                this.EnterAudio = jsonDict["enterAudio"].ToString();
            if (jsonDict.ContainsKey("exitAudio"))
                this.ExitAudio = jsonDict["exitAudio"].ToString();

        }

        public string GetFieldName()
        {
            return "seat";
        }

        public void WriteToJson(Newtonsoft.Json.JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("bones");
            writer.WriteStartArray();
            foreach (Bone b in this.Bones)
                b.WriteToJson(writer);
            writer.WriteEndArray();
            writer.WritePropertyName("ragdollPose");
            writer.WriteValue(this.RagdollPose);
            writer.WritePropertyName("enterAudio");
            writer.WriteValue(this.EnterAudio);
            writer.WritePropertyName("exitAudio");
            writer.WriteValue(this.ExitAudio);
            writer.WriteEndObject();
        }
    }
}
