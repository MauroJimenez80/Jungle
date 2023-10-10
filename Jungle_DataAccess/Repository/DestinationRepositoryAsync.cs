using Jungle_DataAccess.Data;
using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository
{
    public class DestinationRepositoryAsync : RepositoryAsync<Destination>, IDestinationRepositoryAsync
    {
        private readonly JungleDbContext _db;

        public DestinationRepositoryAsync(JungleDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Destination destination)
        {
            _db.Update(destination);
        }
    }
}
