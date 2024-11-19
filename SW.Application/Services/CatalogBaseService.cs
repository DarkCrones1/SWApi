using SW.Common.Entities;
using SW.Common.Interfaces.Entities;
using SW.Common.Interfaces.Repositories;
using SW.Common.Interfaces.Services;
using SW.Domain.Entities;
using SW.Domain.Interfaces;

namespace SW.Application.Services;

public class CatalogBaseService<T> : CrudService<T>, ICatalogBaseService<T> where T : CatalogBaseEntity
{
    protected new ICatalogBaseRepository<T> _repository;
    public CatalogBaseService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        this._repository = GetRepository();
    }

    protected override ICatalogBaseRepository<T> GetRepository()
    {
        var typeRep = typeof(T);

        return (ICatalogBaseRepository<T>)this._unitOfWork.UserCommendRepository;
    }
}