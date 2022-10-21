using System.Windows.Input;
using Bitspace.Services;
using PropertyChanged;
using Xamarin.Forms;

namespace Bitspace.Features
{
    [AddINotifyPropertyChangedInterface]
    public class ConnectFourPageViewModel : BasePageViewModel
    {
        public ConnectFourPageViewModel(IBaseService baseService)
            : base(baseService)
        {
            InitializeBoard();
            PlacePieceCommand = new Command<int>(PlacePiece);
            CheckWinCommand = new Command(CheckWin);
        }

        public IBoard Board { get; set; }
        public ICommand PlacePieceCommand { get; set; }
        public ICommand CheckWinCommand { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public bool UpdateButtons { get; set; }
        private bool Player { get; set; }

        private void PlacePiece(int column)
        {
            AlertService.Snackbar("Piece placed!");
            var player = Player ? Piece.One : Piece.Two;
            Board.PlacePiece(player, column);
            UpdateButtons = !UpdateButtons;
            Player = !Player;
        }

        private void CheckWin()
        {
            var winner = Board.HasWin();
            if (winner != Piece.Empty)
            {
                AlertService.Snackbar($"{winner} is the winner!");
                return;
            }

            AlertService.Toast("No winner yet...");
        }

        private void InitializeBoard()
        {
            Columns = 7;
            Rows = 6;
            Board = new Board();
            Board.Setup(Rows, Columns);
        }
    }
}