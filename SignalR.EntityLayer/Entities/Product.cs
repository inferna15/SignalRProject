﻿namespace SignalR.EntityLayer.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }

        // Navigation properties
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
