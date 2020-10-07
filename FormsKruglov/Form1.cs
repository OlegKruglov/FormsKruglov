using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsKruglov
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn = new Button();
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2;
        TextBox txt_box;
        PictureBox picture;
        TabControl tabControl;
        TabPage page1, page2, page3;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemedid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 50;
            btn.Width = 100;
            //btn.Click += Btn_Click;
            tn.Nodes.Add(new TreeNode("Sint-Label"));
            lbl = new Label();
            lbl.Text = "Tarkavara arendajad";
            lbl.Size = new Size(150, 30);
            lbl.Location = new Point(150, 200);
            tn.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstikast-Textbox"));
            tn.Nodes.Add(new TreeNode("Pildikast-PictureBox"));
            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Sint-Label")
            {
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Märkeruut-Checkbox")
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
                r1.Location = new Point(300, 30);
                r1.CheckedChanged += new EventHandler(RadioButton_Changed);

                r2 = new RadioButton();
                r2.Text = "nupp paremale";
                r2.Location = new Point(300, 70);
                r2.CheckedChanged += new EventHandler(RadioButton_Changed);

                this.Controls.Add(r2);
                this.Controls.Add(r1);
            }
            else if (e.Node.Text == "Pildikast-PictureBox")
            {
                picture = new PictureBox();
                picture.Image = new Bitmap("csharp.png");
                picture.Location = new Point(300, 0);
                picture.Size = new Size(300, 300);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BorderStyle = BorderStyle.Fixed3D;
                Controls.Add(picture);
            }
            else if (e.Node.Text == "Kaart-TabControl")
            {
                tabControl = new TabControl();
                tabControl.Location = new Point(300, 300);
                tabControl.Size = new Size(200, 100);
                page1 = new TabPage("Esimene");
                page1.BackColor = Color.LightSeaGreen;
                page2 = new TabPage("Teine");
                page2.BackColor = Color.Bisque;
                page3 = new TabPage("Kolmas");
                page3.BackColor = Color.DarkGoldenrod;
                tabControl.Controls.Add(page1);
                tabControl.Controls.Add(page2);
                tabControl.Controls.Add(page3);
                tabControl.SelectedIndex = 2;
                Controls.Add(tabControl);
                
            }
            else if (e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MessageBox", "Kõige lihtsam aken");
                var answer= MessageBox.Show("Tahad InpudBoxi näha?", "Aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                   string text=Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("Kas tahad tekst saada Tekskastisse?", "Teksti salevestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);
                    }
                }
            }
            else if (e.Node.Text == "Tekstikast-Textbox")
            {
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = "Write here";
                txt_box.Location = new Point(300, 300);
                txt_box.Width = 200;
                txt_box.Height = 200;
                Controls.Add(txt_box);
                string text;
                try
                {
                    text = File.ReadAllText("file1.txt");
                }
                catch(FileNotFoundException exception)
                {
                    text = "Tekst puudub";
                }
            }
        }

        private void RadioButton_Changed(object sender, EventArgs e)
        {
            if(r1.Checked)
            {
                btn.Location = new Point(300, 100);
            }
            else if (r2.Checked)
            {
                btn.Location = new Point(100, 100);
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

        /*private void Btn_Click(object sender, EventArgs e)
        {
            if(btn.BackColor == Color.Beige)
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.LightGreen;
                lbl.ForeColor = Color.Gray;
            }
            else
            {
                btn.BackColor = Color.Beige;
                lbl.BackColor = Color.LightGoldenrodYellow;
                lbl.ForeColor = Color.Black;
            }*/
        }
    }
