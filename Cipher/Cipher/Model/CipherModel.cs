
using System.Diagnostics;
using System.IO;
using System;
using System.Management;
using System.Management.Instrumentation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;

namespace Cipher.Model
{
    class CipherModel
    {
        // --------------------------------------------------------------------------
        // chrono

        readonly Stopwatch chrono = new Stopwatch();

        public void startChrono()
        {
            chrono.Start();
        }

        public void stopChrono()
        {
            chrono.Stop();
        }

        // --------------------------------------------------------------------------

        // --------------------------------------------------------------------------
        // logical processors

        public void setLogicalProcessors(Label logicalProcessorsLabel, String logicalProcessors)
        {
            logicalProcessorsLabel.Text = logicalProcessors;
        }

        public void countLogicalProcessors(Label logicalProcessorsLabel)
        {
            String number = Environment.ProcessorCount.ToString();
            setLogicalProcessors(logicalProcessorsLabel, number);
        }

        public String countLogicalProcessorsForActiveThreads()
        {
            String number = Environment.ProcessorCount.ToString();
            int logicalProcessors = Convert.ToInt32(number) - 1;
            return logicalProcessors.ToString();
        }

        // --------------------------------------------------------------------------

        // --------------------------------------------------------------------------
        // physical processors

        public void setPhysicalProcessors(Label physicalProcessorsLabel, String physicalProcessors)
        {
            physicalProcessorsLabel.Text = physicalProcessors;
        }

        public void countPhysicalProcessors(Label physicalProcessorsLabel)
        {
            int number = 0;
            foreach (var i in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                number += int.Parse(i["NumberOfProcessors"].ToString());
            }
            setPhysicalProcessors(physicalProcessorsLabel, number.ToString());
        }

        // --------------------------------------------------------------------------

        // --------------------------------------------------------------------------
        // cores

        public void countCores(Label countCoresLabel)
        {
            int number = 0;
            foreach (var i in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                number += int.Parse(i["NumberOfCores"].ToString());
            }
            setCores(countCoresLabel, number.ToString());
        }

        public void setCores(Label countCoresLabel, String cores)
        {
            countCoresLabel.Text = cores;
        }

        // --------------------------------------------------------------------------

        // --------------------------------------------------------------------------
        // check instruction 



    }
}
