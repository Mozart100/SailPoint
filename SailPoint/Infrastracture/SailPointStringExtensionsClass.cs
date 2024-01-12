namespace SailPoint.Infrastracture;

public static class SailPointStringExtensionsClass
{
    public static bool IsEmpty(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return true;
        }

        return false;
    }

    public static bool IsNotEmpty(this string str)
    {
        return !str.IsEmpty();
    }
}
