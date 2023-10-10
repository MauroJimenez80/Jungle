using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICountryRepositoryAsync Country { get; }
        IDestinationRepositoryAsync Destination { get; }
        IGuideRepositoryAsync Guide { get; }
        ITravelRecommendationRepositoryAsync TravelRecommendation { get; }
        ITravelRepositoryAsync Travel { get; }

        void Save();
    }
}
