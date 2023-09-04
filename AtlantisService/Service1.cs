using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AtlantisService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected async override void OnStart(string[] args)
        {
            new MyGame.Sources.Main().Start();
            while (true)
            {
                File.AppendAllText(@"C:\Users\Antis\Desktop\File1.txt", "Test ");
                await Task.Delay(300);
            }
        }

       
    }
}
