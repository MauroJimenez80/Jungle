using Jungle_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Data
{
    public static class ModelBuilderDataGenerator
    {
        public static void GenerateData(this ModelBuilder builder)
        {
            #region Données pour Country
            //builder.Entity<Country>().HasData(new Country() { Id = 1, Name = "Brazil" });
            #endregion

            #region Données pour Destination
            //builder.Entity<Destination>().HasData(new Destination() { Id = 1, Name = "Rio de Janeiro", Region="Rio Grande" });
            #endregion

            #region Données pour Guide
            //builder.Entity<Guide>().HasData(new Guide() { Id = 1, FirstName = "Pedro", LastName = "John", Speciality = "Escalade" });
            #endregion

            #region Données pour Travel

            #endregion

            #region Données pour TravelRecommendation

            #endregion
        }
    }
}
