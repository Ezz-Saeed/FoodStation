﻿namespace FoodCorner.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item>? Items { get; set; }
    }
}