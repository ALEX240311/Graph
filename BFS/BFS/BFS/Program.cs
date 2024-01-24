namespace _22DH110153_PhamTuanAnh_LAB_3_
{
    internal class Program
    {   
        static void topPointConnect()
        {
            BT1 bt = new BT1();
            string path = @"D:\TopPoint.txt";
            bt.storeData(path);
            bt.readData(path);
            Console.WriteLine(bt);
            int v = bt.v;
            List<int> p = bt.BFS(v);
            Console.WriteLine("{0} \n {1}",p.Count, string.Join("->",p ));
        }
        static void findingPath()
        {
            BT2_cs bt = new BT2_cs();
            string path = @"D:\FindingPath.txt";
            bt.storeData(path);
            bt.readData(path);
            int v = bt.v;
            int w = bt.w;
            
            List<int> p = bt.PathBFS(v, w);
            Console.WriteLine("So dinh : {0}", p.Count);
            Console.WriteLine(string.Join("->", p));
        }

        static void ConnectingPoint()
        {
            BT3 bt = new BT3();
            string path = @"D:\Connect.txt";
            bt.storeData(path);
            bt.readData(path);
            Console.WriteLine(bt);
            bool isConneted = bt.isConnected();
            Console.WriteLine(isConneted);
            Console.WriteLine(bt.CountConnectedComponents());
        }
        static void Main(string[] args)
        {
            //topPointConnect();
            // findingPath();
            ConnectingPoint();
        }
    }
}
