using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace ship
{
     public class Ship
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string registration;
        public string Registration
        {
            get { return registration; }
            set { registration = value; }
        }
        private double freight;
        public double Freight
        {
            get { return freight; }
            set { freight = value; }
        }
        private string departure;
        public string Departure
        {
            get { return departure; }
            set { departure = value; }
        }
        private int personnel;
        public int Personnel
        {
            get { return personnel; }
            set { personnel = value; }
        }
        
        public Ship(string n, string r, double f, string d, int p)
        {
            this.name = n;
            this.registration = r;
            this.freight = f;
            this.departure = d;
            this.personnel = p;
        }
        public Ship()
        {
            this.name = "none";
            this.registration = "none";
            this.freight = 0;
            this.departure = "none";
            this.personnel = 0;

        }
        public static Boolean isAlpha(string strToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z\s,]*$");
            return rg.IsMatch(strToCheck);
        }
        public string words(string word)
        {
            while (word.All(Char.IsLetter) == false)
            {
                Console.WriteLine("Error. Wrong word in object with name ", this.name, " ");
                Console.WriteLine("Enter another word ");
                word = Console.ReadLine();
            }
            return word;
        }
        public double numbs(string num)
        {
            while (isfloat(num) == false || num[0].Equals("-") == true)
            {
                Console.WriteLine("Error. Wrong number in object with name ", this.name, " ");
                Console.WriteLine("Enter another number ");
                num = Console.ReadLine();
            }
            return double.Parse(num);
        }

        public Boolean isfloat(string num)
        {
            try
            {
                double n = double.Parse(num);
                return true;
            }
            catch
            {
                return false;
            }


        }
        public int numbsint(string num)
        {
            while (num.All(Char.IsDigit) == false)
            {
                Console.WriteLine("Error. Wrong number in object with name ", this.name, " ");
                Console.WriteLine("Enter another number ");
                num = Console.ReadLine();

            }
            return int.Parse(num);
        }
        public void inp_from_file(string line)
        {
            string[] a = line.Split();
            this.name = words(a[0]);
            this.registration = words(a[1]);
            this.freight = numbs(a[2]);
            this.departure = words(a[3]);
            this.personnel = numbsint(a[4]);
        }
        public override string ToString()
        {
            return this.name + ' ' + this.registration + ' ' + this.freight.ToString()+' ' + this.departure + ' ' + this.personnel.ToString()+'\n';
        }
        public void input_new()
        {
            Console.WriteLine("input new name ");
            string a = Console.ReadLine();
            this.name = words(a);
            Console.WriteLine("input new place of registration ");
            string b = Console.ReadLine();
            this.registration = words(b);
            Console.WriteLine("input new freight ");
            string c = Console.ReadLine();
            this.freight = numbs(c);
            Console.WriteLine("input new departure ");
            string d = Console.ReadLine();
            this.departure = words(d);
            Console.WriteLine("input new number of personnel ");
            string e = Console.ReadLine();
            this.personnel = numbsint(e);
        }

    }

}
