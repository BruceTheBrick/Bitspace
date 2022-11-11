using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.Controls;
using Bitspace.Core;
using Bitspace.Services;
using Prism.Navigation;
using PropertyChanged;
using Xamarin.CommunityToolkit.ObjectModel;
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
            Martini = new ConnectFourEngine();
            Martini.Initialize(Piece.Two);
            PlacePieceCommand = new AsyncCommand<int>(PlacePiece);
            UndoCommand = new Command(Undo);
        }

        public ICommand PlacePieceCommand { get; }
        public ICommand UndoCommand { get; }
        public IBoard Board { get; set; }
        public IConnectFourEngine Martini { get; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public bool UpdateButtons { get; set; }
        public bool IsGameOver { get; set; }
        private bool Player { get; set; } = true;

        private async Task PlacePiece(int column)
        {
            await MakeMove(column, Piece.One);
            await MakeMove(Martini.GetNextMove(Board, Piece.Two), Piece.Two);
        }

        private void InitializeBoard()
        {
            Columns = 7;
            Rows = 6;
            Board = new Board();
            Board.Setup(Rows, Columns);
        }

        private void Undo()
        {
            Board.Undo();
            UpdateButtons = !UpdateButtons;
        }

        private async Task MakeMove(int column, Piece player)
        {
            var win = Board.PlacePiece(column, player);
            UpdateButtons = !UpdateButtons;
            if (win != Piece.Empty)
            {
                await FinishGame(win);
            }
        }

        private Task FinishGame(Piece winner)
        {
            IsGameOver = true;
            var name = winner == Piece.One
                ? "Player one"
                : "Player two";
            var message = $"Congratulations {name}, you won!";
            var parameters = new NavigationParameters { { NavigationConstants.Message, message } };
            return NavigationService.NavigateAsync(nameof(SnackbarPopup), parameters);
        }
    }
}