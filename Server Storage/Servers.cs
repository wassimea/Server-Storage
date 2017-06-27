using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
namespace Server_Storage
{
    public partial class Servers : Form
    {
        Label add_label = new Label();
        List<TextBox> list_servers_tbs = new List<TextBox>();   //list stores textboxes that contain drive path
        List<Button> list_remove_btns = new List<Button>();     //list contains all remove buttons
        List<Button> list_insert_btns = new List<Button>();      //list contains all insert buttons
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);  //do
        ulong FreeBytesAvailable;   //not
        ulong TotalNumberOfBytes;   //touch
        ulong TotalNumberOfFreeBytes;   //!
        int ypadding = 0;
        public Servers()
        {
            InitializeComponent();
        }

        private void Servers_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.storage_icon_png_51;
            Button genereate_btn = new Button();    //create generate button
            genereate_btn.Top = 15;
            genereate_btn.Left = 20;
            genereate_btn.Text = "Generate Report";
            genereate_btn.Font = new Font("Times New Roman", 15);
            genereate_btn.AutoSize = true;
            genereate_btn.Click += new EventHandler(generate_event);    //on click event handler
            this.Controls.Add(genereate_btn);   //add to form

            Label note_label = new Label(); //create label as a note
            note_label.Left = 20;
            note_label.Top = 55;
            note_label.Text = "Note: Empty paths will result in empty excel cells";
            note_label.Font = new Font("Times New Roman", 11);
            note_label.AutoSize = true;
            this.Controls.Add(note_label);  //add to form


            add_label = new Label();    //create label "Add"
            add_label.Left = 20;
            add_label.Top = 85;
            add_label.Text = "Server paths";
            add_label.Font = new Font("Times New Roman", 15);
            add_label.AutoSize = true;
            this.Controls.Add(add_label);   //add to form

            ypadding = add_label.Top + 30;
            
            //call function add server to add the following paths by default
            //note that the empty strings are called to generate empty cells for design purposes


            add_server(@"\\storage\p$");    
            add_server(@"\\nas6\v");
            add_server(@"\\Airnews01\p$");
            add_server(@"\\Airnews02\p$");
            add_server(@"\\Airnews03\P$");
            add_server(@"\\Airnews04\V$");
            add_server(@"\\cinegya\D$");
            add_server(@"\\cinegyb\D$");
            add_server(@"\\filesrv\d$");
            add_server(@"\\webchunking\D$");
            add_server(@"\\webchunking\E$");
            add_server(@"");
            add_server(@"");
            add_server(@"\\ftpsrvr\E$");
            add_server(@"");
            add_server(@"\\ccoder1\E$");
            add_server(@"\\ccoder2\E$");
            add_server(@"\\convert2\E$");
            add_server(@"");
            add_server(@"");
            add_server(@"");
            add_server(@"");
            add_server(@"");
            add_server(@"");
            add_server(@"");
            add_server(@"\\capturer01\p$");
            add_server(@"\\capturer02\p$");
            add_server(@"\\capturer03\p$");
            add_server(@"\\capturer04\p$");
        }

        void add_server(string server_name) //function used to add the default paths
        {
            TextBox tb = new TextBox();
            tb.Top = ypadding;
            tb.Left = 20;
            tb.Width = 200;
            tb.Text = server_name;
            list_servers_tbs.Add(tb);
            this.Controls.Add(tb);

            Button insert_btn = new Button();
            insert_btn.Top = ypadding;
            insert_btn.Left = 250;
            insert_btn.Text = "Insert Here";
            insert_btn.AutoSize = true;
            insert_btn.Click += new EventHandler(insert_event);
            list_insert_btns.Add(insert_btn);
            this.Controls.Add(insert_btn);


            Button delete_btn = new Button();
            delete_btn.Click += new EventHandler(remove_event);
            delete_btn.Text = "Remove";
            delete_btn.AutoSize = true;
            delete_btn.Left = 350;
            delete_btn.Top = ypadding;
            list_remove_btns.Add(delete_btn);
            this.Controls.Add(delete_btn);

            ypadding = ypadding + 30;
        }
        private void insert_event(object sender, EventArgs e)   //insert event when insert button is clicked
        {
            Button insert_btn_here = sender as Button;  //find which insert button was clicked
            int index = list_insert_btns.IndexOf(insert_btn_here);  //get its index

            TextBox tb = new TextBox(); //add textbox 
            tb.Top = list_insert_btns[index].Top + 30;
            tb.Left = 15;
            tb.Width = 200;
            tb.Text = "";
            list_servers_tbs.Insert(index + 1,tb);

            Button insert_btn = new Button();   //add insert button
            insert_btn.Top = list_insert_btns[index].Top + 30; ;
            insert_btn.Left = 250;
            insert_btn.Text = "Insert Here";
            insert_btn.AutoSize = true;
            insert_btn.Click += new EventHandler(insert_event);
            list_insert_btns.Insert(index + 1, insert_btn);


            Button delete_btn = new Button();   //add delete button
            delete_btn.Click += new EventHandler(remove_event);
            delete_btn.Text = "Remove";
            delete_btn.AutoSize = true;
            delete_btn.Left = 350;
            delete_btn.Top = list_insert_btns[index].Top + 30; ;
            list_remove_btns.Insert(index + 1,delete_btn);


            foreach (var item in list_remove_btns)      //remove all controls
                this.Controls.Remove(item);
            foreach (var item in list_servers_tbs)
                this.Controls.Remove(item);
            foreach (var item in list_insert_btns)
                this.Controls.Remove(item);

            ypadding = add_label.Top + 30;  //reset ypadding

            for (int i = 0; i < list_remove_btns.Count(); i++)  //reconstruct all the controls in form
            {
                list_remove_btns[i].Top = ypadding;
                list_remove_btns[i].Left = 350;
                list_servers_tbs[i].Top = ypadding;
                list_servers_tbs[i].Left = 20;
                list_insert_btns[i].Top = ypadding;
                list_insert_btns[i].Left = 250;
                this.Controls.Add(list_remove_btns[i]);
                this.Controls.Add(list_servers_tbs[i]);
                this.Controls.Add(list_insert_btns[i]);
                ypadding = ypadding + 30;
            }
        }
        
        private void remove_event(object sender, EventArgs e)   //when a remove button is clicked
        {
            Button remove_btn = sender as Button;   //find which button was clicked
            int index = list_remove_btns.IndexOf(remove_btn);   //find its index

            foreach (var item in list_remove_btns)  //remove all controls from form
                this.Controls.Remove(item);
            foreach (var item in list_servers_tbs)
                this.Controls.Remove(item);
            foreach (var item in list_insert_btns)
                this.Controls.Remove(item);


            list_servers_tbs.RemoveAt(index);   //remove corresponding controls from their respective lists
            list_remove_btns.RemoveAt(index);
            list_insert_btns.RemoveAt(index);

            ypadding = add_label.Top + 30;  //reset ypadding

            for (int i = 0; i < list_remove_btns.Count(); i++)  //reconstruct 
            {
                list_remove_btns[i].Top = ypadding;
                list_servers_tbs[i].Top = ypadding;
                list_insert_btns[i].Top = ypadding;
                this.Controls.Add(list_remove_btns[i]);
                this.Controls.Add(list_servers_tbs[i]);
                this.Controls.Add(list_insert_btns[i]);
                ypadding = ypadding + 30;
            }
        }
        private void generate_event(object sender, EventArgs e) //when generate button is clicked
        {
            List<string> free_spaces = new List<string>();  //will contain free spaces of given paths

            foreach (var item in list_servers_tbs)  //for every given path
            {
                string free_space = GetTotalFreeSpace(item.Text);   //will contain free space of given path
                if (free_space == "ERROR")  //if free_space returned error
                    free_spaces.Add("ERROR");   //show error in report cell
                if (free_space == "")   //if free_space returned blank(empty path)
                    free_spaces.Add("");    //show empty cell
                else
                    try
                    {
                        free_spaces.Add(FormatBytes((long)Convert.ToDouble(free_space)));   //else get human readable size and add it to list of free spaces
                    }
                    catch
                    {
                        string parsed_path = item.ToString().Substring(item.ToString().IndexOf("\\"));
                    }
            }

            DataTable table = new DataTable();  //table will contain results
            table.Columns.Add("Drive"); 
            table.Columns.Add("Free Space");

            for (int i = 0; i < list_servers_tbs.Count; i++)    //populate table
            {
                DataRow row = table.NewRow();
                row[0] = list_servers_tbs[i].Text;  //server path
                row[1] = free_spaces[i];    //free storage
                table.Rows.Add(row);
            }

            results show_results = new results();   //create show results form
            show_results.set_gv_source(table);  //set datasource for its datagridview
            show_results.Show();
        }
        private string GetTotalFreeSpace(string driveName)  //function returns free space in bytes of given drive path
        {
            if (driveName == "")
                return "";
            bool success = GetDiskFreeSpaceEx(@driveName,
                                  out FreeBytesAvailable,
                                  out TotalNumberOfBytes,
                                  out TotalNumberOfFreeBytes);

            if (!success)
                return "ERROR";
            return FreeBytesAvailable.ToString(); ;
        }

        private static string FormatBytes(long bytes)   //function converts free space to human readable form
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }
    }
}
