using WorldCup.Application.Interfaces.Repositories;
using WorldCup.Application.Interfaces.Repositories.WorldCup;
using WorldCup.Domain.Enumerations;
using WorldCup.Domain.Services.WorldCup;
using WorldCup.Domain.ValueObjects;

namespace WorldCup.Application.WorldCup.Commands
{
    public class RegisterTeamsCommand : ICommand
    {
        public PersonalName? Drawer { get; set; }
        public CupGroupCount Groups { get; set; }
        public int Year { get; set; }
    }

    public class RegisterTeamsCommandHandler : ICommandHandler<RegisterTeamsCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWorldCupRepository worldCups;

        public RegisterTeamsCommandHandler(IUnitOfWork unitOfWork, IWorldCupRepository cup)
        {
            this.worldCups = cup;
            this.unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(RegisterTeamsCommand command)
        {
            if (command.Drawer is null)
                throw new ArgumentNullException(nameof(command.Drawer));

            if (!Enum.IsDefined(command.Groups))
                throw new ArgumentOutOfRangeException(nameof(command.Groups));

            var cupTeams = await this.worldCups.GetWorldCupTeamsAsync();

            var cup = new WorldCupGroupsGenerator()
                .GenerateGroups(cupTeams, command.Groups, command.Year, command.Drawer);

            await worldCups.AddAsync(cup);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
