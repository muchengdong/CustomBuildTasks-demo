using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class GridAbsolutePerfectSerpentine
    {

        public struct PhotoCell
        {
            public int PhysicalRow { get; set; } // 相机实际去的物理行 (4 -> 0)
            public int PhysicalCol { get; set; } // 相机实际去的物理列 (S型)
            public int StitchRow { get; set; }   // 对应的拼图目标行 (从上往下：0 -> 4)
            public int StitchCol { get; set; }   // 对应的拼图目标列 (严格从左往右：0 -> 4)

            public PhotoCell(int pRow, int pCol, int sRow, int sCol)
            {
                PhysicalRow = pRow; PhysicalCol = pCol;
                StitchRow = sRow; StitchCol = sCol;
            }
        }

        public static void test2233()
        {
            const int Size = 5;
            List<PhotoCell> normalList = new List<PhotoCell>();

            // 1. 物理相机从最下面的物理第 4 行，一直走到最上面的物理第 0 行
            for (int pRow = Size - 1; pRow >= 0; pRow--)
            {
                // 拼图行从 0 走到 4 (从上往下拼接)
                int sRow = (Size - 1) - pRow;

                // 根据拼图行的奇偶性，控制物理相机的 S 型转行逻辑
                if (sRow % 2 == 0)
                {
                    // 【偶数拼图行：物理从左 -> 右】
                    // 相机物理移动从 0 到 4 递增 (例如第一行从 4x0 走到 4x4)
                    // 拼图贴图位置同样从 0 到 4 递增 (从左往右)
                    int sCol = 0;
                    for (int pCol = 0; pCol < Size; pCol++)
                    {
                        normalList.Add(new PhotoCell(pRow, pCol, sRow, sCol));
                        sCol++;
                    }
                }
                else
                {
                    // 【奇数拼图行：物理从右 -> 左】
                    // 相机物理移动从 4 到 0 递减 (紧接上一行末尾，原地向上提一格，开始往左走)
                    // 拼图贴图位置从 4 到 0 递减 (倒着映射，确保拼图界面上在这一行依然是从左往右拼)
                    int sCol = Size - 1;
                    for (int pCol = Size - 1; pCol >= 0; pCol--)
                    {
                        normalList.Add(new PhotoCell(pRow, pCol, sRow, sCol));
                        sCol--; // 拼图列倒着赋，抵消相机的反向移动
                    }
                }
            }

            // 2. 将生成好的正向物理顺序，“反向”压入先进后出的栈中
            Stack<PhotoCell> sPath = new Stack<PhotoCell>();
            for (int i = normalList.Count - 1; i >= 0; i--)
            {
                sPath.Push(normalList[i]);
            }

            // 3. 您的 while 消费循环，打印验证
            Console.WriteLine("=== 物理相机启动：从第5行第1个格子[4,0]出发 ===");
            int index = 1;
            while (sPath.Count > 0)
            {
                var cell = sPath.Pop();
                Console.WriteLine($"照片 {index:D2} -> 相机位置:[行:{cell.PhysicalRow},列:{cell.PhysicalCol}] | 贴到拼图:[行:{cell.StitchRow},列:{cell.StitchCol}]");
                index++;
            }
        }
    }
}
