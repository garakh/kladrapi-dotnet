kladrapi-dotnet
===============

.Net Api Client Library для <a href="http://kladr-api.ru/integration/"><b>Кладр в облаке</b></a>

С  примером на WPF и CHM документацией.

<h2>Описание</h2>

Представляет собой DLL, которую можно подключить в References для осуществления поиска aдреса в <a href="http://kladr-api.ru/integration/">Кладр</a>.

<h2>Использование</h2>

* Скопировать <b>KladrApiClient.dll</b> и <b>Newtonsoft.Json.Net20.dll</b> в папку с Вашим проектом (или сделать свою сборку с помощью исходниклв в папке Sources)
* Добавить их в <b>References</b>
* Указать <b>using KladrApiClient;</b> в классе
* Создать объект класса <b>KladrClient</b>, указав Ваш <i>Token</i> или <i>Key<i>, если нужно
* Осуществить поиск с помощью метода <b>FindAddress</b>, которые принимает параметры запроса в формате <i>Dictionary</i>

Список возможных параметров:
* regionId – код родительского региона
* districtId – код района
* cityId – код города
* streetId – код улицы
* buildingId – код строения
* query – строка для поиска по названию
* contentType – тип объекта для поиска
* withParent – вернуть объекты вместе с родителями, если 1 то в каждый объект будет добавлено поле parents содержащее список объектов-родителей объекта
* limit – ограничение количества возвращаемых объектов, по умолчанию = 2000

<h2>Пример</h2>

<code>
    using KladrApiClient;
    using System;
    using System.Collections.Generic;
    using System.Windows;

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

</code>
