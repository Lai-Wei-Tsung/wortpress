using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region 套件
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Newtonsoft.Json;
#endregion

namespace DiaryExportClient
{
    public class Service
    {
        static string basePath = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 解析json檔
        /// </summary>
        /// <returns></returns>
        public static List<Diary> GetData()
        {
            List<Diary> data = new List<Diary>();
            string dataPath = Path.Combine(basePath, @"src\data.json"); //直接跑專案的話要把"src"資料夾放在 bin\Debug 目錄下
                                                                        //src資料夾內的檔案目前是手動放的
            try
            {
                using (StreamReader sr = new StreamReader(dataPath))
                {
                    string json = sr.ReadToEnd();
                    data = JsonConvert.DeserializeObject<List<Diary>>(json);
                }
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine(e.Message);
#endif
                //throw e;
            }
            return data;
        }

        /// <summary>
        /// 日記寫入Word
        /// </summary>
        public static void Export()
        {
            string tocDotx = Path.Combine(basePath, @"src\大事紀要_template_toc.dotx");
            string contentDotx = Path.Combine(basePath, @"src\大事紀要_template_content.dotx");

            //檢查目錄是否存在
            if (!Directory.Exists(Path.Combine(basePath, "output")))
            {
                //當目錄不存在時創建一個
                Directory.CreateDirectory(Path.Combine(basePath, "output"));
            }
            string savePath = Path.Combine(basePath, @"output\output.docx");

            Word.Application _app = new Word.Application();
            _app.Visible = true; //顯示腳本作業
            //_app.Visible = false; //背景腳本作業
            Word.Document _doc = _app.Documents.Add(tocDotx);
            Word.Document _doc2 = _app.Documents.Add(contentDotx);

            // 取代年份
            Word.Bookmark bookmark = _doc.Bookmarks["TocTitleYear"];
            bookmark.Select();
            Word.Find findObj = _app.Selection.Find;
            findObj.Text = "000";
            findObj.Replacement.Text = "108";
            findObj.Execute(Replace: Word.WdReplace.wdReplaceAll);

            _app.Selection.GoTo(Word.WdGoToItem.wdGoToPercent, Word.WdGoToDirection.wdGoToLast);
            _app.Selection.Select();
            // 插入表格
            _doc2.Activate();
            var table = _doc2.Tables.Add(_app.Selection.Range, 3, 4);
            // 設定表格框線
            table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            table.Borders.InsideLineWidth = Word.WdLineWidth.wdLineWidth050pt;
            table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            table.Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth150pt;
            // 表格置中對齊
            table.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;
            table.Title = "○○○○室";
            // 設定第一欄 月 0.92公分
            table.Columns[1].SetWidth(_app.CentimetersToPoints(0.92f), Word.WdRulerStyle.wdAdjustSameWidth);
            // 設定第二欄 日 0.92公分
            table.Columns[2].SetWidth(_app.CentimetersToPoints(0.92f), Word.WdRulerStyle.wdAdjustSameWidth);
            // 設定第三欄 項目 3.21公分
            table.Columns[3].SetWidth(_app.CentimetersToPoints(3.21f), Word.WdRulerStyle.wdAdjustSameWidth);
            // 設定第四欄 內容 10.82公分
            table.Columns[4].SetWidth(_app.CentimetersToPoints(10.82f), Word.WdRulerStyle.wdAdjustSameWidth);

            // 寫入表格標題、合併首行儲存格
            string title = "○○○○室";
            string yearTitle = "000年大事紀要";
            table.Rows[1].HeightRule = Word.WdRowHeightRule.wdRowHeightExactly;
            table.Rows[1].Height = _app.CentimetersToPoints(1.3f);
            table.Cell(1, 1).Merge(table.Cell(1, 4));
            table.Cell(1, 1).Range.set_Style("日記上冊標題");
            table.Cell(1, 1).Range.Text = title + yearTitle;

            // 寫入表格欄位描述
            // 設定欄位描述固定高度 0.8公分
            table.Rows[2].HeightRule = Word.WdRowHeightRule.wdRowHeightExactly;
            table.Rows[2].Height = _app.CentimetersToPoints(0.8f);
            table.Rows[2].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            table.Rows[2].Select();
            _app.Selection.set_Style("日記欄位");

            table.Cell(2, 1).Range.Text = "月";
            table.Cell(2, 2).Range.Text = "日";
            table.Cell(2, 3).Range.Text = "項目";
            table.Cell(2, 4).Range.Text = "內容";

            table.Cell(3, 1).Range.set_Style("日記日期");
            table.Cell(3, 2).Range.set_Style("日記日期");
            table.Cell(3, 3).Range.set_Style("日記內文");
            table.Cell(3, 4).Range.set_Style("日記內文");

            // 寫入內文
            #region 物件測試資料
            var data = GetData();
            List<CoverDetial> coverStash = new List<CoverDetial>();
            int iRow = 3;
            int startPage = _app.Selection.Range.get_Information(Word.WdInformation.wdActiveEndPageNumber);
            int endPage;
            data.ForEach(e =>
            {
                Console.WriteLine($"寫入：{e.Month}月{e.Day}日 {e.Event}, 機敏：{e.IsBold}"); //log
                if (iRow > 3)
                {
                    table.Rows.Add(); //寫入第一行內文之後才要換行
                }

                // 寫入資料列
                table.Cell(iRow, 1).Range.Text = e.Month;
                table.Cell(iRow, 2).Range.Text = e.Day;
                table.Cell(iRow, 3).Range.Text = e.Event;
                table.Cell(iRow, 4).Range.Text = e.Content;

                // 判斷有無機敏(目前是整列粗體顯示)
                if (e.IsBold)
                {
                    table.Rows[iRow].Select();
                    _app.Selection.Font.Bold = 1;

                    // 加入機敏期限暫存列
                    coverStash.Add(e.CoverDetial);
                }
                else
                {
                    table.Rows[iRow].Select();
                    _app.Selection.Font.Bold = 0;
                }

                // 判斷有無跨頁，當跨頁時判斷插入機敏文字方塊
                endPage = _app.Selection.Range.get_Information(Word.WdInformation.wdActiveEndPageNumber);
                if (startPage < endPage || data.IndexOf(e) == data.Count - 1)
                {
                    // 若前頁有機敏文字
                    if (coverStash.Any())
                    {
                        coverStash = coverStash.OrderByDescending(x => x.Year)
                                               .ThenByDescending(x => x.Month)
                                               .ThenByDescending(x => x.Day)
                                               .ToList();
                        CoverDetial cover = coverStash.First();
                        // 游標移到指定頁
                        _app.Selection.GoTo(Word.WdGoToItem.wdGoToPage, Word.WdGoToDirection.wdGoToAbsolute, startPage);
                        // 插入文字方塊
                        float left = _app.CentimetersToPoints(-0.25f) // 距左邊界-0.25公分
                            , top = _app.CentimetersToPoints(-1f) // 距上邊界-1公分
                            , width = _app.CentimetersToPoints(16.28f) // 寬16.28公分
                            , height = 20; // 高2倍字元(pt)
                        Word.Shape textBox = _doc2.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, left, top, width, height, _app.Selection.Range);
                        textBox.Line.Visible = Office.MsoTriState.msoFalse; // 取消顯示外框
                        textBox.WrapFormat.Type = Word.WdWrapType.wdWrapFront; // 文字在後

                        textBox.RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionLeftMarginArea;
                        textBox.Left = left;
                        textBox.RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionTopMarginArea;
                        textBox.Top = top;
                        textBox.TextFrame.TextRange.set_Style("頁首");
                        textBox.TextFrame.TextRange.Text = $"機密(本件屬國家機密亦屬軍事機密，保密至民國{cover.Year}年{cover.Month}月{cover.Day}日解除密等)";

                        // 清空機敏期限暫存列
                        coverStash.Clear();

                        // 如果跨頁的列是機敏，再將它加入暫存列
                        if (e.IsBold)
                        {
                            coverStash.Add(e.CoverDetial);
                        }

                        // 回到表格最後一列
                        table.Rows[iRow].Select();
                    }
                }

                // 迭代至下一列
                iRow++;
                // 紀錄下一列操作之前的起始頁
                startPage = _app.Selection.Range.get_Information(Word.WdInformation.wdActiveEndPageNumber);
            });
            #endregion


            // 全選
            _app.ActiveDocument.Range(_app.ActiveDocument.Content.Start, _app.ActiveDocument.Content.End).Select();
            // 複製
            _app.Selection.Copy();
            // 回到有目錄的範本
            _doc.Activate();
            // 貼上
            _app.Selection.Paste();

            // 將最後一行的段落設定為固定行高 1點，以避免產生空白頁
            //_app.Selection.GoTo(Word.WdGoToItem.wdGoToPercent, Word.WdGoToDirection.wdGoToLast);
            //_app.Selection.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceExactly;
            //_app.Selection.ParagraphFormat.LineSpacing = 1.0f;

            _doc.TablesOfFigures[1].Update();
            //_doc.TablesOfFigures[2].Update();
            _doc.SaveAs2(savePath);
            _doc2.Close(false);
            //_doc.Close(false);
            //_app.Quit(false);
        }
    }
}
