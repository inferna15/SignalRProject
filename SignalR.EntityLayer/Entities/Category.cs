﻿namespace SignalR.EntityLayer.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        // Navigation properties
        public ICollection<Product> Products { get; set; }
    }
}
