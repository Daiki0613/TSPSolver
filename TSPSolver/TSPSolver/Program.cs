using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPSolver
{
    public class Christofides
    {
        //public static List<List<double>> Main()
        public static void Main()
        {
            List<List<double>> CoordList = Samples.Sample6();

            int len = CoordList.Count;
            double[,] G = make_graph(CoordList);
            bool[,] MST = prim(len, G);
            int[] order = loop(len, MST, G);
            int[] path = optimize(order, G);

            List<List<double>> res = new List<List<double>>();
            for (int i = 0; i<len; i++) res.Add(new List<double> { CoordList[path[i]][0], CoordList[path[i]][1] });

            Console.WriteLine(total_dist(len, G));
            Console.WriteLine(total_dist(order, G));
            Console.WriteLine(total_dist(path, G));
            return;
            //return res;
        }
        #region グラフ生成
        private static double[,] make_graph(List<List<double>> CoordList)
        {
            int len = CoordList.Count();
            double[,] G = new double[len + 2, len + 2];
            for (int i = 0; i < len; i++) for (int j = i + 1; j < len; j++) //グラフ作成
            {
                double dist = calc_dist(CoordList[i][0], CoordList[i][1], CoordList[j][0], CoordList[j][1]);
                G[i, j] = dist;
                G[j, i] = dist;
            }
            return G;
        }
        #endregion

        #region 距離計算
        private static double calc_dist(double x1, double y1, double x2, double y2)
        {
            //return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
        private static double total_dist(int[] order, double[,] G)
        {
            double ans = 0;
            for (int i = 0; i < order.Length - 1; i++) ans += G[order[i], order[i+1]];
            return ans;
        }
        private static double total_dist(int len, double[,] G)
        {
            double ans = 0;
            for (int i = 0; i < len-1; i++) ans += G[i, i+1];
            return ans;
        }
        #endregion

        #region 最小全域木
        private static bool[,] prim(int n, double[,] G)
        {
            bool[,] MST = new bool[n, n];
            bool[] visited = new bool[n];
            double[] min_cost = Enumerable.Repeat(double.PositiveInfinity, n).ToArray();
            int[] min_index = Enumerable.Repeat(-1, n).ToArray();
            min_cost[0] = 0;
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
        #endregion

        #region 閉回路作成
        private static int[] loop(int n, bool[,] MST, double[,] G)
        {
            List<int> list = new List<int>();
            bool[] visited = new bool[n];
            int visited_count = 0;
            list.Add(0);
            visited[0] = true;
            
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

            dfs(0);
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
        #endregion

        #region 最適化関数
        private static int[] optimize(int[] order, double[,] G)
        {
            
            int n = order.Length;
            { //開回路の最短距離になるよう、開始点と終了点を追加する
                int[] new_order = new int[n + 2];
                new_order[0] = n;
                for (int x = 0; x < n; x++) new_order[x + 1] = order[x];
                new_order[n + 1] = n + 1;
                order = new_order;
            }

            int count = 0;
            while (true)
            {
                count++;
                double loss = three_opt(G, ref order);
                if (loss == 0) break;
                if (count > 1000) break;
            }

            { //開始点と終了点削除
                int[] new_order = new int[n];
                for (int x = 0; x < n; x++) new_order[x] = order[x + 1];
                order = new_order;
            }
            return order;
        }

        private static void reverse(int i, int j, ref int[] order)
        {
            int n = order.Length; 
            int[] new_order = new int[n];
            int index = 0;
            for (int x = 0; x < i + 1; x++) new_order[index++] = order[x % n];
            for (int x = j; x >= i + 1; x--) new_order[index++] = order[x % n];
            for (int x = j + 1; x < n; x++) new_order[index++] = order[x % n];
            order = new_order;
        }
        private static void cycle(int i, int j, int k, ref int[] order) //i→i+1→j→j+1→k→k+1 を i→j+1→k→i+1→j→k+1
        {
            int n = order.Length; 
            int[] new_order = new int[n];
            int index = 0;
            for (int x = 0; x < i + 1; x++) new_order[index++] = order[x % n];
            for (int x = j + 1; x < k + 1; x++) new_order[index++] = order[x % n];
            for (int x = i + 1; x < j + 1; x++) new_order[index++] = order[x % n];
            for (int x = k + 1; x < n; x++) new_order[index++] = order[x % n];
            order = new_order;
        }

        private static double three_opt(double[,] G, ref int[] order)
        {
            int n = order.Length;
            double loss = 0;
            for (int i = 0; i < n-1; i++)
            {
                for (int j = i + 1; j < n-1; j++)
                {
                    for (int k = j + 1; k < n-1; k++)
                    {
                        int A = order[i], B = order[i + 1], C = order[j];
                        int D = order[j + 1], E = order[k], F = order[k + 1];
                        double d0 = G[A, B] + G[C, D] + G[E, F];
                        double d1 = G[A, B] + G[C, E] + G[D, F];
                        double d2 = G[A, C] + G[B, D] + G[E, F];
                        double d3 = G[A, C] + G[B, E] + G[D, F];
                        double d4 = G[A, D] + G[E, B] + G[C, F];
                        double d5 = G[A, D] + G[E, C] + G[B, F];
                        double d6 = G[A, E] + G[D, B] + G[C, F];
                        double d7 = G[A, E] + G[D, C] + G[B, F];

                        if (d0 > d1) { reverse(j, k, ref order); loss = d0 - d1; }
                        else if (d0 > d2) { reverse(i, j, ref order); loss = d0 - d2; }
                        else if (d0 > d3) { reverse(i, k, ref order); cycle(i, j, k, ref order); loss = d0 - d3; }
                        else if (d0 > d4) { cycle(i, j, k, ref order); loss = d0 - d4; }
                        else if (d0 > d5) { reverse(i, j, ref order); cycle(i, j, k, ref order); loss = d0 - d5; }
                        else if (d0 > d6) { reverse(j, k, ref order); cycle(i, j, k, ref order); loss = d0 - d6; }
                        else if (d0 > d7) { reverse(i, k, ref order); loss = d0 - d7; }
                    }
                }
            }
            return loss;
        }
        #endregion
    }
}
