﻿namespace AzureStorage.Core.Commands
{
    public class ProductCreateCommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
