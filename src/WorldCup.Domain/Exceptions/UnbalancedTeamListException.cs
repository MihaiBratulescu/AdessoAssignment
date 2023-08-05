namespace WorldCup.Domain.Exceptions
{
    public class UnbalancedTeamListException : DomainException
    {
        public UnbalancedTeamListException()
            : base("Could not split teams to avoid country duplication.")
        {

        }
    }
}
