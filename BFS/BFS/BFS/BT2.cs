using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22DH110153_PhamTuanAnh_LAB_3_
{
    internal class BT2_cs
    {
        int n; //node number
        public int v; //top point
        public int w;

        public LinkedList<int>[] Graph;

        public List<int> BFS(int v)
        {
            List<int> path = new List<int>();
            bool[] visited = new bool[n + 1];
            Queue<int> queue = new Queue<int>();
            visited[v] = true;
            queue.Enqueue(v);

            while(queue.Count!= 0)
            {
                v = queue.Dequeue();
                foreach(var neighbor in Graph[v])
                {
                    if(!visited[neighbor])
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

        public List<int> PathBFS(int v, int w)
        {
            List<int> path = new List<int>();
            bool[] visited = new bool[n + 1];
            Queue<int> queue = new Queue<int>();
            Dictionary<int, int> parent = new Dictionary<int, int>();
            queue.Enqueue(v);
            visited[v] = true;
      
            while (queue.Count > 0)
            {
                int currNode = queue.Dequeue();
                if(currNode == w) //if v == w 
                {
                    path = ReParent(parent, v, w);
                }
                foreach (var neighbor in Graph[currNode])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                        parent[neighbor] = currNode;
                    }
                   
                }
            }
            return path;
        }
        private List<int> ReParent(Dictionary<int,int>parent, int start, int end)
        {
            List<int> p = new List<int>();
            int currentNode = end;
            while(currentNode!= start)
            {
                p.Add(currentNode);
                currentNode = parent[currentNode];
            }
            p.Add(start);
            p.Reverse();
            return p;
        }
        public void storeData(string path) //store Data into file lol.txt
        {
            List<string> listA = new List<string>()
            {
                "8 3 8",
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
            if (!File.Exists(path))
            {
                Console.WriteLine($"Error!!! File not found at path: {path}");
                return false;
            }

            string[] listA = File.ReadAllLines(path);

            // Assumes the first line contains 3 integer numbers
            string[] firstLineElements = listA[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (firstLineElements.Length != 3)
            {
                Console.WriteLine($"Error!!! Expected 3 elements in the first line, found {firstLineElements.Length}.");
                return false;
            }

            n = int.Parse(firstLineElements[0]);
            v = int.Parse(firstLineElements[1]);
            w = int.Parse(firstLineElements[2]);

            

            Graph = new LinkedList<int>[n + 1];
            for (int index = 0; index < n; index++)
            {
                Console.WriteLine($"{listA[index + 1]}");

                Graph[index + 1] = new LinkedList<int>();
                string[] subs = listA[index + 1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string item in subs)
                {
                    if ((index + 1) < int.Parse(item))
                    {
                        AddEdge(index + 1, int.Parse(item));
                    }
                }
            }

            return true;
        }

        public void AddEdge(int v, int w)
        {
            Graph[v].AddLast(w);
        }

        
    }
}
