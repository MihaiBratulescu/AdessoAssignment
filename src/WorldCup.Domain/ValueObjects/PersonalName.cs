namespace WorldCup.Domain.ValueObjects
{
    public class PersonalName : ValueObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        #region Constructors
#pragma warning disable CS8618
        private PersonalName() { }
#pragma warning restore CS8618
        public PersonalName(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        #endregion

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Name;
            yield return Surname;
        }
    }
}
