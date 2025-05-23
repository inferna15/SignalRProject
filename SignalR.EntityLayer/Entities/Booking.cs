﻿namespace SignalR.EntityLayer.Entities
{
    public class Booking
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
