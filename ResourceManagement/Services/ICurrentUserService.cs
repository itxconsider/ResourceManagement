namespace ResourceManagement.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}
