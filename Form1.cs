using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2;
        TextBox txt_box;
        PictureBox picture;
        TabControl tabControl;
        TabPage page1, page2, page3;
        ListBox _listbox;
        bool fullScreen = true;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));            
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 40;
            btn.Width = 120;
            btn.Click += Btn_Click;
            lbl = new Label();
            lbl.Text = "Tarkvara arendajad";
            lbl.Size = new Size(150, 30);
            lbl.Location = new Point(150, 200);
            tn.Nodes.Add(new TreeNode("Silt-Label"));
            tn.Nodes.Add(new TreeNode("Märkeruut-CheckBox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Teksttask-Textbox"));
            tn.Nodes.Add(new TreeNode("Piltikast-Picturebox"));
            tn.Nodes.Add(new TreeNode("TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("DataGridView"));
            tn.Nodes.Add(new TreeNode("Menu"));
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt-Label")
            {
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Märkeruut-CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita nupp";
                box_btn.Location = new Point(200, 30);
                this.Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(200, 70);
                this.Controls.Add(box_lbl);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;
            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = "nupp vasakule";
                r1.Location = new Point(310, 30);
                r1.CheckedChanged += new EventHandler(Radiobuttons_Changed);
                r2 = new RadioButton();
                r2.Text = "nupp paremale";
                r2.Location = new Point(310, 70);
                r2.CheckedChanged += new EventHandler(Radiobuttons_Changed);
                this.Controls.Add(r1);
                this.Controls.Add(r2);
            }
            else if (e.Node.Text == "Teksttask-Textbox")
            {
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = "Failist";
                txt_box.Location = new Point(300, 300);
                txt_box.Width = 200;
                txt_box.Height = 200;
            }
            else if (e.Node.Text == "Piltikast - Picturebox")
            {
                picture = new PictureBox();
                picture.Image = new Bitmap("image.png");
                picture.Location = new Point(400, 400);
                picture.Size = new Size(100, 100);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(picture);
            }
            else if (e.Node.Text == "TabControl")
            {
                tabControl = new TabControl();
                tabControl.Location = new Point(300, 300);
                tabControl.Size = new Size(200, 100);
                page1 = new TabPage("Esimene");
                page2 = new TabPage("Teine");
                page3 = new TabPage("Kolmas");
                tabControl.Controls.Add(page1);
                tabControl.Controls.Add(page2);
                tabControl.Controls.Add(page3);
                tabControl.SelectedIndex = 2;//0,1,2
                this.Controls.Add(tabControl);

            }
            else if (e.Node.Text == "ListBox")
            {
                string[] listItems = new string[] { "Sinine", "Kollane", "Roheline", "Punane" };

                _listbox = new ListBox();

                for (int i = 0; i < listItems.Length; i++)
                {
                    _listbox.Items.Add(listItems[i]);
                }

                _listbox.Location = new Point(150, 300);
                _listbox.Width = listItems.Length * 20;
                _listbox.Height = listItems.Length * 15;
                _listbox.SelectedIndexChanged += _listbox_SelectedIndexChanged;
                this.Controls.Add(_listbox);
            }
            else if (e.Node.Text == "DataGridView")
            {
                DataSet _dataset = new DataSet("Näide");
                _dataset.ReadXml("..//..//XMLFile.xml");
                DataGridView dgv = new DataGridView();
                dgv.Location = new Point(200, 200);
                dgv.Width = 500;
                dgv.Height = 250;
                dgv.AutoGenerateColumns = true;
                dgv.DataMember = "PLANT";
                dgv.DataSource = _dataset;
                this.Controls.Add(dgv);
            }
            else if (e.Node.Text == "Menu")
            {
                MainMenu menu = new MainMenu();
                MenuItem item = new MenuItem("File");
                item.MenuItems.Add("EXIT", new EventHandler(item_exit));
                MenuItem my = new MenuItem("My");
                my.MenuItems.Add("New", new EventHandler(item_new));
                my.MenuItems.Add("In full screen", new EventHandler(item_FullScreen));
                my.MenuItems.Add("Random backcolor", new EventHandler(item_random));
                menu.MenuItems.Add(item);
                menu.MenuItems.Add(my);
                this.Menu = menu;
            }
            else if (e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MessageBox","Kõige lihtsam aken");
                var answer=MessageBox.Show("MessageBox", "Aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text=Interaction.InputBox("Sisesta siia mingi tekst", "InputBox","Mingi tekst");
                    if (MessageBox.Show("MessageBox", "Soovite kuvada teavet?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);
                    }
                    else if (MessageBox.Show("MessageBox", "Soovite kuvada teavet?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        lbl.Text = "Sa ei tahtnud teavet kuvada";
                    }
                }
                else if (answer != DialogResult.Yes)
                {
                    
                };
            };

        }
        private void Radiobuttons_Changed(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(150, 100);
            }
            else if (r2.Checked)
            {
                btn.Location = new Point(400, 100);
            }  
        }
        private void item_random(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int R = rnd.Next(0, 255);
            int G = rnd.Next(0, 255);
            int B = rnd.Next(0, 255);

            this.BackColor = Color.FromArgb(R, G, B);

        }

        private void item_FullScreen(object sender, EventArgs e)
        {
            if (fullScreen == true)
            {
                this.WindowState = FormWindowState.Maximized;
                fullScreen = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                fullScreen = true;
            }

        }

        private void item_new(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(tree);
        }

        private void item_exit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas sa oled kindel?", "Küsimus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }

        }
        private void _listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = _listbox.SelectedItem.ToString();

            if (item == "Sinine")
            {
                _listbox.BackColor = Color.Blue;
            }
            if (item == "Kollane")
            {
                _listbox.BackColor = Color.Yellow;
            }
            if (item == "Roheline")
            {
                _listbox.BackColor = Color.Green;
            }
            if (item == "Punane")
            {
                _listbox.BackColor = Color.Red;
            }
        }
        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
            }
        }
        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.Blue;
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Green;
            }
        }
    }
}

