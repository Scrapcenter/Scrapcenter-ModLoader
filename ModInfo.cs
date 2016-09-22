using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Newtonsoft.Json;

namespace Scrapcenter
{
    class ModInfo
    {
        public string FileName;

        public string ModName;
        public string ModURL;
        public string ModLanguage;

        public string AuthorName;
        public string AuthorURL;

        public string ModVersion;
        public string GameVersion;
        public string LoaderVersion;

        public List<string> Contributors;
        public List<string> Dependencies;

        public Image ModIcon;

        public static string[] ParseModID(string modID)
        {
            string[] l = modID.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(l[1].ToString());
            if (l.Length == 0)
                throw new ArgumentException("ModID must contain ::");
            
            if (l.Length == 1)
                return new string[2] { "Unknown", l[1] };
            
            return new string[2] { l[0], l[1] };
        }

        public ModInfo(string fileName, string jsonText, Image icon = null)
        {
            this.FileName = fileName;
            IDictionary<string, object> modinfo = JsonConvert.DeserializeObject<IDictionary<string, object>>(jsonText);

            this.ModIcon = icon;

            LoadFromDict(out ModName, modinfo, "modName", "NoName");
            if (ModName.Contains("::"))
                throw new Exception("Mod name cannot contain ::");

            LoadFromDict(out ModURL, modinfo, "modURL", "");
            LoadFromDict(out ModLanguage, modinfo, "modLanguage", "");
            LoadFromDict(out AuthorName, modinfo, "authorName", "");
            if (AuthorName.Contains("::"))
                throw new Exception("Author name cannot contain ::");
            
            LoadFromDict(out AuthorURL, modinfo, "authorURL", "");
            LoadFromDict(out ModVersion, modinfo, "modVersion", "1.0");
            if (ModVersion.Contains("::"))
                throw new Exception("Mod version cannot contain ::");

            LoadFromDict(out GameVersion, modinfo, "gameVersion", "");
            LoadFromDict(out LoaderVersion, modinfo, "loaderVersion", "1.0");

            this.Dependencies = new List<string>();
            if (modinfo.ContainsKey("dependencies"))
            {
                dynamic dependencies = modinfo["dependencies"];
                foreach (object o in dependencies)
                    Dependencies.Add(o.ToString());
            }

            this.Contributors = new List<string>();
            if (modinfo.ContainsKey("contributors"))
            {
                dynamic contributors = modinfo["contributors"];
                foreach (object o in contributors)
                    Contributors.Add(o.ToString());
            }
        }

        private void LoadFromDict<TKey, TValue>(out TValue dest, IDictionary<TKey, object> dictionary, TKey key, TValue defaultVal)
        {
            if (dictionary.ContainsKey(key))
                dest = (TValue)dictionary[key];
            else
                dest = defaultVal;
        }

        public override string ToString()
        {
            return this.AuthorName + "::" + this.ModName;
        }
    }
}
