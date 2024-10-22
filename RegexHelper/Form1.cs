﻿using System;
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

        #region Setup
        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            UpdateClipboardSearchedTextArea();
            regexSearchInputBox.VisibleChanged += RegexSearchInputBox_VisibleChanged;
            clipboardReplacedTextArea.VisibleChanged += ClipboardReplacedTextArea_VisibleChanged;

            inputGroupsTextBoxes = new List<RichTextBox>();

            this.clipboardSearchedTextArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clipboardSearchedTextArea_KeyDown);
            this.clipboardSearchedTextArea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.clipboardSearchedTextArea_KeyUp);
            this.regexSearchInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.regexSearchInputBox_KeyDown);
            this.clipboardReplacedTextArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clipboardReplacedTextArea_KeyDown);

            keyBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
            keyBox.ForeColor = System.Drawing.Color.White;

            regexReplaceInputBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
            regexReplaceInputBox.ForeColor = System.Drawing.Color.White;

            clipboardSearchedTextArea.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
            clipboardSearchedTextArea.ForeColor = System.Drawing.Color.White;
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

            clipboardSearchedTextArea.AutoWordSelection = false; ;
            clipboardReplacedTextArea.AutoWordSelection = false; ;
            regexReplaceInputBox.AutoWordSelection = false; ;
            regexSearchInputBox.AutoWordSelection = false; ;
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

        #endregion

        //======================================================================================================

        #region Group Functions

        private void GroupInput_TextChanged(object sender, EventArgs e)
        {
            Log.LogExecutionTime();
            UpdateRegexSearchInputBox();

            UpdateClipboardSearchTextArea();

            UpdateRegexReplaceInputAndClipboardReplacedTextView();

            UpdateRegexViewInputBox();
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

        private void AddGroup_Click(object sender, EventArgs e)
        {
            Console.Clear();
            Log.LogExecutionTime();
            RichTextBox newTextBox = new RichTextBox();
            newTextBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
            newTextBox.ForeColor = System.Drawing.Color.White;
            newTextBox.Size = new System.Drawing.Size(483, 43);
            newTextBox.Font = new System.Drawing.Font(newTextBox.Font.FontFamily, 14f);
            newTextBox.BorderStyle = BorderStyle.None;
            inputGroups++;
            newTextBox.Name = $"group{inputGroups}";
            regexSearchInputBox.Text += $"(#{inputGroups})";

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

        #endregion

        //======================================================================================================

        #region Regex Search Inputbox

        /// <summary>
        /// The regex search pattern text changed
        /// </summary>
        private void regexSearchInputbox_TextChanged_1(object sender, EventArgs e)
        {
            Log.LogExecutionTime();
            UpdateRegexSearchInputBox();

            UpdateClipboardSearchTextArea();

            UpdateRegexReplaceInputAndClipboardReplacedTextView();

            UpdateRegexViewInputBox();
            Log.LogExecutionTime();
        }

        //todo is below used
        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    Log.LogExecutionTime();
        //    //HighlightRegexSpecialCharacters(regexInput);

        //    regexSearchInputBox.SelectionStart = 0;
        //    regexSearchInputBox.SelectionLength = 1;
        //    regexSearchInputBox.SelectionBackColor = Color.Yellow;

        //    UpdateClipboardSearchTextArea();
        //    Log.LogExecutionTime();
        //}

        private void regexSearchInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            Log.LogExecutionTime();
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the clipboard data as plain text
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                // Paste the plain text into the RichTextBox
                regexSearchInputBox.SelectedText = clipboardText;
                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }
            Log.LogExecutionTime();
        }

        private void RegexSearchInputBox_VisibleChanged(object sender, EventArgs e)
        {
            Log.LogExecutionTime();
            BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
            {
                regexSearchInputBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
                regexSearchInputBox.ForeColor = System.Drawing.Color.White;
                regexSearchInputBox.Focus();

                regexGeneratedText2.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
                regexGeneratedText2.ForeColor = System.Drawing.Color.White;
            });
            Log.LogExecutionTime();
        }

        private void UpdateRegexSearchInputBox()
        {
            Log.LogExecutionTime();
            int cursorPosition = regexSearchInputBox.SelectionStart;

            regexSearchInputBox.SelectionStart = 0;
            regexSearchInputBox.SelectionLength = regexSearchInputBox.Text.Length;
            regexSearchInputBox.SelectionColor = Colors.groupColors[0];
            //regexSearchInputBox.SelectionBackColor = Colors.groupColorsContrasted[0];

            foreach (char specialChar in @"[](){}^$.|*+?\")
            {
                int index = -1;

                //in a loop to find the character multiple times
                while ((index = regexSearchInputBox.Text.IndexOf(specialChar, index + 1)) != -1)
                {
                    regexSearchInputBox.SelectionStart = index;
                    regexSearchInputBox.SelectionLength = 1;
                    regexSearchInputBox.SelectionColor = Color.Cyan;
                }
            }

            var pairs = Util.GetPairs(regexSearchInputBox.Text, '(', ')');
            pairs = pairs.OrderBy(u => u.Item1).ToList();

            var col = 1;
            foreach (var pair in pairs)
            {
                Util.MarkTextFull(pair.Item1, pair.Item2 + 1, Colors.groupColors[col], Colors.groupColorsContrasted[col], regexSearchInputBox);

                col++;
            }

            if (regexSearchInputBox.Focused)
            {
                regexSearchInputBox.Select(cursorPosition, 0);
            }
            Log.LogExecutionTime();
        }

        #endregion

        //======================================================================================================

        #region Regex Replace Inputbox

        /// <summary>
        /// The replacement regex syntax eg " a $1$2 "
        /// </summary>
        private void regexReplaceInputbox_TextChanged(object sender, EventArgs e)
        {
            Log.LogExecutionTime();
            UpdateRegexReplaceInputAndClipboardReplacedTextView();
            Log.LogExecutionTime();
        }

        void UpdateRegexReplaceInputAndClipboardReplacedTextView()
        {
            Log.LogExecutionTime();
            string regexPattern = UpdateRegexReplaceInputBox();

            UpdateClipboardReplacedTextPannel(regexPattern);

            Log.LogExecutionTime();
        }

        private string UpdateRegexReplaceInputBox()
        {
            Log.LogExecutionTime();

            int regexReplacecursorPosition = regexReplaceInputBox.SelectionStart;

            string regexPattern = regexSearchInputBox.Text;

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
        #endregion

        //======================================================================================================

        #region Clipboard Search Textarea : Left Pane
        /// <summary>
        /// The left Pane, The text to regex search
        /// </summary>
        private void clipboardSearched_TextChanged(object sender, EventArgs e) { }
        private void UpdateClipboardSearchedTextArea()
        {
            Log.LogExecutionTime();
            string clipboardText = Clipboard.GetText();

            clipboardSearchTrueText = clipboardText;

            if (WhiteSpace.ShowWhitespace)
            {
                clipboardText = WhiteSpace.ToViewableWhitespace(clipboardText);
            }

            this.clipboardSearchedTextArea.Text = clipboardText ?? "Clipboard does not contain text.";

            Log.LogExecutionTime();
        }

        private void UpdateClipboardSearchTextArea()
        {
            Log.LogExecutionTime();

            if (
              string.IsNullOrEmpty(regexSearchInputBox.Text)
              &&
              string.IsNullOrEmpty(clipboardSearchedTextArea.Text)
              )
            {
                Log.LogExecutionTime();
                return;
            }

            string regexPattern = regexSearchInputBox.Text;

            regexPattern = SubstituteGroupsTextBoxesIn(regexPattern);

            regexGeneratedText.Text = regexPattern;

            //string clipboardText = clipboardSearched.Text;          
            string textToRegexSearch = clipboardSearchTrueText;

            if (WhiteSpace.ShowWhitespace)
            {
                textToRegexSearch = WhiteSpace.ToVisibleNewLine(textToRegexSearch);
            }
            else
            {
                textToRegexSearch = textToRegexSearch.Replace("\r\n", "\n");
            }

            try
            {
                var regexPatternWithVisibleNewLine = regexPattern;

                if (WhiteSpace.ShowWhitespace)
                {
                    regexPatternWithVisibleNewLine = WhiteSpace.searchToVisibleNewLine(regexPatternWithVisibleNewLine);
                }
                else
                {
                    regexPatternWithVisibleNewLine = regexPatternWithVisibleNewLine.Replace("\\r\\n", "\\n");
                }

                Regex regex = new Regex(regexPatternWithVisibleNewLine);
                MatchCollection matches = regex.Matches(textToRegexSearch);
                LeftPaneDisplayMatches(matches, clipboardSearchedTextArea, textToRegexSearch);
            }
            catch (ArgumentException)
            {
                // richTextBox1.Text = "Invalid regular expression pattern.";
            }

            Log.LogExecutionTime();
        }

        private void LeftPaneDisplayMatches(MatchCollection matches, RichTextBox inputBox, string textToRegexSearch)
        {
            Log.LogExecutionTime();
            var matchesCount = matches.Count;

            inputBox.SelectionStart = 0;
            inputBox.SelectionLength = inputBox.TextLength;
            //inputBox.SelectionBackColor = inputBox.BackColor;
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
                        //inputBox.SelectionBackColor = colorForFirstChar;
                    }
                    else
                    if (twoCharGroup)
                    {
                        inputBox.SelectionStart = group.Index;
                        inputBox.SelectionLength = 1;
                        //inputBox.SelectionBackColor = colorForFirstChar;

                        inputBox.SelectionStart = group.Index + 1;
                        inputBox.SelectionLength = 1;
                        //inputBox.SelectionBackColor = colorForLastChar;
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

        private void clipboardSearchedTextArea_KeyDown(object sender, KeyEventArgs e)
        {
            Log.LogExecutionTime();
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the clipboard data as plain text
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);

                clipboardSearchTrueText = clipboardText;

                if (WhiteSpace.ShowWhitespace)
                {
                    clipboardText = WhiteSpace.ToViewableWhitespace(clipboardText);
                }

                // Paste the plain text into the RichTextBox
                clipboardSearchedTextArea.SelectedText = clipboardText;
                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }

            Log.LogExecutionTime();
        }

        private void clipboardSearchedTextArea_KeyUp(object sender, KeyEventArgs e)
        {
            Log.LogExecutionTime();

            if (e.KeyCode == Keys.Space && WhiteSpace.ShowWhitespace)
            {
                var pos = clipboardSearchedTextArea.SelectionStart;
                clipboardSearchedTextArea.Text = WhiteSpace.ToViewableWhitespace(clipboardSearchedTextArea.Text);
                clipboardSearchedTextArea.SelectionStart = pos;
                clipboardSearchTrueText = WhiteSpace.ToInvisibleWhiteSpace(clipboardSearchedTextArea.Text);

                e.SuppressKeyPress = true;
            }

            Log.LogExecutionTime();
        }

        #endregion

        //======================================================================================================

        #region Clipboard Replace Textarea : Right Pane

        /// <summary>
        /// Right Pane Clipboard Replaced Text Area
        /// </summary>
        private void clipboardReplaced_TextChanged(object sender, EventArgs e) { }

        private void UpdateClipboardReplacedTextPannel(string regexPattern)
        {
            Log.LogExecutionTime();

            string replacePattern = regexReplaceInputBox.Text;
            char groupStartChar = '\u200B';
            char groupIndexChar = '\u200E';
            char groupEndChar = '\u200C';
            replacePattern = AddHiddenMarkingSymbols(replacePattern, groupStartChar, groupIndexChar, groupEndChar);

            replacePattern = replacePattern.Replace("\\n", "\n");
            replacePattern = replacePattern.Replace("\\r", "\r");
            replacePattern = replacePattern.Replace("\\t", "\t");

            var clipboardText = clipboardSearchedTextArea.Text;

            if (clipboardText != null && regexPattern != null && replacePattern != null)
            {
                try
                {
                    clipboardReplacedTextArea.Text = Regex.Replace(clipboardSearchTrueText, regexPattern, replacePattern);

                    clipboardReplacedTextArea.SelectionStart = 0;
                    clipboardReplacedTextArea.SelectionLength = clipboardReplacedTextArea.Text.Length;
                    clipboardReplacedTextArea.SelectionColor = Color.White;

                    var pairs = Util.GetPairsReplaced(clipboardReplacedTextArea.Text, groupStartChar, groupEndChar, groupIndexChar);


                    pairs = MarkMatchesAndGroups(pairs);
                }
                catch (Exception)
                {

                }
            }
            Log.LogExecutionTime();
        }

        private static string AddHiddenMarkingSymbols(string replacePattern, char groupStartChar, char groupIndexChar, char groupEndChar)
        {
            var groups = Regex.Matches(replacePattern, @"\$\d+");
            var alreadyCompletedNumbers = new Dictionary<int, int>();
            foreach (Match group in groups)
            {
                var text = group.Value;
                var numberString = group.Value.Substring(1);
                var number = Int32.Parse(numberString);

                if (alreadyCompletedNumbers.ContainsKey(number))
                {
                    continue;
                }

                alreadyCompletedNumbers.Add(number, number);

                var newText = "" + groupStartChar;
                for (int i = 0; i < number; i++)
                {
                    newText += groupIndexChar;
                }
                newText += text;
                newText += groupEndChar;

                replacePattern = replacePattern.Replace(text, newText);
            }

            return replacePattern;
        }

        private void clipboardReplacedTextArea_KeyDown(object sender, KeyEventArgs e)
        {
            Log.LogExecutionTime();
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the clipboard data as plain text
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                // Paste the plain text into the RichTextBox
                regexSearchInputBox.SelectedText = clipboardText;
                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                var text = clipboardReplacedTextArea.SelectedText;

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

        private void ClipboardReplacedTextArea_VisibleChanged(object sender, EventArgs e)
        {
            Log.LogExecutionTime();
            BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
            {
                clipboardReplacedTextArea.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
                clipboardReplacedTextArea.ForeColor = System.Drawing.Color.White;
            });
            Log.LogExecutionTime();
        }
        #endregion

        //======================================================================================================

        #region Regex View Input Box
        private void UpdateRegexViewInputBox()
        {
            Log.LogExecutionTime();
            string regexPattern = regexSearchInputBox.Text;

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
        #endregion

        //======================================================================================================

        private List<(int, int, int)> MarkMatchesAndGroups(List<(int, int, int)> pairs)
        {
            var endOfMatches = Regex.Matches(clipboardReplacedTextArea.Text, "\u200D");

            var endOfMatchesIndexes = endOfMatches
                .Select(m => (m as Match).Index)
                .OrderBy(i => i)
                .ToList();

            pairs = pairs
                .OrderBy(u => u.Item1)
                .ToList();

            var col = 0;
            var i = 0;
            foreach (var pair in pairs)
            {
                if (i >= MaxMatches - 2)
                {
                    break;
                }

                //if (endOfMatchesIndexes[i] < pair.Item1)
                //{
                //    col = 0;
                //    i++;
                //}

                Util.MarkTextFull(
                    pair.Item1,
                    pair.Item2 + 1,
                    Colors.groupColors[pair.Item3],
                    Colors.groupColorsContrasted[col],
                    clipboardReplacedTextArea);

                col++;
            }

            return pairs;
        }
       

      

        #region NotUsed
        void AllBelowHereIsNonsence______________________________________()
        {

        }




        private void RegexView_TextChanged(object sender, EventArgs e)
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
            var rI = regexSearchInputBox.Text;
            var regexReplaceInputText = regexReplaceInputBox.Text;
            var regexInputText = regexGeneratedText.Text;

            var clipboardReplacedText = clipboardReplacedTextArea.Text;

            clipboardReplacedText = clipboardReplacedText.Replace("\u200B", "");
            clipboardReplacedText = clipboardReplacedText.Replace("\u200C", "");
            clipboardReplacedText = clipboardReplacedText.Replace("\u200D", "");

            var clipboardSearchedText = clipboardSearchedTextArea.Text;

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


            clipboardSearchedTextArea.Text = clipboardReplacedText;
            clipboardReplacedTextArea.Text = "";

            regexSearchInputBox.Text = "";
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

        private void regexGeneratedText2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
