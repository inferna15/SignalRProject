﻿namespace SignalR.DtoLayer.ProductDto
{
    public class GetProductDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public int CategoryID { get; set; }
    }
}
