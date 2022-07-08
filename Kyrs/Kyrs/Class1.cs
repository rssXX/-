using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kyrs
{
    public class Class1 : DbContext
    {
        public DbSet<ContractTabl> contract { get; set; }
        public DbSet<ClientTabl> client { get; set; }
        public DbSet<PassTabl> pass { get; set; }
        public DbSet<TourTabl> tour { get; set; }
        public DbSet<CityTabl> city { get; set; }
        public DbSet<HotelTabl> hotel { get; set; }
        public DbSet<WorkersTabl> workers { get; set; }
        public Class1()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;port=3307;user=root;password=root;database=test_v_8;");
        }

        public static List<ContractTabl> ShowGridTeach1()
        {
            using(Class1 db = new Class1())
            {
                List<ContractTabl> t = new List<ContractTabl>();
                t = db.contract.ToList();
                return t;
            }
        }
        public static List<ClientTabl> ShowGridTeach2()
        {
            using (Class1 db = new Class1())
            {
                List<ClientTabl> t = new List<ClientTabl>();
                t = db.client.ToList();
                return t;
            }
        }
        public static List<PassTabl> ShowGridTeach3()
        {
            using (Class1 db = new Class1())
            {
                List<PassTabl> t = new List<PassTabl>();
                t = db.pass.ToList();
                return t;
            }
        }
        public static List<TourTabl> ShowGridTeach4()
        {
            using (Class1 db = new Class1())
            {
                List<TourTabl> t = new List<TourTabl>();
                t = db.tour.ToList();
                return t;
            }
        }
        public static List<CityTabl> ShowGridTeach5()
        {
            using (Class1 db = new Class1())
            {
                List<CityTabl> t = new List<CityTabl>();
                t = db.city.ToList();
                return t;
            }
        }
        public static List<HotelTabl> ShowGridTeach6()
        {
            using (Class1 db = new Class1())
            {
                List<HotelTabl> t = new List<HotelTabl>();
                t = db.hotel.ToList();
                return t;
            }
        }
        public static List<WorkersTabl> ShowGridTeach7()
        {
            using (Class1 db = new Class1())
            {
                List<WorkersTabl> t = new List<WorkersTabl>();
                t = db.workers.ToList();
                return t;
            }
        }
    }
}
