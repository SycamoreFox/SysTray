using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;

namespace SysTray
{
    internal class ContextMenu : IDisposable
    {
        public void MenuCreate(int inputIconIndex)
        {
            //graphical header
            ToolStripLabel labelHeader = new ToolStripLabel
            {
                AutoSize = false,
                Height = 24,
                Width = 142,
                BackgroundImage = SysTray.Properties.Resources.systray,
                BackgroundImageLayout = ImageLayout.None,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 4, 0, 2)
            };

            //self mention
            ToolStripLabel labelCraftedBy = new ToolStripLabel
            {
                AutoSize = false,
                Height = 16,
                Width = 220,
                BackgroundImage = SysTray.Properties.Resources.craftedby,
                BackgroundImageLayout = ImageLayout.None,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, 10)
            };

            //web link
            ToolStripLabel labelWebLink = new ToolStripLabel
            {
                Text = "david-osborne.github.io/SysTray",
                IsLink = true,
                LinkBehavior = LinkBehavior.HoverUnderline
            };
            labelWebLink.Click += LabelWebLink_Click;
            labelWebLink.Margin = new Padding(0, 0, 0, 10);

            //menu item - settings
            ToolStripMenuItem itemSettings = new ToolStripMenuItem("Settings")
            {
                Image = SysTray.Properties.Resources.settings4
            };
            itemSettings.Click += SettingsClick;

            //menu item - support
            ToolStripMenuItem itemSupport = new ToolStripMenuItem("Support SysTray")
            {
                AutoSize = true,
                Width = 300,
                Image = global::SysTray.Properties.Resources.heart,
                ImageScaling = ToolStripItemImageScaling.None
            };
            itemSupport.Click += ItemSupportClick;

            //menu item - about
            ToolStripMenuItem itemAbout = new ToolStripMenuItem("About SysTray")
            {
                Image = SysTray.Properties.Resources.about
            };
            itemAbout.Click += ItemAboutClick;

            //menu item - exit
            ToolStripMenuItem itemExit = new ToolStripMenuItem("Exit")
            {
                AutoSize = true,
                Width = 300,
                Margin = new Padding(0, 0, 0, 4),
                Image = SysTray.Properties.Resources.exit6,
                ImageScaling = ToolStripItemImageScaling.None
            };
            itemExit.Click += ItemExitOnClick;

            //create the menu instance
            ContextMenuStrip cms1 = new ContextMenuStrip
            {
                AutoSize = true
            };

            //add items to the menu
            cms1.Items.Add(labelHeader);
            cms1.Items.Add(labelCraftedBy);
            cms1.Items.Add(labelWebLink);
            cms1.Items.Add(new ToolStripSeparator());
            cms1.Items.Add(itemSettings);
            cms1.Items.Add(new ToolStripSeparator());
            cms1.Items.Add(itemSupport);
            cms1.Items.Add(itemAbout);
            cms1.Items.Add(new ToolStripSeparator());
            cms1.Items.Add(itemExit);
            //assign menu to the passed icon
            Globals.iconList[inputIconIndex].ContextMenuStrip = cms1;
        }

        private void ItemSupportClick(object sender, EventArgs e)
        {
            MainWindow theWindow = new MainWindow();
            theWindow.tabMaster.SelectedIndex = 2;
            theWindow.Show();
        }

        private void SettingsClick(object sender, EventArgs e)
        {
            MainWindow theWindow = new MainWindow();
            theWindow.tabMaster.SelectedIndex = 0;
            theWindow.Show();
        }

        private void ItemAboutClick(object sender, EventArgs e)
        {
            MainWindow theWindow = new MainWindow();
            theWindow.tabMaster.SelectedIndex = 1;
            theWindow.Show();
        }

        private void LabelWebLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://david-osborne.github.io/SysTray/");
        }

        private void ItemExitOnClick(object sender, EventArgs e)
        {
            MainClass.ExitActions();
        }

        public void Dispose()
        {
            //item1.Dispose();
            //throw new NotImplementedException();
        }
    }
}