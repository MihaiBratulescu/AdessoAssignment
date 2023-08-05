﻿using WorldCup.Domain.Enumerations;
using WorldCup.Domain.ValueObjects;

namespace WorldCup.Domain.AggregateModels.Groups
{
    public class FootballCup : AggregateRoot<int>
    {
        public int Year { get; }
        public CupGroupCount GroupCount { get; }
        public PersonalName Drawer { get; }

        #region Constructors
#pragma warning disable CS8618
        private FootballCup() { }
#pragma warning restore CS8618
        public FootballCup(int year, CupGroupCount groups, PersonalName drawer)
        {
            Year = year;
            Drawer = drawer;
            GroupCount = groups;
        }
        #endregion
    }
}