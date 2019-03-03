using System; //Library used to access system related classes and methods
using System.Collections.Generic; //Accesses Collection datatypes

namespace WebApplication2
{ 
    /*
     Creates class used for the shopping cart function of the website.
     It is serializable as well meaning that the data can be changed to some other format.
     */
    [Serializable]
    public class ShoppingCart
    {
        //Creates Dictionaries for storing the food items of the menu and the options used to customize the options
        Dictionary<int, string> Items = new Dictionary<int, string>();
        Dictionary<int, string> Options = new Dictionary<int, string>();

        //Creates id for item and options used as keys in the dictionary
        public int itemId { get; set; }

        //Adds the string as items and options to the corresponding dictionaries based 
        public void AddToCart(string item)
        {
            itemId++;
            Items.Add(itemId, item);
            Options.Add(itemId, "");
          
            
        }
        //Removes the item with the given id.
        //It returns a boolean to determine if the item exists or not
        public bool RemoveFromCart(int id)
        {

           itemId--;
           bool test_case = Items.Remove(id);
           Options.Remove(id);


           //Used to adjust the key values of the items and options if the items and options have higher key values
           if(Items.ContainsKey(id+1))
            {
                int temp_id = id + 1;
                while (Items.ContainsKey(temp_id))
                {
                    Items.Add(temp_id - 1, Items[temp_id]);
                    Items.Remove(temp_id);

                    Options.Add(temp_id - 1, Options[temp_id]);
                    Options.Remove(temp_id);
                    temp_id++;
                }
            }
           
           return test_case;
        }
        //Changes the options to the options string with the corresponding item id
        public void AlterOptions(int id, string options)
        {
            Options[id] = options;
        }
        //Returns the items dictionary
        public Dictionary<int, string> getItems()
        {
            return Items;
        }
        //Returns the options dictionary
        public Dictionary<int, string> getOptions()
        {
            return Options;
        }

    }
}