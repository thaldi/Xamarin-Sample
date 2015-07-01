using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using natGeo_rss.model;
using System.Xml.Linq;

namespace natGeo_rss.pages
{
    public class FirstPage : ContentPage
    {
        ListView listview;

        public FirstPage()
        {
            SetContent();
        }

        private void SetContent()
        {
            var baseGrid = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.Maroon,
            };

            Image image = new Image
            {
                Source = ImageSource.FromUri(new Uri("http://famouslogos.net/images/national-geographic-logo.jpg")),
                HeightRequest = 150,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.Center,

            };

            Label text = new Label()
            {
                Text = "national geographic feeds",
                FontSize = 30,
                TextColor = Color.Navy,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            

            SetListView();

            baseGrid.Children.Add(image);
            baseGrid.Children.Add(listview);
            baseGrid.Children.Add(text);
            Content = baseGrid;
        }

        private async Task GetString()
        {
            try
            {
                var client = new HttpClient();

                var data = await client.GetStringAsync(new Uri("http://press.nationalgeographic.com/feed/"));

                var items = await ParseFeed(data);

                listview.ItemsSource = items.ToList();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Hata", ex.Message, "Tamam");
            }
        }

        private async Task<List<FeedItem>> ParseFeed(string data)
        {
            return await Task.Run(() =>
            {
                var doc = XDocument.Parse(data);
                var id = 0;

                return (from i in doc.Descendants("item")
                        select new FeedItem()
                        {
                            Title = (string)i.Element("title"),
                            Category = (string)i.Element("category"),
                            Link = (string)i.Element("link"),
                            PublishTime = (string)i.Element("pubDate"),
                            Description = (string)i.Element("description"),
                            ID = id++

                        }).ToList();
            });
        }

        private async void SetListView()
        {
            try
            {
                listview = new ListView()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    RowHeight = 75,
                };


                var template = new DataTemplate(typeof(TextCell));
                template.Bindings.Add(TextCell.TextProperty, new Binding("Description"));
                template.SetBinding(TextCell.TextProperty, new Binding("Link"));
                template.SetBinding(TextCell.TextProperty, new Binding("PublishTime"));
                template.SetBinding(TextCell.TextProperty, ("ID"));
                template.SetBinding(TextCell.TextProperty, ("Title"));
                template.SetBinding(TextCell.DetailProperty, new Binding("Category"));


                listview.ItemTemplate = template;

                await GetString();


                listview.ItemTapped += (sender, args) =>
                {
                    if (listview.SelectedItem != null)
                    {
                        var data = listview.SelectedItem as FeedItem;
                        Navigation.PushAsync(new DetailPage(data.Description,data.Link));
                    }
                };

            }
            catch (Exception ex)
            {
                await DisplayAlert("hata", ex.Message, "evet", "hayır");
            }
        }
    }
}
