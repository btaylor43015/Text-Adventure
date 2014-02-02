using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextAdventure.Classes;

namespace TextAdventure
{
    

   public class Scene : ICloneable
    {
        private string _title;
        private string _description;
        private Scene _east;
        private Scene _west;
        private Scene _north;
        private Scene _south;
        private Scene _up;
        private Scene _down;
        private Boolean _serialized;
        private int _pathCount;
        private int _maxCount;
        private Dictionary<string, Boolean> _directionAvailable;
        private Dictionary<string,Container> _containers;

        public int MaxCount
        {
            get
            {
                return _maxCount;
            }
            set
            {
                _maxCount = value;
            }
        }

        public int PathCount
        {
            get
            {
                return _pathCount;
            }
            set
            {
                _pathCount = value;
            }
        }
        public Boolean Serialized
        {
            get
            {
                return _serialized;
            }
            set
            {
                _serialized = value;
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
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
        public Scene East
        {
            get
            {
                return _east;
            }
            set
            {
                _east = value;
            }
        }
        public Scene West
        {
            get
            {
                return _west;
            }
            set
            {
                _west = value;
            }
        }
        public Scene South
        {
            get
            {
                return _south;
            }
            set
            {
                _south = value;
            }
        }
        public Scene North
        {
            get
            {
                return _north;
            }
            set
            {
                _north = value;
            }
        }
        public Scene Up
        {
            get
            {
                return _up;
            }
            set
            {
                _up = value;
            }
        }
        public Scene Down
        {
            get
            {
                return _down;
            }
            set
            {
                _down = value;
            }
        }
        public Dictionary<string, Boolean> DirectionAvailable
        {
            get
            {
                return _directionAvailable;
            }
            set
            {
                _directionAvailable = value;
            }
        }
        public Dictionary<string,Container> Containers
        {
            get
            {
                return _containers;
            }
            set
            {
                _containers = value;
            }
        }

        public Scene(int number)
        {
            _description = "scene " + number.ToString();
            _title = _description;
            _maxCount = 1;
            _containers = new Dictionary<string, Container>();

        }



        public Object Clone()
        {
            Scene sceneCopy = new Scene(-1);
            sceneCopy.Description = this.Description;
            sceneCopy.South = this.South;
            sceneCopy.North = this.North;
            sceneCopy.East = this.East;
            sceneCopy.West = this.West;
            sceneCopy.Up = this.Up;
            sceneCopy.Down = this.Down;

            return sceneCopy;
        }
    }
}
