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
using System.Threading;
using System.Diagnostics;

namespace Course_work
{
    class Chords_Progression: MusicalUnit, ISaver, IPlayer
    {
        List<Chord> progression;
        public void Play_Piano()
        {
            foreach(var elem in this.progression)
            {
                elem.Play_Piano();
                Thread.Sleep(800);
            }
        }

        public void Play_Guitar()
        {
            foreach (var elem in this.progression)
            {
                elem.Play_Guitar();
                Thread.Sleep(1500);
            }
        }

        public Chords_Progression()
        {
        }

        public void AddChord(Chord chord)
        {
            this.progression.Add(chord);
        }

        public List<Chord> Progression
        {
            set { this.progression = value; }
            get { return this.progression; }
        }

        public void Save_g()
        {
            string[] paths = new string[this.Progression.Count];
            //string path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Resources\\" + chords_progression.Progression[0].Name +".wav";
            
                for (int i = 0; i < paths.Length; i++)
                {
                    paths[i] = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Resources\\" + "guitar" + this.Progression[i].Name + ".wav";
                }
            


            string output = $"{this.Progression[0].Name}_key_guitar_output.mp3";
            ffmpegLauncher.LaunchCommandLineApp_concat(paths, output);
        }

        public void Save_p()
        {
            string[] paths = new string[this.Progression.Count];
            //string path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Resources\\" + chords_progression.Progression[0].Name +".wav";

           
            
                for (int i = 0; i < paths.Length; i++)
                {
                    paths[i] = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Resources\\" + this.Progression[i].Name + ".wav";
                }
            


            string output = $"{this.Progression[0].Name}_key_piano_output.mp3";
           ffmpegLauncher.LaunchCommandLineApp_concat(paths, output);
        }
        

    }
}
