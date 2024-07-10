using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexHelper
{
    internal class Log
    {
        private static Dictionary<string, Stopwatch> stopwatches = new Dictionary<string, Stopwatch>();

        public static int logExecutionTimeIndent = 0;
        public static void LogExecutionTime()
        {

            // Get the method name where LogExecutionTime was called from
            var callingMethodName = new StackTrace().GetFrame(1).GetMethod().Name;

            //Console.WriteLine($"Method: {callingMethodName}");

            if (!stopwatches.ContainsKey(callingMethodName))
            {
                logExecutionTimeIndent++;
                stopwatches[callingMethodName] = Stopwatch.StartNew();
                string tabs = string.Join("", Enumerable.Repeat("\t", logExecutionTimeIndent));
                Console.WriteLine($"{tabs}New Method: {callingMethodName}");
                Console.WriteLine($"{tabs}Method: {callingMethodName}: Start");

            }
            else
            {
                var stopwatch = stopwatches[callingMethodName];

                if (stopwatch.IsRunning)
                {
                    stopwatch.Stop();
                    string tabs = string.Join("", Enumerable.Repeat("\t", logExecutionTimeIndent));
                    Console.WriteLine($"{tabs}Method: {callingMethodName}: End    :{stopwatch.ElapsedMilliseconds} ms");
                    logExecutionTimeIndent--;
                }
                else
                {
                    logExecutionTimeIndent++;
                    string tabs = string.Join("", Enumerable.Repeat("\t", logExecutionTimeIndent));
                    Console.WriteLine($"{tabs}Method: {callingMethodName}: Start");
                    stopwatches[callingMethodName] = Stopwatch.StartNew();

                }
            }
        }
    }
}
