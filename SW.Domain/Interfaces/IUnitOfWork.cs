using SW.Common.Interfaces.Repositories;
using SW.Domain.Entities;

namespace SW.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICrudRepository<DataDream> DataDreamRepository { get; }

    ICrudRepository<UserAccount> UserAccountRepository { get; }

    ICatalogBaseRepository<UserCommend> UserCommendRepository { get; }

    ICrudRepository<UserData> UserDataRepository { get; }

    ICrudRepository<UserDataCommend> UserDataCommendRepository { get; }

    IRetrieveRepository<ActiveUserAccount> ActiveUserAccountRepository { get; }

    IAzureBlobStorageRepository AzureBlobStorageRepository { get; }

    ILocalStorageRepository LocalStorageRepository { get; }

    void SaveChanges();

    Task SaveChangesAsync();
}