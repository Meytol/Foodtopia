namespace Authentication.Common
{
    public enum AuthorizeLevel
    {
        AllowAnanymos,
        LogedIn,
        NeedAuthorize, // Default
        AuthorizeWithRole
    }
}