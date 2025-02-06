using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    const int VK_MENU = 0x12; // Alt
    const int VK_C = 0x43;    // C

    [DllImport("user32.dll")]
    static extern short GetAsyncKeyState(int vKey);

    static async Task Main(string[] args)
    {
        using (Mutex mutex = new Mutex(false, "QwenAgentUniqueInstance"))
        {
            if (!mutex.WaitOne(0, false))
            {
                using(Process ps1 = new Process())
                {
                    ps1.StartInfo.FileName = "QwenClient.exe";
                    ps1.StartInfo.Arguments = "--msgAgentAlreadyExist";
                    ps1.Start();
                }
                return;
            }

            try
            {
                await Task.WhenAll(msgRemember(), WaitForKey());
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }

    private static async Task msgRemember()
    {
        while (true)
        {
            using(Process ps1 = new Process())
            {
                ps1.StartInfo.FileName = "QwenClient.exe";
                ps1.StartInfo.Arguments = "--msgRememberRunning";
                ps1.Start();
            }
            await Task.Delay(18000000);
        }
    }

    private static async Task WaitForKey()
    {
        bool commandExecuted = false;

        while (true)
        {
            bool isAltPressed = (GetAsyncKeyState(VK_MENU) & 0x8000) != 0;
            bool isCPressed = (GetAsyncKeyState(VK_C) & 0x8000) != 0;

            if (isAltPressed && isCPressed)
            {
                if (!commandExecuted)
                {
                    Console.WriteLine("Alt + C Pressed");
                    try
                    {
                        using (Process ps1 = new Process())
                        {
                            ps1.StartInfo.FileName = "QwenClient.exe";
                            ps1.Start();
                        }
                    }
                    catch (Exception e)
                    {
                        using (Process p2 = new Process())
                        {
                            p2.StartInfo.FileName = "cmd.exe";
                            p2.StartInfo.Arguments = "/c msg * " + e.Message + "\n" + e.ToString();
                            p2.Start();
                        }
                    }
                    commandExecuted = true;
                }
            }
            else
            {
                commandExecuted = false;
            }

            await Task.Delay(100);
        }
    }
}