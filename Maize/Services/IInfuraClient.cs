namespace Maize.Services
{
    public interface IInfuraClient
    {
        Task<PinAddResponse> PinAdd();
        Task<PinAddResponse> PinView();
        Task<FileAddResponse> FileAdd(string filePath);
    }
}
