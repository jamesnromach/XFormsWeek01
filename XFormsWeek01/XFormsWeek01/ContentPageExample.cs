using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFormsWeek01
{
    public class ContentPageExample : ContentPage
    {
        string version = "Version 2017.03.20.1044\njames n romach";
        StackLayout thirdLayout = new StackLayout();

        //
        // Elements
        //
        readonly Button firstButton = new Button
        {
            Text = "First Button",
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
            TextColor = Color.Blue,
            BorderRadius = 10,
            BorderWidth = 4,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.EndAndExpand,
        };

        public readonly Label largeLabel = new Label
        {
            Text = "Label",
            FontSize = 40,
            FontAttributes = FontAttributes.Bold,
            //FontFamily =red,
            BackgroundColor = Color.Aqua,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            Margin = 20,
            WidthRequest = 300,
            HorizontalTextAlignment = TextAlignment.End,
            TextColor = Color.Pink,
            FontFamily = "ArialBlack"
        };

        readonly Label smallLabel = new Label
        {
            Text = "This control is great for\n" +
                   "displaying one or more\n" +
                   "lines of text.",
            FontSize = 30,
            FontAttributes = FontAttributes.Bold,
            FontFamily = "ComicSans",
            BackgroundColor = Color.Orange,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            TextColor = Color.Red
        };

        readonly Entry username = new Entry
        {
            Placeholder = "enter your username",
            VerticalOptions = LayoutOptions.Start,
            Keyboard = Keyboard.Email
        };

        readonly Entry passWord = new Entry
        {
            Placeholder = "enter your Password",
            VerticalOptions = LayoutOptions.Start,
            IsPassword = true,
            Keyboard = Keyboard.Text
        };

        readonly BoxView firstBoxView = new BoxView
        {
            Color = Color.Silver,
            WidthRequest = 150,
            HeightRequest = 150,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            VerticalOptions = LayoutOptions.Fill,
        };

        Image firstImage = new Image
        {
            Source = "DeeplyOdd.png",
            Aspect = Aspect.AspectFit,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Fill,
            HeightRequest = 100,
        };


        //*********************************************************************
        //*********************************************************************
        //
        // Events
        //
        public void OnFirstButtonClicked(object sender, EventArgs e)
        {
            //firstButton.Text = "Got It";
            firstButton.Text = passWord.Text;
        }

        public void OnFirstButtonInFocus(object sender, EventArgs e)
        {
            firstBoxView.Margin = 20;
            firstBoxView.Color = Color.Aqua;
            firstBoxView.BackgroundColor = Color.Blue;
        }

        public void OnFirstBoxViewClicked(object sender, EventArgs e)
        {
            firstBoxView.Margin = 20;
            firstBoxView.Color = Color.Aqua;
            firstBoxView.BackgroundColor = Color.Blue;
        }

        public void OnFirstBoxViewInFocus(object sender, EventArgs e)
        {
            firstBoxView.Margin = 20;
            firstBoxView.Color = Color.Aqua;
            firstBoxView.BackgroundColor = Color.Blue;
        }

        
        public async void OnFirstImageTap(object sender, EventArgs e)
        {
            firstImage.Opacity = 1.5;
            //firstImage.BackgroundColor = Color.Red;
            firstImage.Rotation = 180;
            await Task.Delay(2000);
            firstImage.Rotation = 0;
        }


        StackLayout secondLayout = new StackLayout
        {
            Children =
            { 
            new Label
                { Text = "Second Layout", HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = 40,
                        TextColor = Color.Fuchsia,
                        VerticalTextAlignment = TextAlignment.End,
                        MinimumHeightRequest = 400
                }
            }
        };
        


        //*********************************************************************
        //*********************************************************************
        //
        // Content Page
        //
        public ContentPageExample()
        {
            //firstButton.Clicked += (sender, args) => {firstButton.Text = "Got It";};
            firstButton.Clicked += OnFirstButtonClicked;
            firstButton.Focused += OnFirstButtonInFocus;
            firstBoxView.Focused += OnFirstBoxViewInFocus;
            
            var tapGestureRecognizer = new TapGestureRecognizer();
            firstImage.GestureRecognizers.Add(tapGestureRecognizer);
            tapGestureRecognizer.Tapped += OnFirstImageTap;

            BackgroundColor = Color.Yellow;


            Content = new StackLayout
            {
                Padding = new Thickness(20, 20, 20, 20),    // around outside
                Margin = new Thickness(50,50,50,50),        // around control
                Children =
                {
                    new Label { Text = version, HorizontalTextAlignment = TextAlignment.Center,
                                FontSize = 40,
                                TextColor = Color.Purple,
                                VerticalTextAlignment = TextAlignment.End,
                                MinimumHeightRequest = 400},
                    largeLabel,
                    firstImage,
                    smallLabel,
                    firstBoxView,
                    username,
                    passWord,
                    firstButton,
                    secondLayout
                },

                HeightRequest = 1000,
                BackgroundColor = Color.Lime
            };


            ScrollView firstScrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = Content
            };

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            Content = firstScrollView;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
