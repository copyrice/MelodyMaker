using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Course_work
{
    public partial class Form3 : Form
    {
        Form1 f1;
        MyButtonClass mbc = new MyButtonClass();
        List<Button> btn_chords = new List<Button>();
        Button btn1;
        Chord key_chord; //тонический

        Chord[] cl = new Chord[24]; // длина List<Chord> chord_list увеличивается вдвое при
                                    // переходе на новую форму

        Chord chord = new Chord();

        int btn_x = 12;
        int btn_y = 35;
        int mybtn_count = 0;


        List<Button> btns = new List<Button>();


        Chords_Progression chords_progression = new Chords_Progression();
        public Form3(Chord first_chord)
        {
            InitializeComponent();

            f1 = new Form1();
            button7.Visible = false;


            List<Chord> prog = new List<Chord>();
            prog.Add(first_chord);

            chords_progression.Progression = prog;
            mbc.CreateMyButton(btn1, btn_x, btn_y, 70, 70, MyButton_Click, chords_progression.Progression[0].Name, this, mybtn_count, contextMenuStrip1);
            mybtn_count += 1;
            btn_x += 100;
            if (btn_y > 100) btn_y += 10;

            for(int i = 0; i < cl.Length; i++)
            {
                cl[i]=(Form1.chord_list[i]);
            }

            btns.Add(button1);
            btns.Add(button2);
            btns.Add(button3);
            btns.Add(button4);
            btns.Add(button5);
            btns.Add(button6);
            btns.Add(button7);
           /* btns.Add(button8);
            btns.Add(button9);
            btns.Add(button10);
            btns.Add(button11);*/


            key_chord = chords_progression.Progression[0];
            Select_Chords(chords_progression.Progression[0].Name);

        }

        public void my_click(object sender, EventArgs e)
        {
            if (chords_progression.Progression.Count < 12)
            {
                Button clickedButton = (Button)sender;
                for (int i = 0; i < cl.Length; i++)
                {
                    if (clickedButton.Text == "C#") clickedButton.Text = "Db";
                    if (clickedButton.Text == "G#") clickedButton.Text = "Eb";
                    if (cl[i].Name == clickedButton.Text)
                    {
                        if(comboBox1.Text == "Пианино") cl[i].Play_Piano();
                        if (comboBox1.Text == "Гитара") cl[i].Play_Guitar();
                        chords_progression.AddChord(cl[i]);
                        mbc.CreateMyButton(btn1, btn_x, btn_y, 70, 70, MyButton_Click, cl[i].Name, this, mybtn_count, contextMenuStrip1);
                        
                    }
                }
                mybtn_count += 1;
                btn_x += 100;
                if (btn_x > 550)
                {
                    btn_x = 12;
                    btn_y += 100;
                }
                Console.WriteLine(clickedButton.Text);
            }
            else MessageBox.Show("Перебор");
            
        }
         public void Select_Chords(string ch_name)
        {
            Chord ch = new Chord();

            foreach (var elem in cl)
            {
                if (elem.Name == ch_name)
                {
                    ch = elem;
                    if (elem.Name.EndsWith("m"))
                    {
                        button7.Visible = true;
                        button7.Text = button6.Text.Remove(elem.Name.Length - 1);
                        label4.Visible = true;
                        label5.Text += "мажор";
                        Console.WriteLine(button6.Text);
                    }
                    else
                    {
                        label4.Visible = false;
                        button7.Visible = false;
                        label5.Text += "минор";
                    } 
                }
            }

            int id = Array.IndexOf(cl, ch);
            int id_tab = id; 
            List<int> ids = new List<int>();
            List<Chord> chs = new List<Chord>();



            if (id_tab % 2 != 0 && id_tab != 0) id_tab = id_tab - 1;
                if (id_tab == 0)
                {
                  for (int i = cl.Length - 2; i < cl.Length; i++)
                  {
                      chs.Add(cl[i]);
                      ids.Add(i);
                  }
                  for(int i = 0; i < 4; i++)
                  {
                      chs.Add(cl[i]);
                      ids.Add(i);
                  }
                }
                else if(id_tab == 22)
                {
                  for(int i = id_tab-2; i < cl.Length; i++)
                  {
                      chs.Add(cl[i]);
                      ids.Add(i);
                  }
                 for(int i = 0; i < 2; i++)
                  {
                      chs.Add(cl[i]);
                      ids.Add(i);
                  }
                }
                else
                {
                   for (int i = id_tab - 2; i < id_tab + 4; i++)
                  {
                      chs.Add(cl[i]);
                      ids.Add(i);
                  }
                }



            for (int i = 0; i < chs.Count; i++)
             {
                btns[i].Text = chs[i].Name;
             }

            if (ch_name.EndsWith("m"))
            {
                button7.Visible = true;
                button7.Text = button6.Text.Remove(button6.Text.Length - 1);
                label4.Visible = true;
                
                Console.WriteLine(button6.Text);
            }
            else
            {
                label4.Visible = false;
                button7.Visible = false;
                
            }
         

        } 


        


        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        public void MyButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            foreach(var elem in chords_progression.Progression)
            {
                if (clickedButton.Text == elem.Name)
                {
                    if(comboBox1.Text == "Пианино") elem.Play_Piano();
                    if (comboBox1.Text == "Гитара") elem.Play_Guitar();
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            ContextMenuStrip menu = (ContextMenuStrip)item.GetCurrentParent();
            Button del_btn = (Button)menu.SourceControl;
            //chords_progression.Progression.RemoveAt(Convert.ToString(del_btn.Name));
            //mybtn_count -= 1;
            foreach(var elem in chords_progression.Progression)
            {
                if (del_btn.Text == elem.Name)
                {
                    chords_progression.Progression.Remove(elem);
                    break;
                }
            }

            if (btn_x == 12 && btn_y > 135)
            {
                btn_x = 512;
                btn_y = 135;
            }
            if (del_btn.Location.X == 12 && del_btn.Location.Y == 35)
            {
                btn_x = 12;
                btn_y = 35;
            }
  
            else if (del_btn.Location.X == 12 && del_btn.Location.Y > 35 && del_btn.Location.Y < 135)
            {
                btn_x -= 100;
                //btn_x = 12;
            }
  
            else if (del_btn.Location.X < 600 && del_btn.Location.X > 12 && del_btn.Location.Y < 36)
            {
                btn_x -= 100;
            }

            else if (del_btn.Location.X > 550 && del_btn.Location.Y == 35)
            {
                btn_x -= 500;
                btn_y += 100;
            }
            else if (btn_x == -88)
            {
                btn_x = 512;
                btn_y = 35;
            }
            


            this.Controls.Remove(del_btn);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Гитара") this.chords_progression.Play_Guitar();
            if (comboBox1.Text == "Пианино") this.chords_progression.Play_Piano();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string[] paths = new string[chords_progression.Progression.Count];
            //string path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Resources\\" + chords_progression.Progression[0].Name +".wav";

            if(comboBox1.Text == "Гитара")
            {
                chords_progression.Save_g();
            }
            if(comboBox1.Text == "Пианино")
            {
                chords_progression.Save_p();
            }
            
        }


       /* private void LaunchCommandLineApp(string[] inputFiles, string outputFile)
        {
            string arg_string = $"-i ";
            for (int i = 0; i < inputFiles.Length; i++)
            {
                if (i != inputFiles.Length - 1) arg_string += $"{inputFiles[i]} -i ";
                else arg_string += $"{inputFiles[i]} ";
            }
            //[0:0][1:0][2:0][3:0]

            arg_string += $"-filter_complex ";
            for (int i = 0; i < inputFiles.Length; i++)
            {
                arg_string += $"[{i}:0]";
            }
            arg_string += $"concat=n={inputFiles.Length}:v=0:a=1[out] -map [out] {outputFile}";
            Console.WriteLine(arg_string);
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.CreateNoWindow = false;
            psi.UseShellExecute = false;
            psi.FileName = "ffmpeg.exe";
            psi.WindowStyle = ProcessWindowStyle.Normal;
            psi.Arguments = arg_string;
            using (Process exeProcess = Process.Start(psi))
            {

                exeProcess.WaitForExit();
                Console.WriteLine(outputFile);
                Console.WriteLine("ffmpeg" + arg_string);
            } 
        // ffmpeg -i C:\Users\b0nd7\source\repos\Course_work\Course_work\Resources\A.wav -i C:\Users\b0nd7\source\repos\Course_work\Course_work\Resources\B.wav -filter_complex [0:0][1:0][2:0][3:0]concat=n=4:v=0:a=1[out] -map [out] C:\Users\b0nd7\source\repos\Course_work\Course_work\Resources\out.wav
        //C: \Users\b0nd7\source\repos\Course_work\Course_work\Resources
        } */

        private void аппликатураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            ContextMenuStrip menu = (ContextMenuStrip)item.GetCurrentParent();
            Button button_x = (Button)menu.SourceControl;
            foreach(var elem in chords_progression.Progression)
            {
               if(button_x.Text == elem.Name)
                {
                    pictureBox1.Image = elem.Image;
                    label6.Text = elem.Name;
                }
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            label6.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string s = "";
            List<string> names = new List<string>();
            foreach(var chord in chords_progression.Progression)
            {
                foreach(var note in chord.Notes)
                {
                    if (!names.Exists(x => x == note.Name))
                    {
                        names.Add(note.Name);
                        s += note.Name + " ";
                    }
                    
                }
            }
            MessageBox.Show(s);
            
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            ContextMenuStrip menu = (ContextMenuStrip)item.GetCurrentParent();
            Button cur_btn = (Button)menu.SourceControl;
            
            foreach(var chord in chords_progression.Progression)
            {
                if (cur_btn.Text == chord.Name)
                {
                    if (comboBox1.Text == "Гитара")
                    {
                        chord.Save_g();
                    }
                    if (comboBox1.Text == "Пианино")
                    {
                        chord.Save_p();
                    }
                }
            }
        }

        private void сохранитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach(var elem in cl) 
            {
                if(elem.Image == pictureBox1.Image) pictureBox1.Image.Save($"{elem.Name}_appl.jpg");
            }
            
        }
    }
}
