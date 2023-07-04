using Common.Command;
using Microsoft.Practices.Prism.Events;
using MVVMUebung.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMUebung.ViewModels
{
    public class PAYDAYModel : ViewModelsBase
    {
        private string downloadStatus;
        private string playDownload;
        private int percent;
        private string visable;


        public PAYDAYModel(IEventAggregator eventAggregator): base(eventAggregator) 
        {
            this.DownloadComman = new ActionCommand(this.DownloadCommandExecute, this.DownloadCommandCanExecute);
            this.Viable = "hidden";
        }

        public string DownloadStatus
        {
            get { return downloadStatus; }
            set 
            { 
                downloadStatus = value; 
                this.OnPropertyChanged(nameof(DownloadStatus));
            }
        }

        public string Viable
        {
            get { return this.visable; }
            set
            {
                this.visable = value;
                this.OnPropertyChanged(nameof(Viable));
            }
        }

        public int Percent
        {
            get { return percent; }
            set
            {
                this.percent = value; 
                this.OnPropertyChanged(nameof(Percent));
            }
        }

        public string PlayDownload
        {
            get { return playDownload; }
            set
            {
                this.playDownload = value;
                this.OnPropertyChanged(nameof(PlayDownload));
            }
        }

         void ClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesReceived = e.BytesReceived / 1024;
            bytesReceived = bytesReceived / 1024;
            double bytesTotal = e.TotalBytesToReceive / 1024;
            bytesTotal = bytesTotal / 1024;
            this.DownloadStatus = bytesReceived+"/"+bytesTotal;
            this.Percent = e.ProgressPercentage;
        }

         void ClientDownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.DownloadStatus = "Download completed!";
            Thread.Sleep(2000);
            try
            {
                ZipFile.ExtractToDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PhipsiGaming\Games\main.zip", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PhipsiGaming\Games");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Viable = "hidden";
        }

        public ICommand DownloadComman { get; private set; }

        private bool DownloadCommandCanExecute(object parameter)
        {
            

            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PhipsiGaming\Games\PaydayPanic-main"))
            {
                this.PlayDownload = "Play";
            }
            else
            {
                this.PlayDownload = "Download";
            }
            return true;
        }

        private void DownloadCommandExecute(object parameter)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PhipsiGaming\Games\PaydayPanic-main"))
            {
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PhipsiGaming\Games\PaydayPanic-main\PayDay\bin\Debug\PayDay.exe");
            }
            else
            {
                this.Viable = "visable";
                using (var client = new WebClient())
                {
                    Thread.Sleep(1000);
                    client.DownloadProgressChanged += ClientDownloadProgressChanged;
                    client.DownloadFileCompleted += ClientDownloadCompleted;
                    client.DownloadFileAsync(new Uri("https://github.com/Philipkorti/PaydayPanic/archive/refs/heads/main.zip"), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\PhipsiGaming\Games\main.zip");
                }
            }
            
        }
    }
}
