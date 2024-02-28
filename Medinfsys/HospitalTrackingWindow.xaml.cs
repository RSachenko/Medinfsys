using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Medinfsys
{
    public partial class HospitalTrackingApp : Window
    {
        private readonly DispatcherTimer timer;
        private readonly HttpClient httpClient;

        // Коллекции для отображения кружков клиентов и сотрудников
        public ObservableCollection<PersonViewModel> Clients { get; set; }
        public ObservableCollection<PersonViewModel> Staff { get; set; }

        public HospitalTrackingApp()
        {
            InitializeComponent();

            // Инициализация таймера
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(3);

            // Инициализация HttpClient
            httpClient = new HttpClient();

            // Инициализация коллекций
            Clients = new ObservableCollection<PersonViewModel>();
            Staff = new ObservableCollection<PersonViewModel>();

            // Установка контекста данных для XAML
            DataContext = this;
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            // Выполнение запроса к API
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("http://10.30.76.66:8082/PersonLocations");
                response.EnsureSuccessStatusCode();

                // Обработка ответа API
                string responseBody = await response.Content.ReadAsStringAsync();

                // Добавьте код для обработки данных о перемещении клиентов и сотрудников
                // Обновите коллекции Clients и Staff в соответствии с данными API
            }
            catch (Exception ex)
            {
                // Обработка ошибок при запросе к API
                MessageBox.Show($"Ошибка при выполнении запроса к API: {ex.Message}", "Ошибка");
            }
        }

        private void StartTrackingButton_Click(object sender, RoutedEventArgs e)
        {
            // Запуск таймера при нажатии на кнопку
            timer.Start();
        }

        private void StopTrackingButton_Click(object sender, RoutedEventArgs e)
        {
            // Остановка таймера при нажатии на кнопку
            timer.Stop();
        }
    }
}
