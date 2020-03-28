using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ElasticSearch.Helper
{
    public class FileManager
    {
        public static bool Delete(string FileName, string folder)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/" + folder, FileName);
            var pathThumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/" + folder + "/thumbs", FileName);

            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            if (File.Exists(pathThumb))
            {
                File.Delete(pathThumb);
                return true;
            }
            return false;
        }

        public static void FileSave(string filename, IFormFile file, string Folder)
        {
            var stream = file.OpenReadStream();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/" + Folder, filename.Replace(' ', '-'));

            FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.CopyTo(filestream);
        }

        public static string IFormSave(IFormFile file, string folder)
        {
            string filename = Guid.NewGuid().ToString();

            var stream = file.OpenReadStream();
            var path = Path.Combine(Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/uploads/" + folder, filename));

            FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.CopyTo(filestream);


            filestream.Close();
            return path;
        }
    }
}
