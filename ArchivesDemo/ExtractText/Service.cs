using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region 套件
using Word = Microsoft.Office.Interop.Word;
#endregion

namespace ExtractText
{
    public class Service
    {
        static string basePath = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 取word檔中的純文字內容
        /// </summary>
        public static void ExtractText()
        {
            string sourceFile = Path.Combine(basePath, @"src\測試.docx"); //word檔案路徑
                                                                        //src資料夾目前是手動放入bin\Debug內的

            //檢查目錄是否存在
            if (!Directory.Exists(Path.Combine(basePath, "output")))
            {
                //當目錄不存在時創建一個
                Directory.CreateDirectory(Path.Combine(basePath, "output"));
            }
            string savePath = Path.Combine(basePath, $@"output\output{DateTime.Now.ToFileTime()}.txt");

            var _app = new Word.Application();
            _app.Visible = false; //背景作業
            try
            {
                var _doc = _app.Documents.Open(sourceFile); //開啟Word文件
                string text = _doc.Content.Text; //獲取純文字內容
                File.WriteAllText(savePath, text); //寫入txt檔
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _app.Quit(false);
            }
        }
    }
}
