using SailPoint.DataAccess.Models;

namespace SailPoint.DataAccess.Repository;


public class CityRepository : RepositoryBase<CityDetails>
{
    private readonly ILogger<CityRepository> _logger;

    public CityRepository(ILogger<CityRepository> logger)
    {
        _logger = logger;
    }

    public override CityDetails Get(Predicate<CityDetails> selector)
    {
        return base.Get(selector);
    }
}
