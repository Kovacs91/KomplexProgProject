using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            string egy = "               "; //15
            string ketto = "     "; //5
            string harom = "   "; //3
            OpenFileDialog be = new OpenFileDialog();
            be.Filter = "Szöveges Állomány (*.txt)|*.txt|Minden Állomány (*.*)|*.*";
            be.ShowDialog();
            lista.Clear();
            StreamReader sr = new StreamReader(be.FileName);
            while (!sr.EndOfStream)
            {
                lista.Add(new Állat(sr.ReadLine()));

            }
            sr.Close();
            adatok.Items.Add("Név"+egy+"Eszmei érték"+ketto+" Védetté tették"+harom+" Faj");
            int a = 0;
            foreach (var item in lista)
            {
                adatok.Items.Add(item.nev + egy + item.érték + ketto + item.védetté_tették + harom + item.típus);
            }
        }

        private void kilép(object sender, RoutedEventArgs e)
        {
            MessageBoxResult valasz = MessageBox.Show("Biztos kilépsz?", "Üzenet", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (valasz == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void hozzáad(object sender, RoutedEventArgs e)
        {
            nev.Visibility = Visibility.Visible;
            ertek.Visibility = Visibility.Visible;
            védetté_tették.Visibility = Visibility.Visible;
            eszmei_ertek.Visibility = Visibility.Visible;
            rögzít.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            label3.Visibility = Visibility.Visible;
            label4.Visibility = Visibility.Visible;
            adatok.Visibility = Visibility.Hidden;
            combo.Visibility = Visibility.Hidden;
        }

        private void biztoshozzá(object sender, RoutedEventArgs e)
        {
            nev.Visibility = Visibility.Hidden;
            ertek.Visibility = Visibility.Hidden;
            védetté_tették.Visibility = Visibility.Hidden;
            eszmei_ertek.Visibility = Visibility.Hidden;
            rögzít.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            adatok.Visibility = Visibility.Visible;
            string a = nev.Text;
            int b = int.Parse(ertek.Text);
            int c = int.Parse(védetté_tették.Text);
            string d = eszmei_ertek.Text;
            adatok.Items.Add(a + " " + b + " " + c + " " + d);

        }

        private void modosít(object sender, RoutedEventArgs e)
        {
            /* Működik
            string a = "";
            a=Convert.ToString(adatok.SelectedItem);
            MessageBox.Show(a);
            */
            mód.Visibility = Visibility.Visible; //textbox
            label5.Visibility = Visibility.Visible; //label
            végleg.Visibility = Visibility.Visible; //button
        }

        private void véglegesít(object sender, RoutedEventArgs e)
        {
            int index = adatok.SelectedIndex;
            adatok.Items.RemoveAt(index);
            adatok.Items.Insert(index, mód.Text);
            mód.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
            végleg.Visibility = Visibility.Hidden;
        }

        private void Adatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                mód.Text = adatok.SelectedItem.ToString();
            }
            catch 
            {

            }
        }

        private void eltávolít(object sender, RoutedEventArgs e)
        {
            int index = adatok.SelectedIndex;
            MessageBoxResult kilep = MessageBox.Show("Biztosan törlöd?", "Üzenet", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (kilep == MessageBoxResult.Yes)
            {
                adatok.Items.RemoveAt(index);
                MessageBox.Show("A törlés sikeres volt");
            }
            
        }

        private void kombo(object sender, EventArgs e)
        {
            adatok.Items.Clear();
            string a = combo.Text;
            adatok.Items.Add("Név,Eszmei érték, Védetté tették, Faj");
            foreach (var item in lista)
            {
                if (item.típus == a)
                {
                    adatok.Items.Add(item.nev + " " + item.érték + " " + item.védetté_tették + " " + item.típus);
                }
                else if (a=="Összes")
                {
                    adatok.Items.Add(item.nev + " " + item.érték + " " + item.védetté_tették + " " + item.típus);
                }
            }
        }
    }
}
