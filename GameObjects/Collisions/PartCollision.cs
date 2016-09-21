using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Scrapcenter.Util;

namespace Scrapcenter.GameObjects.Collisions
{
    interface PartCollision : JsonRepresentable
    {
        string GetFieldName();

    }
}
