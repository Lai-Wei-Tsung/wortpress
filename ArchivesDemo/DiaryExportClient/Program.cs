using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * 此專案有載入"MSBuild.ILMerge.Task"將所有參考打包在一個.exe
 */
namespace DiaryExportClient
{
    /// <summary>
    /// 日記匯出Word - 端點程式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Service.Export();
        }
    }
}
