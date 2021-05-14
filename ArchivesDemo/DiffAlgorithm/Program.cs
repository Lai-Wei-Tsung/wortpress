using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region 套件
using DiffMatchPatch;
#endregion
/// google/diff - match - patch
/// https://github.com/google/diff-match-patch/wiki/Language:-C%23

namespace DiffAlgorithm
{
    class Program
    {

        static void Main(string[] args)
        {
            string before = StringData.Before;
            string after = StringData.After;

            //string before = @$"測試文字123";
            //string after = @$"測試文字456";

            diff_match_patch dmp = new diff_match_patch();
            List<Diff> diff = dmp.diff_main(before, after);
            // Result: [(-1, "Hell"), (1, "G"), (0, "o"), (1, "odbye"), (0, " World.")]
            dmp.diff_cleanupSemantic(diff);
            // Result: [(-1, "Hello"), (1, "Goodbye"), (0, " World.")]
            for (int i = 0; i < diff.Count; i++)
            {
                switch (diff[i].operation)
                {
                    case Operation.EQUAL: //未修改字段
                        Console.Write(diff[i].text);
                        break;
                    case Operation.DELETE: //刪除字段
                        Console.BackgroundColor = ConsoleColor.Red; //紅色背景
                        Console.Write(diff[i].text);
                        Console.BackgroundColor = ConsoleColor.Black; //還原為黑色背景
                        break;
                    case Operation.INSERT: //新增字段
                        Console.BackgroundColor = ConsoleColor.Green; //綠色背景
                        Console.Write(diff[i].text);
                        Console.BackgroundColor = ConsoleColor.Black; //還原為黑色背景
                        break;
                    default:
                        break;
                }
            }

            string html = dmp.diff_prettyHtml(diff);
            Console.WriteLine("Html結果-------------------------------");
            Console.WriteLine(html);
            Console.ReadKey();
        }
    }
}
