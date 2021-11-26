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
            Console.WriteLine("(2)  Show a Specific train");
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

        private void StationsMenu()
        {
            Console.Clear();
            Console.WriteLine("(1)  List locomotives");
            Console.WriteLine("(2)  Show a Specific train");
            Console.WriteLine("(3)  Add locomotive");
            Console.WriteLine("(4)  Delete locomotive");
            Console.WriteLine("(5)  Update locomotive");
        }

        private void WagonsMenu()
        {

        }
    }
}
