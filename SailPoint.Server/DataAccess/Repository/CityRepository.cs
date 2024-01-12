using SailPoint.DataAccess.Models;

namespace SailPoint.DataAccess.Repository;

public interface ICityRepository : IRepositoryBase<CityDetailDb>
{

}

public class CityRepository : RepositoryBase<CityDetailDb>, ICityRepository
{
    private readonly ILogger<CityRepository> _logger;

    public CityRepository(ILogger<CityRepository> logger)
    {
        _logger = logger;
    }

    public override CityDetailDb Get(Predicate<CityDetailDb> selector)
    {
        return base.Get(selector);
    }
}
