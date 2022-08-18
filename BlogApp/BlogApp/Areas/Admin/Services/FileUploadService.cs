namespace BlogApp.Areas.Admin.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment host;

        public FileUploadService(IWebHostEnvironment host)
        {
            this.host = host;
        }
        public void DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);


        }

        public async Task<string> UploadFile(IFormFile file)
        {
            
             if(file.Length > 0)
            {
                var extension=file.FileName.Substring(file.FileName.LastIndexOf('.') + 1);
                var returnValue= "~"+"\\content"+ Guid.NewGuid().ToString()+'.'+extension;
                var filePath = Path.Combine(host.WebRootPath + "\\content" + Guid.NewGuid().ToString()) + '.' + extension;
                using (var stream = System.IO.File.Create(filePath))
                    await file.CopyToAsync(stream);

                return returnValue;
            }
            return null;
        }
    }
}
