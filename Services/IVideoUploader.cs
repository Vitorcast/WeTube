using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WeTube.Services
{
    public interface IVideoUploader
    {
        Task DeleteUploadedImage(long id);
        Task<string> Upload(IFormFile file, long id);
    }
}