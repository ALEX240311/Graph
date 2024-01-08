using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class adjacencyMatrix
    {
        public int n;
        public int[,] matrix;
        public adjacencyMatrix()
        {

        }

        public void storeData(string path) //store Data into file lol.txt
        {
            List<string> listA = new List<string>()
            {
                "6",
                "0 1 0 0 0 1",
                "1 0 1 0 0 1",
                "0 1 0 1 1 1",
                "0 0 1 0 1 0",
                "0 0 1 1 0 1",
                "1 1 1 0 1 0"};

            using (StreamWriter stream = new StreamWriter(path))
            {
                foreach (string item in listA)
                {
                    stream.WriteLine(item);
                }
            }
        }

        public bool readData(string path)
        {
            if (!File.Exists(path))  //checking file if it exists
            {

                Console.WriteLine("Error!!! Local Path is not found");
                return false;
            }
            string[] listA = File.ReadAllLines(path); //read file
            n = int.Parse(listA[0]);
            matrix = new int[n, n];
            for (int index = 0; index < n; index++)
            {
                string[] subs = listA[index + 1].Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                for (int plat = 0; plat < n; plat++)
                {
                    matrix[index, plat] = int.Parse(subs[plat]);
                }
            }
            return true;
        }

        public override string ToString()
        {
            string line = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    line += matrix[i, j] + " ";
                }
                line += "\n";
            }
            return line;
        }
        public string DegreeGraph()
        {
            string line = "";
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        sum++;
                    }
                }
                line += sum + " ";
                sum = 0;
            }
            return line;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            adjacencyMatrix adjMatrix = new adjacencyMatrix();
            string path = @"D:\Visual studio code\code\file txt\lol.txt"; //follow the path 
            adjMatrix.storeData(path);
            adjMatrix.readData(path);
            if (!adjMatrix.readData(path))
            {
                Console.WriteLine("Error!!! FIle can't be read");
            }
            Console.WriteLine("AdjacencyMatrix \n " + adjMatrix.ToString());
            Console.WriteLine("************");
            Console.WriteLine("Nums of Node :" + adjMatrix.n);
            Console.WriteLine("Degree: " + adjMatrix.DegreeGraph());
            Console.ReadKey();


        }
    }
}
