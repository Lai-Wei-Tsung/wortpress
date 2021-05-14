using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryExportClient
{
    /// <summary>
    /// 日記主要資料結構
    /// </summary>
    public class Diary
    {
        /// <summary>
        /// 是否設置為粗體(機敏文字)
        /// </summary>
        public bool IsBold { get; set; }
        /// <summary>
        /// 機敏保密期限
        /// </summary>
        public CoverDetial CoverDetial { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public string Month { get; set; }
        /// <summary>
        /// 日
        /// </summary>
        public string Day { get; set; }
        /// <summary>
        /// 項目
        /// </summary>
        public string Event { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public string Content { get; set; }
    }

    /// <summary>
    /// 機敏保密期限資訊
    /// </summary>
    public class CoverDetial
    {
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 日
        /// </summary>
        public int Day { get; set; }
    }
}
