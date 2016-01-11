using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WMPLib;
using System.ComponentModel;
using System.Reflection;
using System.IO;

namespace Story_of_my_life
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        #region Variablen
        WMPLib.WindowsMediaPlayer player = new WindowsMediaPlayer();
        public event PropertyChangedEventHandler PropertyChanged;
        int volume = 5;
        string resolution = "525x350";
        string pathSaveData;
        private int _height;
        private int _width;

        #endregion

        #region ChangeWindowAppSize
        public int CustomHeight
        {
            get { return _height; }
            set
            {
                if (value != _height)
                {
                    _height = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("CustomHeight"));
                }
            }
        }
        public int CustomWidth
        {
            get { return _width; }
            set
            {
                if (value != _width)
                {
                    _width = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("CustomWidth"));
                }
            }
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            #region SongFix
            //Dateipfad für song festlegen
            string p = AppDomain.CurrentDomain.BaseDirectory;
            string[] a = p.Split('\\');
            string pathFile = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == "Story_of_my_life")
                {
                    pathFile += a[i] + "\\";
                    break;
                }
                pathFile += a[i] + "\\";
            }
            pathSaveData = pathFile + "Properties.txt";
            pathFile += "The Walking Dead Original Soundtrack - Theme Song HD.wav";
            #endregion

            CustomHeight = 350;
            CustomWidth = 525;

            player.URL = pathFile;
            player.settings.setMode("loop", true);
            player.settings.volume = 5;
        }

        private void OptionGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            OptionsGif.Position = new TimeSpan(0, 0, 1);
            OptionsGif.Play();
        }


        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            stackpanel1.Visibility = Visibility.Collapsed;
            stackpanel2.Visibility = Visibility.Visible;
            l0.Visibility = Visibility.Visible;
            OptionsGif.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "Blood.gif");
            OptionsGif.Visibility = Visibility.Visible;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            stackpanel1.Visibility = Visibility.Collapsed;
            LStory.Visibility = Visibility.Collapsed;



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            player.controls.play();
        }

        private void BacktoMenuButton_Click(object sender, RoutedEventArgs e)
        {
            stackpanel1.Visibility = Visibility.Visible;
            stackpanel2.Visibility = Visibility.Collapsed;
            //gif anhalten
            l0.Visibility = Visibility.Collapsed;
            OptionsGif.Visibility = Visibility.Collapsed;
            SaveChanges(volume, resolution);

        }

        #region SaveOptionData
        public void SaveChanges(int volume, string resolution)
        {
            StreamWriter myWriter;
            if (System.IO.File.Exists(pathSaveData))
            {
                using (myWriter = new StreamWriter(pathSaveData))
                {
                    myWriter.Write(String.Empty);
                    myWriter.WriteLine(volume.ToString());
                    myWriter.WriteLine(resolution);
                    myWriter.Close();
                }
            }
            else
            {
                using (myWriter = File.CreateText(pathSaveData))
                {
                    myWriter.WriteLine("Volume: " + volume.ToString());
                    myWriter.WriteLine("Resolution: " + resolution);
                    myWriter.Close();
                }
            }
        }

        public void ReadChanges() //Not Finished
        {
            if (System.IO.File.Exists(pathSaveData))
            {
                using (StreamReader sr = File.OpenText(pathSaveData))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
        }
        #endregion

        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            volume = Convert.ToInt32(e.NewValue);
            player.settings.volume = volume;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)comb1.SelectedItem;
            resolution = cbi.Name;

            if (resolution == "Full")
            {
                this.WindowState = WindowState.Maximized;
            }
            else if (resolution == "high")
            {
                this.WindowState = WindowState.Normal;
                CustomWidth = 1280;
                CustomHeight = 720;
            }
            else if (resolution == "min")
            {
                this.WindowState = WindowState.Normal;
                CustomWidth = 640;
                CustomHeight = 480;
            }
            else if (resolution == "norm")
            {
                this.WindowState = WindowState.Normal;
                CustomWidth = 525;
                CustomHeight = 350;
            }
        }

        private void _KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    break;
                case Key.Up:
                    break;
                case Key.Down:
                    break;
                case Key.Left:
                    break;
                case Key.Right:
                    break;
                case Key.Enter:
                    break;
            }
        }
    }
}
