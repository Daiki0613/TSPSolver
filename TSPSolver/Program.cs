using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPSolver
{
    public class Coord
    {
        public int index { get; set; } = 0;
        public string Name { get; set; } = "";
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public Coord(Coord point)
        {
            index = point.index; Name = point.Name; X = point.X; Y = point.Y;
        }
        public Coord(int i, string s, double x, double y)
        {
            index = i; Name = s; X = x; Y = y;
        }
        public Coord(double x, double y)
        {
            X = x; Y = y; 
        }
        public static double dist(Coord a, Coord b)
        {
            double ans = (a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y);
            return ans;
        }
    }
    public class Christofides
    {
        public static void Main()
        {
            List<Coord> CoordList = Samples.Sample2();
            int len = CoordList.Count;
            double[,] G = new double[len,len];
            for (int i = 0; i < len; i++) for(int j = i+1; j < len; j++) //グラフ作成
            {
                double dist = Coord.dist(CoordList[i], CoordList[j]);
                G[i,j] = dist;
                G[j,i] = dist;
            }

            //重心計算
            int index = 0;
            {
                double xg = 0, yg = 0;
                for (int i = 0; i < len; i++)
                {
                    xg += (CoordList[i].X - xg) / (i + 1);
                    yg += (CoordList[i].Y - yg) / (i + 1);
                }
                var c = new Coord(xg, yg);
                double max_dist = 0;
                for (int i = 0; i < len; i++)
                {
                    double dist = Coord.dist(CoordList[i], c);
                    if (dist > max_dist)
                    {
                        dist = max_dist;
                        index = i;
                    }
                }
            }

            bool[,] MST = prim(len, G, index);
            int[] order = loop(len, MST, G, index);
            int[] res = three_opt(len, order, G, 10, index);

            for (int i = 0; i < res.Length; i++)
            {
                for(int j = 0; j < res.Length; j++)
                {
                    if (res[j] == i)
                    {
                        //Console.Write(i);
                        Console.Write(" ");
                        Console.Write(j);
                        Console.WriteLine();
                        break;
                    }
                }
                
            }

            return;
        }
        
        public static bool[,] prim(int n, double[,] G, int start_index = 0)
        {
            bool[,] MST = new bool[n, n];
            bool[] visited = new bool[n];
            double[] min_cost = Enumerable.Repeat(double.PositiveInfinity, n).ToArray();
            int[] min_index = Enumerable.Repeat(-1, n).ToArray();
            min_cost[start_index] = 0;
            while (true)
            {
                int v = -1; //最短距離の頂点 v
                for (int u = 0; u < n; u++)
                {  // コストが最小で行ける頂点 v を探す
                    if (!visited[u] && (v == -1 || min_cost[u] < min_cost[v])) v = u;
                }
                if (v == -1) break;  // MST ができたので終了
                visited[v] = true;
                if (min_index[v] != -1)
                {
                    MST[v, min_index[v]] = true;
                    MST[min_index[v], v] = true;
                }
                for (int u = 0; u < n; u++)
                {  // 確定した頂点から行ける頂点について、最小コストを更新
                    if (min_cost[u] > G[v,u])
                    {
                        min_cost[u] = G[v,u];
                        min_index[u] = v;
                    }
                }
            }
            return MST;
        }

        public static int[] loop(int n, bool[,] MST, double[,] G, int start_index = 0)
        {
            List<int> list = new List<int>();
            bool[] visited = new bool[n];
            int visited_count = 0;
            list.Add(start_index);
            visited[start_index] = true;
            
            void dfs(int u)
            {
                list.Add(u);
                visited[u] = true;
                visited_count++;
                if (visited_count == n) return;
                List<Tuple<int, double>> next = new List<Tuple<int, double>>();
                for (int v=0; v<n; v++)
                {
                    if (!visited[v] && MST[u, v])
                    {
                        next.Add(new Tuple<int, double>(v,G[u,v]));
                    }
                }
                next = next.OrderByDescending(x => x.Item2).ToList();
                for (int i =0; i<next.Count; i++)
                {
                    int v = next[i].Item1;
                    MST[u, v] = false; MST[v, u] = false;
                    dfs(v);
                }
            }

            dfs(start_index);
            visited = new bool[n];
            int[] result = new int[n];
            int index = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int next = list[i];
                if (!visited[next])
                {
                    visited[next] = true;
                    result[index] = next;
                    index++;
                }
            }
            return result;
        }

        public static int[] three_opt(int n, int[] order, double[,] G, int rep = 10, int start_index = 0)
        {
            void reverse(int i, int j)
            {
                int[] new_order = new int[n];
                int index = 0;
                for (int x = 0; x < i+1; x++) new_order[index++] = order[(start_index+x)%n];
                for (int x = j; x >= i+1; x--) new_order[index++] = order[(start_index+x)%n];
                for (int x = j+1; x < n; x++) new_order[index++] = order[(start_index+x)%n];
                order = new_order;
            }
            void cycle(int i, int j, int k) //i→i+1→j→j+1→k→k+1 を i→j+1→k→i+1→j→k+1
            {
                int[] new_order = new int[n];
                int index = 0;
                for (int x = 0; x < i+1; x++) new_order[index++] = order[(start_index+x)%n];
                for (int x = j+1; x < k+1; x++) new_order[index++] = order[(start_index+x)%n];
                for (int x = i+1; x < j+1; x++) new_order[index++] = order[(start_index+x)%n];
                for (int x = k+1; x < n; x++) new_order[index++] = order[(start_index+x)%n];
            }
            for (int _ = 0; _ < rep; _++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        for (int k = j + 1; k < n; k++)
                        {
                            int A = order[(start_index+i)%n], B = order[(start_index+i+1)%n], C = order[(start_index+j)%n];
                            int D = order[(start_index+j+1)%n], E = order[(start_index+k)%n], F = order[(start_index+k+1) % n];
                            double d0 = G[A, B] + G[C, D] + G[E, F];
                            double d1 = G[A, C] + G[B, D] + G[E, F];
                            double d2 = G[A, B] + G[C, E] + G[D, F];
                            double d3 = G[A, D] + G[E, B] + G[C, F];
                            double d4 = G[F, B] + G[C, D] + G[E, A];

                            if (d0 > d1)
                            {
                                reverse(i, j);
                            }
                            else if (d0 > d2)
                            {
                                reverse(j, k);
                            }
                            else if (d0 > d4)
                            {
                                reverse(i, k);
                            }
                            else if (d0 > d3)
                            {
                                cycle(i, j, k);
                            }
                        }
                    }
                }
            }
            return order;
        }
    }
}
