using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteTheme
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            changeLogRichTextBox.Text = ChangeLog();
        }

        public string ChangeLog()
        {
            StringBuilder changeLog = new StringBuilder();

            changeLog.AppendLine("Version 2 - 2016/01/20");
            changeLog.AppendLine("Initial complaint fixes!");
            changeLog.AppendLine(" - Forced culture to en-GB which should fix the comma instead of period issue with parsing");
            changeLog.AppendLine(" - Downgraded .NET to 4 client profile to remove the need for the redist");
            changeLog.AppendLine(" - Added platform detection for OSX which should hopefully work to fix paths");
            changeLog.AppendLine(" - Added two more screenshots for rare commodities and the bulletin board");
            changeLog.AppendLine();
            changeLog.AppendLine();
            changeLog.AppendLine("Version 1 - 2016/01/19");
            changeLog.AppendLine("Initial feature set!");
            changeLog.AppendLine(" - Can select from a preset (Sourced from imgur, reddit and frontier forums)");
            changeLog.AppendLine(" - Can change the override graphics xml when pressing Use for the current theme");
            changeLog.AppendLine(" - Can change the current theme using the picker");
            changeLog.AppendLine(" - Can save the current theme as a custom theme, saved to customThemes.xml on close");
            changeLog.AppendLine(" - Can read the theme currently set in the override graphics xml on start up");
            changeLog.AppendLine(" - Can parse themes in the Matrix textbox with two formats, remember to press tab after paste or changing for it work");
            changeLog.AppendLine("   - Simple exmaple: 0 .5 0 - 0 1 0 - 0 0 1");
            changeLog.AppendLine("   - Verbose example: <MatrixRed>0,0,0</MatrixRed> blah blah blah");
            changeLog.AppendLine("     - This is used as the default since Elite uses it");
            changeLog.AppendLine(" - Can randomise a theme from the picker, good luck!");
            changeLog.AppendLine(" - Can duplicate a custom theme");
            changeLog.AppendLine(" - Can delete a custom theme");
            changeLog.AppendLine(" - Can change the name of a custom theme");
            changeLog.AppendLine(" - Can click on the preview panel to change screenshots");
            changeLog.AppendLine(" - 3 Screenshots which make up 1.02MB of the program... (program is 50kb without)");
            changeLog.AppendLine(" - So much jpg arg..");
            changeLog.AppendLine(" - Over zealous saving of changed themes to custom (may need adjusting in future)");
            changeLog.AppendLine("   - I didn't want popup galore asking at every change if you wanted to save as custom");
            changeLog.AppendLine();
            changeLog.AppendLine("Credits");
            changeLog.AppendLine("To those that posted presets, thank you! If I credited incorrectly in the list let me know with a link to your OP and I'll adjust it. But I'm not your mother, and I don't like anal so don't expect me to release an update just to fix your name.");
            changeLog.AppendLine("To those that tested the before inital version, thank you for your passwords (jk)!");
            changeLog.AppendLine();

            return changeLog.ToString();
        }

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }
    }
}
