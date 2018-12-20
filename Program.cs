using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace FileOrganizer
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
        static void Main(string[] args)
        {
            FreeConsole();
            string sourceDirectory = @"C:\Users\Kaeson\Downloads";
            string extension;

            for (; ; )
            {
                try
                {
                    var txtFiles = Directory.EnumerateFiles(sourceDirectory);
                    var txtDir = Directory.EnumerateDirectories(sourceDirectory);

                    foreach (string currentFile in txtFiles)
                    {
                        var directories = Directory.GetDirectories(sourceDirectory);
                        string fileName = currentFile.Substring(sourceDirectory.Length + 1);
                        string fileNameLoc = currentFile.Substring(sourceDirectory.Length);

                        extension = Path.GetExtension(fileName);
                        string fileLetters = extension.Replace(".", string.Empty);

                        string[] folders = Directory.GetDirectories(sourceDirectory);

                        foreach (string currentFolder in txtDir)
                        {
                            string folderName = currentFolder.Substring(sourceDirectory.Length + 1);

                            if (Directory.Exists(sourceDirectory))
                            {
                                if (Directory.Exists(currentFolder))
                                {
                                    if (fileLetters == folderName)
                                    {
                                        File.Move(currentFile, currentFolder + fileNameLoc);
                                    }
                                    else
                                    {
                                        string newDirPath = (sourceDirectory + @"\" + fileLetters);
                                        Directory.CreateDirectory(newDirPath);

                                    }
                                }


                            }

                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }



                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
