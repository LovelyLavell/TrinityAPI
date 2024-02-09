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
        public Item GetItem(DTORequest request)
        {
            ContextGame db = factory.CreateDbContext();
            return db.Items.Where(i => i.ID == request.ID || i.Name.Contains(request.Label) || i.Description.Contains(request.description)).FirstOrDefault();
        }
        public IEnumerable<Item> GetItems()
        {
            ContextGame db = factory.CreateDbContext();
            return db.Items;
        }
    }
}
