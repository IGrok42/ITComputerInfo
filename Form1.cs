using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;   //This namespace is used to work with WMI classes. For using this namespace add reference of System.Management.dll .
using Microsoft.Win32;     //This namespace is used to work with Registry editor.

namespace ITComputerInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            lblMain.Text = "Hello World!";
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Displaying operating system info....\n");
            //Create an object of ManagementObjectSearcher class and pass query as parameter.
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Caption"] != null)
                {
                    textBox1.Text = "Operating System Name  :  " + managementObject["Caption"].ToString();   //Display operating system caption
                }
                //if (managementObject["OSArchitecture"] != null)
                //{
                //    Console.WriteLine("Operating System Architecture  :  " + managementObject["OSArchitecture"].ToString());   //Display operating system architecture.
                //}
                //if (managementObject["CSDVersion"] != null)
                //{
                //    Console.WriteLine("Operating System Service Pack   :  " + managementObject["CSDVersion"].ToString());     //Display operating system version.
                //}
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Caption"] != null)
                {
                    textBox1.Text = "Operating System Name  :  " + managementObject["Caption"].ToString();   //Display operating system caption
                }
                if (managementObject["OSArchitecture"] != null)
                {
                    textBox1.Text += "\r\nOperating System Architecture  :  " + managementObject["OSArchitecture"].ToString();   //Display operating system architecture.
                }
                if (managementObject["CSDVersion"] != null)
                {
                    textBox1.Text += "\r\nOperating System Service Pack   :  " + managementObject["CSDVersion"].ToString();     //Display operating system version.
                }
                if (managementObject["CSName"] != null)
                {
                    textBox1.Text += "\r\nCSName   :  " + managementObject["CSName"].ToString();     //Display operating system version.
                }
            }
            ManagementObjectSearcher mos2 = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
            foreach (ManagementObject managementObject in mos2.Get())
            {
                if (managementObject["Manufacturer"] != null)
                {
                    textBox1.Text += "\r\nManufacturer :  " + managementObject["Manufacturer"].ToString();   //Display operating system caption
                }
                if (managementObject["Model"] != null)
                {
                    textBox1.Text += "\r\nModel  :  " + managementObject["Model"].ToString();   //Display operating system architecture.
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
