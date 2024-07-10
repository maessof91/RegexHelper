
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
            clipboardSearched = new System.Windows.Forms.RichTextBox();
            RegexLabel = new System.Windows.Forms.Label();
            RegexReplaceLabel = new System.Windows.Forms.Label();
            regexReplaceInputBox = new System.Windows.Forms.RichTextBox();
            ClipboardSearchedLabel = new System.Windows.Forms.Label();
            ClipboardReplacedLabel = new System.Windows.Forms.Label();
            clipboardReplaced = new System.Windows.Forms.RichTextBox();
            SearchLabel = new System.Windows.Forms.Label();
            regexInput = new System.Windows.Forms.RichTextBox();
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
            regexGeneratedText.Dock = System.Windows.Forms.DockStyle.Fill;
            regexGeneratedText.Font = new System.Drawing.Font("Segoe UI", 14F);
            regexGeneratedText.Location = new System.Drawing.Point(63, 43);
            regexGeneratedText.Name = "regexGeneratedText";
            regexGeneratedText.ReadOnly = true;
            regexGeneratedText.Size = new System.Drawing.Size(580, 32);
            regexGeneratedText.TabIndex = 1;
            regexGeneratedText.TextChanged += textBox2_TextChanged;
            // 
            // clipboardSearched
            // 
            clipboardSearched.DetectUrls = false;
            clipboardSearched.Dock = System.Windows.Forms.DockStyle.Fill;
            clipboardSearched.Font = new System.Drawing.Font("Segoe UI", 14F);
            clipboardSearched.Location = new System.Drawing.Point(3, 23);
            clipboardSearched.MinimumSize = new System.Drawing.Size(4, 600);
            clipboardSearched.Name = "clipboardSearched";
            clipboardSearched.Size = new System.Drawing.Size(357, 754);
            clipboardSearched.TabIndex = 2;
            clipboardSearched.Text = "";
            clipboardSearched.TextChanged += richTextBox1_TextChanged;
            // 
            // RegexLabel
            // 
            RegexLabel.AutoSize = true;
            RegexLabel.Location = new System.Drawing.Point(3, 40);
            RegexLabel.Name = "RegexLabel";
            RegexLabel.Size = new System.Drawing.Size(39, 15);
            RegexLabel.TabIndex = 5;
            RegexLabel.Text = "Regex";
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
            regexReplaceInputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            regexReplaceInputBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            regexReplaceInputBox.Location = new System.Drawing.Point(63, 123);
            regexReplaceInputBox.Name = "regexReplaceInputBox";
            regexReplaceInputBox.Size = new System.Drawing.Size(580, 54);
            regexReplaceInputBox.TabIndex = 8;
            regexReplaceInputBox.Text = "";
            regexReplaceInputBox.TextChanged += regexReplace_TextChanged;
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
            // clipboardReplaced
            // 
            clipboardReplaced.Dock = System.Windows.Forms.DockStyle.Fill;
            clipboardReplaced.Font = new System.Drawing.Font("Segoe UI", 14F);
            clipboardReplaced.Location = new System.Drawing.Point(366, 23);
            clipboardReplaced.MinimumSize = new System.Drawing.Size(4, 600);
            clipboardReplaced.Name = "clipboardReplaced";
            clipboardReplaced.Size = new System.Drawing.Size(357, 754);
            clipboardReplaced.TabIndex = 4;
            clipboardReplaced.Text = "";
            clipboardReplaced.TextChanged += richTextBox2_TextChanged;
            // 
            // SearchLabel
            // 
            SearchLabel.AutoSize = true;
            SearchLabel.Location = new System.Drawing.Point(3, 0);
            SearchLabel.Name = "SearchLabel";
            SearchLabel.Size = new System.Drawing.Size(42, 15);
            SearchLabel.TabIndex = 5;
            SearchLabel.Text = "Search";
            SearchLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            SearchLabel.Click += label4_Click;
            // 
            // regexInput
            // 
            regexInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            regexInput.CausesValidation = false;
            regexInput.DetectUrls = false;
            regexInput.Dock = System.Windows.Forms.DockStyle.Fill;
            regexInput.Font = new System.Drawing.Font("Segoe UI", 14F);
            regexInput.Location = new System.Drawing.Point(63, 3);
            regexInput.MinimumSize = new System.Drawing.Size(100, 4);
            regexInput.Multiline = false;
            regexInput.Name = "regexInput";
            regexInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            regexInput.Size = new System.Drawing.Size(580, 34);
            regexInput.TabIndex = 4;
            regexInput.Text = "";
            regexInput.WordWrap = false;
            regexInput.TextChanged += regexInput_TextChanged_1;
            // 
            // AddGroup
            // 
            AddGroup.AutoSize = true;
            AddGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            AddGroup.Location = new System.Drawing.Point(649, 3);
            AddGroup.Name = "AddGroup";
            AddGroup.Size = new System.Drawing.Size(74, 34);
            AddGroup.TabIndex = 3;
            AddGroup.Text = "AddGroup";
            AddGroup.UseVisualStyleBackColor = true;
            AddGroup.Click += AddGroup_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AllowDrop = true;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanel1.Controls.Add(regexReplaceInputBox, 1, 3);
            tableLayoutPanel1.Controls.Add(RegexReplaceLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(RegexLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(SearchLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(regexGeneratedText, 1, 1);
            tableLayoutPanel1.Controls.Add(regexInput, 1, 0);
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
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new System.Drawing.Size(726, 220);
            tableLayoutPanel1.TabIndex = 11;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint_1;
            // 
            // regexGeneratedText2
            // 
            regexGeneratedText2.Dock = System.Windows.Forms.DockStyle.Fill;
            regexGeneratedText2.Font = new System.Drawing.Font("Segoe UI", 14F);
            regexGeneratedText2.Location = new System.Drawing.Point(63, 83);
            regexGeneratedText2.Name = "regexGeneratedText2";
            regexGeneratedText2.ReadOnly = true;
            regexGeneratedText2.Size = new System.Drawing.Size(580, 34);
            regexGeneratedText2.TabIndex = 10;
            regexGeneratedText2.Text = "";
            // 
            // keyBox
            // 
            tableLayoutPanel1.SetColumnSpan(keyBox, 2);
            keyBox.Dock = System.Windows.Forms.DockStyle.Fill;
            keyBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            keyBox.Location = new System.Drawing.Point(63, 183);
            keyBox.Name = "keyBox";
            keyBox.Size = new System.Drawing.Size(660, 34);
            keyBox.TabIndex = 11;
            keyBox.Text = "";
            keyBox.TextChanged += keyBox_TextChanged;
            // 
            // key
            // 
            key.AutoSize = true;
            key.Location = new System.Drawing.Point(3, 180);
            key.Name = "key";
            key.Size = new System.Drawing.Size(43, 30);
            key.TabIndex = 12;
            key.Text = "Group Key";
            // 
            // buttonToTransformFile
            // 
            buttonToTransformFile.Location = new System.Drawing.Point(649, 83);
            buttonToTransformFile.Name = "buttonToTransformFile";
            buttonToTransformFile.Size = new System.Drawing.Size(74, 23);
            buttonToTransformFile.TabIndex = 13;
            buttonToTransformFile.Text = "ToTransformFile";
            buttonToTransformFile.UseVisualStyleBackColor = true;
            buttonToTransformFile.Click += buttonToTransformFile_Click;
            // 
            // buttonTransformFile
            // 
            buttonTransformFile.Location = new System.Drawing.Point(649, 123);
            buttonTransformFile.Name = "buttonTransformFile";
            buttonTransformFile.Size = new System.Drawing.Size(74, 23);
            buttonTransformFile.TabIndex = 14;
            buttonTransformFile.Text = "TransformFile";
            buttonTransformFile.UseVisualStyleBackColor = true;
            buttonTransformFile.Click += buttonTransformFile_Click;
            // 
            // menuStrip1
            // 
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
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(ClipboardSearchedLabel, 0, 0);
            tableLayoutPanel2.Controls.Add(ClipboardReplacedLabel, 1, 0);
            tableLayoutPanel2.Controls.Add(clipboardSearched, 0, 1);
            tableLayoutPanel2.Controls.Add(clipboardReplaced, 1, 1);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 244);
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
            Text = "Form1";
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
        private System.Windows.Forms.RichTextBox clipboardSearched;
        private System.Windows.Forms.RichTextBox clipboardReplaced;
        private System.Windows.Forms.Label RegexLabel;
        private System.Windows.Forms.Label ClipboardSearchedLabel;
        private System.Windows.Forms.Label ClipboardReplacedLabel;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Label RegexReplaceLabel;
        private System.Windows.Forms.RichTextBox regexReplaceInputBox;
        private System.Windows.Forms.RichTextBox regexInput;
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
    }
}

