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

namespace IranyitoMutato
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SzamolB_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(ata_kis.Text, out int kiserlet) || !int.TryParse(sik_ata.Text, out int sikeres) || !int.TryParse(Passz_yard.Text, out int yardok) || !int.TryParse(TD_passz.Text, out int tdPassz) || !int.TryParse(ela_ata.Text, out int eladott))
            {
                iranyita_m.Content = "Hibás adat";
                iranyita_m.Foreground = Brushes.Red;
            }
            else
            {
                iranyita_m.Content = $"Irányító mutató: {Math.Round(Szamol(kiserlet, sikeres, yardok, tdPassz, eladott), 2)}";
            }
        }

        private double Szamol(int kiserlet, int sikeres, int yardok, int tdPassz, int eladott)
        {
            double a, b, c, d;
            a = MinMax(((double)sikeres / kiserlet - 0.3) * 5);
            b = MinMax(((double)yardok / kiserlet - 3) * 0.25);
            c = MinMax(((double)tdPassz / kiserlet) * 20);
            d = MinMax(2.375 - ((double)eladott / kiserlet) * 25);

            return 100 * (a + b + c + d) / 6;
        }

        private double MinMax(double x)
        {
            if(x < 0)
            {
                return 0;
            }
            if(x > 2.375)
            {
                return 2.375;
            }
            return x;
        }

        private void ata_kis_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(int.TryParse(ata_kis.Text, out int kiserlet) && kiserlet > 0)
            {
                sik_ata.IsEnabled = true;
                Passz_yard.IsEnabled = true;
                TD_passz.IsEnabled = true;
                ela_ata.IsEnabled = true;
            }
        }
    }
}
