using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
namespace ship
{


    class Program
    {
        static void Main(string[] args)

        {

            StreamReader file_to_read = new StreamReader("read.txt");
            StreamWriter file_to_write = new StreamWriter("write.txt");
            Ship f = new Ship();
            Container l = new Container();
            l.create_list(file_to_read);
            int action = 1;
            while (action != 0)
            {
                Console.WriteLine("Choose the action and write it`s number ");
                Console.WriteLine("1.print ");
                Console.WriteLine("2.sort");
                Console.WriteLine("3.delete ");
                Console.WriteLine("4.add new item");
                Console.WriteLine("5.edit one item");
                Console.WriteLine("6.find item");
                Console.WriteLine("0.exit");
                action = int.Parse(Console.ReadLine());
                if (action == 1)
                {

                    l.print_all();
                    l.write_all_to_file(file_to_write);
                }
                else if (action == 2) {
                    string a = "1";
                    while (a != "0") {
                        Console.WriteLine("Write a parameter for sorting");
                        Console.WriteLine("To return press 0\n");
                        a = Console.ReadLine();
                        if (a == "0")
                            break;
                        else
                        {
                            try
                            {
                                Type t = typeof(Ship);
                                FieldInfo fi = t.GetField(a, BindingFlags.NonPublic | BindingFlags.Instance);
                                l.Sort1(fi);
                                l.print_all();
                                l.write_all_to_file(file_to_write);
                            }
                            catch
                            { throw new Exception("wrong parameter\n"); }
                        }

                    }
                }

                else if (action == 3) {
                    Console.WriteLine("input name of element ");
                    string name = Console.ReadLine();
                    l.delete_by_name(name);
                    l.print_all();
                    l.write_all_to_file(file_to_write);
                }
                else if (action == 4) {
                    l.add_new();
                    l.print_all();
                    l.write_all_to_file(file_to_write);
                }
                else if (action == 5) {
                    Console.WriteLine("input name of element ");
                    string name = Console.ReadLine();
                    l.edit_by_name(name);
                    l.print_all();
                    l.write_all_to_file(file_to_write);
                }
                else if (action == 0)
                    break;
                else if (action == 6) {
                    Console.WriteLine("input data for searching ");
                    string name = Console.ReadLine();
                    l.find_obj(name);
                }
                else {
                    Console.WriteLine("incorrect number ");
                    continue;
                                }

            }
        }
    }
}
