using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using nsCode1st.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nsCode1st.Data
{
    public class SampleData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // Look for any provinces.
                if (context.Provinces.Any())
                {
                    return; // DB has already been seeded
                }

                var provinces = GetProvinces().ToArray();
                context.Provinces.AddRange(provinces);
                context.SaveChanges();

                var cities = GetCities(context).ToArray();
                context.Cities.AddRange(cities);
                context.SaveChanges();
            }
        }

        public static List<Province> GetProvinces()
        {
            List<Province> provinces = new List<Province>() {

                new Province() {
                    ProvinceCode ="BC",
                    ProvinceName="British Columbia",
                },
                new Province() {
                    ProvinceCode ="AB",
                    ProvinceName="Alberta",
                },
                new Province() {
                    ProvinceCode ="MA",
                    ProvinceName="Manitoba",
                },
            };
            return provinces;
        }

        public static List<City> GetCities(ApplicationDbContext context)
        {
            List<City> cities = new List<City>() {
                new City {
                    CityName = "Surrey",
                    Population = 300000,
                    ProvinceCode = context.Provinces.Find("BC").ProvinceCode
                },
                new City {
                    CityName = "Victoria",
                    Population = 92141,
                    ProvinceCode = context.Provinces.Find("BC").ProvinceCode
                },
                new City {
                    CityName = "Calgary",
                    Population = 1000000,
                    ProvinceCode = context.Provinces.Find("AB").ProvinceCode
                },
            };
            return cities;
        }
    }
}
