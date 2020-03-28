namespace Core.Services.Rest
{
    public interface ICloudinaryService
    {
        string Store(string file);
        string BuildUrl(string publicId, string crop = "fill", int width = 150, int height = 150);
        void Delete(string publicId);
    } 
}