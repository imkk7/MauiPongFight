using Microsoft.Maui.Controls;
using PongFight.Models;
using System.Linq;
using Cell = PongFight.Models.Cell;

namespace PongFight.Presentation;

public partial class GamePage : ContentPage
{
    private readonly Color Blue = Color.FromRgba(27, 154, 249, 255);
    private readonly Color Green = Color.FromRgba(107, 227, 173, 255);

    public GamePage(GameViewModel viewModel)
    {
        // Set the BindingContext to the GameViewModel
        BindingContext = viewModel;

        var grid = new Grid
        {
            Padding = 20,
            RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto }
            }
        };

        // Cell Grid (ItemsRepeater equivalent)
        var collectionView = new CollectionView
        {
            ItemsSource = viewModel.Cells,
            WidthRequest = 160,
            HeightRequest = 160,
            ItemsLayout = new GridItemsLayout(16, ItemsLayoutOrientation.Vertical),
            ItemTemplate = new DataTemplate(() =>
            {
                // Directly bind each cell to the template
                var cellTemplate = new ContentView();
                var cell = new Cell();  // This should be set dynamically from the CollectionView's ItemSource

                // Bind the cell data to the CellTemplate
                var gridCell = CellTemplate(cell);
                cellTemplate.Content = gridCell;

                return cellTemplate;
            })
        };

        grid.Children.Add(collectionView);

        // Score Label
        var scoreLabel = new Label
        {
            HorizontalOptions = LayoutOptions.Center,
            FontSize = 20,
            Margin = new Thickness(0, 10),
        };
        scoreLabel.SetBinding(Label.TextProperty, "Score");
        grid.Children.Add(scoreLabel);
        Grid.SetRow(scoreLabel, 1);

        // Speed Slider
        var speedSlider = new Slider
        {
            Minimum = DeviceInfo.Platform == DevicePlatform.Android ? 100 : 10,
            Maximum = 1000,
            WidthRequest = 400,
            Margin = new Thickness(16)
        };
        speedSlider.SetBinding(Slider.ValueProperty, new Binding("Speed", mode: BindingMode.TwoWay));
        grid.Children.Add(speedSlider);
        Grid.SetRow(speedSlider, 2);

        // Set the layout to the page
        Content = grid;
    }

    // PlayerColor function (converts Player to corresponding color)
    public Color PlayerColor(Cell cell) => cell.Player == 0 ? Blue : Green;

    // CellColor function (converts Player to corresponding cell color)
    public Color CellColor(Cell cell) => cell.Player == 0 ? Green : Blue;

    // CellTemplate function (to create a template for the cell UI)
    public View CellTemplate(Cell cell)
    {
        return new Grid
        {
            Children =
            {
                new Rectangle
                {
                    WidthRequest = 10,
                    HeightRequest = 10,
                    Fill = new SolidColorBrush(CellColor(cell))
                },
                new Ellipse
                {
                    WidthRequest = 10,
                    HeightRequest = 10,
                    Fill = new SolidColorBrush(PlayerColor(cell)),
                    IsVisible = cell.HasBall
                }
            }
        };
    }
}
