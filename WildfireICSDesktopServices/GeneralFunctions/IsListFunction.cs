using System.Collections;
using System.Collections.Generic;

namespace WildfireICSDesktopServices.GeneralFunctions
{
    public static class IsListFunction
    {
        public static bool IsList(object obj)
        {
            if (obj == null) return false;

            var type = obj.GetType();
            bool isList = typeof(IList).IsAssignableFrom(type) || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>));
            return isList;
        }
    }
}
