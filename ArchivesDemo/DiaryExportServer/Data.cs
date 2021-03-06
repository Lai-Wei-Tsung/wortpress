using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryExportServer
{
    /// <summary>
    /// 測試資料
    /// </summary>
    public static class TestData
    {
        public static List<Diary> Data { get; set; } = new List<Diary>()
        {
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "2",
                Event = "○○○會報",
                Content = "0730 時部長○○○先生於○○○會議室，主持「○○○會報」，參謀○長○○○上將、軍○副部長○○○上將、軍○副部長○○○上將、陸軍○參謀總長○行官○○○上將等各級長官計26員與會。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "2",
                Event = "全球資訊網站維護驗收",
                Content = "1000 時○○○○處簡任編纂○○○先生於博愛樓辦公室，主持「107年○○○全球資訊網站維護等3項第2期驗收」，主驗人○○○○處簡任編纂○○○先生、會驗人○○○○處○○○科員、協驗人○○○○處○○○上尉、監辦人主計室○○○稽核及○○綜合處監察官○○○中校辦理驗收。驗收結果：抽驗相關資料，承商「○○○○股份有限公司」均按合約規範執行，驗收合格。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "2",
                Event = "簽署儀式",
                Content = "1030 時○○○○次長○○○中將與美國史丹佛大學胡佛研究所副所長Dr. E○○○ W○○○○於○○○○史館，共同簽署「○○○圖書館與胡佛研究所圖書檔案館史料合作備忘錄」，觀禮人員美國史丹佛大學胡佛研究所○○○○部主任○○○博士、○軍司令（指揮）部、○○大學等史政、外事聯絡、智庫及軍事教育相關聯參代表計60員與會，並邀請「○○時報」等12家媒體到部採訪。簽署儀式完成後，副所長Dr. E○○○ W○○○○、○○○博士及媒體記者參觀「國防部部史館」，由○○○○處編譯官○○○上校及史政官○○○中校進行全程導覽。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "2",
                Event = "文物史料蒐整",
                Content = "1100 時民人○○○先生親臨○○○史文物館，致贈其父○○○先生收藏「○軍軍官學校第○期同學錄」之文物，由史政編譯處○○○上校及○○○中校接待，並致贈○○○先生國防部感謝狀乙幀，蒐整之文物由○○○史文物館典藏運用。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "3",
                Event = "專案辦公室揭牌典禮",
                Content = "1000 時○○○○次長○○○中將於○○○○室第1會議室，主持「國防部『○○○○博物館專案辦公室』揭牌典禮」，主任○○○少將率政務綜合處處長○○○少將等5處處長及○○○○博物館籌備處○○○上校等5員合計○○員與會。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "3",
                Event = "人事命令",
                Content = "國防部○○○年○○月○○日國人○○字第○○○○○○○○○○號令核定原任○○察長○○○中將退役，自○○○年○○月○○日生效；另本部○○○年○○月○○日國人○○字第○○○○○○○○○○號令核定海軍陸戰隊○○○中將接任總督察長，自○○○年○○月○○日生效。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "5",
                Event = "監察院巡察",
                Content = "0900 時○○院院長○○○女士、○○及○○委員會○○○召集委員、○○○、○○○、○○○、○○○、○○○等20位委員赴新店○○營區與陽明山○○營區，實施「○○○○局巡察」，國防部○○○○次長○○○中將、○○○報局局長○○○中將、○○○○局○○情研中心主任○○○少將及○○辦公室○○事務處處長○○○少將等20員陪同。"
            },
            new Diary
            {
                IsBold = true,
                CoverDetial = new CoverDetial
                {
                    Year = 118,
                    Month = 1,
                    Day = 6,
                },
                Year = "108",
                Month = "1",
                Day = "6",
                Event = "研討會",
                Content = "0930 時助理次長○○○少將於○○參謀次長室第1會議室，主持「國民革命軍第三軍軍史第2次研討會」，○○○中心主任○○○少將及各副主任、○○○備處副處長○○○上校與會。"
            },
            new Diary
            {
                IsBold = true,
                CoverDetial = new CoverDetial
                {
                    Year = 118,
                    Month = 1,
                    Day = 7,
                },
                Year = "108",
                Month = "1",
                Day = "7",
                Event = "接見行程",
                Content = "1030 時○○○務處處長○○○少將於處長辦公室，接見「美國在臺協會(AIT)連絡組組長李開杰上校(COL Gene L. Richards)」，○○○務處處長○○○少將率○○○務處吳○○中校陪同。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "2",
                Event = "○○○會報",
                Content = "0730 時部長○○○先生於○○○會議室，主持「○○○會報」，參謀○長○○○上將、軍○副部長○○○上將、軍○副部長○○○上將、陸軍○參謀總長○行官○○○上將等各級長官計26員與會。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "7",
                Event = "計畫講習",
                Content = "1400 時○○○參謀總長○○○中將於○○○部○○○室，主持「○○○戰計畫-○○○判斷講習」，由○○○研中心○○○上校擔任授課教官，次長○○○中將率助理次長○○○少將及○○○備處處長○○○上校與會。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "15",
                Event = "會議預報",
                Content = "1630 時部長○○○先生於部長會議室，主持「烽火同舟○○○案會議預報」，次長○○○中將率助理次長○○○少將及聯合情研中心主任○○○少將與會。"
            },
            new Diary
            {
                IsBold = true,
                CoverDetial = new CoverDetial
                {
                    Year = 118,
                    Month = 1,
                    Day = 16,
                },
                Year = "108",
                Month = "1",
                Day = "16",
                Event = "行程預報",
                Content = "0830 時參謀總長○○○上將於參謀總長辦公室，聽取○○外賓專案拜會行程預報，次長○○○中將及○○○務處處長○○○少將與會。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "25",
                Event = "專案預報",
                Content = "0830 時次長○○○中將於次長辦公室，主持「國家書店展售預報」，○○○研中心主任○○○少將與會。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "28",
                Event = "專案預報",
                Content = "1000 時次長○○○中將於次長辦公室，主持「青年日報專報預報」，○○○研中心主任○○○少將與會。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "28",
                Event = "專案預報",
                Content = "1630 時○○○參謀總長○○○中將於國防部第1會議室，主持「○○○府運用國軍電子市場清單系統第2次預報」，助理次長○○○少將、軍備局副局長○○○少將及軍備局生產製造中心第四０一廠廠長○○○上校及情報整備處○○○中校等4員與會。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "28",
                Event = "專案預報",
                Content = "1630 時○○○參謀總長○○○中將於國防部第1會議室，主持「○○○府運用國軍電子市場清單系統第2次預報」，助理次長○○○少將、軍備局副局長○○○少將及軍備局生產製造中心第四０一廠廠長○○○上校及情報整備處○○○中校等4員與會。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "28",
                Event = "專案預報",
                Content = "1630 時○○○參謀總長○○○中將於國防部第1會議室，主持「○○○府運用國軍電子市場清單系統第2次預報」，助理次長○○○少將、軍備局副局長○○○少將及軍備局生產製造中心第四０一廠廠長○○○上校及情報整備處○○○中校等4員與會。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "28",
                Event = "專案預報",
                Content = "1630 時○○○參謀總長○○○中將於國防部第1會議室，主持「○○○府運用國軍電子市場清單系統第2次預報」，助理次長○○○少將、軍備局副局長○○○少將及軍備局生產製造中心第四０一廠廠長○○○上校及情報整備處○○○中校等4員與會。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "28",
                Event = "專案預報",
                Content = "1630 時○○○參謀總長○○○中將於國防部第1會議室，主持「○○○府運用國軍電子市場清單系統第2次預報」，助理次長○○○少將、軍備局副局長○○○少將及軍備局生產製造中心第四０一廠廠長○○○上校及情報整備處○○○中校等4員與會。"
            },
            new Diary
            {
                IsBold = true,
                CoverDetial = new CoverDetial
                {
                    Year = 118,
                    Month = 1,
                    Day = 29,
                },
                Year = "108",
                Month = "1",
                Day = "29",
                Event = "專案預報",
                Content = "0830 時次長○○○中將於次長辦公室，主持「國家書店展售預報」，○○○研中心主任○○○少將與會。"
            },
            new Diary
            {
                IsBold = true,
                CoverDetial = new CoverDetial
                {
                    Year = 118,
                    Month = 1,
                    Day = 30,
                },
                Year = "108",
                Month = "1",
                Day = "30",
                Event = "專案預報",
                Content = "0830 時次長○○○中將於次長辦公室，主持「國家書店展售預報」，○○○研中心主任○○○少將與會。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "30",
                Event = "接見行程",
                Content = "1030 時○○○務處處長○○○少將於處長辦公室，接見「美國在臺協會(AIT)連絡組組長李開杰上校(COL Gene L. Richards)」，○○○務處處長○○○少將率○○○務處吳○○中校陪同。"
            },
            new Diary
            {
                IsBold = false,
                Year = "108",
                Month = "1",
                Day = "30",
                Event = "接見行程",
                Content = "1030 時○○○務處處長○○○少將於處長辦公室，接見「美國在臺協會(AIT)連絡組組長李開杰上校(COL Gene L. Richards)」，○○○務處處長○○○少將率○○○務處吳○○中校陪同。"
            }
        };
    }
}
