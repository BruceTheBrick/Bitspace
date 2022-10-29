using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.Controls;
using Bitspace.Core;
using Bitspace.Services;
using Prism.Navigation;
using PropertyChanged;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Bitspace.Features
{
    [AddINotifyPropertyChangedInterface]
    public class ConnectFourPageViewModel : BasePageViewModel
    {
        public ConnectFourPageViewModel(IBaseService baseService)
            : base(baseService)
        {
            InitializeBoard();
            PlacePieceCommand = new AsyncCommand<int>(PlacePiece);
        }

        public IBoard Board { get; set; }
        public ICommand PlacePieceCommand { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public bool UpdateButtons { get; set; }
        private bool Player { get; set; }

        private async Task PlacePiece(int column)
        {
            var player = Player ? Piece.One : Piece.Two;
            var winningPiece = Board.PlacePiece(player, column);
            if (winningPiece != Piece.Empty)
            {
                await DisplayWinnerBanner(winningPiece);
            }

            UpdateButtons = !UpdateButtons;
            Player = !Player;
        }

        private void InitializeBoard()
        {
            Columns = 7;
            Rows = 6;
            Board = new Board();
            Board.Setup(Rows, Columns);
        }

        private Task DisplayWinnerBanner(Piece winner)
        {
            var name = winner == Piece.One
                ? "Player one"
                : "Player two";
            var message = $"Congratulations {name}, you won!";
            var parameters = new NavigationParameters { { NavigationConstants.Message, message } };
            return NavigationService.NavigateAsync(nameof(SnackbarPopup), parameters);
        }
    }
}