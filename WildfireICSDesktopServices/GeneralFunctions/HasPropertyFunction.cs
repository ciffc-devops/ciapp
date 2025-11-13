using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildfireICSDesktopServices.GeneralFunctions
{
    public static class HasPropertyFunction
    {
        public static bool HasProperty(this object obj, string PropertyName)
        {
            return obj.GetType().GetProperty(PropertyName) != null;
        }
    }
}
