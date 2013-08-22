

using System;
using System.Collections.Generic;

namespace KladrAPIClientExample
{
    using KladrApiClient;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KladrClient kladrClient;
        public MainWindow()
        {
            InitializeComponent();
            kladrClient = new KladrClient("some_token", "some_key");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            kladrClient.FindAddress(new Dictionary<string, string>
                                        {
                                            {"query", "Арх"},
                                            {"contentType", "city"},
                                            {"withParent", "1"},
                                            {"limit", "2"}
                                        }, fetchedAddress);
        }

        private void fetchedAddress(KladrResponse response)
        {
            if(response!=null)
            {
                if (response.result != null && response.InfoMessage.Equals("OK"))
                    MessageBox.Show(string.Format("Found {0} results", response.result.Length));
            }
        }
    }
}
