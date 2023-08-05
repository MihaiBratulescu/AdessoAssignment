using Microsoft.AspNetCore.Mvc;
using WorldCup.Application.WorldCup.Commands;
using WorldCup.Presentation.Web.Controllers;

namespace WorldCup.Presentation.Web.Areas.WorldCup
{
    [Route("api/WorldCup")]
    public class WorldCupAPIController : BaseController
    {
        public WorldCupAPIController(IHandler handler) : base(handler)
        {
        }

        [HttpPut("create-cup")]
        public Task RegisterTeams(RegisterTeamsCommand command)
        {
            return handler.SendAsync(command);
        }

        [HttpGet("cup/{year}")]
        public Task GetCup([FromRoute] int year)
        {
            return Task.CompletedTask;
        }

    }
}
