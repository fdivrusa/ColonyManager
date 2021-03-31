﻿namespace ColonyManager.Data.Entities
{
    public class PeopleAddress : BaseEntity
    {
        public int PeopleId { get; set; }
        public int ConfigGenericTypeGroupId { get; set; }
        public int ConfigGenericTypeId { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public int? Box { get; set; }
        public int Number { get; set; }
        public int CountryId { get; set; }

        public virtual People People { get; set; }
        public virtual Country Country { get; set; }
        public virtual ConfigGenericItem Type { get; set; }
    }
}
