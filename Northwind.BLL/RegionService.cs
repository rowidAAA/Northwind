using Northwind.DAL;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Northwind.BLL
{
    public class RegionService
    {
        public List<Region> GetAllRegions()
        {
            using (var db = new NorthwindContext())
            {
                return db.Regions.ToList();
            }
        }

        public Region GetRegionByID(int id)
        {
            using (var db = new NorthwindContext())
            {
                return db.Regions.Find(id);
            }
        }

        public void CreateRegion(Region region)
        {
            using (var db = new NorthwindContext())
            {
                db.Regions.Add(region);
                db.SaveChanges();
            }
        }

        public void DeleteRegion(int id)
        {
            using (var db = new NorthwindContext())
            {
                var region = db.Regions.Find(id);
                if (region != null)
                {
                    db.Regions.Remove(region);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateRegion(Region region)
        {
            using (var db = new NorthwindContext())
            {
                db.Entry(region).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
