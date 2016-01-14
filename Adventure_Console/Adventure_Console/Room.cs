using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Console
{
    public class Room
    {
        private string roomName;
        private string roomDesc;
        protected const string _newline = "\r\n";
        private Direction[] directions = new Direction[8];
        public Item[] items = new Item[4];

        public void AddItem(string name, string description, string hidden, string location)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = new Item();
                    items[i].itemName = name;
                    items[i].itemDesc = description;
                    items[i].isHidden = bool.Parse(hidden);
                    items[i].located = location;
                    return;
                }
            }
            Console.WriteLine("Couldn't add item to room: {0}", roomName);
        }
        public void AddDirection(string name, string pathdes, string destinationArea, string hidden, string locked, string requires)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == null)
                {
                    directions[i] = new Direction();
                    directions[i].directionName = name;
                    directions[i].directionDescription = pathdes;
                    directions[i].travelLocation = destinationArea;
                    directions[i].isHidden = bool.Parse(hidden);
                    directions[i].isLocked = bool.Parse(locked);
                    directions[i].itemRequired = requires;
                    return;
                }
            }
            Console.WriteLine("Couldn't add direction to room: {0}", roomName);
        }
        public void SetNameOfArea(string name)
        {
            this.roomName = name;
        }
        public void SetDescriptionOfArea(string description)
        {
            this.roomDesc = description;
        }

        public string Name
        {
            get { return roomName; }
        }
        public string Description
        {
            get { return roomDesc; }
        }

        public void GetDirectionsInArea()
        {
            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == null || directions[i].isHidden)
                    return;
                else
                    Console.Write(directions[i].directionDescription);
            }
        }
        public void GetItemsInArea()
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null || items[i].isHidden)
                    return;
                else
                    Console.WriteLine(items[i].located);
            }
        }

        public void DisplayArea()
        {
            Console.WriteLine(roomName);
            Console.Write(roomDesc);
        }
    }
}
