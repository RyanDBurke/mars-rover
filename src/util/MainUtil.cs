/******************************************************************************
    MainUtil
        * just holds methods for handling input args
        * I had this in main originally, but it made the code feel cluttered
******************************************************************************/

using System;
using System.IO;
using System.Collections.Generic;

namespace Lib {

    class MainUtil {

        //// handles input arg for input-file
        public static bool handleInput(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("Please include input in command-args.");
                Console.WriteLine("EX: mono Main.exe input.txt");
                Console.WriteLine("EX: mono Main.exe input.txt --verbose");
                System.Environment.Exit(1);
            } else if (args.Length >= 1) {
                if (!File.Exists(args[0])) {
                    Console.WriteLine("File: {0} does NOT exist.", args[0]);
                    System.Environment.Exit(1);
                } else {
                    return true;
                }
            }

            return false; 
        }

        //// set verbose flag given command-line arg
        public static bool handleVerbose(string[] args) {
            return (args.Length >= 2) ? (args[1] == "--verbose") : false;
        }
    }
}