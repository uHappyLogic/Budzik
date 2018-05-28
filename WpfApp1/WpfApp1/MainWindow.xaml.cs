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
using System.Timers;
using System.Globalization;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Ustawienie dzisiejszej daty w DatePicker
            Data.SelectedDate = DateTime.Today;
            //Pobranie wartości obecnej godziny, minuty i sekundy w momencie startu programu
            string CurrentHour = DateTime.Now.Hour.ToString();
            string CurrentMinute = DateTime.Now.Minute.ToString();
            string CurrentSecond = DateTime.Now.Second.ToString();
            //Konwersja pobranych wartości do int
            int h = 0, m=0, s=0;
            Int32.TryParse(CurrentHour, out h);
            Int32.TryParse(CurrentMinute, out m);
            Int32.TryParse(CurrentSecond, out s);
            //Ustawienie startowych wartości na bieżący czas w momencie uruchomienia programu
            Godzina.SelectedIndex = h;
            Minuta.SelectedIndex = m;
            Sekunda.SelectedIndex = s;
            
        }
        
        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            Timer alarm = new Timer();
            alarm.Elapsed += wydarzenie;
            alarm.Interval = 100;
            alarm.Enabled = true;

	        if (!Data.SelectedDate.HasValue)
	        {
				MessageBox.Show("Nie wybrano daty");
				return;
	        }

	        DateTime czasalarmu = Data.SelectedDate.Value.Date
				.AddHours(Godzina.SelectedIndex)
				.AddMinutes(Minuta.SelectedIndex)
				.AddSeconds(Sekunda.SelectedIndex);

			MessageBox.Show(czasalarmu.ToString());
        }

        private void wydarzenie(object sender, ElapsedEventArgs e)
        {
            
        }
    }
}
