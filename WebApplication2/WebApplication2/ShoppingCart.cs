using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    [Serializable]
    public class ShoppingCart
    {

        Dictionary<int, string> Items = new Dictionary<int, string>();

        Dictionary<int, string> Options = new Dictionary<int, string>();

        public int itemId { get; set; }

        public int OrderId { get; set; }

        public void AddToCart(string item)
        {
            itemId++;
            Items.Add(itemId, item);
            Options.Add(itemId, "");
          
            
        }

        public bool RemoveFromCart(int id)
        {

           bool test_case = Items.Remove(id);
           Options.Remove(id);
           
           return test_case;
        }

        public void AlterOptions(int id, string options)
        {
            Options[id] = options;
        }

        public Dictionary<int, string> getItems()
        {
            return Items;
        }

        public Dictionary<int, string> getOptions()
        {
            return Options;
        }

    }
}