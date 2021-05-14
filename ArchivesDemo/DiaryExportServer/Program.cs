using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryExportServer
{
    /// <summary>
    /// 日記匯出Word - Server端資料處理、轉成json檔、回傳zip包給使用者下載
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //...
            
            //將select出的資料轉json格式
            Service.ExportData();

            //...
            //把.dotx、.json、.exe(端點程式)包成zip檔回傳給使用者
        }
    }
}
