namespace NatijaUz.Application.Auth.Services.RegisterService.Interfaces
{
    public interface ICacheService
    {
        protected Task SetAsync<T>(string key, T value, TimeSpan expiry);
        protected Task<T?> GetAsync<T>(string key);
        protected Task RemoveAsync(string key);
    }
}
