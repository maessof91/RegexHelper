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

        private RichTextBox richTextBox;

        int inputGroups = 0;

        private List<RichTextBox> inputGroupsTextBoxes;


        public Form1()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;           

            UpdateClipboardText();
            regexInput.VisibleChanged += RegexInput_VisibleChanged;
            clipboardReplaced.VisibleChanged += ClipboardReplaced_VisibleChanged;

            inputGroupsTextBoxes = new List<RichTextBox>();

            this.clipboardSearched.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clipboardSearched_KeyDown);
            this.regexInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.regexInput_KeyDown);
            this.clipboardReplaced.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clipboardReplaced_KeyDown);

            keyBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
            keyBox.ForeColor = System.Drawing.Color.White;

            regexReplaceInputBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
            regexReplaceInputBox.ForeColor = System.Drawing.Color.White;

            clipboardSearched.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
            clipboardSearched.ForeColor = System.Drawing.Color.White;
            LogExecutionTime();

            LoadSettings();
        }


        public static int MaxMatches = 600;
        public static int MaxGroups = 1200;
        public static int Test = 1200;
        public static string NppPath = "";

        private static void LoadSettings()
        {
            Form1.MaxMatches = Properties.Settings.Default.MaxMatches;
            Form1.MaxGroups = Properties.Settings.Default.MaxGroups;
            Form1.NppPath = Properties.Settings.Default.NppPath;
            Form1.Test = Properties.Settings.Default.Test;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LogExecutionTime();

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
            LogExecutionTime();


        }


        private void GroupInput_TextChanged(object sender, EventArgs e)
        {
            LogExecutionTime();
            UpdateRegexInputBox();

            UpdateClipboardSearchTextArea();

            UpdateRegexReplaceInputAndClipboardReplacedTextView();

            UpdateRegexViewInputBox();
            LogExecutionTime();
        }

        //Search Text Box
        private void regexInput_TextChanged_1(object sender, EventArgs e)
        {
            LogExecutionTime();
            UpdateRegexInputBox();

            UpdateClipboardSearchTextArea();

            UpdateRegexReplaceInputAndClipboardReplacedTextView();

            UpdateRegexViewInputBox();
            LogExecutionTime();
        }

        //Replace Rext Box
        private void regexReplace_TextChanged(object sender, EventArgs e)
        {
            LogExecutionTime();
            UpdateRegexReplaceInputAndClipboardReplacedTextView();
            LogExecutionTime();
        }


        private void regexInput_KeyDown(object sender, KeyEventArgs e)
        {
            LogExecutionTime();
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the clipboard data as plain text
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                // Paste the plain text into the RichTextBox
                regexInput.SelectedText = clipboardText;
                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }
            LogExecutionTime();
        }


        private void clipboardReplaced_KeyDown(object sender, KeyEventArgs e)
        {
            LogExecutionTime();
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
            LogExecutionTime();
        }


        private void clipboardSearched_KeyDown(object sender, KeyEventArgs e)
        {
            LogExecutionTime();
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Get the clipboard data as plain text
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                // Paste the plain text into the RichTextBox
                clipboardSearched.SelectedText = clipboardText;
                // Cancel the paste operation
                e.SuppressKeyPress = true;
            }
            LogExecutionTime();
        }


        private void RegexInput_VisibleChanged(object sender, EventArgs e)
        {
            LogExecutionTime();
            BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
            {
                regexInput.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
                regexInput.ForeColor = System.Drawing.Color.White;
                regexInput.Focus();

                regexGeneratedText2.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
                regexGeneratedText2.ForeColor = System.Drawing.Color.White;
            });
            LogExecutionTime();
        }


        private void ClipboardReplaced_VisibleChanged(object sender, EventArgs e)
        {
            LogExecutionTime();
            BeginInvoke((System.Windows.Forms.MethodInvoker)delegate
            {
                clipboardReplaced.BackColor = System.Drawing.Color.FromArgb(45, 45, 48); // Dark background color
                clipboardReplaced.ForeColor = System.Drawing.Color.White;
            });
            LogExecutionTime();
        }


        private void LeftPaneDisplayMatches(MatchCollection matches, RichTextBox inputBox)
        {
            LogExecutionTime();
            var matchesCount = matches.Count;

            inputBox.SelectionStart = 0;
            inputBox.SelectionLength = inputBox.TextLength;
            inputBox.SelectionBackColor = inputBox.BackColor;
            inputBox.SelectionColor = Color.White;

            var colorForFirst = Color.FromArgb(10, 10, 10);
            var colorForLast = Color.FromArgb(30, 30, 30);

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
                        inputBox.SelectionBackColor = colorForFirst;
                    }
                    else
                    if (twoCharGroup)
                    {
                        inputBox.SelectionStart = group.Index;
                        inputBox.SelectionLength = 1;
                        inputBox.SelectionBackColor = colorForFirst;

                        inputBox.SelectionStart = group.Index + 1;
                        inputBox.SelectionLength = 1;
                        inputBox.SelectionBackColor = colorForLast;
                    }
                    else
                    if (firstGroup)
                    {
                        inputBox.SelectionStart = group.Index;
                        inputBox.SelectionLength = 1;
                        inputBox.SelectionBackColor = colorForFirst;

                        inputBox.SelectionStart = group.Index + group.Length - 1;
                        inputBox.SelectionLength = 1;
                        inputBox.SelectionBackColor = colorForLast;
                    }

                    groupIndex++;
                    groupsHit++;
                }

            }
            LogExecutionTime();
        }


        private void UpdateClipboardSearchTextArea()
        {
            LogExecutionTime();

            if (
              string.IsNullOrEmpty(regexInput.Text)
              &&
              string.IsNullOrEmpty(clipboardSearched.Text)
              )
            {
                LogExecutionTime();
                return;
            }

            string regexPattern = regexInput.Text;

            regexPattern = SubstituteGroupsTextBoxesIn(regexPattern);

            regexGeneratedText.Text = regexPattern;

            string clipboardText = clipboardSearched.Text;          

            try
            {
                Regex regex = new Regex(regexPattern);
                MatchCollection matches = regex.Matches(clipboardText);
                LeftPaneDisplayMatches(matches, clipboardSearched);
            }
            catch (ArgumentException)
            {
                // richTextBox1.Text = "Invalid regular expression pattern.";
            }
            
            LogExecutionTime();
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
            LogExecutionTime();
            string clipboardText = Clipboard.GetText();
            this.clipboardSearched.Text = clipboardText ?? "Clipboard does not contain text.";
            LogExecutionTime();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LogExecutionTime();
            //HighlightRegexSpecialCharacters(regexInput);

            regexInput.SelectionStart = 0;
            regexInput.SelectionLength = 1;
            regexInput.SelectionBackColor = Color.Yellow;

            UpdateClipboardSearchTextArea();
            LogExecutionTime();
        }


        private void AddGroup_Click(object sender, EventArgs e)
        {
            Console.Clear();
            LogExecutionTime();
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
            LogExecutionTime();
        }


        private void UpdateRegexInputBox()
        {
            LogExecutionTime();
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

            var pairs = GetPairs(regexInput.Text, '(', ')');
            pairs = pairs.OrderBy(u => u.Item1).ToList();

            var col = 1;
            foreach (var pair in pairs)
            {
                MarkTextFull(pair.Item1, pair.Item2 + 1, Colors.groupColors[col],Colors.groupColorsContrasted[col], regexInput);

                col++;
            }

            if (regexInput.Focused)
            {
                regexInput.Select(cursorPosition, 0);
            }
            LogExecutionTime();
        }


        private void UpdateRegexViewInputBox()
        {
            LogExecutionTime();
            string regexPattern = regexInput.Text;

            for (int i = inputGroupsTextBoxes.Count - 1; i >= 0; i--)
            {
                regexPattern = regexPattern.Replace("#" + (i + 1), inputGroupsTextBoxes[i].Text);
            }

            var text = regexPattern;

            text = text.Replace(@"[\s\S\r\n]", "●");
            text = text.Replace(@"[\s\S\n\r]", "●");
            text = text.Replace(@"[\s\r\S\n]", "●");
            text = text.Replace(@"[\s\r\n\S]", "●");
            text = text.Replace(@"[\s\n\S\r]", "●");
            text = text.Replace(@"[\s\n\r\S]", "●");
            text = text.Replace(@"[\S\s\r\n]", "●");
            text = text.Replace(@"[\S\s\n\r]", "●");
            text = text.Replace(@"[\S\r\s\n]", "●");
            text = text.Replace(@"[\S\r\n\s]", "●");
            text = text.Replace(@"[\S\n\s\r]", "●");
            text = text.Replace(@"[\S\n\r\s]", "●");
            text = text.Replace(@"[\r\s\S\n]", "●");
            text = text.Replace(@"[\r\s\n\S]", "●");
            text = text.Replace(@"[\r\S\s\n]", "●");
            text = text.Replace(@"[\r\S\n\s]", "●");
            text = text.Replace(@"[\r\n\s\S]", "●");
            text = text.Replace(@"[\r\n\S\s]", "●");
            text = text.Replace(@"[\n\s\S\r]", "●");
            text = text.Replace(@"[\n\s\r\S]", "●");
            text = text.Replace(@"[\n\S\s\r]", "●");
            text = text.Replace(@"[\n\S\r\s]", "●");
            text = text.Replace(@"[\n\r\s\S]", "●");
            text = text.Replace(@"[\n\r\S\s]", "●");


            text = text.Replace("\\r?\\n", "⏎");
            text = text.Replace("\\r", "`r");
            text = text.Replace("\\n", "`n");

            text = text.Replace("\\w", "💬");
            text = text.Replace("\\d", "🔟");
            //text = text.Replace(".", "🤷‍");
            text = text.Replace("^", "🏁");
            text = text.Replace("$", "🔚");
            text = text.Replace("\\b", "🎁");
            //text = text.Replace("+", "🍄");
            //text = text.Replace("*", "♾");
            //text = text.Replace("?", "❓");
            text = text.Replace("\\s", "﹏");

            text = text.Replace("\\", "\u200D");
            text = text.Replace("(", "\u200B");
            text = text.Replace(")", "\u200C");
            text = text.Replace("\u200D" + "\u200B", "\u200D" + "(");
            text = text.Replace("\u200D" + "\u200C", "\u200D" + ")");

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

            var pairs = GetPairs(text, '\u200B', '\u200C');

            pairs = pairs.OrderBy(u => u.Item1).ToList();

            regexGeneratedText2.Text = text;

            var col = 1;
            foreach (var pair in pairs)
            {
                MarkTextFull(pair.Item1, pair.Item2 + 1, Colors.groupColors[col], Colors.groupColorsContrasted[col], regexGeneratedText2);

                col++;
            }
            LogExecutionTime();
        }


        void MarkTextFull(int indexStart, int indexEnd, Color color,Color colorBack, RichTextBox input)
        {
            input.SelectionStart = indexStart;
            input.SelectionLength = indexEnd - indexStart;
            input.SelectionColor = color;
            input.SelectionBackColor = colorBack;
        }


        static List<(int, int)> GetPairs(string input, char start, char end)
        {
            LogExecutionTime();
            var pairs = new List<(int, int)>();
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == start && (i == 0 || input[i - 1] != '\\'))
                {
                    stack.Push(i);
                }
                else if (input[i] == end && (i == 0 || input[i - 1] != '\\'))
                {
                    if (stack.Count > 0)
                    {
                        int openingIndex = stack.Pop();
                        pairs.Add((openingIndex, i));
                    }
                    else
                    {

                    }
                }
            }

            if (stack.Count > 0)
            {
            }

            LogExecutionTime();
            return pairs;
        }



        void UpdateRegexReplaceInputAndClipboardReplacedTextView()
        {
            LogExecutionTime();
            string regexPattern = UpdateRegexReplaceInputBox();

            UpdateClipboardReplacedTextPannel(regexPattern);

            LogExecutionTime();
        }

        private void UpdateClipboardReplacedTextPannel(string regexPattern)
        {
            LogExecutionTime();

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

                    clipboardReplaced.Text = Regex.Replace(clipboardText, regexPattern, replacePattern);
                    //DisplayMatches(matches, clipboardReplaced);

                    clipboardReplaced.SelectionStart = 0;
                    clipboardReplaced.SelectionLength = clipboardReplaced.Text.Length;
                    clipboardReplaced.SelectionColor = Color.White;

                    var pairs = GetPairs(clipboardReplaced.Text, '\u200B', '\u200C');
                    //var pairs = GetPairs(clipboardReplaced.Text, '>', '<');

                    pairs = MarkMatchesAndGroups(pairs);
                }
                catch (Exception)
                {

                }
            }
            LogExecutionTime();
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
                MarkTextFull(pair.Item1, pair.Item2 + 1, Colors.groupColors[col], Colors.groupColorsContrasted[col], clipboardReplaced);

                col++;
            }

            return pairs;
        }

        private string UpdateRegexReplaceInputBox()
        {
            LogExecutionTime();

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

            LogExecutionTime();
            return regexPattern;
        }

        private static Dictionary<string, Stopwatch> stopwatches = new Dictionary<string, Stopwatch>();

        public static int indent = 0;
        public static void LogExecutionTime()
        {

            // Get the method name where LogExecutionTime was called from
            var callingMethodName = new StackTrace().GetFrame(1).GetMethod().Name;

            //Console.WriteLine($"Method: {callingMethodName}");

            if (!stopwatches.ContainsKey(callingMethodName))
            {
                indent++;
                stopwatches[callingMethodName] = Stopwatch.StartNew();
                string tabs = string.Join("", Enumerable.Repeat("\t", indent));
                Console.WriteLine($"{tabs}New Method: {callingMethodName}");
                Console.WriteLine($"{tabs}Method: {callingMethodName}: Start");

            }
            else
            {
                var stopwatch = stopwatches[callingMethodName];

                if (stopwatch.IsRunning)
                {
                    stopwatch.Stop();
                    string tabs = string.Join("", Enumerable.Repeat("\t", indent));
                    Console.WriteLine($"{tabs}Method: {callingMethodName}: End    :{stopwatch.ElapsedMilliseconds} ms");
                    indent--;
                }
                else
                {
                    indent++;
                    string tabs = string.Join("", Enumerable.Repeat("\t", indent));
                    Console.WriteLine($"{tabs}Method: {callingMethodName}: Start");
                    stopwatches[callingMethodName] = Stopwatch.StartNew();

                }
            }
        }

        #region NotUsed
        void AllBelowHereIsNonsence______________________________________()
        {

        }

        //void MarkText(int indexStart, int indexEnd, Color color, RichTextBox regexInput)
        //{
        //    regexInput.SelectionStart = indexStart;
        //    regexInput.SelectionLength = 1;
        //    regexInput.SelectionColor = color;

        //    regexInput.SelectionStart = indexEnd;
        //    regexInput.SelectionLength = 1;
        //    regexInput.SelectionColor = color;
        //}

        //static List<(int, int)> GetBracketPairs(string input)
        //{
        //    var pairs = new List<(int, int)>();
        //    var stack = new Stack<int>();

        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        if (input[i] == '(' && (i == 0 || input[i - 1] != '\\'))
        //        {
        //            stack.Push(i);
        //        }
        //        else if (input[i] == ')' && (i == 0 || input[i - 1] != '\\'))
        //        {
        //            if (stack.Count > 0)
        //            {
        //                int openingIndex = stack.Pop();
        //                pairs.Add((openingIndex, i));
        //            }
        //            else
        //            {

        //            }
        //        }
        //    }

        //    if (stack.Count > 0)
        //    {
        //    }

        //    return pairs;
        //}

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
