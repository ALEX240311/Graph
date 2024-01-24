using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22DH110153_PhamTuanAnh_LAB_3_
{
    internal class BT3
    {
        int n; //node number
        public int v; //top point

        public LinkedList<int>[] Graph;

        public List<int> BFS(int v)
        {
            List<int> path = new List<int>();
            bool[] visited = new bool[n + 1];
            Queue<int> queue = new Queue<int>();
            visited[v] = true;
            queue.Enqueue(v);

            while (queue.Count != 0)
            {
                v = queue.Dequeue();
                foreach (var neighbor in Graph[v])
                {
                    if (visited[neighbor])
                    {
                        continue;
                    }
                    queue.Enqueue(neighbor);
                    visited[neighbor] = true;
                    path.Add(neighbor);
                }
            }
            return path;
        }
        public bool isConnected()
        {
            int v = 1;
            bool[] visited = new bool[n + 1];
            BFS(v, visited);
            for(int i = 1; i<n+1; i++)
            {
                if (!visited[i])
                {
                    return false;
                }
            }
            return false;
        }
        public int CountConnectedComponents()
        {
            int count = 0;
            bool[] visited = new bool[n + 1];
            for(int i = 1; i<=n; i++)
            {
                if (!visited[i])
                {
                    BFS(i, visited);
                    count++;
                }
            }
            return 0;
        }
        public void  BFS(int v, bool[] visited)
        {
            Queue<int> queue = new Queue<int>();
            
            visited[v] = true;
            queue.Enqueue(v);

            while (queue.Count != 0)
            {
                v = queue.Dequeue();
                foreach (var neighbor in Graph[v])
                {
                    if (visited[neighbor])
                    {
                        continue;
                    }
                    queue.Enqueue(neighbor);
                    visited[neighbor] = true;
                
                }
            }

        }
        public void storeData(string path) //store Data into file lol.txt
        {
            List<string> listA = new List<string>()
            {
                "8",
                "2",
                "1 5",
                "4",
                "3 7 6",
                "2",
                "4",
                "4 8",
                "7"
             };

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
            string[] listA = File.ReadAllLines(path); //If the file exists, it reads all lines from the file and stores them in an array called listA.

            //Assumes the first line contains 2 interger numbers 
            n = int.Parse(listA[0].Split(' ', (char)StringSplitOptions.RemoveEmptyEntries)[0]);
           




            //Initialize Graph !!!
            Graph = new LinkedList<int>[n + 1];
            for (int index = 0; index < n; index++)
            {
                Graph[index + 1] = new LinkedList<int>();
                string[] subs = listA[index + 1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in subs)
                {
                    AddEdge(index + 1, int.Parse(item));
                }
            }
            return true;
        }
        public void AddEdge(int v, int w)
        {
            Graph[v].AddLast(w);
        }

        public override string ToString()
        {
            string line = "";
            for (int i = 1; i <= n; i++)
            {
                foreach (int e in Graph[i])
                {
                    line += e.ToString() + " ";
                }
                line += "\n";
            }
            return line;
        }

    }
}

