
namespace RegexHelper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            regexGeneratedText = new System.Windows.Forms.TextBox();
            clipboardSearchedTextArea = new RoundedRichTextBox();
            RegexLabel = new System.Windows.Forms.Label();
            RegexReplaceLabel = new System.Windows.Forms.Label();
            regexReplaceInputBox = new System.Windows.Forms.RichTextBox();
            ClipboardSearchedLabel = new System.Windows.Forms.Label();
            ClipboardReplacedLabel = new System.Windows.Forms.Label();
            clipboardReplacedTextArea = new System.Windows.Forms.RichTextBox();
            SearchLabel = new System.Windows.Forms.Label();
            regexSearchInputBox = new System.Windows.Forms.RichTextBox();
            AddGroup = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            regexGeneratedText2 = new System.Windows.Forms.RichTextBox();
            keyBox = new System.Windows.Forms.RichTextBox();
            key = new System.Windows.Forms.Label();
            buttonToTransformFile = new System.Windows.Forms.Button();
            buttonTransformFile = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // regexGeneratedText
            // 
            regexGeneratedText.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            regexGeneratedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            regexGeneratedText.Dock = System.Windows.Forms.DockStyle.Fill;
            regexGeneratedText.Font = new System.Drawing.Font("Segoe UI", 14F);
            regexGeneratedText.Location = new System.Drawing.Point(63, 43);
            regexGeneratedText.Name = "regexGeneratedText";
            regexGeneratedText.ReadOnly = true;
            regexGeneratedText.Size = new System.Drawing.Size(580, 25);
            regexGeneratedText.TabIndex = 1;
            regexGeneratedText.TextChanged += RegexView_TextChanged;
            // 
            // clipboardSearchedTextArea
            // 
            clipboardSearchedTextArea.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            clipboardSearchedTextArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            clipboardSearchedTextArea.CornerRadius = 15;
            clipboardSearchedTextArea.DetectUrls = false;
            clipboardSearchedTextArea.Dock = System.Windows.Forms.DockStyle.Fill;
            clipboardSearchedTextArea.Font = new System.Drawing.Font("Segoe UI", 14F);
            clipboardSearchedTextArea.Location = new System.Drawing.Point(3, 23);
            clipboardSearchedTextArea.MinimumSize = new System.Drawing.Size(4, 600);
            clipboardSearchedTextArea.Name = "clipboardSearchedTextArea";
            clipboardSearchedTextArea.Size = new System.Drawing.Size(357, 754);
            clipboardSearchedTextArea.TabIndex = 2;
            clipboardSearchedTextArea.Text = "";
            clipboardSearchedTextArea.TextChanged += clipboardSearched_TextChanged;
            // 
            // RegexLabel
            // 
            RegexLabel.AutoSize = true;
            RegexLabel.Location = new System.Drawing.Point(3, 40);
            RegexLabel.Name = "RegexLabel";
            RegexLabel.Size = new System.Drawing.Size(42, 30);
            RegexLabel.TabIndex = 5;
            RegexLabel.Text = "Regex View";
            RegexLabel.Click += RegexLabel_Click;
            // 
            // RegexReplaceLabel
            // 
            RegexReplaceLabel.AutoSize = true;
            RegexReplaceLabel.Location = new System.Drawing.Point(3, 120);
            RegexReplaceLabel.Name = "RegexReplaceLabel";
            RegexReplaceLabel.Size = new System.Drawing.Size(48, 30);
            RegexReplaceLabel.TabIndex = 9;
            RegexReplaceLabel.Text = "Regex Replace";
            RegexReplaceLabel.Click += label5_Click;
            // 
            // regexReplaceInputBox
            // 
            regexReplaceInputBox.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            regexReplaceInputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            regexReplaceInputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            regexReplaceInputBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            regexReplaceInputBox.Location = new System.Drawing.Point(63, 123);
            regexReplaceInputBox.Name = "regexReplaceInputBox";
            regexReplaceInputBox.Size = new System.Drawing.Size(580, 34);
            regexReplaceInputBox.TabIndex = 8;
            regexReplaceInputBox.Text = "";
            regexReplaceInputBox.TextChanged += regexReplaceInputbox_TextChanged;
            // 
            // ClipboardSearchedLabel
            // 
            ClipboardSearchedLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            ClipboardSearchedLabel.AutoSize = true;
            ClipboardSearchedLabel.Location = new System.Drawing.Point(126, 5);
            ClipboardSearchedLabel.Name = "ClipboardSearchedLabel";
            ClipboardSearchedLabel.Size = new System.Drawing.Size(110, 15);
            ClipboardSearchedLabel.TabIndex = 6;
            ClipboardSearchedLabel.Text = "Clipboard Searched";
            ClipboardSearchedLabel.Click += label2_Click;
            // 
            // ClipboardReplacedLabel
            // 
            ClipboardReplacedLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            ClipboardReplacedLabel.AutoSize = true;
            ClipboardReplacedLabel.Location = new System.Drawing.Point(489, 5);
            ClipboardReplacedLabel.Name = "ClipboardReplacedLabel";
            ClipboardReplacedLabel.Size = new System.Drawing.Size(110, 15);
            ClipboardReplacedLabel.TabIndex = 7;
            ClipboardReplacedLabel.Text = "Clipboard Replaced";
            ClipboardReplacedLabel.Click += label3_Click;
            // 
            // clipboardReplacedTextArea
            // 
            clipboardReplacedTextArea.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            clipboardReplacedTextArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            clipboardReplacedTextArea.Dock = System.Windows.Forms.DockStyle.Fill;
            clipboardReplacedTextArea.Font = new System.Drawing.Font("Segoe UI", 14F);
            clipboardReplacedTextArea.Location = new System.Drawing.Point(366, 23);
            clipboardReplacedTextArea.MinimumSize = new System.Drawing.Size(4, 600);
            clipboardReplacedTextArea.Name = "clipboardReplacedTextArea";
            clipboardReplacedTextArea.Size = new System.Drawing.Size(357, 754);
            clipboardReplacedTextArea.TabIndex = 4;
            clipboardReplacedTextArea.Text = "";
            clipboardReplacedTextArea.TextChanged += clipboardReplaced_TextChanged;
            // 
            // SearchLabel
            // 
            SearchLabel.AutoSize = true;
            SearchLabel.Location = new System.Drawing.Point(3, 0);
            SearchLabel.Name = "SearchLabel";
            SearchLabel.Size = new System.Drawing.Size(42, 30);
            SearchLabel.TabIndex = 5;
            SearchLabel.Text = "Regex Input";
            SearchLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            SearchLabel.Click += label4_Click;
            // 
            // regexSearchInputBox
            // 
            regexSearchInputBox.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            regexSearchInputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            regexSearchInputBox.CausesValidation = false;
            regexSearchInputBox.DetectUrls = false;
            regexSearchInputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            regexSearchInputBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            regexSearchInputBox.Location = new System.Drawing.Point(63, 3);
            regexSearchInputBox.MinimumSize = new System.Drawing.Size(100, 4);
            regexSearchInputBox.Multiline = false;
            regexSearchInputBox.Name = "regexSearchInputBox";
            regexSearchInputBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            regexSearchInputBox.Size = new System.Drawing.Size(580, 34);
            regexSearchInputBox.TabIndex = 4;
            regexSearchInputBox.Text = "";
            regexSearchInputBox.WordWrap = false;
            regexSearchInputBox.TextChanged += regexSearchInputbox_TextChanged_1;
            // 
            // AddGroup
            // 
            AddGroup.AutoSize = true;
            AddGroup.BackColor = System.Drawing.Color.Silver;
            AddGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            AddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            AddGroup.Location = new System.Drawing.Point(649, 3);
            AddGroup.Name = "AddGroup";
            AddGroup.Size = new System.Drawing.Size(74, 34);
            AddGroup.TabIndex = 3;
            AddGroup.Text = "AddGroup";
            AddGroup.UseVisualStyleBackColor = false;
            AddGroup.Click += AddGroup_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AllowDrop = true;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.BackColor = System.Drawing.Color.Gray;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanel1.Controls.Add(regexReplaceInputBox, 1, 3);
            tableLayoutPanel1.Controls.Add(RegexReplaceLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(RegexLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(SearchLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(regexGeneratedText, 1, 1);
            tableLayoutPanel1.Controls.Add(regexSearchInputBox, 1, 0);
            tableLayoutPanel1.Controls.Add(AddGroup, 2, 0);
            tableLayoutPanel1.Controls.Add(regexGeneratedText2, 1, 2);
            tableLayoutPanel1.Controls.Add(keyBox, 1, 4);
            tableLayoutPanel1.Controls.Add(key, 0, 4);
            tableLayoutPanel1.Controls.Add(buttonToTransformFile, 2, 2);
            tableLayoutPanel1.Controls.Add(buttonTransformFile, 2, 3);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new System.Drawing.Size(726, 200);
            tableLayoutPanel1.TabIndex = 11;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint_1;
            // 
            // regexGeneratedText2
            // 
            regexGeneratedText2.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            regexGeneratedText2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            regexGeneratedText2.Dock = System.Windows.Forms.DockStyle.Fill;
            regexGeneratedText2.Font = new System.Drawing.Font("Segoe UI", 14F);
            regexGeneratedText2.Location = new System.Drawing.Point(63, 83);
            regexGeneratedText2.Name = "regexGeneratedText2";
            regexGeneratedText2.ReadOnly = true;
            regexGeneratedText2.Size = new System.Drawing.Size(580, 34);
            regexGeneratedText2.TabIndex = 10;
            regexGeneratedText2.Text = "";
            regexGeneratedText2.TextChanged += regexGeneratedText2_TextChanged;
            // 
            // keyBox
            // 
            keyBox.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            keyBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tableLayoutPanel1.SetColumnSpan(keyBox, 2);
            keyBox.Dock = System.Windows.Forms.DockStyle.Fill;
            keyBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            keyBox.Location = new System.Drawing.Point(63, 163);
            keyBox.Name = "keyBox";
            keyBox.Size = new System.Drawing.Size(660, 34);
            keyBox.TabIndex = 11;
            keyBox.Text = "";
            keyBox.TextChanged += keyBox_TextChanged;
            // 
            // key
            // 
            key.AutoSize = true;
            key.Location = new System.Drawing.Point(3, 160);
            key.Name = "key";
            key.Size = new System.Drawing.Size(43, 30);
            key.TabIndex = 12;
            key.Text = "Group Key";
            // 
            // buttonToTransformFile
            // 
            buttonToTransformFile.BackColor = System.Drawing.Color.Silver;
            buttonToTransformFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonToTransformFile.Location = new System.Drawing.Point(649, 83);
            buttonToTransformFile.Name = "buttonToTransformFile";
            buttonToTransformFile.Size = new System.Drawing.Size(74, 23);
            buttonToTransformFile.TabIndex = 13;
            buttonToTransformFile.Text = "ToTransformFile";
            buttonToTransformFile.UseVisualStyleBackColor = false;
            buttonToTransformFile.Click += buttonToTransformFile_Click;
            // 
            // buttonTransformFile
            // 
            buttonTransformFile.BackColor = System.Drawing.Color.Silver;
            buttonTransformFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonTransformFile.Location = new System.Drawing.Point(649, 123);
            buttonTransformFile.Name = "buttonTransformFile";
            buttonTransformFile.Size = new System.Drawing.Size(74, 23);
            buttonTransformFile.TabIndex = 14;
            buttonTransformFile.Text = "TransformFile";
            buttonTransformFile.UseVisualStyleBackColor = false;
            buttonTransformFile.Click += buttonTransformFile_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.Color.Gray;
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(726, 24);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { settingsToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            toolStripMenuItem1.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            settingsToolStripMenuItem.Text = "settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = System.Drawing.Color.Gray;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(ClipboardSearchedLabel, 0, 0);
            tableLayoutPanel2.Controls.Add(ClipboardReplacedLabel, 1, 0);
            tableLayoutPanel2.Controls.Add(clipboardSearchedTextArea, 0, 1);
            tableLayoutPanel2.Controls.Add(clipboardReplacedTextArea, 1, 1);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 224);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(50, 10, 10, 10);
            tableLayoutPanel2.MinimumSize = new System.Drawing.Size(0, 800);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new System.Drawing.Size(726, 800);
            tableLayoutPanel2.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(726, 762);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new System.Drawing.Size(400, 400);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            Text = "Regex Helper";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox regexGeneratedText;
        private System.Windows.Forms.RichTextBox clipboardReplacedTextArea;
        private System.Windows.Forms.Label RegexLabel;
        private System.Windows.Forms.Label ClipboardSearchedLabel;
        private System.Windows.Forms.Label ClipboardReplacedLabel;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Label RegexReplaceLabel;
        private System.Windows.Forms.RichTextBox regexReplaceInputBox;
        private System.Windows.Forms.RichTextBox regexSearchInputBox;
        private System.Windows.Forms.Button AddGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RichTextBox regexGeneratedText2;
        private System.Windows.Forms.RichTextBox keyBox;
        private System.Windows.Forms.Label key;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button buttonToTransformFile;
        private System.Windows.Forms.Button buttonTransformFile;

        private RoundedRichTextBox clipboardSearchedTextArea;
    }
}

