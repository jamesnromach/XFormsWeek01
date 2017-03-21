//o Display the following line of text vertically centered and horizontally left aligned:
//  “This multi-line label contains red italic, yellow bold, and regular blue text.”
//o Put a line break after “label”, “italic,” and “bold,”.
//o Indent the first line. (Hint: Unicode for em space)
//o Make the text “red italic” both red and italic.Make it smaller than normal.
//o Make the text “yellow bold” both yellow and bold. Make it bigger than normal.
//o Make the text “blue” blue.
//o Make the entire label have a white background color, but be sure the background of the app remains black.
//o Format the text by creating a static method in your page that takes in a single string and returns a List<Span>.

using Xamarin.Forms;

namespace XFormsWeek01
{
    public class DeepIntoText : ContentPage
    {
        string version = "Version 2017.03.20.1809\njames n romach";

        public DeepIntoText()
        {
            Content = new StackLayout
            {
                Padding = new Thickness(10), BackgroundColor = Color.Aqua,
                
                Children = {
                    new Label
                    {
                        Text = version + "This multi-line label contains red italic, yellow bold, and regular blue text.",
                                HorizontalTextAlignment = TextAlignment.End,
                                FontSize = 40,
                                TextColor = Color.Yellow,
                                BackgroundColor = Color.Fuchsia,
                                VerticalTextAlignment = TextAlignment.Center,
                                MinimumHeightRequest = 400
                    }
                }
            };
        }
    }
}
