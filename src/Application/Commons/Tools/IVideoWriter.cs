using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Commons.Tools
{
    public interface IVideoWriter
    {
        Task<string> SaveFileAsync(IFormFile file);
    }
}
