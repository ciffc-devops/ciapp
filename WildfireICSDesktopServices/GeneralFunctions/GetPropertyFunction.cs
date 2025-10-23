namespace WildfireICSDesktopServices.GeneralFunctions
{
    public static class GetPropertyFunction
    {
        public static object GetProperty(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }
    }
}
