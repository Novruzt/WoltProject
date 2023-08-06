namespace Wolt.BLL.Services.Abstract
{
    public interface IThingsService
    {
        Task<bool> GetUserCommentAsync(int UserId, int RestId);
        Task<bool> GetUserAsync(string email);
        Task<bool> LoginUserAsync(string email, string password);
        Task<bool> GetUserByToken(string token);
    }
}
