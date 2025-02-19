using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_work
{
    class ffmpegLauncher
    {
        public static void LaunchCommandLineApp_concat(string[] inputFiles, string outputFile)
        {
            string arg_string = $" -i ";
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
        }
        public static void LaunchCommandLineApp_save(string inputFile, string outputFile)
        {
            string arg_string = $" -i " + inputFile;
            arg_string += $" {outputFile}";
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
        }
    }

}
