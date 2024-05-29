using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMergeTool
{
    /// <summary>
    /// 排序方法
    /// </summary>
    public enum BinFileSort
    {
        None,       /* 0.不排序 */
        Id,         /* 1.ID排序 */
        FileName,   /* 2.文件名排序 */
        FileSize,   /* 3.文件大小排序 */
    }

    //
    // 摘要:
    //     指定列表中的项的排序方式。
    public enum BinFileOrder
    {
        //
        // 摘要:
        //     项不排序。
        None = 0,
        //
        // 摘要:
        //     这些项按升序排序。
        Ascending = 1,
        //
        // 摘要:
        //     这些项按降序排序。
        Descending = 2
    }


    /// <summary>
    /// 文件信息类
    /// </summary>
    public class BinFileInfo
    {
        public int Id { get; set; } /* 索引 */
        public string FileName { get; set; } /* 文件名 */
        public int FileSize { get; set; } /* 文件大小 */
        public int Offset { get; set; } /* 偏移 */
        public int Align { get; set; } /* 对齐 */
        public byte PadValue { get; set; } /* 填充数据 */
        public int PadSize { get => Align - (int)(FileSize % Align); } /* 填充大小 */
    }


    /// <summary>
    /// 文件信息列表操作类
    /// </summary>
    static public class BinFileInfoEx
    {
        static List<BinFileInfo> _bfi = new List<BinFileInfo>();

        static private string PadLeft(this string str, int totalByteCount, char c)
        {
            Encoding coding = Encoding.GetEncoding("gb2312");
            int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (coding.GetByteCount(ch.ToString()) == 2)
                    dcount++;
            }
            string w = str.PadRight(totalByteCount - dcount, c);
            return w;
        }

        static private string PadRight(this string str, int totalByteCount, char c)
        {
            Encoding coding = Encoding.GetEncoding("gb2312");
            int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (coding.GetByteCount(ch.ToString()) == 2)
                    dcount++;
            }
            string w = str.PadRight(totalByteCount - dcount, c);
            return w;
        }


        /// <summary>
        /// 返回实例
        /// </summary>
        /// <returns></returns>
        static public List<BinFileInfo> Instance()
        {
            return _bfi;
        }

        /// <summary>
        /// 返回总大小
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        static public long TotalSize(this List<BinFileInfo> dic)
        {
            if (dic == null) return 0;

            var size = 0L;

            dic.ForEach(i => size += (i.FileSize + i.PadSize));

            return size;
        }

        /// <summary>
        /// 刷新索引
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        static public List<BinFileInfo> Refresh(this List<BinFileInfo> dic)
        {
            if (dic == null) return dic;
            var offset = 0;

            dic.ForEach(i =>
            {
                i.Id = dic.IndexOf(i);
                i.Offset = offset;
                offset += i.FileSize + i.PadSize;
            });

            return dic;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="fileName"></param>
        /// <param name="align"></param>
        /// <param name="pad"></param>
        /// <returns></returns>
        static public List<BinFileInfo> Add(this List<BinFileInfo> dic, string fileName, int align, byte pad)
        {
            if (dic == null) return dic;
            if (!File.Exists(fileName)) return dic;

            var fi = new FileInfo(fileName);
            dic.Add(new BinFileInfo
            {
                Id = dic.Count,
                FileName = fi.FullName,
                FileSize = (int)fi.Length,
                Offset = (int)dic.TotalSize(),
                Align = align,
                PadValue = pad,
            });

            return dic;
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        static public List<BinFileInfo> Modify(this List<BinFileInfo> dic, int id, int offset, int align, byte pad)
        {
            if (dic == null) return dic;

            var item = dic.Find(i => i.Id == id);
            item.Offset = offset;
            item.Align = align;
            item.PadValue = pad;

            return dic;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        static public List<BinFileInfo> Delete(this List<BinFileInfo> dic, int id)
        {
            if (dic == null) return dic;

            var ix = dic.FindIndex(i => i.Id == id);
            dic.RemoveAt(ix);
            dic.Refresh();

            return dic;
        }


        /// <summary>
        /// 排序功能
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        static public List<BinFileInfo> Sort(this List<BinFileInfo> dic, BinFileSort column, BinFileOrder order)
        {
            if (dic == null) return dic;

            dic.Sort((x,y) =>
            {
                var result = 0;
                var xLength = Encoding.Default.GetByteCount(x.FileName);
                var yLength = Encoding.Default.GetByteCount(y.FileName);

                switch (column)
                {
                    case BinFileSort.Id:
                        result = x.Id == y.Id ? 0 : x.Id < y.Id ? -1 : 1;
                        break;
                    case BinFileSort.FileName:
                        result = xLength == yLength ? string.Compare(x.FileName, y.FileName) : xLength < yLength ? -1 : 1;
                        break;
                    case BinFileSort.FileSize:
                        result = x.FileSize == y.FileSize ? 0 : x.FileSize < y.FileSize ? -1 : 1;
                        break;

                    default:
                        order = BinFileOrder.None;
                        break;
                }

                return order == BinFileOrder.Descending ? -result : result;
            });
            dic.Refresh();

            return dic;
        }


        /// <summary>
        /// 合并文件
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="outpath"></param>
        /// <param name="ext">包括扩展名</param>
        /// <returns></returns>
        static public List<BinFileInfo> Merge(this List<BinFileInfo> dic, string outpath, bool ext)
        {
            if (dic == null) return dic;

            var offset = 0;
            var fs_write = File.Open(outpath, FileMode.Create);
            StreamWriter sw_txt = new StreamWriter(outpath + ".txt");

            sw_txt.Write(@"
本文件由FileMergeTool创建

/* FileInfo */
typedef struct _FileInfo
{
    uint8_t id;         /* 索引 */
    char* name;         /* 名字 */
    uint32_t offset;    /* 偏移 */
    uint32_t size;      /* 大小 */
}FileInfo;

/* 文件信息索引 */
static const FileInfo _infos[] = {
    /* 索引 文件名                                                       偏移量      大小       */
");

            foreach (var i in dic)
            {
                var fs_read = File.Open(i.FileName, FileMode.Open);  //创建文件对象
                var buff = Enumerable.Repeat(i.PadValue, (int)(fs_read.Length + i.PadSize)).ToArray();
                var name = ext ? Path.GetFileName(i.FileName) : Path.GetFileNameWithoutExtension(i.FileName);

                fs_read.Read(buff, 0, (int)fs_read.Length);
                fs_read.Close();

                fs_write.Write(buff, 0, buff.Length);
                sw_txt.Write($"    {{ {i.Id,3:D}, {PadRight("\""+name+"\"", 60, ' ')}, 0x{i.Offset:X08}, 0x{i.FileSize:X08}, }},\r\n");

                offset += buff.Length;
            }

            sw_txt.Write(@"
};
");
            fs_write.Close();
            sw_txt.Close();

            return dic;
        }

    }
}
