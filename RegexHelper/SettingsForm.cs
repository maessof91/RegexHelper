using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegexHelper
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

           // this.WindowState = FormWindowState.Maximized;
            LoadSettings();
        }

        private void LoadSettings()
        {
            var settingsType = Properties.Settings.Default.GetType();
            var properties = settingsType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.Module.Name == "RegexHelper.dll").ToList();

            foreach (var prop in properties)
            {
                var settingValue = prop.GetValue(Properties.Settings.Default, null);
                var label = new Label
                {
                    Text = prop.Name,
                    AutoSize = true
                };

                Control control;

                if (prop.PropertyType == typeof(int))
                {
                    control = new TextBox
                    {
                        Name = prop.Name,
                        Text = settingValue?.ToString(),
                        Dock = DockStyle.Fill
                    };
                }
                else
                if (prop.PropertyType == typeof(string))
                {
                    control = new TextBox
                    {
                        Name = prop.Name,
                        Text = settingValue?.ToString(),
                        Dock = DockStyle.Fill
                    };
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    control = new CheckBox
                    {
                        Name = prop.Name,
                        Checked = (bool)settingValue,
                        Dock = DockStyle.Fill
                    };
                }
                else
                {
                    // Handle other types as needed
                    continue;
                }
                tableLayoutPanel.RowCount+=1;

                RowStyle newRowStyle = new RowStyle(SizeType.AutoSize); // Or any other size type you prefer
                tableLayoutPanel.RowStyles.Add(newRowStyle);

                tableLayoutPanel.SetRow(label, tableLayoutPanel.RowCount);
                tableLayoutPanel.SetColumn(label, 0);

                tableLayoutPanel.SetRow(control, tableLayoutPanel.RowCount);
                tableLayoutPanel.SetColumn(control, 1);

                tableLayoutPanel.Controls.Add(label);
                tableLayoutPanel.Controls.Add(control);

            }
        }

        private void SaveSettings()
        {
            var settingsType = Properties.Settings.Default.GetType();
            var properties = settingsType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.Module.Name == "RegexHelper.dll").ToList();

            foreach (var prop in properties)
            {
                var control = tableLayoutPanel.Controls[prop.Name];

                if (control is TextBox textBox)
                {
                    //Properties.Settings.Default[prop.Name] = int.Parse(textBox.Text);

                    //Type form1Type = typeof(Form1);

                    //FieldInfo fieldInfo = form1Type.GetField(prop.Name, BindingFlags.Public | BindingFlags.Static);
                    //fieldInfo.SetValue(null, Properties.Settings.Default[prop.Name]);

                    if (prop.PropertyType == typeof(int))
                    {
                        // Try parsing the text as an integer
                        if (int.TryParse(textBox.Text, out int intValue))
                        {
                            Properties.Settings.Default[prop.Name] = intValue;

                            Type form1Type = typeof(Form1);
                            FieldInfo fieldInfo = form1Type.GetField(prop.Name, BindingFlags.Public | BindingFlags.Static);
                            fieldInfo.SetValue(null, intValue);
                        }
                        else
                        {
                            // Handle invalid input (optional)
                            MessageBox.Show("Invalid input for property " + prop.Name);
                        }
                    }
                    else if (prop.PropertyType == typeof(string))
                    {
                        // Directly assign the text as string
                        Properties.Settings.Default[prop.Name] = textBox.Text;

                        Type form1Type = typeof(Form1);
                        FieldInfo fieldInfo = form1Type.GetField(prop.Name, BindingFlags.Public | BindingFlags.Static);
                        fieldInfo.SetValue(null, textBox.Text);
                    }
                }
            }

            Properties.Settings.Default.Save();


            //Form1.maxMatches = Properties.Settings.Default.MaxMatches;
            //Form1.maxGroups = Properties.Settings.Default.maxGroups;


            this.Close();
        }

        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            save = new Button();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(save, 1, 0);
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.MinimumSize = new System.Drawing.Size(0, 800);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel.Size = new System.Drawing.Size(584, 800);
            tableLayoutPanel.TabIndex = 0;
            // 
            // save
            // 
            save.Dock = DockStyle.Fill;
            save.Location = new System.Drawing.Point(203, 3);
            save.Name = "save";
            save.Size = new System.Drawing.Size(378, 794);
            save.TabIndex = 0;
            save.Text = "save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // SettingsForm
            // 
            ClientSize = new System.Drawing.Size(584, 261);
            Controls.Add(tableLayoutPanel);
            MinimumSize = new System.Drawing.Size(600, 0);
            Name = "SettingsForm";
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Button save;
        private TableLayoutPanel tableLayoutPanel;

        private void save_Click(object sender, EventArgs e)
        {
            SaveSettings();
            MessageBox.Show("____________________________ Settings Saved ____________________________");
        }
    }
}
