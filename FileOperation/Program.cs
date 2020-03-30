using System;
using System.IO;

namespace FileOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Operations");
            Console.WriteLine("1. Create a file");
            Console.WriteLine("2. Copy a file ");
            Console.WriteLine("3. Rename a file");
            Console.WriteLine("4. Concate files");
            Console.WriteLine("5. Read from file");
            string path = @"E:\Dipti";
            
            int choice;
            Console.WriteLine("Enter your choice");
            choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    CreateFile();
                    break;
                case 2: CopyFile();
                    break;
                case 3:RenameFile();
                    break;
                case 4:ConcateFile();
                    break;
                case 5: Display();
                    break;
                default:break;
            }
            void CreateFile()
            {
                string pathString = @"E:\Dipti";
                Console.WriteLine("Enter the file name");
                string fileName = Console.ReadLine();
                pathString = System.IO.Path.Combine(pathString, fileName);
                Console.WriteLine("Path to my file: {0}\n", pathString);
                if (!System.IO.File.Exists(pathString))
                {
                    System.IO.File.Create(pathString);
                }
                else
                {
                    Console.WriteLine("File \"{0}\" already exists.", fileName);
                    return;
                }

                try
                {
                    byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
                    foreach (byte b in readBuffer)
                    {
                        Console.Write(b + " ");
                    }
                    Console.WriteLine();
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }

                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
            void CopyFile()
            {
                Console.WriteLine("Enter file1");
                string file1 = Console.ReadLine();
                Console.WriteLine("Enter file2");
                string file2 = Console.ReadLine();
                string sourceFile = System.IO.Path.Combine(path, file1);
                string destFile = System.IO.Path.Combine(path, file2);
                System.IO.File.Copy(sourceFile, destFile, true);

            }
            void RenameFile()
            {
                string filepath = @"E:\Dipti";
                Console.WriteLine("Enter FileName ");
                string fName = Console.ReadLine();
                string Path = System.IO.Path.Combine(filepath, fName);

                FileInfo fileInfo = new System.IO.FileInfo(Path);

                if (fileInfo.Exists)
                {
                    Console.WriteLine("Enter new File Name");
                    string newName = Console.ReadLine();
                    string newPath = System.IO.Path.Combine(filepath, newName);
                    fileInfo.MoveTo(newPath);
                    Console.WriteLine("File Renamed Successfully");
                }
                else
                {
                    Console.WriteLine("File Not exist");
                }
            }

            void ConcateFile()
            {
                string fpath = @"E:\Dipti";
                Console.WriteLine("Enter First FileName");
                string firstfileName = Console.ReadLine();
                string FirstFilePath = System.IO.Path.Combine(fpath, firstfileName);
                Console.WriteLine("Enter Second FileName");
                string secondfileName = Console.ReadLine();
                string secondFilePath = System.IO.Path.Combine(fpath, secondfileName);
                if (File.Exists(FirstFilePath))
                {
                    FileStream f1 = null;
                    FileStream f2 = null;
                    f1 = File.Open(FirstFilePath, FileMode.Open);
                    f2 = File.Open(secondFilePath, FileMode.Append);
                    //f1.Read()
                    StreamReader sr = new StreamReader(f1);
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        StreamWriter sw = new StreamWriter(f2);
                        sw.Write(line);
                        sw.Close();
                    }
                    sr.Close();
                    Console.WriteLine("Successfully Done");
                }
                else
                {
                    Console.WriteLine("File Not Found");
                }
            }

             void Display()
            {
                string filepath = @"E:\Dipti";
                Console.WriteLine("Enter File name.");
                string fileName = Console.ReadLine();
                string Path = System.IO.Path.Combine(filepath, fileName);
                if (File.Exists(Path))
                {
                    StreamReader sr = new StreamReader(Path);
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    sr.Close();
                }
            }

        }

    }
}
