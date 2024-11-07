using BaseBackend.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseBackend.Entities
{
    public class ProductCategory: IBaseEntity
    {
        private static int nextId = 1;
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ProductCategory(string categoryName)
        {
            Id = nextId++;
            CategoryName = categoryName;
        }
    }
}
