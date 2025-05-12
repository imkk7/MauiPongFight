using PongFight.Controls;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;
using Cell = PongFight.Models.Cell;

namespace PongFight
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            Game game = new Game(16, 16);
            Content = new Grid
            {
                RowDefinitions = Rows.Define(Star, Auto, Auto),
                Margin = 20,
                Children =
                {
                    new ViewBox
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        Children =
                        {
                            new CollectionView
                            {
                                ItemsSource = game.GameLogic(game.Initialize()),
                                ItemTemplate = new DataTemplate(() =>
                                {
                                    var rectangle = new BoxView
                                    {
                                        WidthRequest = 50,
                                        HeightRequest = 50
                                    };

                                    var ellipse = new Ellipse
                                    {
                                        WidthRequest = 50,
                                        HeightRequest = 50
                                    };

                                    var grid = new Grid
                                    {
                                        WidthRequest = 50,
                                        HeightRequest = 50,
                                        Children = { rectangle, ellipse },
                                        BackgroundColor = Colors.Red,
                                    };

                                    grid.BindingContextChanged += (s, e) =>
                                    {
                                        if (grid.BindingContext is Cell cell)
                                        {
                                            rectangle.BackgroundColor = CellColor(cell);
                                            ellipse.Fill = new SolidColorBrush(PlayerColor(cell));
                                            ellipse.IsVisible = cell.HasBall;
                                        }
                                    };


                                    return grid;
                                }),
                                ItemsLayout = new GridItemsLayout(ItemsLayoutOrientation.Vertical)
                                {
                                    Span = 16,
                                },
                                VerticalOptions = LayoutOptions.Center,
                                WidthRequest = 802,
                                HeightRequest = 802,
                            },
                        }
                    },
                    new Label()
                        .Text("Green 100 | Blue 100")
                        .CenterHorizontal()
                        .FontSize(24)
                        .Margin(10)
                        .Row(1),
                    new Slider
                    {
                        Maximum = 1000,
                        MaximumWidthRequest = 400,
                        Margin = 16,
#if __ANDROID__
                        Minimum = 100,
#else
                        Minimum = 10,
#endif
                        Value = 50,
                    }
                    .Row(2),
                }
            };
        }

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
        
    private readonly Color Blue = Color.FromRgba(27, 154, 249, 255);
    private readonly Color Green = Color.FromRgba(107, 227, 173, 255);

        public Color PlayerColor(Cell cell) => cell.Player == 0 ? Blue : Green;
        public Color CellColor(Cell cell) => cell.Player == 0 ? Green : Blue;
    }

}
