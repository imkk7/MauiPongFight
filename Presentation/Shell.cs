//using Microsoft.Maui.Controls;

//namespace PongFight.Presentation;

//public partial class ShellPage : ContentPage
//{
//    public ShellPage()
//    {
//        // Initialize page content

//        var grid = new Grid
//        {
//            RowDefinitions =
//            {
//                new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
//                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
//            },
//            BackgroundColor = Colors.White // Set default background color
//        };

//        // Create a Frame to simulate the Border from Uno
//        var borderFrame = new Frame
//        {
//            BorderColor = Colors.Black,  // Adjust color if needed
//            BackgroundColor = Colors.Transparent,
//            Padding = new Thickness(0),
//            Margin = new Thickness(0)
//        };

//        // Add the Frame to the grid
//        grid.Children.Add(borderFrame);

//        // Create and configure the ProgressIndicator
//        var progressRing = new ActivityIndicator
//        {
//            IsRunning = true,
//            Color = Colors.Gray, // Adjust the color if needed
//            HeightRequest = 100,
//            WidthRequest = 100,
//            HorizontalOptions = LayoutOptions.Center,
//            VerticalOptions = LayoutOptions.Center
//        };

//        // Add the ActivityIndicator to the second row
//        grid.Children.Add(progressRing);

//        // Set the page content
//        Content = grid;
//    }
//}
