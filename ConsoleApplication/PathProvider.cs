﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ConsoleApplication
{
    [Export(typeof(IPathProvider))]
    public class PathProvider : IPathProvider
    {
        public string GetPath()
        {
            while (true)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                Console.Write("Enter file name: " + path);
                path = path + Console.ReadLine();
                //path += "TestLibrary.dll";

                if (File.Exists(path))
                    return path;
                else
                {
                    Console.WriteLine("There is no such file");
                    Thread.Sleep(300);
                }
            }
        }
    }
}
