using System.Diagnostics;

namespace testcmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Environment.CurrentDirectory.Replace("\\bin\\Debug\\net7.0", "");
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine("cd "+ path);
            process.StandardInput.WriteLine("mkdir vite");
            process.StandardInput.WriteLine("cd vite");
            process.StandardInput.WriteLine("pnpm create vite@latest vue_app --template vue");
            process.StandardInput.WriteLine(ConsoleKey.DownArrow);
            process.StandardInput.WriteLine(ConsoleKey.Enter);
            process.StandardInput.WriteLine("cd vue_app");
            process.StandardInput.WriteLine("code .");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.StandardOutput.ReadToEnd();
        }
    }
}