using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Storage
{
    public partial class results : Form
    {
        public results()
        {
            InitializeComponent();
        }

        public void set_gv_source(DataTable table)
        {
            results_dgv.DataSource = table;
            results_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
        }

        private void results_dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Copy"));
                int currentMouseOverRow = results_dgv.HitTest(e.X, e.Y).RowIndex;
                m.Show(results_dgv, new Point(e.X, e.Y));
                if (results_dgv.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    try
                    {
                        // Add the selection to the clipboard.
                        Clipboard.SetDataObject(
                            results_dgv.GetClipboardContent());
                    }
                    catch (System.Runtime.InteropServices.ExternalException)
                    {

                        MessageBox.Show("The Clipboard could not be accessed. Please try again.");
                    }
                }
            }

        }

        private void results_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.storage_icon_png_51;
        }
    }
}
