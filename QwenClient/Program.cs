using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Threading;
using System.Windows.Forms;

namespace QwenClient
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                string mutexName = "QwenClientUniqueInstance";
                using (Mutex mutex = new Mutex(true, mutexName, out bool isNewInstance))
                {
                    if (isNewInstance)
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new mainWindow());
                    }
                    else
                    {

                        //MessageBox.Show("An instance of QwenClient is already running.", "QwenClient", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        new ToastContentBuilder()
                            .AddText("QwenClient já está em execução")
                            .AddText("Já existe uma aplicação QwenClient em execução neste computador")
                            .Show();
                    }
                }
            }
            else if (args[0] == "--msgRememberRunning")
            {
                new ToastContentBuilder()
                    .AddText("QwenAgent em execução")
                    .AddText("Pressione a tecla Alt+C para abrir seu assistente de IA")
                    .Show();
            }
            else if (args[0] == "--msgDoMore")
            {
                new ToastContentBuilder()
                    .AddText("QwenAgent em execução")
                    .AddText("Pressione a tecla Alt+C para abrir seu assistente de IA")
                    .Show();

            }
            else if (args[0] == "--msgAgentAlreadyExist")
            {
                new ToastContentBuilder()
                    .AddText("QwenAgent já está em execução")
                    .AddText("Somente uma instância do QwenAgent é permitida")
                    .Show();

            }
        }
    }
}