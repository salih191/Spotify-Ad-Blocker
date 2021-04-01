using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Spotify_Ad_Blocker.Properties;

namespace Spotify_Ad_Blocker
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        static extern bool SetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        private struct POINTAPI
        {
            public int x;
            public int y;
        }
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public POINTAPI ptMinPosition;
            public POINTAPI ptMaxPosition;
            public RECT rcNormalPosition;
        }

        public const int KEYEVENTF_EXTENTEDKEY = 1;
        public const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        public const int VK_MEDIA_NEXT_TRACK = 0xB0;

        private Process spotify;

        private string spotifyName = "Spotify";
        private int reklamSayac = 0;
        private int digerSayac = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uygulamaVerisi();
            if (UygulamaKontrol())
            {
                this.ShowInTaskbar = false;
                this.Hide();
                timer1.Start();
            }
            else
            {
                this.Close();
            }

        }
        private bool UygulamaKontrol()
        {
            if (Settings.Default.ilkCalistirma)
            {
                Settings.Default.SpotifyPath = System.Environment.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Microsoft\WindowsApps\SpotifyAB.SpotifyMusic_zpdnekdrzrea0\Spotify.exe";
                Settings.Default.ilkCalistirma = false;
                Settings.Default.Save();
            }
            if (!File.Exists(Settings.Default.SpotifyPath))
            {
                MessageBox.Show("spotify bulunamadı");
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "spotify kısayol dosyası |*.lnk;.exe | All files |*.*";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    Settings.Default.SpotifyPath = openFile.FileName;
                    UygulamaKontrol();
                }
                else
                {
                    return false;
                }

            }
            return true;
        }
        private void uygulamaVerisi()
        {
            bilidirimGösterToolStripMenuItem.Checked = Settings.Default.BildirimGoster;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            var a = key.GetValue(Application.ProductName);
            if (a!=null && a.Equals("\"" + Application.ExecutablePath + "\""))
            {
                bilgisayarlaAçılmaToolStripMenuItem.Checked = true;
            }
            else
            {
                bilgisayarlaAçılmaToolStripMenuItem.Checked = false;
            }
        }
        private void bilgisayarlaAçılmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bilgisayarlaAçılmaToolStripMenuItem.Checked = !bilgisayarlaAçılmaToolStripMenuItem.Checked;
            if (bilgisayarlaAçılmaToolStripMenuItem.Checked)        // program oto başlatma işaretlenirse
            {
                //işaretlendi ise Regedit e açılışta çalıştır olarak ekle
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue(Application.ProductName, "\"" + Application.ExecutablePath + "\""); 
            }
            else              //program oto çalıştırma iptal edilirse
            {

                //işaret kaldırıldı ise Regeditten açılışta çalıştırılacaklardan kaldır
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.DeleteValue(Application.ProductName);

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (spotify!=null && !spotify.HasExited)
            {
                çalanŞarkıToolStripMenuItem.Text = spotify.MainWindowTitle;
                notifyIcon1.Text = spotify.MainWindowTitle;
            }
            spotify = spotifyHook();
            if (spotify == null)
            {
                spotify = spotifyHook();
            }
            else if ((!spotify.HasExited) && (spotify.MainWindowTitle.Contains("Advertisement") || !spotify.MainWindowTitle.Contains(" - ")) && !spotify.MainWindowTitle.Equals("Drag") && !spotify.MainWindowTitle.Equals("Spotify Free") && !spotify.MainWindowTitle.Equals("Spotify"))
            {

                if ((spotify.MainWindowTitle.Equals("Advertisement")))
                {
                    reklamSayac++;
                    geçilenReklamSayısıToolStripMenuItem.Text = "Geçilen toplam reklam:" + reklamSayac;
                    if (Settings.Default.BildirimGoster) notifyIcon1.ShowBalloonTip(2000, "Reklam Geçildi", "Geçilen toplam reklam:" + reklamSayac, ToolTipIcon.Info);
                }
                else
                {
                    digerSayac++;
                    geçilenDiğerSayısıToolStripMenuItem.Text = "Gecilen toplam diger:" + digerSayac;
                    if (Settings.Default.BildirimGoster) notifyIcon1.ShowBalloonTip(2000, "Diğer Geçildi", "Geçilen toplam diğer:" + digerSayac, ToolTipIcon.Info);
                }

                try
                {
                    sonGeçilenToolStripMenuItem.Text = "Son Gecilen:" + spotify.MainWindowTitle;
                    acKapa();
                }
                catch (Exception exception)
                {
                    notifyIcon1.ShowBalloonTip(1000,"Hata",exception.Message,ToolTipIcon.Error);
                }
            }
            else if(spotify != null && !spotify.HasExited)
            {
                spotify.Refresh();
            }
        }
        private void spotifyKapat()
        {
            Process[] p;
            p = Process.GetProcessesByName(spotifyName);
            if (p.Length > 0)
            {
                foreach (Process process in p)
                {
                    process.Kill();
                }
            }
            spotify = null;
        }
        private void spotifyMinimizeEt()
        {
            Process[] p2;
            p2 = Process.GetProcessesByName(spotifyName);
            while (p2.Select(p => p.MainWindowTitle != "").FirstOrDefault(c => c == true) == false)
            {
                p2 = Process.GetProcessesByName("Spotify");
            }
            foreach (var process in p2)
            {
                IntPtr app_hwnd;
                WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
                app_hwnd = process.MainWindowHandle;
                GetWindowPlacement(app_hwnd, ref wp);
                wp.showCmd = 2; // 1- Normal; 2 - Minimize; 3 - Maximize
                SetWindowPlacement(app_hwnd, ref wp);
            }
        }
        public void acKapa()
        {
            spotifyKapat();
            try
            {
                Process.Start(Settings.Default.SpotifyPath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.Close();
            }
            spotifyMinimizeEt();
            Thread.Sleep(1500);
            keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            Thread.Sleep(500);
            keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
        }
        private Process spotifyHook()
        {
            foreach (var process in Process.GetProcessesByName(spotifyName))
            {
                if (process.MainWindowTitle.Length > 0)
                {
                    return process;
                }
            }

            return null;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void bilidirimGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bilidirimGösterToolStripMenuItem.Checked = !bilidirimGösterToolStripMenuItem.Checked;
            Settings.Default.BildirimGoster = bilidirimGösterToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

    }
}
