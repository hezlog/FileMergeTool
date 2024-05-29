using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMergeTool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 窗体加载成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            listView_files.InitializeColumnSort(
                (x) => {
                    var xx = x as ListViewColumnSorter;
                    var col = xx.SortColumnName == "Id" ? BinFileSort.Id : xx.SortColumnName == "FileName" ? BinFileSort.FileName : xx.SortColumnName == "Size" ? BinFileSort.FileSize : BinFileSort.None;
                    var order = (BinFileOrder)xx.Order;
                    var bfi = BinFileInfoEx.Instance();

                    bfi.Sort(col, order);
                    listView_Refresh();
                },
                (x, y) => {
                    var xLength = Encoding.Default.GetByteCount(x);
                    var yLength = Encoding.Default.GetByteCount(y);

                    return xLength == yLength ? string.Compare(x, y) : xLength < yLength ? -1 : 1;
                }
            );
        }


        /// <summary>
        /// 刷新ListView
        /// </summary>
        private void listView_Refresh()
        {
            var bfi = BinFileInfoEx.Instance();
            var lvis = new List<ListViewItem>();

            foreach (var i in bfi)
            {
                var lvi = new ListViewItem()
                {
                    Text = $"{i.Id}",
                };
                var name = this.checkBox_FileNameExt.Checked ? Path.GetFileName(i.FileName) : Path.GetFileNameWithoutExtension(i.FileName);
                ListViewItem.ListViewSubItem[] lvsi = {
                    new ListViewItem.ListViewSubItem { Text = $"{name}", },
                    new ListViewItem.ListViewSubItem { Text = $"0x{i.Offset:X08}", },
                    new ListViewItem.ListViewSubItem { Text = $"0x{i.FileSize:X08}", },
                };
                lvi.SubItems.AddRange(lvsi);

                lvis.Add(lvi);
            }

            listView_files.BeginUpdate();
            listView_files.Items.Clear();
            listView_files.Items.AddRange(lvis.ToArray());
            listView_files.EndUpdate();
        }


        /// <summary>
        /// 拖拽文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_files_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All; //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// 拖拽文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_files_DragDrop(object sender, DragEventArgs e)
        {
            var files = ((string[])e.Data.GetData(DataFormats.FileDrop)); //获得路径
            var bfi = BinFileInfoEx.Instance();
            var align = Convert.ToInt32(textBox_align.Text, 16);
            var pad = Convert.ToByte(textBox_pad.Text, 16);

            foreach (var fn in files)
            {
                bfi.Add(fn, align, pad);
            }

            listView_Refresh();
        }

        /// <summary>
        /// ListView选择行变动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_files_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var bfi = BinFileInfoEx.Instance();
            var i = bfi[e.ItemIndex];

            textBox_offset.Text = $"0x{i.Offset:X08}";
            textBox_align.Text = $"0x{i.Align:X04}";
            textBox_pad.Text = $"0x{i.PadValue:X02}";
        }


        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_src_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog()
            {
                Multiselect = true,//该值确定是否可以选择多个文件
                Title = "请选择文件",
                Filter = "所有文件(*.*)|*.*",
            };
            var dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                var bfi = BinFileInfoEx.Instance();
                var align = Convert.ToInt32(textBox_align.Text, 16);
                var pad = Convert.ToByte(textBox_pad.Text, 16);

                foreach (var fn in ofd.FileNames)
                {
                    bfi.Add(fn, align, pad);
                }
            }

            listView_Refresh();
        }

        /// <summary>
        /// 保存文件路径和文件名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_desc_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog()
            {
                Title = "请保存文件",
                Filter = "所有文件(*.*)|*.*",
            };
            var dr = sfd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                this.textBox_destFile.Text = sfd.FileName;
            }
        }

        /// <summary>
        /// 生成合并文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_merge_Click(object sender, EventArgs e)
        {
            try
            {
                var bfi = BinFileInfoEx.Instance();
                var fileName = this.textBox_destFile.Text;

                bfi.Merge(fileName, this.checkBox_FileNameExt.Checked);

                MessageBox.Show($"合并文件成功，保存在:\n{fileName}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"写文件异常:{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_modify_Click(object sender, EventArgs e)
        {
            var bfi = BinFileInfoEx.Instance();
            var offset = Convert.ToInt32(textBox_offset.Text, 16);
            var align = Convert.ToInt32(textBox_align.Text, 16);
            var pad = Convert.ToByte(textBox_pad.Text, 16);

            foreach (int i in this.listView_files.SelectedIndices)
            {
                bfi.Modify(i, offset, align, pad);
            }

            listView_Refresh();
        }

        /// <summary>
        /// ListView删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_delete_Click(object sender, EventArgs e)
        {
            var bfi = BinFileInfoEx.Instance();
            var count = this.listView_files.SelectedItems.Count;

            while (0 < count--)
            {
                ListViewItem i = this.listView_files.SelectedItems[count];

                bfi.Delete(int.Parse(i.Text));
            }

            listView_Refresh();
        }

    }
}
