using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EliteTheme
{
    public partial class MainFrm : Form
    {
        //http://arkku.com/elite/hud_editor/ - web editor
        //https://www.reddit.com/r/EliteDangerous/comments/2sqg81/10_more_ui_themes_with_a_focus_on_readability/
        //https://www.reddit.com/r/EliteDangerous/comments/2p3784/you_can_manually_customize_the_gui_colors
        //http://imgur.com/gallery/GB7Dd - snakeeyesx21 gallery
        //http://imgur.com/gallery/RVEsI - black ui
        //https://forums.frontier.co.uk/showthread.php?t=73419 - 20 page thread with presets

        //https://docs.rainmeter.net/tips/colormatrix-guide/

        Theme currentTheme = new Theme();
        bool ignoreUpdate = false;
        Random randomGenerator = new Random();
        int currentBitmapIdx = 0;
        List<Bitmap> previewScreenshots = new List<Bitmap>();

        public MainFrm()
        {
            InitializeComponent();

            //guess where the game is made
            //guess what has hardcoded the culture
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");

            ChangePickerLimit(1000);
            
            previewScreenshots.Add(EliteTheme.Properties.Resources.ui_test_bit_of_everything);
            previewScreenshots.Add(EliteTheme.Properties.Resources.commodities_rare);
            previewScreenshots.Add(EliteTheme.Properties.Resources.bulletin_board);
            previewScreenshots.Add(EliteTheme.Properties.Resources.screenshot);
            previewScreenshots.Add(EliteTheme.Properties.Resources.ed_collage);

            if (File.Exists(PathToOverride()))
            {
                string overrideContents = File.ReadAllText(PathToOverride());
                Theme currentOverride = ParseMatrixText(overrideContents);
                if (currentOverride != null)
                {
                    currentOverride.Name = "Current (As of startup)";
                    presetListBox.Items.Add(currentOverride);
                }
            }
           
            presetListBox.Items.AddRange(PresetThemes.List());

            LoadCustom();

            DisableCustomControls();

            //Double buffer the previewPanel without having to subclass Panel (DoubleBuffered is a protected property)
            //http://stackoverflow.com/questions/76993/how-to-double-buffer-net-controls-on-a-form
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty(
               "DoubleBuffered",
               System.Reflection.BindingFlags.NonPublic |
               System.Reflection.BindingFlags.Instance);
            aProp.SetValue(previewPanel, true, null);

            string pickerHelp = "Basics:" + Environment.NewLine;
            pickerHelp += "Keep values between 0 and 100 to begin with" + Environment.NewLine;
            pickerHelp += "Red row handles the main UI tint" + Environment.NewLine;
            pickerHelp += "Green row affects the accents (shields etc.)" + Environment.NewLine;
            pickerHelp += "Blue row affects the accents aswell" + Environment.NewLine;

            pickerHelpLabel.Text = pickerHelp;
        }
        
        private string PathToOverrideDirectory()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            if (Environment.OSVersion.Platform == PlatformID.MacOSX) // or Unix...
            {
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Library" + Path.DirectorySeparatorChar + "Application Support");
            }

            path += Path.DirectorySeparatorChar + "Frontier Developments";
            path += Path.DirectorySeparatorChar + "Elite Dangerous";
            path += Path.DirectorySeparatorChar + "Options";
            path += Path.DirectorySeparatorChar + "Graphics";
            path += Path.DirectorySeparatorChar;

            return path;
        }

        private string PathToOverride()
        {
            string path = PathToOverrideDirectory();
            path += "GraphicsConfigurationOverride.xml";
            return path;
        }

        private void SetTheme(Theme theme)
        {
            UpdatePickerValues();

            if (theme != null) // pickers or not
            {
                currentTheme = theme.Clone();
            }
            else
            {
                currentTheme.Altered = true;
            }

            themeNameLabel.Text = currentTheme.Name;
            matrixTextBox.Text = MatrixToString(currentTheme.Matrix);
            previewPanel.Invalidate();
        }

        private string F(float v)
        {
            return v.ToString("n7");
        }

        private string MatrixToString(float[][] matrix)
        {
            string m = "";

            m += "<MatrixRed> " + F(matrix[0][0]) + ", " + F(matrix[0][1]) + ", " + F(matrix[0][2]) + " </MatrixRed>\n";
            m += "<MatrixGreen> " + F(matrix[1][0]) + ", " + F(matrix[1][1]) + ", " + F(matrix[1][2]) + " </MatrixGreen>\n";
            m += "<MatrixBlue> " + F(matrix[2][0]) + ", " + F(matrix[2][1]) + ", " + F(matrix[2][2]) + " </MatrixBlue>\n";

            return m;
        }

        private void CreateMatrixConfig(Theme theme)
        {
            string data = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n";
            data += "<GraphicsConfig>\n";
            data += "    <GUIColour>\n";
            data += "        <Default>\n";
            data += "            <LocalisationName>Standard</LocalisationName>\n";
            data += "            <MatrixRed> " + F(theme.Matrix[0][0]) + ", " + F(theme.Matrix[0][1]) + ", " + F(theme.Matrix[0][2]) + " </MatrixRed>\n";
            data += "            <MatrixGreen> " + F(theme.Matrix[1][0]) + ", " + F(theme.Matrix[1][1]) + ", " + F(theme.Matrix[1][2]) + " </MatrixGreen>\n";
            data += "            <MatrixBlue> " + F(theme.Matrix[2][0]) + ", " + F(theme.Matrix[2][1]) + ", " + F(theme.Matrix[2][2]) + " </MatrixBlue>\n";
            data += "        </Default>\n";
            data += "    </GUIColour>\n";
            data += "</GraphicsConfig>\n";

            string path = PathToOverride();

            File.WriteAllText(path, data);

            MessageBox.Show("Success!\n" + theme.Name + " should now be used by Elite");
        }

        private void SaveCustom()
        {
            List<Theme> themes = new List<Theme>();
            foreach(Theme theme in customListBox.Items)
            {
                themes.Add(theme);
            }

            try
            {
                using (Stream stream = File.Create("customThemes.xml"))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Theme>), new XmlRootAttribute("Themes"));
                    ser.Serialize(stream, themes);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception:\n" + exc.Message);
            }
        }

        private void LoadCustom()
        {
            if (!File.Exists("customThemes.xml")) return;

            List<Theme> themes = new List<Theme>();

            try
            {
                using (Stream stream = File.Open("customThemes.xml", FileMode.Open))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Theme>), new XmlRootAttribute("Themes"));
                    themes = (List<Theme>)ser.Deserialize(stream);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("Exception:\n" + exc.Message);
            }

            customListBox.Items.AddRange(themes.ToArray());
        }

        private void AddCurrentCustom()
        {
            if (currentTheme.Altered)
            {
                currentTheme.Name += " - " + DateTime.Now.ToString("yyyyMMdd");

                currentTheme.Altered = false;
                currentTheme.Preset = false;
                currentTheme.Custom = true;

                customListBox.Items.Add(currentTheme);
            }
        }

        private void UpdatePickerValues()
        {
            ignoreUpdate = true;

            redRedNumeric.Value = (int)(currentTheme.Matrix[0][0] * 100);
            redRedScroll.Value = (int)(currentTheme.Matrix[0][0] * 100);
            redGreenNumeric.Value = (int)(currentTheme.Matrix[0][1] * 100);
            redGreenScroll.Value = (int)(currentTheme.Matrix[0][1] * 100);
            redBlueNumeric.Value = (int)(currentTheme.Matrix[0][2] * 100);
            redBlueScroll.Value = (int)(currentTheme.Matrix[0][2] * 100);

            greenRedNumeric.Value = (int)(currentTheme.Matrix[1][0] * 100);
            greenRedScroll.Value = (int)(currentTheme.Matrix[1][0] * 100);
            greenGreenNumeric.Value = (int)(currentTheme.Matrix[1][1] * 100);
            greenGreenScroll.Value = (int)(currentTheme.Matrix[1][1] * 100);
            greenBlueNumeric.Value = (int)(currentTheme.Matrix[1][2] * 100);
            greenBlueScroll.Value = (int)(currentTheme.Matrix[1][2] * 100);

            blueRedNumeric.Value = (int)(currentTheme.Matrix[2][0] * 100);
            blueRedScroll.Value = (int)(currentTheme.Matrix[2][0] * 100);
            blueGreenNumeric.Value = (int)(currentTheme.Matrix[2][1] * 100);
            blueGreenScroll.Value = (int)(currentTheme.Matrix[2][1] * 100);
            blueBlueNumeric.Value = (int)(currentTheme.Matrix[2][2] * 100);
            blueBlueScroll.Value = (int)(currentTheme.Matrix[2][2] * 100);

            ignoreUpdate = false;
        }

        private void ChangePickerLimit(int value)
        {
            //Maximum

            redRedNumeric.Maximum = value;
            redRedScroll.Maximum = value;
            redGreenNumeric.Maximum = value;
            redGreenScroll.Maximum = value;
            redBlueNumeric.Maximum = value;
            redBlueScroll.Maximum = value;

            greenRedNumeric.Maximum = value;
            greenRedScroll.Maximum = value;
            greenGreenNumeric.Maximum = value;
            greenGreenScroll.Maximum = value;
            greenBlueNumeric.Maximum = value;
            greenBlueScroll.Maximum = value;

            blueRedNumeric.Maximum = value;
            blueRedScroll.Maximum = value;
            blueGreenNumeric.Maximum = value;
            blueGreenScroll.Maximum = value;
            blueBlueNumeric.Maximum = value;
            blueBlueScroll.Maximum = value;

            //Minimum

            redRedNumeric.Minimum = -value;
            redRedScroll.Minimum = -value;
            redGreenNumeric.Minimum = -value;
            redGreenScroll.Minimum = -value;
            redBlueNumeric.Minimum = -value;
            redBlueScroll.Minimum = -value;

            greenRedNumeric.Minimum = -value;
            greenRedScroll.Minimum = -value;
            greenGreenNumeric.Minimum = -value;
            greenGreenScroll.Minimum = -value;
            greenBlueNumeric.Minimum = -value;
            greenBlueScroll.Minimum = -value;

            blueRedNumeric.Minimum = -value;
            blueRedScroll.Minimum = -value;
            blueGreenNumeric.Minimum = -value;
            blueGreenScroll.Minimum = -value;
            blueBlueNumeric.Minimum = -value;
            blueBlueScroll.Minimum = -value;
        }

        private Theme ParseMatrixText(string source)
        {
            bool didWork = false;

            string[] redMatrix = new string[0];
            string[] greenMatrix = new string[0];
            string[] blueMatrix = new string[0];

            try
            {

                if (source.Contains("<MatrixRed>") && source.Contains("<MatrixGreen>") && source.Contains("<MatrixBlue>"))
                {
                    redMatrix = GetMatrixString("<MatrixRed>", "</MatrixRed>", source).Split(',');
                    greenMatrix = GetMatrixString("<MatrixGreen>", "</MatrixGreen>", source).Split(',');
                    blueMatrix = GetMatrixString("<MatrixBlue>", "</MatrixBlue>", source).Split(',');

                    didWork = true;
                }
                else if (source.Contains("-"))
                {
                    string[] parts = source.Split("-".ToArray());

                    redMatrix = parts[0].Trim().Split(' ');
                    greenMatrix = parts[1].Trim().Split(' ');
                    blueMatrix = parts[2].Trim().Split(' ');

                    didWork = true;
                }

                if (didWork)
                {
                    Theme parsed = new Theme();
                    parsed.Name = "Parsed";

                    parsed.Matrix[0][0] = float.Parse(redMatrix[0].Trim());
                    parsed.Matrix[0][1] = float.Parse(redMatrix[1].Trim());
                    parsed.Matrix[0][2] = float.Parse(redMatrix[2].Trim());
                    parsed.Matrix[1][0] = float.Parse(greenMatrix[0].Trim());
                    parsed.Matrix[1][1] = float.Parse(greenMatrix[1].Trim());
                    parsed.Matrix[1][2] = float.Parse(greenMatrix[2].Trim());
                    parsed.Matrix[2][0] = float.Parse(blueMatrix[0].Trim());
                    parsed.Matrix[2][1] = float.Parse(blueMatrix[1].Trim());
                    parsed.Matrix[2][2] = float.Parse(blueMatrix[2].Trim());

                    return parsed;
                }
            }
            catch(Exception)
            {
                //Nothing for now
                //error console in future ??
            }

            return null;
        }

        private string GetMatrixString(string start, string end, string source)
        {
            string result = "";

            if (source.Contains(start) && source.Contains(end))
            {
                int startLocation = source.IndexOf(start) + start.Length;
                int endLocation = source.IndexOf(end, startLocation);
                result = source.Substring(startLocation, endLocation - startLocation);
            }

            return result;
        }

        private void DisableCustomControls()
        {
            customNameTextBox.Enabled = false;
            deleteCustomBtn.Enabled = false;
            duplicateCustomBtn.Enabled = false;
            customListBox.SelectedIndex = -1;
        }

        private void EnableCustomControls()
        {
            customNameTextBox.Enabled = true;
            deleteCustomBtn.Enabled = true;
            duplicateCustomBtn.Enabled = true;
        }

        private float GenColorNumber(float chanceMinus, float chanceMidRange, float chanceOverOne)
        {
            bool midRange = false;
            float number = 0.0f;
            float limit = 1.0f;

            if (randomGenerator.NextDouble() < chanceMidRange)
            {
                midRange = true;
            }

            if (randomGenerator.NextDouble() < chanceOverOne)
            {
                limit = (float)redRedNumeric.Maximum / 100; // picker gets adjusted at startup or maybe elsewhere in future
            }

            if (midRange)
            {
                number = (float)randomGenerator.Next(0, ((int)limit * 100)) / ((int)limit * 100);
            }
            else
            {
                number = randomGenerator.Next(0, (int)limit); // ugh (should auto round)
            }

            if (randomGenerator.NextDouble() < chanceMinus)
            {
                number = -number;
            }

            return number;
        }

        private void GenerateRandomTheme()
        {
            Theme random = new Theme();
            random.Name = "Random";
            random.Altered = true;
            
            //Red
            random.Matrix[0][0] = GenColorNumber(0.5f, 0.35f, 0.2f);
            random.Matrix[0][1] = GenColorNumber(0.5f, 0.35f, 0.2f);
            random.Matrix[0][2] = GenColorNumber(0.5f, 0.35f, 0.2f);

            //Green
            random.Matrix[1][0] = GenColorNumber(0.5f, 0.2f, 0);
            random.Matrix[1][1] = GenColorNumber(0.5f, 0.2f, 0);
            random.Matrix[1][2] = GenColorNumber(0.5f, 0.2f, 0);

            //Blue
            random.Matrix[2][0] = GenColorNumber(0.2f, 0.1f, 0);
            random.Matrix[2][1] = GenColorNumber(0.2f, 0.1f, 0);
            random.Matrix[2][2] = GenColorNumber(0.2f, 0.1f, 0);

            //Make sure the theme isn't black or without detail
            if (random.Matrix[0][0] + random.Matrix[0][1] + random.Matrix[0][2] < 0.3f ||
                random.Matrix[1][0] + random.Matrix[1][1] + random.Matrix[1][2] < 0.2f ||
                random.Matrix[2][0] + random.Matrix[2][1] + random.Matrix[2][2] < 0.2f)
            {
                GenerateRandomTheme(); // if crap make a new one
            }
            else
            {
                if (random.Matrix[0][0] > random.Matrix[0][1] && random.Matrix[0][0] > random.Matrix[0][2])
                {
                    random.Name += " Red";
                }
                else if (random.Matrix[0][1] > random.Matrix[0][0] && random.Matrix[0][1] > random.Matrix[0][2])
                {
                    random.Name += " Green";
                }
                else if (random.Matrix[0][2] > random.Matrix[0][0] && random.Matrix[0][2] > random.Matrix[0][1])
                {
                    random.Name += " Blue";
                }

                SetTheme(random); // 'good' one!
            }
        }

        // Where the magic happens for the preview
        private void previewPanel_Paint(object sender, PaintEventArgs e)
        {
            //https://msdn.microsoft.com/en-us/library/a7xw19wh(v=vs.110).aspx
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(currentTheme.Matrix);
            
            Bitmap currentBitmap = previewScreenshots[currentBitmapIdx];

            imageAttributes.SetColorMatrix(
               colorMatrix,
               ColorMatrixFlag.Default,
               ColorAdjustType.Bitmap);

            e.Graphics.DrawImage(
               currentBitmap,
               new Rectangle(-previewPanel.HorizontalScroll.Value, -previewPanel.VerticalScroll.Value, currentBitmap.Width, currentBitmap.Height),  // destination rectangle 
               0, 0,        // upper-left corner of source rectangle 
               currentBitmap.Width,       // width of source rectangle
               currentBitmap.Height,      // height of source rectangle
               GraphicsUnit.Pixel,
               imageAttributes);

            previewPanel.AutoScrollMinSize = new Size(currentBitmap.Width, currentBitmap.Height);
        }

        private void previewPanel_Click(object sender, EventArgs e)
        {
            currentBitmapIdx = (currentBitmapIdx + 1) % previewScreenshots.Count;

            previewPanel.Invalidate();
        }

        private void presetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddCurrentCustom();

            if (presetListBox.SelectedItem is Theme)
            {
                Theme theme = presetListBox.SelectedItem as Theme;
                SetTheme(theme);
            }
        }

        private void useThemeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CreateMatrixConfig(currentTheme);
                AddCurrentCustom();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception:\n" + exc.Message);
            }
        }

        private void openConfigBtn_Click(object sender, EventArgs e)
        {
            string path = PathToOverrideDirectory();

            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch(Exception)
            {
                MessageBox.Show("Make sure this path is accessible:\n"+path);
            }
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void matrixTextBox_Leave(object sender, EventArgs e)
        {
            Theme parsed = ParseMatrixText(matrixTextBox.Text);
            if (parsed != null)
            {
                SetTheme(parsed);
                currentTheme.Altered = true;
            }
        }

        private void randomiseBtn_Click(object sender, EventArgs e)
        {
            GenerateRandomTheme();
        }

        private void customListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customListBox.SelectedItem is Theme)
            {
                Theme theme = customListBox.SelectedItem as Theme;
                SetTheme(theme);
                EnableCustomControls();

                customNameTextBox.Text = currentTheme.Name;
            }
        }

        private void customNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (customListBox.SelectedItem is Theme)
            {
                Theme theme = customListBox.SelectedItem as Theme;
                theme.Name = customNameTextBox.Text;

                //Can't be bothered doing a bindinglist or sub classing list box just to force a draw call
                //http://stackoverflow.com/questions/61421/how-do-i-make-a-listbox-refresh-its-item-text
                typeof(ListBox).InvokeMember("RefreshItems",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.InvokeMethod,
                    null, customListBox, new object[] { });
                // Below just seems like a slack way to force a draw call
                //customListBox.Items[customListBox.SelectedIndex] = customListBox.SelectedItem;
            }
        }

        private void duplicateCustomBtn_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == customTabPage)
            {
                if (customListBox.SelectedItem != null)
                {
                    Theme cloned = currentTheme.Clone();
                    cloned.Name += " (Duplicated)";
                    customListBox.Items.Add(cloned);
                }
            }
        }

        private void deleteCustomBtn_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == customTabPage)
            {
                if (customListBox.SelectedItem != null)
                {
                    customListBox.Items.Remove(customListBox.SelectedItem);
                    SetTheme(new Theme());
                    customNameTextBox.Text = "";
                    DisableCustomControls();
                }
            }
        }

        private void saveCustomBtn_Click(object sender, EventArgs e)
        {
            SaveCustom();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == customTabPage)
            {
                AddCurrentCustom();
            }
            else if (tabControl1.SelectedTab == huePickerTabPage)
            {
                button1_Click(null, EventArgs.Empty);
            }

            DisableCustomControls();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AddCurrentCustom();
            SaveCustom();
        }

        #region Picker Events

        // == Red Matrix ==

        private void redRedScroll_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            redRedNumeric.Value = redRedScroll.Value;
            currentTheme.Matrix[0][0] = (float)redRedScroll.Value / 100;
            SetTheme(null);
        }

        private void redRedNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            redRedScroll.Value = (int)redRedNumeric.Value;
            currentTheme.Matrix[0][0] = (float)redRedScroll.Value / 100;
            SetTheme(null);
        }

        private void redGreenScroll_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            redGreenNumeric.Value = redGreenScroll.Value;
            currentTheme.Matrix[0][1] = (float)redGreenScroll.Value / 100;
            SetTheme(null);
        }

        private void redGreenNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            redGreenScroll.Value = (int)redGreenNumeric.Value;
            currentTheme.Matrix[0][1] = (float)redGreenScroll.Value / 100;
            SetTheme(null);
        }

        private void redBlueScroll_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            redBlueNumeric.Value = redBlueScroll.Value;
            currentTheme.Matrix[0][2] = (float)redBlueScroll.Value / 100;
            SetTheme(null);
        }

        private void redBlueNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            redBlueScroll.Value = (int)redBlueNumeric.Value;
            currentTheme.Matrix[0][2] = (float)redBlueScroll.Value / 100;
            SetTheme(null);
        }

        // == Green Matrix ==

        private void greenRedScroll_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            greenRedNumeric.Value = greenRedScroll.Value;
            currentTheme.Matrix[1][0] = (float)greenRedScroll.Value / 100;
            SetTheme(null);
        }

        private void greenRedNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            greenRedScroll.Value = (int)greenRedNumeric.Value;
            currentTheme.Matrix[1][0] = (float)greenRedScroll.Value / 100;
            SetTheme(null);
        }

        private void greenGreenScroll_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            greenGreenNumeric.Value = greenGreenScroll.Value;
            currentTheme.Matrix[1][1] = (float)greenGreenScroll.Value / 100;
            SetTheme(null);
        }

        private void greenGreenNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            greenGreenScroll.Value = (int)greenGreenNumeric.Value;
            currentTheme.Matrix[1][1] = (float)greenGreenScroll.Value / 100;
            SetTheme(null);
        }

        private void greenBlueScroll_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            greenBlueNumeric.Value = greenBlueScroll.Value;
            currentTheme.Matrix[1][2] = (float)greenBlueScroll.Value / 100;
            SetTheme(null);
        }

        private void greenBlueNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            greenBlueScroll.Value = (int)greenBlueNumeric.Value;
            currentTheme.Matrix[1][2] = (float)greenBlueScroll.Value / 100;
            SetTheme(null);
        }

        // == Blue Matrix ==

        private void blueRedScroll_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            blueRedNumeric.Value = blueRedScroll.Value;
            currentTheme.Matrix[2][0] = (float)blueRedScroll.Value / 100;
            SetTheme(null);
        }

        private void blueRedNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            blueRedScroll.Value = (int)blueRedNumeric.Value;
            currentTheme.Matrix[2][0] = (float)blueRedScroll.Value / 100;
            SetTheme(null);
        }

        private void blueGreenScroll_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            blueGreenNumeric.Value = blueGreenScroll.Value;
            currentTheme.Matrix[2][1] = (float)blueGreenScroll.Value / 100;
            SetTheme(null);
        }

        private void blueGreenNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            blueGreenScroll.Value = (int)blueGreenNumeric.Value;
            currentTheme.Matrix[2][1] = (float)blueGreenScroll.Value / 100;
            SetTheme(null);
        }

        private void blueBlueScroll_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            blueBlueNumeric.Value = blueBlueScroll.Value;
            currentTheme.Matrix[2][2] = (float)blueBlueScroll.Value / 100;
            SetTheme(null);
        }

        private void blueBlueNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            blueBlueScroll.Value = (int)blueBlueNumeric.Value;
            currentTheme.Matrix[2][2] = (float)blueBlueScroll.Value / 100;
            SetTheme(null);
        }

        // == Rotation ==
        
        private void rotationRedGreenScroll_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            rotationRedGreenNumeric.Value = rotationRedGreenScroll.Value;

            float r = (float)(rotationRedGreenScroll.Value * Math.PI / 180); //deg to rad
            currentTheme.Matrix[0][0] = (float)Math.Cos(r);
            currentTheme.Matrix[0][1] = (float)Math.Sin(r);
            
            currentTheme.Matrix[1][0] = (float)-Math.Sin(r);
            currentTheme.Matrix[1][1] = (float)Math.Cos(r);

            SetTheme(null);
        }

        private void rotationRedGreenNumeric_ValueChanged(object sender, EventArgs e)
        {
            rotationRedGreenScroll.Value = (int)rotationRedGreenNumeric.Value;
        }

        private void rotationGreenBlueScroll_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            rotationGreenBlueNumeric.Value = rotationGreenBlueScroll.Value;

            float r = (float)(rotationGreenBlueScroll.Value * Math.PI / 180); //deg to rad
            currentTheme.Matrix[1][1] = (float)Math.Cos(r);
            currentTheme.Matrix[1][2] = (float)Math.Sin(r);

            currentTheme.Matrix[2][1] = (float)-Math.Sin(r);
            currentTheme.Matrix[2][2] = (float)Math.Cos(r);

            SetTheme(null);
        }

        private void rotationGreenBlueNumeric_ValueChanged(object sender, EventArgs e)
        {
            rotationGreenBlueScroll.Value = (int)rotationGreenBlueNumeric.Value;
        }

        private void rotationBlueRedScroll_ValueChanged(object sender, EventArgs e)
        {
            if (ignoreUpdate) return;
            rotationBlueRedNumeric.Value = rotationBlueRedScroll.Value;

            float r = (float)(rotationBlueRedScroll.Value * Math.PI / 180); //deg to rad
            currentTheme.Matrix[0][0] = (float)Math.Cos(r);
            currentTheme.Matrix[0][2] = (float)-Math.Sin(r);

            currentTheme.Matrix[2][0] = (float)Math.Sin(r);
            currentTheme.Matrix[2][2] = (float)Math.Cos(r);

            SetTheme(null);
        }

        private void rotationBlueRedNumeric_ValueChanged(object sender, EventArgs e)
        {
            rotationBlueRedScroll.Value = (int)rotationBlueRedNumeric.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rotationRedGreenScroll.Value = 0;
            rotationGreenBlueScroll.Value = 0;
            rotationBlueRedScroll.Value = 0;
        }

        #endregion

        #region Hue Picker Events

        private void UpdateFromHuePicker()
        {
            if (ignoreUpdate) return;

            float[][] m = ColorMatrixHelper.CreateIdentity();

            //it 'can' alter preset or picker but only for hue and saturation
            //offset or scale changes would immediately ruin it, 'brightness'/'intensity'
            
            ColorMatrixHelper.Offset(ref m, (float)redOffsetPScroll.Value / 100, (float)greenOffsetPScroll.Value / 100, (float)blueOffsetPScroll.Value / 100);
            //ColorMatrixHelper.Offset(ref m, redOffsetPScroll.Value, greenOffsetPScroll.Value, blueOffsetPScroll.Value);

            ColorMatrixHelper.Scale(ref m, (float)redScalePScroll.Value / 100, (float)greenScalePScroll.Value / 100, (float)blueScalePScroll.Value / 100);
            ColorMatrixHelper.Saturation(ref m, (float)saturationPScroll.Value / 100);
            ColorMatrixHelper.HueRotate(ref m, (float)huePScroll.Value / 2);

            SetTheme(new Theme("Hue " + huePScroll.Value, ColorMatrixHelper.Compat(m)));
        }

        private void huePScroll_ValueChanged(object sender, EventArgs e)
        {
            UpdateFromHuePicker();
        }

        private void saturationPScroll_ValueChanged(object sender, EventArgs e)
        {
            UpdateFromHuePicker();
        }

        private void redScalePScroll_ValueChanged(object sender, EventArgs e)
        {
            UpdateFromHuePicker();
        }

        private void greenScalePScroll_ValueChanged(object sender, EventArgs e)
        {
            UpdateFromHuePicker();
        }

        private void blueScalePScroll_ValueChanged(object sender, EventArgs e)
        {
            UpdateFromHuePicker();
        }

        private void redOffsetPScroll_ValueChanged(object sender, EventArgs e)
        {
            UpdateFromHuePicker();
        }

        private void greenOffsetPScroll_ValueChanged(object sender, EventArgs e)
        {
            UpdateFromHuePicker();
        }

        private void blueOffsetPScroll_ValueChanged(object sender, EventArgs e)
        {
            UpdateFromHuePicker();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ignoreUpdate = true;

            redOffsetPScroll.Value = 0;
            greenOffsetPScroll.Value = 0;
            blueOffsetPScroll.Value = 0;
            redScalePScroll.Value = 100;
            greenScalePScroll.Value = 100;
            blueScalePScroll.Value = 100;
            saturationPScroll.Value = 100;

            ignoreUpdate = false;

            huePScroll.Value = 0;
        }

        private Color AngleToColor(int degrees)
        {
            double rad = degrees * Math.PI / 180.0;
            //ugh - cos = 1 to -1, needs to be normalised
            return Color.FromArgb(  (int)(((Math.Cos(rad) + 1) / 2) * 255),
                                    (int)(((Math.Cos(rad + ((4 * Math.PI) / 3)) + 1) / 2) * 255),
                                    (int)(((Math.Cos(rad + ((2 * Math.PI) / 3)) + 1) / 2) * 255));
        }

        private void huePickerTabPage_Paint(object sender, PaintEventArgs e)
        {
            Brush angle = Brushes.Black;

            int controlSize = 17;

            float step = (float)(huePScroll.Size.Width - (controlSize * 2)) / 360;
            float x = huePScroll.Location.X + controlSize;

            for (int d = 0; d < 360; d++)
            {
                angle = new SolidBrush(AngleToColor(d));

                e.Graphics.FillRectangle(angle, x, huePScroll.Location.Y + huePScroll.Size.Height, step, 5);
                x += step;
            }
        }

        #endregion
    }
}
