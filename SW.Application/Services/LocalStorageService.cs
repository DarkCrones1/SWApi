using SW.Common.Enumerations;
using SW.Common.Interfaces.Services;
using SW.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace SW.Application.Services;

public class LocalStorageService : ILocalStorageService
{
    private readonly IUnitOfWork _unitOfWork;

    public LocalStorageService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task DeteleAsync(LocalContainer container, string route)
    {
        await _unitOfWork.LocalStorageRepository.DeteleAsync(container, route);
    }

    public async Task<string> EditFileAsync(IFormFile file, LocalContainer container, string route)
    {
        return await _unitOfWork.LocalStorageRepository.EditFileAsync(file, container, route);
    }

    public async Task<string> UploadAsync(IFormFile file, LocalContainer container, string route)
    {
        return await _unitOfWork.LocalStorageRepository.UploadAsync(file, container, route);
    }
}