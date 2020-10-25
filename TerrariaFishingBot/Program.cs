using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace TerrariaFishingBot
{
    class Program
    {

        static bool catched = false;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void keybd_event(uint bVk, uint bScan, uint dwFlags, uint dwExtraInfo);


        public static void PressE()
        {
            keybd_event(0x01, 0, 0, 0);
            Thread.Sleep(100);
            keybd_event(0x01, 0, 2, 0);
        }

        static void Main(string[] args)
        {
            Console.Title = "Terraria fishing bot for verion 1.4.1.1";
            Process[] processes = Process.GetProcessesByName("Terraria");
            if (processes.Length > 0)
            {
                IntPtr BaseAdress = IntPtr.Zero;
                Process MYProc = processes[0];

                foreach (ProcessModule module in MYProc.Modules)
                {
                    if (module.ModuleName.ToLower().Contains("asw"))
                    {
                        BaseAdress = module.BaseAddress;
                    }
                }
                if (BaseAdress != IntPtr.Zero)
                {
                    VAMemory memory = new VAMemory("Terraria");
                    int finalAdress = memory.ReadInt32((IntPtr)BaseAdress + 0x00159B24);

                    Console.WriteLine("Press enter when you're ready ");
                    Console.ReadLine();
                    Console.WriteLine("starting in:");
                    for (int i = 5; i > 0; i--)
                    {
                        Console.WriteLine(i);
                        Thread.Sleep(1000);
                    }

                    while (true)
                    {
                        catched = false;
                        PressE();
                        Console.WriteLine("the rod was thrown");
                        //click
                        Thread.Sleep(2000);

                        while (catched == false)
                        {
                            byte x = memory.ReadByte((IntPtr)finalAdress + 0x170);
                            if (x != 0)
                            {
                                //click
                                Console.WriteLine($"you got a fish");
                                PressE();
                                catched = true;
                            }
                        }
                        Thread.Sleep(2000);
                    }
                }
            }
            else
            {
                Console.WriteLine("You have to start terraria first.");
                Console.ReadLine();
            }
        }
    }
}
