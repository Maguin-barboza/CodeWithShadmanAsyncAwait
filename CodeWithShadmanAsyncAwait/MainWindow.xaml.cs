using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;


namespace CodeWithShadmanAsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    //Projeto criado para seguir os passos do artigo Async and Await In C# - Code with Shadman
    //Link para o site: https://codewithshadman.com/async-await-c/
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Ok_Click(object sender, RoutedEventArgs e)
        {
            var url = textBox.Text;
            var isValidurl = Uri.TryCreate(url, UriKind.Absolute, out _);
            if(!isValidurl)
            {
                txtStatus.Text = "Given url is not valid.";
                return;
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            try
            {
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                txtStatus.Text = data;
            }
            catch (Exception ex)
            {
                txtStatus.Text = ex.Message;
            }
        }
    }
}
