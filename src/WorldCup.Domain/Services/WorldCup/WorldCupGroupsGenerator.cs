using WorldCup.Domain.AggregateModels.Groups;
using WorldCup.Domain.AggregateModels.Teams;
using WorldCup.Domain.Enumerations;
using WorldCup.Domain.Exceptions;
using WorldCup.Domain.ValueObjects;

namespace WorldCup.Domain.Services.WorldCup
{
    public class WorldCupGroupsGenerator
    {
        private readonly Random _random = new Random();

        public FootballCup GenerateGroups(FootballTeam[] teams, CupGroupCount groups, int year, PersonalName drawer)
        {
            var allGroups = GenerateGroups(teams, groups);

            var cup = new FootballCup(year, groups, drawer);

            foreach (var entry in allGroups)
            {
                entry.Value.ForEach(t => cup.AddTeam(t, entry.Key));

            }

            return cup;
        }

        private Dictionary<FootballGroups, List<FootballTeam>> GenerateGroups(FootballTeam[] teams, CupGroupCount groups)
        {
            var allGroups = groups
                .GetGroups()
                .ToDictionary(k => k, _ => new List<FootballTeam>((int)groups));

            var teamsLeft = teams.ToList();

            while(teamsLeft.Count > 0 )
            {
                foreach (var group in allGroups.Keys)
                {
                    var currentTeam = allGroups[group];
                    var countries = currentTeam.Select(g => g.CountryId);
                    var applicants = teamsLeft.Where(t => !countries.Contains(t.CountryId)).ToArray();

                    if(applicants.Length == 0 )
                    {
                        throw new UnbalancedTeamListException();
                    }

                    var selected = _random.OneOf(applicants);

                    currentTeam.Add(selected);
                    teamsLeft.Remove(selected);
                }
            }

            return allGroups;
        }
    }
}
