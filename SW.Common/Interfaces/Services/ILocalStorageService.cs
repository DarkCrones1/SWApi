using SW.Common.Enumerations;
using Microsoft.AspNetCore.Http;

namespace SW.Common.Interfaces.Services;

public interface ILocalStorageService
{
    Task DeteleAsync(LocalContainer container, string route);
    Task<string> EditFileAsync(IFormFile file, LocalContainer container, string route);
    Task<string> UploadAsync(IFormFile file, LocalContainer container, string route);
}