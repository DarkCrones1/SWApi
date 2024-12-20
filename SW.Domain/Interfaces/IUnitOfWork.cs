using SW.Common.Interfaces.Repositories;
using SW.Domain.Entities;
using SW.Domain.Interfaces.Repositories;

namespace SW.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IDataDreamRepository DataDreamRepository { get; }

    IUserAccountRepository UserAccountRepository { get; }

    IUserCommendRepository UserCommendRepository { get; }

    IUserDataRepository UserDataRepository { get; }

    ICrudRepository<UserDataCommend> UserDataCommendRepository { get; }

    IRetrieveRepository<ActiveUserAccount> ActiveUserAccountRepository { get; }

    IAzureBlobStorageRepository AzureBlobStorageRepository { get; }

    ILocalStorageRepository LocalStorageRepository { get; }

    void SaveChanges();

    Task SaveChangesAsync();
}