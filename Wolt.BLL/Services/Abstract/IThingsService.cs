namespace Wolt.BLL.Services.Abstract
{
    public interface IThingsService
    {
        Task<bool> CheckUserCommentForRestaurantAsync(int UserId, int RestId);
        Task<bool> CheckUserForEmailAsync(string email);
        Task<bool> CheckLoginUserAsync(string email, string password);
        Task<bool> CheckUserByToken(string token);
    }
}
