using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region 套件
using Newtonsoft.Json;
#endregion

namespace DiaryExportServer
{
    public class Service
    {
        /// <summary>
        /// 將測試資料匯出成.json檔
        /// </summary>
        public static void ExportData()
        {

            List<Diary> data = TestData.Data; //取得資料
            string jsonData = JsonConvert.SerializeObject(data); //轉json格式

            string basePath = AppDomain.CurrentDomain.BaseDirectory; //應用程式路徑
            string filePaht = "output";
            string fileName = "data.json";

            //檢查目錄是否存在
            if (!Directory.Exists(Path.Combine(basePath, filePaht)))
            {
                //當目錄不存在時創建一個
                Directory.CreateDirectory(Path.Combine(basePath, filePaht));
            }

            string outputPath = Path.Combine(basePath, filePaht, fileName); //匯出資料夾及檔案名稱

            File.WriteAllText(outputPath, jsonData);
        }
    }
}
