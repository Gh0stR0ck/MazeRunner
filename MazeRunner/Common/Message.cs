using System;

namespace MazeRunner
{
    /// <summary>
    /// Class to handle messages.
    /// </summary>
    public static class Message
    {
        /// <summary>
        /// This function should write messages to a log.
        /// </summary>
        /// <param name="message"> The message the write. </param>
        public static void WriteToLog(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// This function should write messages to a GUI.
        /// In the case it's just the console.
        /// </summary>
        /// <param name="message"> The message the write. </param>
        public static void Write(string message) 
        {
            Console.WriteLine(message);
        }
    }
}
