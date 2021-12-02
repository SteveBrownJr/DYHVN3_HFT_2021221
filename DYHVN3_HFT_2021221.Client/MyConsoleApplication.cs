using DYHVN3_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYHVN3_HFT_2021221.Client
{
    class MyConsoleApplication
    {
        RestService rest;
        public MyConsoleApplication(RestService rest)
        {
            this.rest = rest;
        }
        public void Start()
        {
            Menu();
        }
        private void Menu()
        {
            bool run = true;

            do
            {
            Console.WriteLine("(1) Locomotives");
            Console.WriteLine("(2) Wagons");
            Console.WriteLine("(3) Stations");
            Console.WriteLine("(4) Exit");
            switch (Console.ReadLine())
            {
                case "1" :
                        LocomotivesMenu();
                    ;break;
                case "2" :
                        WagonsMenu();
                    ;break;
                case "3" :
                        StationsMenu();
                    ;break;
                case "4" :
                    run = false;
                    ;break;
                default:
                    Console.WriteLine("Incorrect input!");
                        break;
            }
            } while (run);
        }

        private void LocomotivesMenu()
        {
            Console.Clear();
            Console.WriteLine("(1)  List locomotives");
            Console.WriteLine("(2)  Show a Specific locomotive");
            Console.WriteLine("(3)  Add locomotive");
            Console.WriteLine("(4)  Delete locomotive");
            Console.WriteLine("(5)  Update locomotive");
            Console.WriteLine("(6)  Show the longest train's locomotive");
            Console.WriteLine("(7)  Show the most powerful locomotive");
            Console.WriteLine("(8)  Show the weakest locomotive");
            Console.WriteLine("(9)  Show the fastest accelerating train's locomotive");
            Console.WriteLine("(10) Show the touched stations by a specified locomotive");
            Console.WriteLine("(11) Show the route of the train!");
            int v = int.Parse(Console.ReadLine());
            switch (v)
            {
                case 1:
                    {
                        Console.Clear();
                        var Locomotives = rest.Get<Locomotive>("locomotive");
                        Console.WriteLine("id\tname\ttype\tstart torq\tstaff\tload");
                        foreach (Locomotive l in Locomotives)
                        {
                            Console.WriteLine(l.Locomotive_Id + "\t" + l.Name + "\t" + l.Type + "\t" + l.Starting_Torque + "\t\t" + l.Staff + "\t" + l.load + "kg");
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Id of the train");
                        int id = int.Parse(Console.ReadLine());

                        var l = rest.Get<Locomotive>(id, "locomotive");
                        Console.WriteLine("id\tname\ttype\tstart torq\tstaff\tload");
                        Console.WriteLine(l.Locomotive_Id + "\t" + l.Name + "\t" + l.Type + "\t" + l.Starting_Torque + "\t\t" + l.Staff + "\t" + l.load + "kg");
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("Name:"); string name = Console.ReadLine();
                        Console.WriteLine("Type:"); string type = Console.ReadLine();
                        Console.WriteLine("Starting torque:"); int starting = int.Parse(Console.ReadLine());
                        Console.WriteLine("Staff number:"); int staff = int.Parse(Console.ReadLine());

                        rest.Post<Locomotive>(new Locomotive()
                        {
                            Name = name,
                            Type = type,
                            Starting_Torque = starting,
                            Staff = staff
                        }, "locomotive");
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("Id of the locomotives what you want to be scapped :(");
                        int id = int.Parse(Console.ReadLine());
                        rest.Delete(id, "locomotive");
                        break;
                    }
                case 5 :
                    {
                        Console.WriteLine("Id of the locomotive you want to update:");
                        int id = int.Parse(Console.ReadLine());
                        
                        var l = rest.Get<Locomotive>(id, "locomotive");
                        Console.WriteLine("id\tname\ttype\tstart torq\tstaff\tload");
                        Console.WriteLine(l.Locomotive_Id + "\t" + l.Name + "\t" + l.Type + "\t" + l.Starting_Torque + "\t\t" + l.Staff + "\t" + l.load + "kg");
                        try
                        {
                            Console.WriteLine("New name:"); l.Name = Console.ReadLine();
                            Console.WriteLine("New Type:"); l.Type = Console.ReadLine();
                            Console.WriteLine("New starting torq: "); l.Starting_Torque = int.Parse(Console.ReadLine());
                            Console.WriteLine("New number of staff: "); l.Staff = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        

                        rest.Put<Locomotive>(l, "locomotive");
                        break;
                    }
                case 6:
                    {
                        Locomotive l =rest.GetSingle<Locomotive>("train/longesttrain");
                        Console.WriteLine("id\tname\ttype\tstart torq\tstaff\tload");
                        Console.WriteLine(l.Locomotive_Id + "\t" + l.Name + "\t" + l.Type + "\t" + l.Starting_Torque + "\t\t" + l.Staff + "\t" + l.load + "kg");
                        break;
                    }
                case 7:
                    {
                        Locomotive l = rest.GetSingle<Locomotive>("train/mostpowerfullocomotive");
                        Console.WriteLine("id\tname\ttype\tstart torq\tstaff\tload");
                        Console.WriteLine(l.Locomotive_Id + "\t" + l.Name + "\t" + l.Type + "\t" + l.Starting_Torque + "\t\t" + l.Staff + "\t" + l.load + "kg");
                        break;
                    }
                case 8:
                    {
                        Locomotive l = rest.GetSingle<Locomotive>("train/weakestlocomotive");
                        Console.WriteLine("id\tname\ttype\tstart torq\tstaff\tload");
                        Console.WriteLine(l.Locomotive_Id + "\t" + l.Name + "\t" + l.Type + "\t" + l.Starting_Torque + "\t\t" + l.Staff + "\t" + l.load + "kg");
                        break;
                    }
                case 9:
                    {
                        Locomotive l = rest.GetSingle<Locomotive>("train/fastestacceleratingtrain");
                        Console.WriteLine("id\tname\ttype\tstart torq\tstaff\tload");
                        Console.WriteLine(l.Locomotive_Id + "\t" + l.Name + "\t" + l.Type + "\t" + l.Starting_Torque + "\t\t" + l.Staff + "\t" + l.load + "kg");
                        break;
                    }
                case 10:
                    {
                        Console.WriteLine("Which train's stations do you peek for?");
                        int id = int.Parse(Console.ReadLine());
                        var l = rest.Get2<Station>(id,"train/touchedstations");
                        Console.WriteLine("Stations: ");
                        foreach (Station s in l)
                        {
                            Console.Write(s.Name+" ");
                        }
                        break;
                    }
                case 11:
                    {
                        Console.WriteLine("Which train's stations do you peek for?");
                        int id = int.Parse(Console.ReadLine());
                        var l = rest.Get2<Station>(id, "train/route");
                        Console.WriteLine("Stations: ");
                        foreach (Station s in l)
                        {
                            Console.Write(s.Name + " ");
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine(v+" that's invalid");
                        System.Threading.Thread.Sleep(1500);
                    break;
                    }
            }
        }
        private void WagonsMenu()
        {
            Console.Clear();
            Console.WriteLine("(1) List wagons");
            Console.WriteLine("(2) Show a specific wagon");
            Console.WriteLine("(3) Add Wagon");
            Console.WriteLine("(4) Delete wagon");
            Console.WriteLine("(5) Connect a wagon to another locomotive (Update wagon)");
            Console.WriteLine("(6) Heaviest wagon");
            Console.WriteLine("(7) Most common cargo type");
            Console.WriteLine("(8) Avarage starting torq for one wagon");
            int v = int.Parse(Console.ReadLine());
            switch (v)
            {
                case 1:
                    {
                        Console.Clear();
                        var Wagons = rest.Get<Wagon>("wagon");
                        Console.WriteLine("Id\tCargoType\tQuantity\tLocomotive Id");
                        foreach (Wagon w in Wagons)
                        {
                            Console.WriteLine(w.Wagon_Id+"\t"+w.CargoType+"\t\t"+w.Quantity+"\t\t"+w.Locomotive_Id);
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Id of the Wagon");
                        int id = int.Parse(Console.ReadLine());

                        var w = rest.Get<Wagon>(id, "wagon");
                        Console.WriteLine("Id\tCargoType\tQuantity\tLocomotive Id");
                        Console.WriteLine(w.Wagon_Id + "\t" + w.CargoType + "\t\t" + w.Quantity + "\t\t" + w.Locomotive_Id);
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("CargoType:");
                        Cargo_Type ct=Cargo_Type.Passanger;

                        switch (Console.ReadLine())
                        {
                            case "Hopper":
                                {
                                    ct = Cargo_Type.Hopper;
                                    break;
                                }
                            case "Mail":
                                {
                                    ct = Cargo_Type.Mail;
                                    break;
                                }
                            case "Passanger":
                                {
                                    ct = Cargo_Type.Passanger;
                                    break;
                                }
                            case "Tank":
                                {
                                    ct = Cargo_Type.Tank;
                                    break;
                                }
                            default:
                                break;
                        }
                        Console.WriteLine("Locomotive_Id:"); int locomotiveid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Quantity:"); int q = int.Parse(Console.ReadLine());

                        rest.Post<Wagon>(new Wagon()
                        {
                            CargoType = ct,
                            Locomotive_Id = locomotiveid,
                            Quantity = q
                        }, "wagon");
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("Id of the wagon what you want to be scapped :(");
                        int id = int.Parse(Console.ReadLine());
                        rest.Delete(id, "wagon");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Id of the wagon you want to update:");
                        int id = int.Parse(Console.ReadLine());

                        var w = rest.Get<Wagon>(id, "wagon");
                        Console.WriteLine("Id\tCargoType\tQuantity\tLocomotive Id");
                        Console.WriteLine(w.Wagon_Id + "\t" + w.CargoType + "\t\t" + w.Quantity + "\t\t" + w.Locomotive_Id);
                        try
                        {
                            Console.WriteLine("New LocomotiveId"); w.Locomotive_Id= int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input!");
                        }


                        rest.Put<Wagon>(w, "wagon");
                        break;
                    }
                case 6:
                    {
                        var w = rest.GetSingle<Wagon>("train/heviestwagon");
                        Console.WriteLine("Id\tCargoType\tQuantity\tLocomotive Id");
                        Console.WriteLine(w.Wagon_Id + "\t" + w.CargoType + "\t\t" + w.Quantity + "\t\t" + w.Locomotive_Id);
                        Console.ReadKey();
                        break;
                    }
                case 7:
                    {
                        Console.Clear();
                        var ct = rest.GetSingle<Cargo_Type>("train/mostcommoncargotype");
                        Console.WriteLine("Most common cargo type is: "+ct.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 8:
                    {
                        Console.Clear();
                        Console.WriteLine("Tell me the wagon's id"); int id = int.Parse(Console.ReadLine()); Console.Clear();
                        Console.WriteLine("Avarage starting torq for one wagon is "+rest.Get<double>(id,"train/avaragestartingtorqueforthewagon")+"kN");
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input!");
                        Console.ReadKey();
                        break;
                    }
            }
        }

        private void StationsMenu()
        {
            Console.Clear();
            Console.WriteLine("(1)  List Stations");
            Console.WriteLine("(2)  Show a specific station");
            Console.WriteLine("(3)  Add station");
            Console.WriteLine("(4)  Delete station");
            Console.WriteLine("(5)  Update station");
            Console.WriteLine("(6)  Distance between two station");
            Console.WriteLine("(7)  Show the Locmotive of the specific station");
            Console.WriteLine("(8)  Show the wagons of the specific station");
            Console.WriteLine("(9)  How much cargo travel through a specific station");
            Console.WriteLine("(10) What type of cargo travel through a specific station");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.Clear();
                        var Stations = rest.Get<Station>("station");
                        Console.WriteLine("id\tname\t\tLocomotive id\tX\tY");
                        foreach (Station s in Stations)
                        {
                            if (s.Name.Length<8)
                                Console.WriteLine(s.Station_Id + "\t" + s.Name + "\t\t" + s.Locomotive_Id + "\t\t" + s.x_cordinate + "\t" + s.y_cordinate);
                            else
                                Console.WriteLine(s.Station_Id+"\t"+s.Name+"\t"+s.Locomotive_Id+"\t\t"+s.x_cordinate+"\t"+s.y_cordinate);
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Id of the station");
                        int id = int.Parse(Console.ReadLine());

                        var s = rest.Get<Station>(id, "station");
                        if (s.Name.Length < 8)
                            Console.WriteLine(s.Station_Id + "\t" + s.Name + "\t\t" + s.Locomotive_Id + "\t\t" + s.x_cordinate + "\t" + s.y_cordinate);
                        else
                            Console.WriteLine(s.Station_Id + "\t" + s.Name + "\t" + s.Locomotive_Id + "\t\t" + s.x_cordinate + "\t" + s.y_cordinate);

                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("Name:"); string name = Console.ReadLine();
                        Console.WriteLine("Locomotive id:"); int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("X:"); int x = int.Parse(Console.ReadLine());
                        Console.WriteLine("Y:"); int y = int.Parse(Console.ReadLine());
                        rest.Post<Station>(new Station()
                        {
                            Name = name,
                            Locomotive_Id=id,
                            x_cordinate=x,
                            y_cordinate=y
                        }, "station");
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("Id of the Station what you want to be demolished :(");
                        int id = int.Parse(Console.ReadLine());
                        rest.Delete(id, "station");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Id of the station you want to update:");
                        int id = int.Parse(Console.ReadLine());

                        var s = rest.Get<Station>(id, "station");
                        if (s.Name.Length < 8)
                            Console.WriteLine(s.Station_Id + "\t" + s.Name + "\t\t" + s.Locomotive_Id + "\t\t" + s.x_cordinate + "\t" + s.y_cordinate);
                        else
                            Console.WriteLine(s.Station_Id + "\t" + s.Name + "\t" + s.Locomotive_Id + "\t\t" + s.x_cordinate + "\t" + s.y_cordinate);

                        try
                        {
                            Console.WriteLine("New name:"); s.Name = Console.ReadLine();
                            Console.WriteLine("New locomotive id:");s.Locomotive_Id = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input!");
                        }


                        rest.Put<Station>(s, "station");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Which stations do you looking for?");
                        int id1 = int.Parse(Console.ReadLine());
                        int id2 = int.Parse(Console.ReadLine());
                        var d = rest.Get<double>(id1,id2, "train/distancebetweentwostation");
                        Console.WriteLine("Distance "+Math.Round(d,2)+"km.");
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Station: ");
                        int id = int.Parse(Console.ReadLine());
                        Locomotive l = rest.Get<Locomotive>(id, "train/touchinglocomotive");
                        Console.WriteLine("id\tname\ttype\tstart torq\tstaff\tload");
                        Console.WriteLine(l.Locomotive_Id + "\t" + l.Name + "\t" + l.Type + "\t" + l.Starting_Torque + "\t\t" + l.Staff + "\t" + l.load + "kg");
                        Console.ReadKey();
                        break;
                    }
                case 8:
                    {
                        Console.Clear();
                        Console.WriteLine("Station: ");
                        int id = int.Parse(Console.ReadLine());
                        var Wagons = rest.Get2<Wagon>(id, "train/touchingwagons");
                        Console.WriteLine("Id\tCargoType\tQuantity\tLocomotive Id");
                        foreach (Wagon w in Wagons)
                        {
                            Console.WriteLine(w.Wagon_Id + "\t" + w.CargoType + "\t\t" + w.Quantity + "\t\t" + w.Locomotive_Id);
                        }
                        Console.ReadKey();
                        break;
                    }
                case 9:
                    {
                        Console.WriteLine("Station id:");
                        int id = int.Parse(Console.ReadLine());
                        double d = rest.Get<double>(id, "train/movedquantity");
                        Console.WriteLine(Math.Round(d,2)+"kg");
                        Console.ReadKey();
                        break;
                    }
                case 10:
                    {
                        Console.WriteLine("Station id:");
                        int id = int.Parse(Console.ReadLine());
                        List<Cargo_Type> collection = rest.Get2<Cargo_Type>(id, "train/movedcargotypes");
                        Console.WriteLine("Cargo types:");
                        foreach (var item in collection)
                        {
                            Console.WriteLine(item.ToString()+" ");
                        }
                        Console.ReadKey();
                        break;
                    }
            }
        }

    }
}
