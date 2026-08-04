using Northwind.DAL;
using Northwind.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Northwind.BLL
{
    public class RegionInUseException : Exception
    {
        public RegionInUseException(string message) : base(message) { }
    }

    public class RegionService
    {
        public List<Region> GetAllRegions()
        {
            using (var db = new NorthwindContext())
            {
                var regions = db.Regions.ToList();
                foreach (var r in regions)
                {
                    r.RegionDescription = r.RegionDescription?.Trim();
                }
                return regions;
            }
        }
        public Region GetRegionByID(int id)
        {
            using (var db = new NorthwindContext())
            {
                var region = db.Regions.Find(id);
                if (region != null)
                {
                    region.RegionDescription = region.RegionDescription?.Trim();
                }
                return region;
            }
        }
        public void CreateRegion(Region region)
        {
            region.RegionDescription = region.RegionDescription?.Trim();
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
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateException ex)
                    {
                        var sqlEx = ex.InnerException?.InnerException as SqlException;
                        if (sqlEx != null && sqlEx.Number == 547) 
                        {
                            throw new RegionInUseException(
                                "This region can't be deleted because one or more territories are still assigned to it. Reassign or delete those territories first.");
                        }
                        throw; 
                    }
                }
            }
        }
        public void UpdateRegion(Region region)
        {
            region.RegionDescription = region.RegionDescription?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Entry(region).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}