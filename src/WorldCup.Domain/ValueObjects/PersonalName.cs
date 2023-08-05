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
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));

            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentException(nameof(surname));

            Name = name;
            Surname = surname;
        }
        #endregion

        public string FullName() => $"{Name} {Surname}";

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Name;
            yield return Surname;
        }
    }
}
