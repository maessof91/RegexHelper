using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RegexHelper
{
    public partial class Form1 : Form
    {
        //Form1
        //LoadSettings
        //Form1_Load
        //GroupInput_TextChanged
        //regexInput_TextChanged_1 > Improtant
        //regexReplace_TextChanged
        //regexInput_KeyDown
        //clipboardReplaced_KeyDown
        //clipboardSearched_KeyDown
        //clipboardSearched_KeyUp
        //textBox1_TextChanged
        //AddGroup_Click
        //UpdateRegexInputBox
        //UpdateRegexViewInputBox
        //UpdateRegexReplaceInputAndClipboardReplacedTextView
        //UpdateClipboardReplacedTextPannel
        //MarkMatchesAndGroups
        //UpdateRegexReplaceInputBox

        //LeftPaneDisplayMatches > Important

        private RichTextBox richTextBox;

        int inputGroups = 0;

        private List<RichTextBox> inputGroupsTextBoxes;

        public static int MaxMatches = 600;
        public static int MaxGroups = 1200;
        public static int Test = 1200;
        public static string NppPath = "";

        public string clipboardSearchTrueText = "";

        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;           

            UpdateClipboardText();
            regexInput.VisibleChanged += RegexInput_VisibleChanged;
            clipboardReplaced.VisibleChanged += ClipboardReplaced_VisibleChanged;

            inputGroupsTextBoxes = new List<RichTextBox>();

            this.clipboardSearched.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clipboardSearched_KeyDown);
            this.clipboardSearched.KeyUp += new System.Windows.Forms.KeyEventHandler(this.clipboardSearched_KeyUp);
            this.regexInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.regexInput_KeyDown);
            this.clipboardReplaced.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clipboardReplaced_KeyDown);

            keyBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
            keyBox.ForeColor = System.Drawing.Color.White;

            regexReplaceInputBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
            regexReplaceInputBox.ForeColor = System.Drawing.Color.White;

            clipboardSearched.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
            clipboardSearched.ForeColor = System.Drawing.Color.White;
            Log.LogExecutionTime();

            LoadSettings();
        }

        private static void LoadSettings()
        {
            Form1.MaxMatches = Properties.Settings.Default.MaxMatches;
            Form1.MaxGroups = Properties.Settings.Default.MaxGroups;
            Form1.NppPath = Properties.Settings.Default.NppPath;
            Form1.Test = Properties.Settings.Default.Test;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log.LogExecutionTime();

            clipboardSearched.AutoWordSelection = false; ;
            clipboardReplaced.AutoWordSelection = false; ;
            regexReplaceInputBox.AutoWordSelection = false; ;
            regexInput.AutoWordSelection = false; ;
            regexGeneratedText2.AutoWordSelection = false; ;
            keyBox.AutoWordSelection = false; ;

            this.keyBox.Text = "";

            var groupIndex = 0;
            foreach (var groupColor in Colors.groupColors)
            {
                this.keyBox.Text += groupIndex + " ";
                groupIndex++;
            }

            var pos = 0;
            groupIndex = 0;

            keyBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
            keyBox.ForeColor = System.Drawing.Color.Black;

            foreach (var groupColor in Colors.groupColors)
            {
                var numberLength = ("" + (groupIndex)).Length;

                keyBox.SelectionStart = pos;
                keyBox.SelectionLength = numberLength;
                keyBox.SelectionColor = Colors.groupColors[groupIndex];
                //keyBox.SelectionBackColor = Colors.groupColorsContrasted[groupIndex];

                pos += numberLength + 1;
                groupIndex++;
            }
            Log.LogExecutionTime();
        }

        private void GroupInput_TextChanged(object sender, EventArgs e)
        {
            Log.LogExecutionTime();
            UpdateRegexInputBox();

            UpdateClipboardSearchTextArea();

            UpdateRegexReplaceInputAndClipboardReplacedTextView();

            UpdateRegexViewInputBox();
            Log.LogExecutionTime();
        }

        /// <summary>
        /// The regex search pattern text changed
        /// </summary>
        private void regexInput_TextChanged_1(object sender, EventArgs e)
        {
            Log.LogExecutionTime();
            UpdateRegexInputBox();

            UpdateClipboardSearchTextArea();

            UpdateRegexReplaceInputAndClipboardReplacedTextView();

            UpdateRegexViewInputBox();
            Log.LogExecutionTime();
        }

        /// <summary>
        /// The replacement regex syntax eg " a $1$2 "
        /// </summary>
        private void regexReplace_TextChanged(object sender, EventArgs e)
        {
            Log.LogExecutionTime();
            UpdateRegexReplaceInputAndClipboardReplacedTextView();
            Log.LogExecutionTime();
        }


        private void regexInput_KeyDown(object sender, KeyEventArgs e)
        {
            Log.LogExecutionTime();
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the clipboard data as plain text
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                // Paste the plain text into the RichTextBox
                regexInput.SelectedText = clipboardText;
                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }
            Log.LogExecutionTime();
        }


        private void clipboardReplaced_KeyDown(object sender, KeyEventArgs e)
        {
            Log.LogExecutionTime();
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the clipboard data as plain text
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                // Paste the plain text into the RichTextBox
                regexInput.SelectedText = clipboardText;
                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                var text = clipboardReplaced.SelectedText;

                text = text.Replace("\u200B", "");
                text = text.Replace("\u200C", "");
                text = text.Replace("\u200D", "");

                Clipboard.SetText(text);
                // Get the clipboard data as plain text
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);

                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }
            Log.LogExecutionTime();
        }
     


        private void RegexInput_VisibleChanged(object sender, EventArgs e)
        {
            Log.LogExecutionTime();
            BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
            {
                regexInput.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
                regexInput.ForeColor = System.Drawing.Color.White;
                regexInput.Focus();

                regexGeneratedText2.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
                regexGeneratedText2.ForeColor = System.Drawing.Color.White;
            });
            Log.LogExecutionTime();
        }


        private void ClipboardReplaced_VisibleChanged(object sender, EventArgs e)
        {
            Log.LogExecutionTime();
            BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
            {
                clipboardReplaced.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
                clipboardReplaced.ForeColor = System.Drawing.Color.White;
            });
            Log.LogExecutionTime();
        }


        private void LeftPaneDisplayMatches(MatchCollection matches, RichTextBox inputBox, string textToRegexSearch)
        {
            Log.LogExecutionTime();
            var matchesCount = matches.Count;

            inputBox.SelectionStart = 0;
            inputBox.SelectionLength = inputBox.TextLength;
            inputBox.SelectionBackColor = inputBox.BackColor;
            inputBox.SelectionColor = Color.White;

            var colorForFirstChar = Color.FromArgb(10, 10, 10);
            var colorForLastChar = Color.FromArgb(30, 30, 30);

            var matchList = matches.Take(MaxMatches).ToList();

            var groupsHit = 0;
            foreach (Match match in matchList)
            {
                var groupIndex = 0;

                foreach (Group group in match.Groups)
                {
                    if (groupsHit > MaxGroups)
                    {
                        break;
                    }

                    inputBox.SelectionStart = group.Index;
                    inputBox.SelectionLength = group.Length;
                    inputBox.SelectionColor = Colors.groupColors[groupIndex];
                    //inputBox.SelectionBackColor = Colors.groupColorsContrasted[groupIndex];


                    var singleCharGroup = group.Length == 1;
                    var twoCharGroup = group.Length == 2;

                    var firstGroup = groupIndex == 0;

                    if (singleCharGroup)
                    {
                        inputBox.SelectionStart = group.Index;
                        inputBox.SelectionLength = 1;
                        inputBox.SelectionBackColor = colorForFirstChar;
                    }
                    else
                    if (twoCharGroup)
                    {
                        inputBox.SelectionStart = group.Index;
                        inputBox.SelectionLength = 1;
                        inputBox.SelectionBackColor = colorForFirstChar;

                        inputBox.SelectionStart = group.Index + 1;
                        inputBox.SelectionLength = 1;
                        inputBox.SelectionBackColor = colorForLastChar;
                    }
                    else
                    if (firstGroup)
                    {
                        inputBox.SelectionStart = group.Index;
                        inputBox.SelectionLength = 1;
                        inputBox.SelectionBackColor = colorForFirstChar;

                        inputBox.SelectionStart = group.Index + group.Length - 1;
                        inputBox.SelectionLength = 1;
                        inputBox.SelectionBackColor = colorForLastChar;
                    }

                    groupIndex++;
                    groupsHit++;
                }

            }
            Log.LogExecutionTime();
        }

      

        private void UpdateClipboardSearchTextArea()
        {
            Log.LogExecutionTime();

            if (
              string.IsNullOrEmpty(regexInput.Text)
              &&
              string.IsNullOrEmpty(clipboardSearched.Text)
              )
            {
                Log.LogExecutionTime();
                return;
            }

            string regexPattern = regexInput.Text;

            regexPattern = SubstituteGroupsTextBoxesIn(regexPattern);

            regexGeneratedText.Text = regexPattern;

            //string clipboardText = clipboardSearched.Text;          
            string textToRegexSearch = WhiteSpace.ToVisibleNewLine(clipboardSearchTrueText);

            try
            {
                var regexPatternWithVisibleNewLine = WhiteSpace.searchToVisibleNewLine(regexPattern);
                Regex regex = new Regex(regexPatternWithVisibleNewLine);
                MatchCollection matches = regex.Matches(textToRegexSearch);
                LeftPaneDisplayMatches(matches, clipboardSearched, textToRegexSearch);
            }
            catch (ArgumentException)
            {
                // richTextBox1.Text = "Invalid regular expression pattern.";
            }
            
            Log.LogExecutionTime();
        }

        private string SubstituteGroupsTextBoxesIn(string regexPattern)
        {
            for (int i = inputGroupsTextBoxes.Count - 1; i >= 0; i--)
            {
                regexPattern = regexPattern.Replace("#" + (i + 1), inputGroupsTextBoxes[i].Text);
            }

            return regexPattern;
        }

        private void UpdateClipboardText()
        {
            Log.LogExecutionTime();
            string clipboardText = Clipboard.GetText();

            clipboardSearchTrueText = clipboardText;
            clipboardText = WhiteSpace.ToViewableWhitespace(clipboardText);

            this.clipboardSearched.Text = clipboardText ?? "Clipboard does not contain text.";

            Log.LogExecutionTime();
        }
                
       

        private void clipboardSearched_KeyDown(object sender, KeyEventArgs e)
        {
            Log.LogExecutionTime();
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the clipboard data as plain text
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);

                clipboardSearchTrueText = clipboardText;
                clipboardText = WhiteSpace.ToViewableWhitespace(clipboardText);
                // Paste the plain text into the RichTextBox
                clipboardSearched.SelectedText = clipboardText;
                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }

            Log.LogExecutionTime();
        }

        private void clipboardSearched_KeyUp(object sender, KeyEventArgs e)
        {
            Log.LogExecutionTime();

            if (e.KeyCode == Keys.Space)            
            {
                var pos = clipboardSearched.SelectionStart;

                clipboardSearched.Text = WhiteSpace.ToViewableWhitespace(clipboardSearched.Text);
                clipboardSearched.SelectionStart = pos;
                clipboardSearchTrueText = WhiteSpace.ToInvisibleWhiteSpace(clipboardSearched.Text);

                e.SuppressKeyPress = true;
            }

            Log.LogExecutionTime();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Log.LogExecutionTime();
            //HighlightRegexSpecialCharacters(regexInput);

            regexInput.SelectionStart = 0;
            regexInput.SelectionLength = 1;
            regexInput.SelectionBackColor = Color.Yellow;

            UpdateClipboardSearchTextArea();
            Log.LogExecutionTime();
        }

        private void AddGroup_Click(object sender, EventArgs e)
        {
            Console.Clear();
            Log.LogExecutionTime();
            RichTextBox newTextBox = new RichTextBox();
            newTextBox.Size = new System.Drawing.Size(483, 23);
            inputGroups++;
            newTextBox.Name = $"group{inputGroups}";
            regexInput.Text += $"(#{inputGroups})";

            inputGroupsTextBoxes.Add(newTextBox);
            newTextBox.TextChanged += GroupInput_TextChanged;

            // Determine the number of columns in your TableLayoutPanel
            int columnCount = tableLayoutPanel1.ColumnCount;

            // Create a new row
            int rowIndex = tableLayoutPanel1.RowCount;
            tableLayoutPanel1.RowCount++;

            for (int i = tableLayoutPanel1.RowCount - 1; i > 0; i--)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    Control control = tableLayoutPanel1.GetControlFromPosition(j, i - 1);
                    if (control != null)
                    {
                        tableLayoutPanel1.SetRow(control, i);
                    }
                }
            }

            // Create a new button control
            var newButton = new System.Windows.Forms.Button();
            newButton.Text = "#" + inputGroups;

            // Set the row and column indexes for the button
            tableLayoutPanel1.SetRow(newButton, 0);
            tableLayoutPanel1.SetColumn(newButton, 0);

            tableLayoutPanel1.SetRow(newTextBox, 0);
            tableLayoutPanel1.SetColumn(newTextBox, 1);
            //newTextBox.KeyPress += regexInput_TextChanged_1;

            // Add the button to the TableLayoutPanel
            tableLayoutPanel1.Controls.Add(newButton);
            tableLayoutPanel1.Controls.Add(newTextBox);

            // Optionally, you can adjust the row styles if needed
            RowStyle newRowStyle = new RowStyle(SizeType.AutoSize); // Or any other size type you prefer
            tableLayoutPanel1.RowStyles.Add(newRowStyle);

            newTextBox.Focus();
            Log.LogExecutionTime();
        }


        private void UpdateRegexInputBox()
        {
            Log.LogExecutionTime();
            int cursorPosition = regexInput.SelectionStart;

            regexInput.SelectionStart = 0;
            regexInput.SelectionLength = regexInput.Text.Length;
            regexInput.SelectionColor = Colors.groupColors[0];
            regexInput.SelectionBackColor = Colors.groupColorsContrasted[0];

            foreach (char specialChar in @"[](){}^$.|*+?\")
            {
                int index = -1;

                //in a loop to find the character multiple times
                while ((index = regexInput.Text.IndexOf(specialChar, index + 1)) != -1)
                {
                    regexInput.SelectionStart = index;
                    regexInput.SelectionLength = 1;
                    regexInput.SelectionColor = Color.Cyan;
                }
            }

            var pairs = Util.GetPairs(regexInput.Text, '(', ')');
            pairs = pairs.OrderBy(u => u.Item1).ToList();

            var col = 1;
            foreach (var pair in pairs)
            {
                Util.MarkTextFull(pair.Item1, pair.Item2 + 1, Colors.groupColors[col],Colors.groupColorsContrasted[col], regexInput);

                col++;
            }

            if (regexInput.Focused)
            {
                regexInput.Select(cursorPosition, 0);
            }
            Log.LogExecutionTime();
        }


        private void UpdateRegexViewInputBox()
        {
            Log.LogExecutionTime();
            string regexPattern = regexInput.Text;

            for (int i = inputGroupsTextBoxes.Count - 1; i >= 0; i--)
            {
                regexPattern = regexPattern.Replace("#" + (i + 1), inputGroupsTextBoxes[i].Text);
            }

            string text = RegexView.AlterRegexViewText(regexPattern);

            regexGeneratedText2.SelectionStart = 0;
            regexGeneratedText2.SelectionLength = text.Length;
            regexGeneratedText2.SelectionColor = Colors.groupColors[0];

            foreach (char specialChar in @"[](){}^$.|*+?\")
            {
                int index = -1;

                //in a loop to find the character multiple times
                while ((index = text.IndexOf(specialChar, index + 1)) != -1)
                {
                    if (index != 0)
                    {
                        if (text[index - 1] == '\u200D')
                        {

                            continue;
                        }
                    }
                    //regexGeneratedText2.SelectionStart = index;
                    //regexGeneratedText2.SelectionLength = 1;
                    //regexGeneratedText2.SelectionColor = Color.Red;

                    regexGeneratedText2.SelectionStart = index;
                    regexGeneratedText2.SelectionLength = 1;
                    regexGeneratedText2.SelectionFont = new Font(regexGeneratedText2.Font, FontStyle.Underline);
                    regexGeneratedText2.SelectionColor = Color.Cyan;
                    // regexGeneratedText2.SelectionBackColor = Color.Transparent; // Set it to transparent to avoid changing the background color
                    // regexGeneratedText2.SelectionColor = Color.Blue; // Set the font color to blue
                }
            }

            var pairs = Util.GetPairs(text, '\u200B', '\u200C');

            pairs = pairs.OrderBy(u => u.Item1).ToList();

            regexGeneratedText2.Text = text;

            var col = 1;
            foreach (var pair in pairs)
            {
                Util.MarkTextFull(pair.Item1, pair.Item2 + 1, Colors.groupColors[col], Colors.groupColorsContrasted[col], regexGeneratedText2);

                col++;
            }
            Log.LogExecutionTime();
        }       

        void UpdateRegexReplaceInputAndClipboardReplacedTextView()
        {
            Log.LogExecutionTime();
            string regexPattern = UpdateRegexReplaceInputBox();

            UpdateClipboardReplacedTextPannel(regexPattern);

            Log.LogExecutionTime();
        }

        private void UpdateClipboardReplacedTextPannel(string regexPattern)
        {
            Log.LogExecutionTime();

            string replacePattern = "\u200B" + regexReplaceInputBox.Text + "\u200C" + "\u200D";
            replacePattern = Regex.Replace(replacePattern, @"\$(\d+)", "\u200B" + "$$$1" + "\u200C");
            replacePattern = replacePattern.Replace("\\n", "\n");
            replacePattern = replacePattern.Replace("\\r", "\r");
            replacePattern = replacePattern.Replace("\\t", "\t");

            //string replacePattern = ">"+regexReplace.Text+ "<";
            //replacePattern = Regex.Replace(replacePattern, @"\$(\d+)", ">$$1‌‌‌‌‌‌‌‌‌‌‌‌‌<");

            var clipboardText = clipboardSearched.Text;

            if (clipboardText != null && regexPattern != null && replacePattern != null)
            {
                try
                {
                    //   Regex regex = new Regex(regexPattern);
                    //    MatchCollection matches = regex.Matches(clipboardText);

                    clipboardReplaced.Text = Regex.Replace(clipboardSearchTrueText, regexPattern, replacePattern);
                    //DisplayMatches(matches, clipboardReplaced);

                    clipboardReplaced.SelectionStart = 0;
                    clipboardReplaced.SelectionLength = clipboardReplaced.Text.Length;
                    clipboardReplaced.SelectionColor = Color.White;

                    var pairs = Util.GetPairs(clipboardReplaced.Text, '\u200B', '\u200C');
                    //var pairs = GetPairs(clipboardReplaced.Text, '>', '<');

                    pairs = MarkMatchesAndGroups(pairs);
                }
                catch (Exception)
                {

                }
            }
            Log.LogExecutionTime();
        }

        private List<(int, int)> MarkMatchesAndGroups(List<(int, int)> pairs)
        {
            var endOfMatches = Regex.Matches(clipboardReplaced.Text, "\u200D");

            var endOfMatchesIndexes = endOfMatches.Select(m => (m as Match).Index).OrderBy(i => i).ToList();

            pairs = pairs.OrderBy(u => u.Item1).ToList();
            var col = 0;
            var i = 0;
            foreach (var pair in pairs)
            {
                if (i >= MaxMatches - 2)
                {
                    break;
                }

                if (endOfMatchesIndexes[i] < pair.Item1)
                {
                    col = 0;
                    i++;
                }
                Util.MarkTextFull(pair.Item1, pair.Item2 + 1, Colors.groupColors[col], Colors.groupColorsContrasted[col], clipboardReplaced);

                col++;
            }

            return pairs;
        }

        private string UpdateRegexReplaceInputBox()
        {
            Log.LogExecutionTime();

            int regexReplacecursorPosition = regexReplaceInputBox.SelectionStart;

            string regexPattern = regexInput.Text;

            for (int i = inputGroupsTextBoxes.Count - 1; i >= 0; i--)
            {
                regexPattern = regexPattern.Replace("#" + (i + 1), inputGroupsTextBoxes[i].Text);
            }

            var regexGroups = new Regex(@"\$(\d+)");
            var groupsMatches = regexGroups.Matches(regexReplaceInputBox.Text);

            foreach (Match match in groupsMatches)
            {
                var colorIndex = int.Parse(match.Groups[1].ToString());
                var index = match.Index;
                var length = match.Length;
                regexReplaceInputBox.SelectionStart = index;
                regexReplaceInputBox.SelectionLength = length;
                regexReplaceInputBox.SelectionColor = Colors.groupColors[colorIndex];
                //regexReplaceInputBox.SelectionBackColor = Colors.groupColorsContrasted[colorIndex];
            }

            if (regexReplaceInputBox.Focused)
            {
                regexReplaceInputBox.SelectionLength = 0;
                regexReplaceInputBox.SelectionStart = regexReplacecursorPosition;
            }

            Log.LogExecutionTime();
            return regexPattern;
        }

       

        #region NotUsed
        void AllBelowHereIsNonsence______________________________________()
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void RegexLabel_Click(object sender, EventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void keyBox_TextChanged(object sender, EventArgs e)
        {
        }
        #endregion

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void buttonToTransformFile_Click(object sender, EventArgs e)
        {
            var rI= regexInput.Text;
            var regexReplaceInputText = regexReplaceInputBox.Text;
            var regexInputText= regexGeneratedText.Text;

            var clipboardReplacedText = clipboardReplaced.Text;

            clipboardReplacedText = clipboardReplacedText.Replace("\u200B", "");
            clipboardReplacedText = clipboardReplacedText.Replace("\u200C", "");
            clipboardReplacedText = clipboardReplacedText.Replace("\u200D", "");

            var clipboardSearchedText = clipboardSearched.Text;

            //==

            var regex = regexInputText;
            var replace = regexReplaceInputText;

            var filePath = "C:/temp/regexTransformFile.txt";

            if (!File.Exists(NppPath))
            {
                MessageBox.Show("Please correct nppPath in settings, other text editors should work too", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Optionally, you might want to return from the method or perform other actions as needed.
            }

            File.AppendAllText(filePath, $"\n~{regex}~{replace}~");


            clipboardSearched.Text = clipboardReplacedText;
            clipboardReplaced.Text = "";

            regexInput.Text = "";
            regexGeneratedText.Text = "";
            regexGeneratedText2.Text = "";
            regexReplaceInputBox.Text = "";
        }

        private void buttonTransformFile_Click(object sender, EventArgs e)
        {
            var filePath = "C:/temp/regexTransformFile.txt";

            if (!File.Exists(NppPath))
            {
                MessageBox.Show("Please correct nppPath in settings, other text editors should work too", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Optionally, you might want to return from the method or perform other actions as needed.
            }

            try
            {
                // Launch Notepad++ with the file
                Process.Start(NppPath, filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
