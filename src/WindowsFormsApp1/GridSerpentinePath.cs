using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AntdUI.Table;

namespace WindowsFormsApp1
{
    internal class GridSerpentinePath
    {
        public struct Point
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public Point(int r, int c) { Row = r; Col = c; }
            public override string ToString() => $"[{Row},{Col}]";
        }


        public static void test() {

            const int Size = 5;
            List<Point> sPath = new List<Point>();

            // 遍历每一行
            for (int i = 0; i < Size; i++)
            {
                // 如果是偶数行 (0, 2, 4)：从左向右走 (0 -> Size-1)
                if (i % 2 == 0)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        sPath.Add(new Point(i, j));
                    }
                }
                // 如果是奇数行 (1, 3)：从右向左走 (Size-1 -> 0) —— 实现 S 型拐弯
                else
                {
                    for (int j = Size - 1; j >= 0; j--)
                    {
                        sPath.Add(new Point(i, j));
                    }
                }
            }

            // ---- 打印结果 ----
            Console.WriteLine("=== 5x5 方格 S 型(蛇形)行走路径 ===");

            // 1. 打印详细坐标序列
            for (int k = 0; k < sPath.Count; k++)
            {
                Console.Write(sPath[k]);
                if (k < sPath.Count - 1) Console.Write(" -> ");
                if ((k + 1) % Size == 0) Console.WriteLine(); // 换行打印方便看
            }

            // 2. 模拟行走顺序可视化
            Console.WriteLine("\n=== 行走顺序步数地图 ===");
            int[,] stepMap = new int[Size, Size];
            for (int step = 0; step < sPath.Count; step++)
            {
                var p = sPath[step];
                stepMap[p.Row, p.Col] = step + 1; // 记录是第几步
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write($"{stepMap[i, j]:D2}  ");
                }
                Console.WriteLine();
            }
        }




        public static void test2()
        {

            const int Size = 5;
            var sPath = new Queue<Point>();

            // 遍历每一行
            for (int i = 0; i < Size; i++)
            {
                // 如果是偶数行 (0, 2, 4)：从左向右走 (0 -> Size-1)
                if (i % 2 == 0)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        sPath.Enqueue(new Point(i, j));
                    }
                }
                // 如果是奇数行 (1, 3)：从右向左走 (Size-1 -> 0) —— 实现 S 型拐弯
                else
                {
                    for (int j = Size - 1; j >= 0; j--)
                    {
                        sPath.Enqueue(new Point(i, j));
                    }
                }
            }

            // ---- 打印结果 ----
            Console.WriteLine("=== 5x5 方格 S 型(蛇形)行走路径 ===");

            Point cell;

            sPath.Peek();
            // 1. 打印详细坐标序列
            for (int k = 0; k < sPath.Count; k++)
            {
                Console.Write(sPath.ElementAt(k));
                if (k < sPath.Count - 1) Console.Write(" -> ");
                if ((k + 1) % Size == 0) Console.WriteLine(); // 换行打印方便看
            }

            // 2. 模拟行走顺序可视化
            Console.WriteLine("\n=== 行走顺序步数地图 ===");
            int[,] stepMap = new int[Size, Size];
            for (int step = 0; step < sPath.Count; step++)
            {
                var p = sPath.ElementAt(step);
                stepMap[p.Row, p.Col] = step + 1; // 记录是第几步
            }

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write($"{stepMap[i, j]:D2}  ");
                }
                Console.WriteLine();
            }
        }
    }
}
