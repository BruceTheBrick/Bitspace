using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.Core;
using Bitspace.Services;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Bitspace.Features
{
    public class ConnectFourPageViewModel : BasePageViewModel
    {
        public ConnectFourPageViewModel(IConnectFourEngine martini, IBaseService baseService)
            : base(baseService)
        {
            Columns = 7;
            Rows = 6;
            Board = new Board(Rows, Columns);

            Martini = martini;
            Martini.SetPlayer(Piece.TWO);

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
        public Piece Winner { get; set; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey(NavigationConstants.Reset))
            {
                Reset();
            }
        }

        private async Task PlacePiece(int column)
        {
            MakeMove(column, Piece.ONE);
            if (IsGameOver)
            {
                await FinishGame();
            }

            MakeMove(Martini.GetNextMove(Board, Piece.TWO), Piece.TWO);
            if (IsGameOver)
            {
                await FinishGame();
            }
        }

        private void MakeMove(int column, Piece player)
        {
            if (IsGameOver)
            {
                return;
            }

            Board.PlacePiece(column, player);
            var winningPiece = Board.HasWin();
            UpdateButtons = !UpdateButtons;
            if (winningPiece == Piece.INVALID || winningPiece == Piece.EMPTY)
            {
                return;
            }

            Winner = winningPiece;
            IsGameOver = true;
        }

        private Task FinishGame()
        {
            IsGameOver = true;
            var name = Winner == Piece.ONE
                ? "Player one"
                : "Player two";
            var parameters = new NavigationParameters { { NavigationConstants.Winner, name } };
            return NavigationService.NavigateAsync(nameof(GameOverPopupPage), parameters);
        }

        private void Reset()
        {
            Board.Reset();
            UpdateButtons = !UpdateButtons;
            IsGameOver = false;
        }

        private void Undo()
        {
            Board.Undo();
            UpdateButtons = !UpdateButtons;
        }
    }
}