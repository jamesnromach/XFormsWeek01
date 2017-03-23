//o Display the following line of text vertically centered and horizontally left aligned:
//    “This multi-line label contains red italic, yellow bold, and regular blue text.”
//o Put a line break after “label”, “italic,” and “bold,”.
//o Indent the first line. (Hint: Unicode for em space)
//o Make the text “red italic” both red and italic.Make it smaller than normal.
//o Make the text “yellow bold” both yellow and bold. Make it bigger than normal.
//o Make the text “blue” blue.
//o Make the entire label have a white background color, but be sure the background of the app remains black.
//o Format the text by creating a static method in your page that takes in a single string and returns a List<Span>.

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
            //
            // Set the desired label font size
            //
            var labelFontSize = 40;

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

            firstLayout.BackgroundColor = Color.White;

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
                    case "This":
                        {
                            element.ForegroundColor = Color.Black;
                            element.Text = "   " + element.Text;
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
                        element.ForegroundColor = Color.Black;
                        element.Text += "\n";
                        break;
                    }
                    default:
                    {
                        element.ForegroundColor = Color.Black;
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

            Label versionLabel = new Label
            {
                FormattedText = new FormattedString(),
                Text = version,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 40,
                TextColor = Color.Yellow,
                BackgroundColor = Color.Fuchsia,
                VerticalTextAlignment = TextAlignment.Center,
            };

            Content = new StackLayout
            {
                Padding = new Thickness(10),
                BackgroundColor = Color.Black,
                Children =
                {
                    versionLabel,
                    firstLayout
                }
            };
        }
    }
}
