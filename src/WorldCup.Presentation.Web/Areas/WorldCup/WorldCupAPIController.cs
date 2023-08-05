﻿using Microsoft.AspNetCore.Mvc;
using WorldCup.Application.WorldCup.Commands;
using WorldCup.Application.WorldCup.Queries;
using WorldCup.Domain.AggregateModels.Groups;
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
        public async Task<FootballCup?> GetCup([FromRoute] int year)
        {
            var res = await handler.SendAsync(new GetWorldCupQuery { Year = year });

            return res;
        }

    }
}
