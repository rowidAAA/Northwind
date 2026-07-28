using Northwind.DAL.Models;
using Northwind.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Northwind.BLL
{
    public class TerritoryService
    {
        public List<Territory> GetAllTerritories(Territory territory)
        {
            using (var db = new NorthwindContext())
            {
                var territories = db.Territories.Include(t => t.Region).ToList();
                foreach (var t in territories)
                {
                    t.TerritoryDescription = t.TerritoryDescription?.Trim();
                }
                return territories;
            }
        }

        public Territory GetTerritoryByID(string id)
        {
            using (var db = new NorthwindContext())
            {
                var territory = db.Territories.Include(t => t.Region).FirstOrDefault(t => t.TerritoryID == id);
                if (territory != null)
                {
                    territory.TerritoryDescription = territory.TerritoryDescription?.Trim();
                }
                return territory;
            }
        }

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

        public void CreateTerritory(Territory territory)
        {
            territory.TerritoryDescription = territory.TerritoryDescription?.Trim();
            using (var db =new NorthwindContext())
            {
                db.Territories.Add(territory);
                db.SaveChanges();
            }
        }

        public void UpdateTerritory(Territory territory)
        {
            territory.TerritoryDescription = territory.TerritoryDescription?.Trim();
            using (var db = new NorthwindContext())
            {
                db.Entry(territory).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteTerritory(string id)
        {
            using (var db = new NorthwindContext())
            {
                var territory = db.Territories.Find(id);
                if (territory != null)
                {
                    db.Territories.Remove(territory);
                    db.SaveChanges();
                }
            }
        }
    }
}
