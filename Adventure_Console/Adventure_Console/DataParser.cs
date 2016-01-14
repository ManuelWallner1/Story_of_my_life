using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Adventure_Console
{
    public class DataParser
    {
        private string[] data;
        public List<Room> rooms = new List<Room>();

        public void InitalizeGame(string filePath)
        {
            ReadDataFile(filePath);
            ParseData();
            // Free Memmory
            data = null;
        }


        private void ReadDataFile(string filePath)
        {
            /* Load Data File into Memmory */
            data = File.ReadAllLines(filePath);
        }

        private void ParseData()
        {
            /* Loops through each line of the data */
            for (int i = 0; i < data.Length; i++)
            {
                /* We use a switch to use the right action on the right keyword */
                switch (data[i])
                {
                    case "@area":/* The keyword for an area */
                        CreateArea(i);
                        break;

                    default: /* Ignore null-lines and //-comments */
                        break;
                }
            }
        }
        private void CreateArea(int index)
        {
            rooms.Add(new Room());

            int listIndex = (rooms.Count - 1);
            /* Start reading the file from the keyword+1 */
            index++;
            string[] lineparser;

            for (int i = index; i < data.Length; i++)
            {
                /* Split it by the #. 0 argument is the subword and 1 is the information */
                lineparser = data[i].Split('#');
                lineparser[0].Trim();
                switch (lineparser[0])
                {
                    case "name":
                        rooms[listIndex].SetNameOfArea(lineparser[1]);
                        break;

                    case "description":
                        rooms[listIndex].SetDescriptionOfArea(lineparser[1]);
                        break;

                    case "item":
                        lineparser = lineparser[1].Split(',');
                        rooms[listIndex].AddItem(lineparser[0], lineparser[1], lineparser[2], lineparser[3]);
                        break;

                    case "direction":
                        lineparser = lineparser[1].Split(',');
                        rooms[listIndex].AddDirection
                            (
                            lineparser[0],
                            lineparser[1],
                            lineparser[2],
                            lineparser[3],
                            lineparser[4],
                            lineparser[5]
                            );
                        break;

                    default:
                        return;
                }
            }
        }
    }
}
