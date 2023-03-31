using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class ShoppingCart<T> where T : new()
    {
        private List<T> _items;

        public ShoppingCart()
        {
            _items = new List<T>();
        }

        public void AddItem(T item)
        {
            _items.Add(item);
        }

        public int GetTotalItemCount()
        {
            return _items.Count;
        }
    }
}
