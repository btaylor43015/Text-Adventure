using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAdventure.Classes
{
    public class Player
    {

        private string _name;
        private PlayerStates _state;
        private List<string> _inventory;
        private string _searching;

        public List<string> getInventory()
        {
            return _inventory;
        }
        public Boolean addToInventory(string item)
        {
            Boolean ret = false;

           
            _inventory.Add(item);
            ret = true;

          
            return ret;
        }
        public Boolean removeFromInventory(string item)
        {
            Boolean ret = false;

            if (_inventory.Contains(item))
            {
                _inventory.Remove(item);
                ret = true;
            }
            return ret;

        }
        public string Searching
        {
            get
            {
                return _searching;
            }
            set
            {
                _searching = value;
            }
        }

       public enum PlayerStates
        {
            Active,
            Sleeping
        }


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public PlayerStates State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }
        public Player()
        {
            _inventory = new List<string>();

        }

    }
}
