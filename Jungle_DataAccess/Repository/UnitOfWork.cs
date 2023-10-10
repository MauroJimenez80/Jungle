using Jungle_DataAccess.Data;
using Jungle_DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly JungleDbContext _db;
        public UnitOfWork(JungleDbContext db)
        {
            _db = db;

            Country = new CountryRepositoryAsync(_db);
            Destination = new DestinationRepositoryAsync(_db);
            Guide = new GuideRepositoryAsync(_db);
            TravelRecommendation = new TravelRecommendationRepositoryAsync(_db);
            Travel = new TravelRepositoryAsync(_db);
        }

        public ICountryRepositoryAsync Country { get; private set; }
        public IDestinationRepositoryAsync Destination { get; private set; }
        public IGuideRepositoryAsync Guide { get; private set; }
        public ITravelRecommendationRepositoryAsync TravelRecommendation { get; private set; }
        public ITravelRepositoryAsync Travel { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
