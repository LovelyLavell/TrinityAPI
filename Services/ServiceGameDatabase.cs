using Microsoft.EntityFrameworkCore;
using TrinityAPI.Database.Context;
using TrinityAPI.DTO;
using TrinityAPI.DTO.Game;
using TrinityAPI.Interfaces;
using TrinityAPI.Models.Game;

namespace TrinityAPI.Services
{
    public class ServiceGameDatabase : IDatabaseService
    {
        private readonly IDbContextFactory<ContextGame> factory;
        public ServiceGameDatabase(IDbContextFactory<ContextGame> factory) { 
            this.factory = factory;
        }
        public Item AddItem(DTOItem item)
        {
            var db = factory.CreateDbContext();
            var baseItem = new Item()
            {
                SID = item.SID,
                Name = item.Name,
                Description = item.Description,
                //type = item.type,
                Group = item.Group
            };
            db.Add(baseItem);
            db.SaveChanges();
            return baseItem;
        }
        public IEnumerable<Item> GetItem(DTORequest request)
        {
            ContextGame db = factory.CreateDbContext();
            if (db.Items is null)
                return new List<Item>();
            return db.Items.Where(
            i => i.ID == request.ID || 
            (!string.IsNullOrEmpty(i.Name) && !string.IsNullOrEmpty(request.Label) && i.Name.Contains(request.Label) || 
            (!string.IsNullOrEmpty(i.Description) && !string.IsNullOrEmpty(request.description) && i.Description.Contains(request.description))));
        }
        public IEnumerable<Item> GetItems()
        {
            ContextGame db = factory.CreateDbContext();
            if (db.Items is null)
                throw new Exception("Database issue Detected");
            return db.Items;
        }
    }
}
