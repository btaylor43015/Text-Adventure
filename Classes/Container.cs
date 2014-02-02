using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventure.Classes
{
    public class Container
    {
        private string _key;
        private string _description;
        private Dictionary<string,ContainerItem> _items;

        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public Dictionary<string,ContainerItem> CItems
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        
        public Container(string key, string description)
        {
            _key = key;
            _description = description;
            _items = new Dictionary<string,ContainerItem>();

        }

    }
}
