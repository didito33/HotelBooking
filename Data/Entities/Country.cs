﻿namespace HotelBooking.Data.Entities
#nullable disable
{
    public class Country
    {
        public Country()
        {
            Cities = new List<City>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public List<City> Cities { get; set; }
    }
}
