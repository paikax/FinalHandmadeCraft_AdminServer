namespace HandMadeCraftAdminServer.Services
{
    public interface IAuthenticationStatus
    {
        bool IsAuthenticated { get; set; }
    }
}