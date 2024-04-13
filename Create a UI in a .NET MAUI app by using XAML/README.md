# Create a UI in a .NET MAUI app by using XAML

## Difference between .NET MAUI XAML and Microsoft XAML

XAML is based on the Microsoft 2009 XAML specification. However, that specification defines only the language syntax. As with Windows Presentation Foundation (WPF), Universal Windows Platform (UWP), and WinUI 3, all of which use XAML, the elements you declare in the XAML will change.

XAML first appeared in 2006, with WPF. If you've been working with Microsoft XAML for a while, the XAML syntax should look familiar.

There are some key differences between the .NET MAUI flavor of XAML and XAML used by other UI tools. The structure and concepts are similar, but some of the names of the classes and properties are different.

## Create a UI by using .NET MAUI XAML

```
namespace MauiCode;

public partial class MainPage : ContentPage
{
    Button loginButton;
    VerticalStackLayout layout;

    public MainPage()
    {
        this.BackgroundColor = Color.FromArgb("512bdf");

        layout = new VerticalStackLayout
        {
            Margin = new Thickness(15, 15, 15, 15),
            Padding = new Thickness(30, 60, 30, 30),
            Children =
            {
                new Label { Text = "Please log in", FontSize = 30, TextColor = Color.FromRgb(255, 255, 100) },
                new Label { Text = "Username", TextColor = Color.FromRgb(255, 255, 255) },
                new Entry (),
                new Label { Text = "Password", TextColor = Color.FromRgb(255, 255, 255) },
                new Entry { IsPassword = true }
            }
        };

        loginButton = new Button { Text = "Login", BackgroundColor = Color.FromRgb(0, 148, 255) };
        layout.Children.Add(loginButton);

        Content = layout;

        loginButton.Clicked += (sender, e) =>
        {
            Debug.WriteLine("Clicked !");
        };
    }
}
```
