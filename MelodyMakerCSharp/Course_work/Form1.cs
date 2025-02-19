using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Course_work.Properties;
using System.IO;

namespace Course_work
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\b0nd7\source\repos\Course_work\Course_work\Database1.mdf;Integrated Security=True";

        SoundPlayer player = null;

        
        public static List<Chord> chord_list = new List<Chord>();

        public static Dictionary<string, System.IO.UnmanagedMemoryStream> piano_sounds_dict =
            new Dictionary<string, System.IO.UnmanagedMemoryStream>()
            {
                { "C", Properties.Resources.C},
                { "Cm", Properties.Resources.Cm },
                { "Db", Properties.Resources.C_ },
                { "C#m", Properties.Resources.C_m },
                { "D", Properties.Resources.D },
                { "Dm", Properties.Resources.Dm },
                { "Eb", Properties.Resources.D_ },
                { "Ebm", Properties.Resources.D_m },
                { "E", Properties.Resources.E },
                { "Em", Properties.Resources.Em },
                { "F", Properties.Resources.F },
                { "Fm", Properties.Resources.Fm },
                { "F#", Properties.Resources.F_ },
                { "F#m", Properties.Resources.F_m },
                { "G", Properties.Resources.G },
                { "Gm", Properties.Resources.Gm },
                { "Ab", Properties.Resources.G_ },
                { "G#m", Properties.Resources.G_m },
                { "A", Properties.Resources.A },
                { "Am", Properties.Resources.Am },
                { "Bb", Properties.Resources.A_ },
                { "Bbm", Properties.Resources.A_m },
                { "B", Properties.Resources.B },
                { "Bm", Properties.Resources.Bm },
            };


        public static Dictionary<string, System.IO.UnmanagedMemoryStream> guitar_sounds_dict =
           new Dictionary<string, System.IO.UnmanagedMemoryStream>()
           {
                { "C", Properties.Resources.guitarC},
                { "Cm", Properties.Resources.guitarCm },
                { "Db", Properties.Resources.guitarC_ },
                { "C#m", Properties.Resources.guitarC_m },
                { "D", Properties.Resources.guitarD },
                { "Dm", Properties.Resources.guitarDm },
                { "Eb", Properties.Resources.guitarD_ },
                { "Ebm", Properties.Resources.guitarD_m },
                { "E", Properties.Resources.guitarE },
                { "Em", Properties.Resources.guitarEm },
                { "F", Properties.Resources.guitarF },
                { "Fm", Properties.Resources.guitarFm },
                { "F#", Properties.Resources.guitarF_ },
                { "F#m", Properties.Resources.guitarF_m },
                { "G", Properties.Resources.guitarG },
                { "Gm", Properties.Resources.guitarGm },
                { "Ab", Properties.Resources.guitarAb },
                { "G#m", Properties.Resources.guitarG_m },
                { "A", Properties.Resources.guitarA },
                { "Am", Properties.Resources.guitarAm },
                { "Bb", Properties.Resources.guitarBb },
                { "Bbm", Properties.Resources.guitarBbm },
                { "B", Properties.Resources.guitarB },
                { "Bm", Properties.Resources.guitarBm },
           };


        public static Dictionary<string, System.Drawing.Bitmap> images_dict =
            new Dictionary<string, System.Drawing.Bitmap>() 
            {
                { "C", Properties.Resources.imageC},
                { "Cm", Properties.Resources.imageCm },
                { "Db", Properties.Resources.imageC_ },
                { "C#m", Properties.Resources.imageC_m },
                { "D", Properties.Resources.imageD },
                { "Dm", Properties.Resources.imageDm },
                { "Eb", Properties.Resources.imageD_ },
                { "Ebm", Properties.Resources.imageD_m },
                { "E", Properties.Resources.imageE },
                { "Em", Properties.Resources.imageEm },
                { "F", Properties.Resources.imageF },
                { "Fm", Properties.Resources.imageFm },
                { "F#", Properties.Resources.imageF_ },
                { "F#m", Properties.Resources.imageF_m },
                { "G", Properties.Resources.imageG },
                { "Gm", Properties.Resources.imageGm },
                { "Ab", Properties.Resources.imageG_ },
                { "G#m", Properties.Resources.imageG_m },
                { "A", Properties.Resources.imageA },
                { "Am", Properties.Resources.imageAm },
                { "Bb", Properties.Resources.imageA_ },
                { "Bbm", Properties.Resources.imageA_m },
                { "B", Properties.Resources.imageB },
                { "Bm", Properties.Resources.imageBm },
            };

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            f2 = new Form2();
            player = new SoundPlayer();
            Load_Chords_List();
            //dbg();
        }
        Form2 f2;
        Form3 f3;
        
        
        

        public Chord read (string btn_text)
        {
            for(int i = 0; i < chord_list.Count; i++)
            {
                if (chord_list[i].Name == btn_text)
                {
                    return chord_list[i];
                }
            }
            return null;
        }

     /*   private Chord Read_Chord(string btn_text)
        {
            Chord r_chord = new Chord();

            Note note = new Note($"{btn_text}");
            //r_chord.Notes.Add(note);
            string name = "";

            sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Chords] WHERE [Name]=" + $"'{btn_text}'", sqlConnection);
            //try
            //{
            sqlReader = command.ExecuteReader();


            r_chord.Notes = new List<Note>();

            while (sqlReader.Read())
            {

                string[] mas = Convert.ToString(sqlReader["Notes"]).Split();

                for (int i = 0; i < mas.Length; i++)
                {
                    Note nt = new Note($"{mas[i]}");
                    r_chord.Notes.Add(nt);
                }


                name = Convert.ToString(sqlReader["Name"]).Trim();
            }

                r_chord.Sound = sounds_dict[$"{name}"];
                r_chord.Name = name;

                //if (sqlReader != null)
                //{
                    //sqlReader.Close();
                //}

                return r_chord;
        } */
        

        public  void Load_Chords_List()
        {

                sqlConnection = new SqlConnection(Form1.connectionString);

                sqlConnection.Open();

                SqlDataReader sqlReader = null;

                SqlCommand command = new SqlCommand("SELECT * FROM [Chords]", sqlConnection);
                //"SELECT * FROM [Chords] WHERE [Name]="+"'C'"
                //try
                //{
                    sqlReader = command.ExecuteReader();


            while (sqlReader.Read())
            {
                List<Note> notes = new List<Note>();

                string[] mas = Convert.ToString(sqlReader["Notes"]).Split();

                for (int i = 0; i < mas.Length; i++)
                {
                    Note nt = new Note($"{mas[i]}");
                    notes.Add(nt);
                }

                Chord c = new Chord(Convert.ToString(sqlReader["Name"]).Trim(), notes,
                      piano_sounds_dict[$"{Convert.ToString(sqlReader["Name"]).Trim()}"], guitar_sounds_dict[$"{Convert.ToString(sqlReader["Name"]).Trim()}"], images_dict[$"{Convert.ToString(sqlReader["Name"]).Trim()}"]);
                chord_list.Add(c);
            }
                
        }

        public void Choose_Chord(string btn_text)
        {
            Chord chord = read(btn_text);
            Form3 f3 = new Form3(chord);
            f3.Show();
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f22 = new Form2();
            f22.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Choose_Chord(button3.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Choose_Chord(button14.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Choose_Chord(button16.Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Choose_Chord(button17.Text);
        }


        private void button7_Click(object sender, EventArgs e)
        {
            Choose_Chord(button7.Text);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Choose_Chord(button15.Text);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            // chord = read(button5.Text);
            //chord.Play();
            //Form3 f3 = new Form3(chord);
            //f3.Show();
            Choose_Chord(button5.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "G";
            Choose_Chord(button2.Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Choose_Chord(button4.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Choose_Chord(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Choose_Chord(button9.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Choose_Chord(button10.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Choose_Chord(button11.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Choose_Chord(button12.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Choose_Chord(button13.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Choose_Chord(button6.Text);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Choose_Chord(button21.Text);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Choose_Chord(button22.Text);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Choose_Chord(button23.Text);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            button25.Text = "Ab";
            Choose_Chord(button24.Text);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            
            Choose_Chord(button25.Text);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Choose_Chord(button20.Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Choose_Chord(button19.Text);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Choose_Chord(button18.Text);
        }



    }
}
