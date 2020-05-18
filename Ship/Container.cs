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
    class Container
    {
        private  List<Ship> l;
        public Container()
        {
            this.l = new List<Ship>();
        }
        public List<Ship> create_list(StreamReader f)
        {
            int i = 0;
            string line;
            while ((line = f.ReadLine()) != null)
            {
                Ship s = new Ship();
                s.inp_from_file(line);
                this.l.Add(s);
                i++;
            }
            return l;
        }
        public void Sort< TKey>(FieldInfo f, Func<Ship, TKey> selector, IComparer<TKey> comparer = null)
        {
            
            comparer = comparer ?? Comparer<TKey>.Default;
            this.l.Sort((a, b) => comparer.Compare(selector(a), selector(b)));
        }
        public void Sort1(FieldInfo f, IComparer<object> comparer = null)
        {

            comparer = comparer ?? Comparer<object>.Default;
            this.l.Sort((a, b) => comparer.Compare(f.GetValue(a),f.GetValue(b)));
        }
        public void find_obj(string word)
        {
            int m = 0;
            for (int i = 0; i < l.Count; i++)
            {
                if ((l[i].Name.Contains(word)) || (l[i].Registration.Contains(word)) || (l[i].Freight.ToString().Contains(word)) || (l[i].Departure.Contains(word)) || (l[i].Personnel.ToString().Contains(word)) )
            {
                Console.WriteLine(l[i].ToString());
            }
              m += 1;
            }
            if (m == 0)
            { Console.WriteLine("There are no such elements in the list:("); }
        }
        public void print_all()
        {
            Console.WriteLine("\n");
            for(int i = 0;i<l.Count;i++)
            {
                Console.WriteLine(l[i].ToString());
            }
        }
        public void delete_by_name(string name)
        {
            int m = 0, i = 0;
            while (i < l.Count)
            {
                if (name.Equals(this.l[i].Name) == true)
                {
                    l.RemoveAt(i);
                    m += 1;
                    
                }
                i += 1;
            }
            if (m == 0)
            { Console.WriteLine("There are no such elements in the list:("); }
        }
        public void add_new()
        {
            Ship a = new Ship();
            a.input_new();
            l.Add(a);
        }
        public void edit_by_name(string name)
        {
            int m = 0;
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Name.Contains(name))
                {
                    l[i].input_new();
                    m += 1;
                }
            }
            if (m == 0)
            {
                Console.WriteLine("There are no such elements in the list:(");
            }
        }
        public void write_all_to_file(StreamWriter f)
        {
            for (int i = 0; i < l.Count; i++)
            {
                f.WriteLine(l[i].ToString());
            }
        }

    }
}
