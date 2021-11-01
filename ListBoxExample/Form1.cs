using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace ListBoxExample
{
    public partial class Form1 : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                logger.Info("Log Started");
                //if (!Directory.Exists(Path.Combine(Application.StartupPath, "TestFolder")))
                //    Directory.CreateDirectory(Path.Combine(Application.StartupPath, "TestFolder"));

                // The folder for the roaming current user 
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string folder1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                // Combine the base folder with your specific folder....
                string specificFolder = Path.Combine(folder, "SmartTagFolder");

                // CreateDirectory will check if every folder in path exists and, if not, create them.
                // If all folders exist then CreateDirectory will do nothing.
                Directory.CreateDirectory(specificFolder);

                using (WebClient client = new WebClient())
                {
                    byte[] fileData = client.DownloadData("https://smartdevremote.blob.core.windows.net/001000/smartprint/StudentPhoto/qr_13579.jpg");
                    File.WriteAllBytes(Path.Combine(specificFolder, "123.jpg"), fileData);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
