namespace BlogApp.Areas.Admin.Services
{
    public interface IFileUploadService
    {
       Task<string> UploadFile(IFormFile file);
        void DeleteFile(string path);
    }
}
