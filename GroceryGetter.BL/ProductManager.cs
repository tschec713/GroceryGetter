﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryGetter.BL.Models;
using GroceryGetter.PL;

namespace GroceryGetter.BL
{
    public class ProductManager
    {
        public static List<Product> LoadAll()
        {
            using (GroceryGetterEntities dc = new GroceryGetterEntities())
            {
                List<Product> products = new List<Product>();
                dc.tblProducts.ToList().ForEach(p => products.Add(new Product
                {
                    Id = p.Id,
                    Title = p.Title
                }));

                return products;

            }
            
        }
        public static List<Product> LoadByAisleId(Guid aisleId)
        {
            List<Product> products = new List<Product>();
            using (GroceryGetterEntities dc = new GroceryGetterEntities())
            {
                    
                var results = (from ap in dc.tblAisleProducts
                                join p in dc.tblProducts on ap.ProductId equals p.Id
                                join a in dc.tblAisles on ap.AisleId equals a.Id
                                where ap.AisleId == aisleId
                                select new
                                {
                                    Id = p.Id,
                                    Title = p.Title
                                }).ToList();



                results.ForEach(p => products.Add(new Product
                {
                    Id = p.Id,
                    Title = p.Title,
                }));
            }
            return products;
          
        }
    }
}
