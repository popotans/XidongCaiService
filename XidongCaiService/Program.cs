using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
namespace XidongCaiService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            //RunService();

            RunConsole();
        }


        static void RunService()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new Service1() 
			};
            ServiceBase.Run(ServicesToRun);
        }

        static void RunConsole()
        {
            //new CaiCore().DoList();

            //ThreadPool.QueueUserWorkItem(new WaitCallback(
            //    delegate(object obj)
            //    {
            //        Form1 f1 = new Form1();
            //        f1.Show();
            //    }
            //    ));

            WfService.WfService wse = new WfService.WfService();

            Console.ReadKey();
        }
    }
}
