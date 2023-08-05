using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Application.Interfaces.Repositories.WorldCup;
using WorldCup.Domain.AggregateModels.Groups;

namespace WorldCup.Application.WorldCup.Queries
{
    public class GetWorldCupQuery : IQuery<FootballCup?>
    {
        public int Year { get; set; }
    }

    public class GetWorldCupQueryHandler : IQueryHandler<GetWorldCupQuery, FootballCup?>
    {
        private readonly IWorldCupRepository worldCup;

        public GetWorldCupQueryHandler(IWorldCupRepository worldCup)
        {
            this.worldCup = worldCup;
        }

        public Task<FootballCup?> HandleAsync(GetWorldCupQuery query)
        {
            return worldCup.GetByYearAsync(query.Year);
        }
    }
}
