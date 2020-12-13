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
                argError("\nPlease include input in command-args.\n" +
                    "EX: mono Main.exe input.txt\n" + 
                    "EX: mono Main.exe input.txt --verbose\n");
            } else if (args.Length >= 1) {
                if (!File.Exists(args[0])) {
                    argError(String.Format("\nFile: {0} does NOT exist.", args[0]));
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

        //// throws arg error and prints string
        public static void argError(string msg) {
            Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg);
                Console.ForegroundColor = ConsoleColor.White;
                throw new ArgumentException();
        }
    }
}