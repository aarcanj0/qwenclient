using CefSharp;
using CefSharp.WinForms;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Windows.Forms;

namespace QwenClient
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
            chromiumWebBrowser1.LoadError += OnLoadError;
            
        }

        private async void mainWindow_Shown(object sender, EventArgs e)
        {
            chromiumWebBrowser1.LoadUrlAsync("https://qwenlm.ai");
            
        }

        private void OnLoadError(object sender, LoadErrorEventArgs args)
        {
            if (args.ErrorCode != CefErrorCode.Aborted)
            {
                new ToastContentBuilder()
                    .AddText("QwenAI Client")
                    .AddText($"Failed to load page: {args.ErrorText} ({args.ErrorCode})")
                    .Show();
                
                //MessageBox.Show($"Failed to load page: {args.ErrorText} ({args.ErrorCode})");
                chromiumWebBrowser1.Load("https://example.com/error-page");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("QwenClient\nmade by aarcanj0\n\nv0.115b:\n  > Correção de Bugs\n\n\nPróximas Atualizações:\n  [+] Método para limpar dados de navegação\n  [+] Customizar pasta padrão para dados de navegação");
        }
    }
}
