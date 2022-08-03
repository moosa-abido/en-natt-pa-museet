using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Museet.Models;

namespace museet.Models
{
    public class RoomList
    {
        Dictionary<string, Room> rooms;

        public int getCount()
        {
            return rooms.Count;
        }

        public Dictionary<string, Room>  getRooms()
        {
            return rooms;
        }

        public RoomList()
        {
            rooms = new Dictionary<string, Room>();
        }


        public string add(Room room)
        {
            room.RoomID = room.RoomID.ToLower().Trim();

            if (rooms.ContainsKey(room.RoomID))
            {
                return "room " + room.RoomID + " already exists, will not be added";
            }

            rooms.Add(room.RoomID, room);
            return "room " + room.RoomID + " has been added";

        }



        public string delete(string room_id)
        {
            room_id = room_id.ToLower().Trim();
            if (rooms.ContainsKey(room_id))
            {

                Room room = rooms[room_id];
                if (room.hasArt())
                {
                    return "room " + room_id + " has arts and can not be deleted";
                }
                else
                {
                    rooms.Remove(room_id);
                    return "room " + room_id + " has been deleted";
                }


            }
            return "room " + room_id + " does not exists";
        }






        public Room getRoom(string room_id)
        {
            room_id = room_id.ToLower().Trim();
            if (rooms.ContainsKey(room_id))
            {

                return rooms[room_id];
            }
            return null;
        }

       
    }
}