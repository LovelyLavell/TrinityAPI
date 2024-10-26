using Microsoft.AspNetCore.Mvc;
using TrinityAPI.DTO;
using TrinityAPI.DTO.Game;
using TrinityAPI.Models.Game;
using TrinityAPI.Services;

namespace TrinityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GameController : ControllerBase
    {
        private readonly ServiceGameDatabase gameDatabase;
        public GameController(ServiceGameDatabase database) { 
            gameDatabase = database;
        }
        [HttpPost(Name = "AddItem")]
        public void AddItem(DTOItem item)
        {
            gameDatabase.AddItem(item);
        }
        [HttpGet(Name = "GetItems")]
        public IEnumerable<Item> GetItem(int? i, string? name, string? desc)
        {
            return gameDatabase.GetItem(new DTORequest() { 
            ID = i ?? 0,
            Label = name,
            description = desc});
        }
        [HttpGet(Name = "GetAllItems")]
        public IEnumerable<Item> GetItems()
        {
            return gameDatabase.GetItems();
        }
    }
}
