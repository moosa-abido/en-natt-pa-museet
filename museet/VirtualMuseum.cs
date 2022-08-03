using System;
using Simulator;
using System.Collections.Generic;
using Museet.Models;
using museet.Models;

namespace Museet
{
    internal class VirtualMuseumProgram : IApplication
    {
        RoomList roomslist = null;
        Building active_building = null;

        public Dictionary<string, Building> buildings { get; set; }


        public void Run(string verb, string[] options)
        {
            if (buildings == null)
            {
                buildings = new Dictionary<string, Building>();
                active_building = new Building("Main Building");
                roomslist = active_building.Rooms;
                buildings.Add(active_building.BuildingID, active_building);
                System.Console.WriteLine("We are Currntly in Building: {0}", active_building.BuildingID);
            }

            Room MyRoom;
            // FIXME: Continue with your program here
            Console.WriteLine("Verb: \"{0}\", Options: \"{1}\"", verb, String.Join(",", options));

            switch (verb)
            {
                case "status":
                    System.Console.WriteLine("stauts is OK: ");
                    System.Console.WriteLine("Building {0}", active_building.BuildingID);
                    System.Console.WriteLine("{0} rooms", roomslist.getCount());
                    break;

                case "addbuilding":
                    if (options.Length == 0)
                    {
                        System.Console.WriteLine("[mu] No Building specified!");
                        throw new Exception("mu error!");
                    }

                    Building fb = buildings.ContainsKey(options[0]) ? buildings[options[0]] : null;
                    if (fb == null)
                    {
                        active_building = new Building(options[0]);
                        roomslist = active_building.Rooms;
                        buildings.Add(active_building.BuildingID, active_building);
                        System.Console.WriteLine("Building {0} is created and is the active building now.", active_building.BuildingID);
                    }
                    else
                    {
                        active_building = fb;
                        roomslist = active_building.Rooms;
                        System.Console.WriteLine("Building {0} does exist and it is the active building now", active_building.BuildingID);

                    }

                    break;

                case "select":

                    System.Console.WriteLine("Select building from list (enter q to exit):");
                    foreach (Building bl in buildings.Values)
                    {
                        System.Console.WriteLine("- {0}", bl.BuildingID);

                    }

                    string id = System.Console.ReadLine();
                    while ( (id != "q") && !buildings.ContainsKey(id))
                    {
                        System.Console.WriteLine("Write correct building ID or q to exit:");
                        id = System.Console.ReadLine();
                    }
                    fb = buildings.ContainsKey(id) ? buildings[id] : null;
                    if (fb != null) { 
                        active_building = fb;
                        roomslist = active_building.Rooms;
                        System.Console.WriteLine("Building {0} does exist and it is the active building now", active_building.BuildingID);
                    }
                    break;

                case "addroom":
                    if (options.Length == 0)
                    {
                        System.Console.WriteLine("[mu] No Room specified!");
                        throw new Exception("mu error!");
                    }

                    roomslist.add(new Room(options[0]));
                    System.Console.WriteLine("room {0} is created", options[0]);
                    break;
                case "deleteroom":
                    {
                        MyRoom = roomslist.getRoom(options[0]);
                        // Check If room is found
                        if (MyRoom == null)
                        {
                            System.Console.WriteLine("[Room Not Found!]");
                            throw new Exception("mu error!");
                        }

                        string res = roomslist.delete(MyRoom.RoomID);
                        System.Console.WriteLine(res);
                    }


                    break;

                case "addart":

                    // addart roomid artid "artdes cription"
                    if (options.Length < 4)
                    {
                        System.Console.WriteLine("at least three parameters");
                        throw new Exception("mu error!");
                    }

                    foreach (Room room in roomslist.getRooms().Values)
                    {
                        bool room_found = false;
                        if (room.RoomID == options[0])
                        {
                            if (room.arts.Count == 3)
                            {
                                System.Console.WriteLine("This room has three arts. No more arts can be added.");
                            }
                            else
                            {
                                string res = room.addart(options[1], options[2], options[3]);
                                room_found = true;
                                Console.WriteLine(res);
                            }

                            break;
                        }
                        if (!room_found)
                        {
                            Console.WriteLine("Room not found " + options[0]);
                        }

                    }

                    break;

                case "deleteart":

                    break;
                case "list":
                    if (options.Length > 1)
                    {

                        Console.WriteLine("List Arts Of Room: " + options[0]);
                        bool found = false;
                        foreach (Room room in roomslist.getRooms().Values)
                        {
                            if (room.RoomID == options[0])
                            {
                                Console.WriteLine(room);
                                found = true;
                            }

                        }
                        if (!found)
                        {
                            Console.WriteLine("Error: Room (" + options[0] + ")not found");
                        }

                    }
                    else
                    {
                        Console.WriteLine("List Of Rooms:");
                        foreach (Room room in roomslist.getRooms().Values)
                        {
                            Console.WriteLine(room);
                        }
                    }

                    break;
                default:
                    // Show the help menu when the verb was unrecognized
                    System.Console.WriteLine("Unkown command!");

                    break;
            }


        }

    }
}