using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Scrapcenter.Util;

namespace Scrapcenter.GameObjects.Features
{
    interface PartFeature : JsonRepresentable
    {

        string GetFieldName();

    }
}
