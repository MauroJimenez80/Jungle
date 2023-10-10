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
    public class GuideRepositoryAsync : RepositoryAsync<Guide>, IGuideRepositoryAsync
    {
        private readonly JungleDbContext _db;

        public GuideRepositoryAsync(JungleDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Guide guide)
        {
            _db.Update(guide);
        }
    }
}
