using Microsoft.Extensions.Configuration;

using SW.Common.Interfaces.Repositories;
using SW.Domain.Entities;
using SW.Domain.Interfaces;
// using SW.Domain.Interfaces.Repositories;
using SW.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace SW.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly SWDbContext _dbContext;

    private readonly IConfiguration _configuration;

    private readonly IWebHostEnvironment _env;

    private readonly IHttpContextAccessor _httpContextAccessor;

    protected ICrudRepository<DataDream> _dataDreamRepository;

    protected ICrudRepository<UserAccount> _userAccountRepository;

    protected ICatalogBaseRepository<UserCommend> _userCommendRepository;

    protected ICrudRepository<UserData> _userDataRepository;

    protected ICrudRepository<UserDataCommend> _userDataCommendRepository;

    protected IRetrieveRepository<ActiveUserAccount> _activeUserAccountRepository;

    protected IAzureBlobStorageRepository _azureBlobStorageRepository;

    protected ILocalStorageRepository _localStorageRepository;

    private bool disposed;

    public UnitOfWork(SWDbContext dbContext, IConfiguration configuration, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;

        this._configuration = configuration;

        this._env = env;

        this._httpContextAccessor = httpContextAccessor;

        disposed = false;

        _dataDreamRepository = new CrudRepository<DataDream>(_dbContext);

        _userAccountRepository = new CrudRepository<UserAccount>(_dbContext);

        _userCommendRepository = new CatalogBaseRepository<UserCommend>(_dbContext);
        
        _userDataRepository = new CrudRepository<UserData>(_dbContext);

        _userDataCommendRepository = new CrudRepository<UserDataCommend>(_dbContext);

        _activeUserAccountRepository = new RetrieveRepository<ActiveUserAccount>(_dbContext);

        _azureBlobStorageRepository = new AzureBlobStorageRepository(_configuration);

        _localStorageRepository = new LocalStorageRepository(_configuration, _env, _httpContextAccessor);
    }

    public ICrudRepository<DataDream> DataDreamRepository => _dataDreamRepository;

    public ICrudRepository<UserAccount> UserAccountRepository => _userAccountRepository;

    public ICatalogBaseRepository<UserCommend> UserCommendRepository => _userCommendRepository;

    public ICrudRepository<UserData> UserDataRepository => _userDataRepository;

    public ICrudRepository<UserDataCommend> UserDataCommendRepository => _userDataCommendRepository;

    public IRetrieveRepository<ActiveUserAccount> ActiveUserAccountRepository => _activeUserAccountRepository;

    public IAzureBlobStorageRepository AzureBlobStorageRepository => _azureBlobStorageRepository;

    public ILocalStorageRepository LocalStorageRepository => _localStorageRepository;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
            if (disposing)
                _dbContext.Dispose();

        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}