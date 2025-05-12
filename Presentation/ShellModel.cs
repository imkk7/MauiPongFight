//using System.Threading.Tasks;
//using Microsoft.Maui.Controls;

//namespace PongFight.Presentation
//{
//    public class ShellModel
//    {
//        private readonly INavigator _navigator;

//        public ShellModel(INavigator navigator)
//        {
//            _navigator = navigator;
//            _ = Start();
//        }

//        public async Task Start()
//        {
//            // Assuming _navigator.NavigateViewModelAsync navigates to a page corresponding to GameModel.
//            // MAUI doesn't have a direct ViewModel-based navigation, so we'd use a Page instead.

//            // For navigation, you might use Shell navigation or normal page navigation:
//            // Example with Shell navigation:
//            await Shell.Current.GoToAsync(nameof(GamePage));

//            // If you are using normal navigation:
//            // await Application.Current.MainPage.Navigation.PushAsync(new GamePage());
//        }
//    }
//}
