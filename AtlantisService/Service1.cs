using System.Diagnostics;
using System;
using System.IO;
using System.ServiceProcess;
using System.Threading.Tasks;
using CrossConsole;

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
            if (File.Exists(@"C:\Users\Antis\Desktop\File1.txt"))
            {
                File.Delete(@"C:\Users\Antis\Desktop\File1.txt");
                //File.CreateText(@"C:\Users\Antis\Desktop\File1.txt");
            }



            File.AppendAllText(@"C:\Users\Antis\Desktop\File1.txt", "OnStart\n");
            var logger = ConsoleCreator.CreateForService();

            var t = new MyGame.Sources.Main();
            await t.Start(logger);


            //while (true)
            //{ 
            //    File.AppendAllText(@"C:\Users\Antis\Desktop\File1.txt", "Test ");
            //    await Task.Delay(300);
            //}
        }


        private void test()
        {
            // Create the source, if it does not already exist.
            if (!EventLog.SourceExists("MySource"))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("MySource", "MyNewLog");

                File.AppendAllText(@"C:\Users\Antis\Desktop\File1.txt", "\n\n\n\n\nCreatedEventSource");
                File.AppendAllText(@"C:\Users\Antis\Desktop\File1.txt", "Exiting, execute the application a second time to use the source. \n\n\n\n\n");
                //Console.WriteLine("CreatedEventSource");
                //Console.WriteLine("Exiting, execute the application a second time to use the source.");

                // The source is created.  Exit the application to allow it to be registered.
                return;
            }
            File.AppendAllText(@"C:\Users\Antis\Desktop\File1.txt", "\n\n\n\nMySource Created\n\n\n\n\n");
            // Create an EventLog instance and assign its source.
            EventLog myLog = new EventLog();
            myLog.Source = "MySource";

            // Write an informational entry to the event log.
            myLog.WriteEntry("Writing to event log.");
        }
    }
}

