namespace Common;

public class Constants
{
    public static class ApiAppsettings
    {
        public static class ConnectionStrings
        {
            public static readonly string SqlConnection1 = $"{nameof(ConnectionStrings)}:{nameof(SqlConnection1)}";
            public static readonly string SqlConnection2 = $"{nameof(ConnectionStrings)}:{nameof(SqlConnection2)}";
        }
    }
}