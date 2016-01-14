using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Console
{
    public class Direction
    {
        public string directionName;
        public string directionDescription;
        public bool isHidden = false;
        public bool isLocked = false;
        public string itemRequired;
        public string travelLocation;
    }
}
