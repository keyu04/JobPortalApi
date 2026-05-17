namespace JobPortalAPI.Common.Setting;

public static class AppSetting
{
    public static string? JwtSecreteKey { set; get; }
    public static string? JwtIssuer { set; get; }
    public static string? JwtAudience { set; get; }
}

// public static class DbSetting
// {
//     public static string? ConnectionString { set; get; }
// }