using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FileMergeTool
{
    /// <summary>
    /// ListView排序器,继承自IComparer
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// 声明CaseInsensitiveComparer类对象
        /// </summary>
        private IComparer ObjectCompare;
        /// <summary>
        /// 虚排序方法
        /// </summary>
        private Action<IComparer> ListSort;
        /// <summary>
        /// 自定义比较器
        /// </summary>
        private Func<string, string, int> Comparer;

        /// <summary>
        /// 获取或设置按照哪一列排序.
        /// </summary>
        public int SortColumn { set; get; }
        /// <summary>
        /// 获取排序列名称
        /// </summary>
        public string SortColumnName { set; get; }
        /// <summary>
        /// 获取或设置排序方式.
        /// </summary>
        public SortOrder Order { set; get; }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="listSort">虚排序方法</param>
        /// <param name="comparer">自定义比较器</param>
        public ListViewColumnSorter(Action<IComparer> listSort = null, Func<string, string, int> comparer = null)
        {
            // 初始化CaseInsensitiveComparer类对象
            ObjectCompare = new CaseInsensitiveComparer();
            ListSort = listSort;
            Comparer = comparer;

            // 默认按第一列排序
            SortColumn = 0;
            SortColumnName = string.Empty;
            // 排序方式为不排序
            Order = SortOrder.None;
        }


        /// <summary>
        /// 判断是否为正确的IP地址，IP范围（0.0.0.0～255.255.255）
        /// </summary>
        /// <param name="ip">需验证的IP地址</param>
        /// <returns></returns>
        private bool IsIP(String ip)
        {
            return Regex.Match(ip, @"^((2[0-4]\d|25[0-5]|[1-9]?\d|1\d{2})\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$").Success;
        }

        /// <summary>
        /// 比较两个数字的大小
        /// </summary>
        /// <param name="ipx">要比较的第一个对象</param>
        /// <param name="ipy">要比较的第二个对象</param>
        /// <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        private int CompareInt(int x, int y)
        {
            if (x > y)
            {
                return 1;
            }
            else if (x < y)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 比较两个IP地址的大小
        /// </summary>
        /// <param name="ipx">要比较的第一个对象</param>
        /// <param name="ipy">要比较的第二个对象</param>
        /// <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        private int CompareIp(string ipx, string ipy)
        {
            string[] ipxs = ipx.Split('.');
            string[] ipys = ipy.Split('.');

            for (int i = 0; i < 4; i++)
            {
                if (Convert.ToInt32(ipxs[i]) > Convert.ToInt32(ipys[i]))
                {
                    return 1;
                }
                else if (Convert.ToInt32(ipxs[i]) < Convert.ToInt32(ipys[i]))
                {
                    return -1;
                }
                else
                {
                    continue;
                }
            }
            return 0;
        }

        /// <summary>
        /// 重写IComparer接口.
        /// </summary>
        /// <param name="x">要比较的第一个对象</param>
        /// <param name="y">要比较的第二个对象</param>
        /// <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        private int Compare(ListViewItem listviewX, ListViewItem listviewY)
        {
            int compareResult;
            string xText = listviewX.SubItems[SortColumn].Text;
            string yText = listviewY.SubItems[SortColumn].Text;

            int xInt, yInt;

            // 比较,如果值为IP地址，则根据IP地址的规则排序。
            if (IsIP(xText) && IsIP(yText))
            {
                compareResult = CompareIp(xText, yText);
            }
            else if (int.TryParse(xText, out xInt) && int.TryParse(yText, out yInt)) //是否全为数字
            {
                //比较数字
                compareResult = CompareInt(xInt, yInt);
            }
            else if (Comparer != null)
            {
                compareResult = Comparer(xText, yText);
            }
            else
            {
                //比较对象
                compareResult = ObjectCompare.Compare(xText, yText);
            }

            // 根据上面的比较结果返回正确的比较结果
            if (Order == SortOrder.Ascending)
            {
                // 因为是正序排序，所以直接返回结果
                return compareResult;
            }
            else if (Order == SortOrder.Descending)
            {
                // 如果是反序排序，所以要取负值再返回
                return (-compareResult);
            }
            else
            {
                // 如果相等返回0
                return 0;
            }
        }


        /// <summary>
        /// 重写IComparer接口.
        /// </summary>
        /// <param name="x">要比较的第一个对象</param>
        /// <param name="y">要比较的第二个对象</param>
        /// <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        public int Compare(object x, object y)
        {
            ListViewItem listviewX, listviewY;

            // 将比较对象转换为ListViewItem对象
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            return Compare(listviewX, listviewY);
        }

        /// <summary>
        /// 排序
        /// </summary>
        public bool Sort()
        {
            // 用新的排序方法对ListView排序
            if (ListSort != null)
            {
                ListSort(this);
            }

            return ListSort != null;
        }

    }


    /// <summary>
    /// 对ListView点击列标题自动排序功能
    /// </summary>
    public static class ListViewExtension
    {
        /// <summary>
        /// 列点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnColumnClick(object sender, ColumnClickEventArgs e)
        {
            var lv = sender as ListView;
            var sorter = lv.ListViewItemSorter as ListViewColumnSorter;

            // 检查点击的列是不是现在的排序列.
            if (e.Column == sorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                if (sorter.Order == SortOrder.Ascending)
                {
                    sorter.Order = SortOrder.Descending;
                }
                else
                {
                    sorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // 设置排序列，默认为正向排序
                sorter.SortColumn = e.Column;
                sorter.SortColumnName = lv.Columns[e.Column].Tag as string;
                sorter.Order = SortOrder.Ascending;
            }

            // 用新的排序方法对ListView排序
            if (!sorter.Sort())
            {
                lv.Sort();
            }
        }


        /// <summary>
        /// 初始化ListView列排序
        /// </summary>
        /// <param name="listView">ListView控件</param>
        /// <param name="listSort">虚排序方法</param>
        /// <param name="comparer">自定义排序器</param>
        public static void InitializeColumnSort(this ListView listView, Action<IComparer> listSort = null, Func<string, string, int> comparer = null)
        {
            listView.ListViewItemSorter = new ListViewColumnSorter(listSort, comparer);
            listView.ColumnClick += new ColumnClickEventHandler(OnColumnClick);
        }
    }
}
