using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace natGeo_rss.pages
{
    public class DetailPage : ContentPage
    {
        public DetailPage(string value, string link)
        {
            SetContent(value, link);
        }

        private void SetContent(string desc, string link)
        {
            var desc_label = new Label()
            {
                Text = desc,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 20,
                TextColor = Color.White
            };

            Button btn = new Button()
            {
                BorderColor = Color.Transparent,
                BackgroundColor = Color.Transparent,
                Text = link,
                TextColor = Color.Lime,
                FontSize = 25,
            };

            btn.Clicked += (e, o) =>
            {
                if (Device.OS == TargetPlatform.WinPhone)
                {
                    Device.OpenUri(new Uri(btn.Text));
                }
                else
                {
                    DisplayAlert("Hata!", "AÇılamıyor", "Tamam");
                }
            };

            var label = new Label()
            {
                Text = "Detail Page",
                FontSize = 30,
                BackgroundColor = Color.Maroon,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            var layout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            layout.Children.Add(label);
            layout.Children.Add(desc_label);
            layout.Children.Add(btn);


            var baseGrid = new Grid()
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Padding = new Thickness(0, 0, 0, 30)
            };

            baseGrid.Children.Add(layout);
            Content = baseGrid;

        }
    }
}
