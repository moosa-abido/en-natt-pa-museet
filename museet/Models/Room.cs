using System.Collections.Generic;

namespace Museet.Models
{
    // TODO: Needs further work
    public class Room
    {
        public Dictionary<string, Art> arts { get; }
        public Room(string RoomID)
        {
            this.RoomID = RoomID;
            arts = new Dictionary<string, Art>();
        }

        public string RoomID { get; set; }



        public override string ToString()
        {
            return RoomID + ": " + string.Join(" , ", arts); // Arts
        }

        public bool hasArt()
        {
            return arts.Count > 0;
        }

        public Art getArt(string art_id)
        {
            if (arts.ContainsKey(art_id)) return arts[art_id];
            return null;
        }

        public string addart(string art_id, string creator, string artdec)
        {

            Art art = getArt(art_id);

            if (art != null)
            {
                return "room " + RoomID + " already contains art " + art_id;
            }
            else
            {

                arts.Add(art_id,new Art(art_id, creator, artdec));
                return "Art added: " + art_id;

            }

        }

    }

}

