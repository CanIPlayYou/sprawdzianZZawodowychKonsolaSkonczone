using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprawdzian
{
    internal class Program
    {
        class UniqueTable
        {
            private double[] table = new double[0];

            public void addItem(double newItem)
            {
                foreach(var item in table)
                {
                    if (item == newItem) return;
                }

                double[] newTable = new double[table.Length + 1];
                for (int i = 0; i < table.Length; i++)
                {
                    newTable[i] = table[i];
                }
                newTable[newTable.Length - 1] = newItem;
                table = newTable;
            }

            public void deleteItem(double deleteItem)
            {
                int index = -1;

                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i] == deleteItem)
                    {
                        index = i;
                        break;
                    }
                }

                if (index != -1)
                {
                    double[] newTable = new double[table.Length - 1];
                    for (int i = 0, j = 0; i < table.Length; i++)
                    {
                        if (i != index)
                        {
                            newTable[j++] = table[i];
                        }
                    }
                    table = newTable;
                }
            }

            public string toString()
            {
                string string_table = "[";

                for (int i = 0; i < table.Length - 1; i++)
                {
                    string_table += $"{table[i]}, ";
                }

                if (table.Length > 0)
                {
                    string_table += $"{table[table.Length - 1]}";
                }

                string_table += "]";

                return string_table;
            }
        }

        class DynamicTable
        {
            private double[] table = new double[0];

            public void addItem(double newItem)
            {
                double[] newTable = new double[table.Length + 1];
                for (int i = 0; i < table.Length; i++)
                {
                    newTable[i] = table[i];
                }
                newTable[newTable.Length - 1] = newItem;
                table = newTable;
            }

            public void deleteItem(int deleteIndex)
            {
                if (deleteIndex < 0 || deleteIndex >= table.Length) return;

                double[] newTable = new double[table.Length - 1];
                for (int i = 0, j = 0; i < table.Length; i++)
                {
                    if (i != deleteIndex)
                    {
                        newTable[j++] = table[i];
                    }
                }
                table = newTable;
            }

            public string toString()
            {
                string string_table = "[";

                for (int i = 0; i < table.Length - 1; i++)
                {
                    string_table += $"{table[i]}, ";
                }

                if (table.Length > 0)
                {
                    string_table += $"{table[table.Length - 1]}";
                }

                string_table += "]";

                return string_table;
            }
        }

        static void Main(string[] args)
        {

            UniqueTable unTable = new UniqueTable();

            unTable.addItem(2.0);
            unTable.addItem(4.5);
            unTable.addItem(3.7);
            unTable.addItem(5.7);
            unTable.addItem(5.7);
            unTable.addItem(9.7);

            Console.WriteLine("Tablica unikalna po dodaniu: " + unTable.toString());

            unTable.deleteItem(2.0);
            unTable.deleteItem(3.7);

            Console.WriteLine("Tablica unikalna po usunięciu: " + unTable.toString());


            //////


            DynamicTable dmTable = new DynamicTable();

            dmTable.addItem(3.4);
            dmTable.addItem(2.7);
            dmTable.addItem(8.9);
            dmTable.addItem(8.9);
            dmTable.addItem(10.9);

            Console.WriteLine("\nTablica dynamiczna po dodaniu: " + dmTable.toString());

            dmTable.deleteItem(0);
            dmTable.deleteItem(2);

            Console.WriteLine("Tablica dynamiczna po usunięciu: " + dmTable.toString());

            Console.ReadKey();

        }
    }
}
