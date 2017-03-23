////o Display the following line of text vertically centered and horizontally left aligned:
////  “This multi-line label contains red italic, yellow bold, and regular blue text.”
////o Indent the first line. (Hint: Unicode for em space)
////o Make the text “red italic” both red and italic.Make it smaller than normal.
////o Make the text “yellow bold” both yellow and bold. Make it bigger than normal.
////o Make the text “blue” blue.
////o Make the entire label have a white background color, but be sure the background of the app remains black.
////o Format the text by creating a static method in your page that takes in a single string and returns a List<Span>.

using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XFormsWeek01
{
    public class DeepIntoText : ContentPage
    {
        //
        // Set common items
        //
        string version = "Version 2017.03.23.1258\njames n romach";
        string layerTextString = @"This multi-line label contains red italic, yellow bold, and regular blue text.";
        FormattedString outputFormattedString = new FormattedString();


        //
        // Convert a string to a span list
        //
        List<Span> GetStringElements(string inputString)
        {
            List<Span> stringElements = new List<Span>();
            var  splitArray = inputString.Split(' ');
            foreach (string element in splitArray)
            {
                stringElements.Add(new Span() { Text = element });
            }
            return stringElements;
        }

        //
        // A page with different styles of text
        //
        public DeepIntoText()
        {
            var labelFontSize = 40; // Set the desired label font size

            //StackLayout spanLayout = new StackLayout { Padding = new Thickness(5, 10) };
            //Title = "Label Demo - Code";
            //spanLayout.Children.Add(new Label { TextColor = Color.FromHex("#77d065"), Text = "This is a green label." });
            //spanLayout.Children.Add(new Label { Text = "This is a default, non-customized label." });
            //spanLayout.Children.Add(new Label { Text = "This label has a font size of 30.", FontSize = 30 });
            //spanLayout.Children.Add(new Label { Text = "This is bold text.", FontAttributes = FontAttributes.Bold });
            //var fstring = new FormattedString();
            //fstring.Spans.Add(new Span { Text = "Red bold ", ForegroundColor = Color.Red, FontAttributes = FontAttributes.Bold });
            //fstring.Spans.Add(new Span { Text = "Default" });
            //fstring.Spans.Add(new Span { Text = "italic small", FontAttributes = FontAttributes.Italic, FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) });
            //spanLayout.Children.Add(new Label { FormattedText = fstring });
            ////this.Content = layout;


            //
            // Stack layout to hold the test label
            //
            StackLayout firstLayout = new StackLayout
            {
                Padding = new Thickness(10),
                BackgroundColor = Color.Green,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
            };

            //
            // Convert a string to a span list.
            // Each span is a substring split on a blank.
            //
            List<Span> substringList = GetStringElements(layerTextString);
            outputFormattedString.Spans.Add(new Span {Text = " "});
            var defaultFontSize = Device.GetNamedSize(NamedSize.Default, firstLayout);
            foreach (var element in substringList)
            {
                switch (element.Text)
                {
                    case "The":
                    {
                        element.Text = "\t" + element.Text;
                        break;
                    }
                    case "italic,":
                    case "red":
                    {
                        element.FontAttributes = FontAttributes.Bold;
                        element.FontAttributes = FontAttributes.Italic;
                        element.ForegroundColor = Color.Red;
                        element.FontSize = Device.GetNamedSize(NamedSize.Default, firstLayout) - (element.FontSize / 2);
                        if (element.Text == "italic,")
                        {
                            element.Text += "\n";
                        }
                        break;
                    }
                    case "yellow":
                    case "bold,":
                    {
                        element.ForegroundColor = Color.Yellow;
                        element.FontSize = Device.GetNamedSize(NamedSize.Default, firstLayout) + (element.FontSize / 2);
                        if (element.Text == "bold,")
                        {
                            element.Text += "\n";
                        }
                        break;
                    }
                    case "blue":
                    {
                        element.ForegroundColor = Color.Blue;
                        element.FontSize = Device.GetNamedSize(NamedSize.Default, firstLayout);
                        break;
                    }
                    case "label":
                    {
                        element.Text += "\n";
                        break;
                    }
                    default:
                    {
                        element.FontSize = Device.GetNamedSize(NamedSize.Default, firstLayout);
                        break;
                    }
                }

                element.Text += " ";
                element.FontSize += labelFontSize - Device.GetNamedSize(NamedSize.Default, firstLayout);
                outputFormattedString.Spans.Add(element);
            }

            firstLayout.Children.Add(new Label
            {
                FormattedText = outputFormattedString,
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
            });

            var x = 1; // breakpoint statement - garbage

            Content = new StackLayout
            {
                Padding = new Thickness(10),
                BackgroundColor = Color.Black,
                Children =
                {
                    new Label
                    {
                        FormattedText = new FormattedString(),
                        Text = version,
                        HorizontalTextAlignment = TextAlignment.Start,
                        FontSize = 40,
                        TextColor = Color.Yellow,
                        BackgroundColor = Color.Fuchsia,
                        VerticalTextAlignment = TextAlignment.Center,
                    },
                    firstLayout
                }
            };
        }
    }
}
