using Microsoft.AspNetCore.Mvc;
using TrinityAPI.DTO.Game;
using TrinityAPI.Models.Game;
using TrinityAPI.Services;

namespace TrinityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ServiceGameDatabase gameDatabase;
        public GameController(ServiceGameDatabase database) { 
            gameDatabase = database;
        }
        [HttpPost(Name = "AddItem")]
        public void GetItem(DTOItem item)
        {
            gameDatabase.AddItem(item);
        }
    }
}
