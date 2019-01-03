﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaton.feature_ex_4
{
    class ProcessOutputGenerator
    {
        public static StringBuilder ProcessToStringBuilder(ProcessStartInfo sInfo)
        {
            var process = new Process();
            sInfo.CreateNoWindow = false;

            // 4.3. Parse output - display all IPv4 addresses 

            sInfo.UseShellExecute = false;
            sInfo.RedirectStandardOutput = true;
            sInfo.RedirectStandardError = true;

            var output = new StringBuilder();
            process.OutputDataReceived += (sender, eventArgs) => output.AppendLine(
                $"OUT: {eventArgs.Data}");
            process.ErrorDataReceived += (sender, eventArgs) => output.AppendLine(
                $"ERR: {eventArgs.Data}");

            process.StartInfo = sInfo;
            process.Start();

            process.BeginOutputReadLine();
            process.WaitForExit();
            
            return output; 
        }
    }
}
