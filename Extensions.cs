using System.Xml;

namespace PfpToDbService;

public static class Extensions
{
    public static bool ToBool(this string s, bool defaultValue = default)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return false;
        }

        if (s.Equals(bool.TrueString, StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }

        if (s.Equals(bool.FalseString, StringComparison.InvariantCultureIgnoreCase))
        {
            return false;
        }

        try
        {
            return XmlConvert.ToBoolean(s);
        }
        catch
        {
            return defaultValue;
        }
    }

}