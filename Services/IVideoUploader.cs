using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static WeTube.Services.VideoUploader;

namespace WeTube.Services
{
    public interface IVideoUploader
    {
        Task Delete(long id);
        Task<MediaLinks> Upload(IFormFile file, long id);
    }
}