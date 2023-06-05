using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Globalization;
using System.Net.Http;
using TodoItemApp.Models;
using System.Net.Http.Headers;
using MahApps.Metro.Controls.Dialogs;
using System.Diagnostics;

namespace TodoItemApp
{

    public class DivCode
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private List<DivCode> divCodes = new List<DivCode>();
        HttpClient client = new HttpClient();
        TodoItemsCollection todoItems = new TodoItemsCollection();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            divCodes.Add(new DivCode { Key= "True", Value = "1"});
            divCodes.Add(new DivCode { Key = "False", Value = "0"});
            CboIsComplete.ItemsSource= divCodes;
            CboIsComplete.DisplayMemberPath = "Key";    // 콤보박스에 True/False 추가

            DtpTodoDate.Culture = new CultureInfo("ko-KR");

            // RestAPI 호출시작 // 이 아래 두 문장은 다시 호출하면 안됨
            client.BaseAddress = new Uri("https://localhost:7139/");    // RestAPI 서버 기본 URL
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            GetData();  // 데이터 로드 메서드 호출
        }

        // RestAPI Get Method 호출
        private async void GetData()
        {
            GrdTodoItems.ItemsSource = todoItems;   // 미리 바인딩
            try// API 호출
            {
                // https://localhost:7139/api/TodoItems
                HttpResponseMessage? response = await client.GetAsync("api/TodoItems");
                //var response = await client.GetAsync("api/TodoItems");
                response.EnsureSuccessStatusCode(); // 에러가 났으면 오류코드를 던진다. (예외발생)

                // 응답에서 List<TodoItem> 형식으로 읽어옴
                var items = await response.Content.ReadAsAsync<IEnumerable<TodoItem>>();
                todoItems.CopyFrom(items);
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                await(this.ShowMessageAsync("error", jEx.Message, MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true
                }));
            }
            catch (HttpRequestException ex)
            {
                await this.ShowMessageAsync("error", ex.Message, MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true,
                });
            }
        }

        private async void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var todoItem = new TodoItem()
                {
                    Id = 0,
                    Title = TxtTitle.Text,
                    TodoDate = ((DateTime)DtpTodoDate.SelectedDateTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    IsComplete = Int32.Parse((CboIsComplete.SelectedItem as DivCode).Value)
                };

                // Insert할때는 POST 메서드 사용
                var response = await client.PostAsJsonAsync("api/TodoItems", todoItem);
                response.EnsureSuccessStatusCode();

                GetData();

                TxtId.Text = TxtTitle.Text = string.Empty;
                CboIsComplete.SelectedIndex = -1;
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                await (this.ShowMessageAsync("error", jEx.Message, MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true
                }));
            }
            catch (HttpRequestException ex)
            {
                await this.ShowMessageAsync("error", ex.Message, MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true,
                });
            }
        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var todoItem = new TodoItem()
                {
                    Id = Int32.Parse(TxtId.Text),
                    Title = TxtTitle.Text,
                    TodoDate = ((DateTime)DtpTodoDate.SelectedDateTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    IsComplete = Int32.Parse((CboIsComplete.SelectedItem as DivCode).Value)

                };

                // Update할때는 Put 메서드 사용
                var response = await client.PutAsJsonAsync($"api/TodoItems/{todoItem.Id}", todoItem);
                response.EnsureSuccessStatusCode();

                GetData();

                TxtId.Text = TxtTitle.Text = string.Empty;
                CboIsComplete.SelectedIndex = -1;
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                await(this.ShowMessageAsync("error", jEx.Message, MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true
                }));
            }
            catch (HttpRequestException ex)
            {
                await this.ShowMessageAsync("error", ex.Message, MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true,
                });
            }
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Id = Int32.Parse(TxtId.Text);


                // Update할때는 Put 메서드 사용
                var response = await client.DeleteAsync($"api/TodoItems/{Id}");
                response.EnsureSuccessStatusCode();

                GetData();

                TxtId.Text = TxtTitle.Text = string.Empty;
                CboIsComplete.SelectedIndex = -1;
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                await(this.ShowMessageAsync("error", jEx.Message, MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true
                }));
            }
            catch (HttpRequestException ex)
            {
                await this.ShowMessageAsync("error", ex.Message, MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true,
                });
            }
        }

        private async void GrdTodoItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try // API 호출
            {
                var Id = ((TodoItem)GrdTodoItems.SelectedItem).Id;
                Debug.WriteLine(Id);
                // https://localhost:7139/api/TodoItems
                HttpResponseMessage? response = await client.GetAsync($"api/TodoItems/{Id}");
                //var response = await client.GetAsync("api/TodoItems");
                response.EnsureSuccessStatusCode(); // 에러가 났으면 오류코드를 던진다. (예외발생)

                // 응답에서 List<TodoItem> 형식으로 읽어옴
                var item = await response.Content.ReadAsAsync<TodoItem>();
                // Debug.WriteLine(item.Title);

                TxtId.Text = item.Id.ToString();
                TxtTitle.Text = item.Title;
                DtpTodoDate.SelectedDateTime = DateTime.Parse(item.TodoDate);
                CboIsComplete.SelectedIndex = item.IsComplete == 1 ? 0 : 1;
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                await(this.ShowMessageAsync("error", jEx.Message, MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true
                }));
            }
            catch (HttpRequestException ex)
            {
                await this.ShowMessageAsync("error", ex.Message, MessageDialogStyle.Affirmative, new MetroDialogSettings()
                {
                    AnimateShow = true,
                    AnimateHide = true,
                });
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"이외 오류 에러{ex.Message}");
            }
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            GetData();
        }
    }
}
