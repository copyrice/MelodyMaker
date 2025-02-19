using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Media;
using System.Diagnostics;

namespace Course_work
{
    public class Chord: MusicalUnit, ISaver
    {
        
        List<Note> notes;

        string name;

        UnmanagedMemoryStream sound_piano;
        UnmanagedMemoryStream sound_guitar;
        System.Drawing.Bitmap image;


        

        public List<Note> Notes
        {
            get { return this.notes; }
            set { notes = value; }
        }


        public Chord(string name_, List<Note> notes_, UnmanagedMemoryStream sound_piano_, UnmanagedMemoryStream sound_guitar_, System.Drawing.Bitmap image_)
        {
            name = name_;
            notes = notes_;
            sound_piano = sound_piano_;
            sound_guitar = sound_guitar_;
            image = image_;
        }

        public Chord()
        {

        }

        public void Save_p()
        {
            //ffmpeg - i gA.wav ou.mp3
            string path = "";
            //string path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Resources\\" + chords_progression.Progression[0].Name +".wav";


            path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Resources\\" + this.Name + ".wav";




            string output = $"{this.Name}_piano_mp3_output.mp3";
            ffmpegLauncher.LaunchCommandLineApp_save(path, output);

        }
        
        public void Save_g()
        {
            string path = "";
            //string path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Resources\\" + chords_progression.Progression[0].Name +".wav";

            
            path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Resources\\" + "guitar" + this.Name + ".wav";
            



            string output = $"{this.Name}_guitar_mp3_output.mp3";
            ffmpegLauncher.LaunchCommandLineApp_save(path, output);
        }

        

        public void PrintInfo()
        {
            Console.WriteLine(this.Name);
            foreach (var elem in this.Notes)
            {
                Console.WriteLine(elem.Name);
            }
            Console.WriteLine(Convert.ToString(this.Sound_piano));
            Console.WriteLine(Convert.ToString(this.Sound_guitar));
        }

        public string Name
        {
            get { return this.name; }
            set { name = value; }
        }

        public UnmanagedMemoryStream Sound_piano
        {
            set { sound_piano = value; }
            get { return this.sound_piano; }
 
        }

        public System.Drawing.Bitmap Image
        {
            set { image = value; }
            get { return this.image; }
            

        }

        public UnmanagedMemoryStream Sound_guitar
        {
            set { sound_piano = value; }
            get { return this.sound_guitar; }

        }
        public void Play_Piano()
        {
            if(this.sound_piano != null)
            {
                SoundPlayer player = new SoundPlayer(); 
                player.Stream = this.sound_piano;
                player.Play();
                player.Stream.Position = 0;
                
            }
        }

        public void Save_image()
        {
            this.image.Save($"{this.name}");
        }

        public void Play_Guitar()
        {
            if (this.sound_guitar != null)
            {
                SoundPlayer player = new SoundPlayer();
                player.Stream = this.sound_guitar;
                player.Play();
                player.Stream.Position = 0;
            }
        }
    }
}
