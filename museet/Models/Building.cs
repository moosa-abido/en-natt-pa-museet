using museet.Models;
using System.Collections.Generic;

namespace Museet.Models
{
    // TODO: Needs further work
    public class Building
    {

        public Building(string BuildingID)
        {
            this.BuildingID = BuildingID;
            this.Rooms = new RoomList();
        }

        public string BuildingID { get; set; }
        public RoomList Rooms { get; }

    }
}

