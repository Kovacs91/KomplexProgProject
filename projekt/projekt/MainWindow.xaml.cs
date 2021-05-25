using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Állat> lista;
        public MainWindow()
        {
            lista = new List<Állat>();
            InitializeComponent();
        }

        private void beolvas(object sender, RoutedEventArgs e)
        {
            OpenFileDialog be = new OpenFileDialog();
            be.Filter="Szöveges Állomány (*.txt)|*.txt|Minden Állomány (*.*)|*.*";
            be.ShowDialog();
            lista.Clear();
            StreamReader sr = new StreamReader(be.FileName);
            while (!sr.EndOfStream)
            {
                lista.Add(new Állat(sr.ReadLine()));

            }
            sr.Close();
            adatok.Items.Add("Név,Eszmei érték, Védetté tették, Faj");
            foreach (var item in lista)
            {
                adatok.Items.Add(item.nev + " " + item.érték + " " + item.védetté_tették + " " + item.típus); 
            }
        }

        private void kilép(object sender, RoutedEventArgs e)
        {
            MessageBoxResult valasz = MessageBox.Show("Biztos kilépsz?", "Üzenet", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (valasz==MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
