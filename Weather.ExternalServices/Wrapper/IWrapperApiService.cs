namespace Weather.ExternalServices.Wrapper
{
    public interface IWrapperApiService
    {
        Task<T> GetAsync<T>(string wrapperApi, string url);
    }
}
