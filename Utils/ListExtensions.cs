namespace csharp.Utils
{
    static class ListExtensions
    {
        public static T IfDefaultGiveMe<T>(this T value, T alternate)
        {
            if (value.Equals(default(T))) return alternate;
            return value;
        }
    }
}
