
namespace FileMergeTool
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listView_files = new System.Windows.Forms.ListView();
            this.ch_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_offset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_destFile = new System.Windows.Forms.TextBox();
            this.button_desc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_merge = new System.Windows.Forms.Button();
            this.button_src = new System.Windows.Forms.Button();
            this.textBox_offset = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_align = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_modify = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.textBox_pad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_FileNameExt = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listView_files
            // 
            this.listView_files.AllowColumnReorder = true;
            this.listView_files.AllowDrop = true;
            this.listView_files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_ID,
            this.ch_file,
            this.ch_offset,
            this.ch_size});
            this.listView_files.FullRowSelect = true;
            this.listView_files.GridLines = true;
            this.listView_files.HideSelection = false;
            this.listView_files.Location = new System.Drawing.Point(2, 2);
            this.listView_files.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView_files.Name = "listView_files";
            this.listView_files.Size = new System.Drawing.Size(597, 302);
            this.listView_files.TabIndex = 0;
            this.listView_files.UseCompatibleStateImageBehavior = false;
            this.listView_files.View = System.Windows.Forms.View.Details;
            this.listView_files.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView_files_ItemSelectionChanged);
            this.listView_files.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_files_DragDrop);
            this.listView_files.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_files_DragEnter);
            // 
            // ch_ID
            // 
            this.ch_ID.Tag = "Id";
            this.ch_ID.Text = "索引";
            // 
            // ch_file
            // 
            this.ch_file.Tag = "FileName";
            this.ch_file.Text = "文件名";
            this.ch_file.Width = 500;
            // 
            // ch_offset
            // 
            this.ch_offset.Tag = "Offset";
            this.ch_offset.Text = "偏移";
            this.ch_offset.Width = 100;
            // 
            // ch_size
            // 
            this.ch_size.Tag = "Size";
            this.ch_size.Text = "大小";
            this.ch_size.Width = 100;
            // 
            // textBox_destFile
            // 
            this.textBox_destFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_destFile.Location = new System.Drawing.Point(68, 330);
            this.textBox_destFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_destFile.Name = "textBox_destFile";
            this.textBox_destFile.ReadOnly = true;
            this.textBox_destFile.Size = new System.Drawing.Size(405, 21);
            this.textBox_destFile.TabIndex = 1;
            // 
            // button_desc
            // 
            this.button_desc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_desc.Location = new System.Drawing.Point(478, 331);
            this.button_desc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_desc.Name = "button_desc";
            this.button_desc.Size = new System.Drawing.Size(56, 18);
            this.button_desc.TabIndex = 2;
            this.button_desc.Text = "浏览";
            this.button_desc.UseVisualStyleBackColor = true;
            this.button_desc.Click += new System.EventHandler(this.button_desc_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 334);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "目标文件：";
            // 
            // button_merge
            // 
            this.button_merge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_merge.Location = new System.Drawing.Point(536, 331);
            this.button_merge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_merge.Name = "button_merge";
            this.button_merge.Size = new System.Drawing.Size(56, 18);
            this.button_merge.TabIndex = 4;
            this.button_merge.Text = "合并";
            this.button_merge.UseVisualStyleBackColor = true;
            this.button_merge.Click += new System.EventHandler(this.button_merge_Click);
            // 
            // button_src
            // 
            this.button_src.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_src.Location = new System.Drawing.Point(416, 308);
            this.button_src.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_src.Name = "button_src";
            this.button_src.Size = new System.Drawing.Size(56, 18);
            this.button_src.TabIndex = 2;
            this.button_src.Text = "添加";
            this.button_src.UseVisualStyleBackColor = true;
            this.button_src.Click += new System.EventHandler(this.button_src_Click);
            // 
            // textBox_offset
            // 
            this.textBox_offset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_offset.Location = new System.Drawing.Point(68, 307);
            this.textBox_offset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_offset.Name = "textBox_offset";
            this.textBox_offset.Size = new System.Drawing.Size(70, 21);
            this.textBox_offset.TabIndex = 5;
            this.textBox_offset.Text = "0x00000000";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 311);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "偏移量：";
            // 
            // textBox_align
            // 
            this.textBox_align.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_align.Location = new System.Drawing.Point(185, 307);
            this.textBox_align.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_align.Name = "textBox_align";
            this.textBox_align.Size = new System.Drawing.Size(57, 21);
            this.textBox_align.TabIndex = 5;
            this.textBox_align.Text = "0x0400";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 311);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "对齐：";
            // 
            // button_modify
            // 
            this.button_modify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_modify.Location = new System.Drawing.Point(478, 308);
            this.button_modify.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_modify.Name = "button_modify";
            this.button_modify.Size = new System.Drawing.Size(56, 18);
            this.button_modify.TabIndex = 7;
            this.button_modify.Text = "修改";
            this.button_modify.UseVisualStyleBackColor = true;
            this.button_modify.Click += new System.EventHandler(this.button_modify_Click);
            // 
            // button_delete
            // 
            this.button_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_delete.Location = new System.Drawing.Point(536, 308);
            this.button_delete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(56, 18);
            this.button_delete.TabIndex = 7;
            this.button_delete.Text = "删除";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // textBox_pad
            // 
            this.textBox_pad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_pad.Location = new System.Drawing.Point(290, 307);
            this.textBox_pad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_pad.Name = "textBox_pad";
            this.textBox_pad.Size = new System.Drawing.Size(50, 21);
            this.textBox_pad.TabIndex = 5;
            this.textBox_pad.Text = "0x00";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 311);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "填充：";
            // 
            // checkBox_FileNameExt
            // 
            this.checkBox_FileNameExt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_FileNameExt.AutoSize = true;
            this.checkBox_FileNameExt.Location = new System.Drawing.Point(359, 309);
            this.checkBox_FileNameExt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_FileNameExt.Name = "checkBox_FileNameExt";
            this.checkBox_FileNameExt.Size = new System.Drawing.Size(60, 16);
            this.checkBox_FileNameExt.TabIndex = 8;
            this.checkBox_FileNameExt.Text = "扩展名";
            this.checkBox_FileNameExt.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 366);
            this.Controls.Add(this.textBox_pad);
            this.Controls.Add(this.textBox_align);
            this.Controls.Add(this.textBox_offset);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_modify);
            this.Controls.Add(this.button_merge);
            this.Controls.Add(this.button_src);
            this.Controls.Add(this.button_desc);
            this.Controls.Add(this.textBox_destFile);
            this.Controls.Add(this.checkBox_FileNameExt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView_files);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(618, 405);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "二进制文件合并工具";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_files;
        private System.Windows.Forms.ColumnHeader ch_ID;
        private System.Windows.Forms.ColumnHeader ch_file;
        private System.Windows.Forms.ColumnHeader ch_size;
        private System.Windows.Forms.ColumnHeader ch_offset;
        private System.Windows.Forms.TextBox textBox_destFile;
        private System.Windows.Forms.Button button_desc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_merge;
        private System.Windows.Forms.Button button_src;
        private System.Windows.Forms.TextBox textBox_offset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_align;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_modify;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.TextBox textBox_pad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_FileNameExt;
    }
}

