using System.Threading.Tasks;
using System.Windows.Input;
using Bitspace.Core;
using Bitspace.Resources;
using Humanizer;
using Prism.Navigation;
using PropertyChanged;
using Xamarin.Forms;

namespace Bitspace.Features
{
    public class ConnectFourPageViewModel : BasePageViewModel
    {
        public ConnectFourPageViewModel(IBaseService baseService, IConnectFourScoringService scoringService)
            : base(baseService)
        {
            Columns = 7;
            Rows = 6;
            Board = new Board(Rows, Columns);

            Martini = new ConnectFourEngine(scoringService);
            Martini.SetPlayer(Piece.TWO);

            PlacePieceCommand = new Command<int>(PlacePiece);
            UndoCommand = new Command(Undo);
            ResetCommand = new Command(Reset);
        }

        public ICommand PlacePieceCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand ResetCommand { get; }
        public IBoard Board { get; set; }
        public IConnectFourEngine Martini { get; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public bool UpdateButtons { get; set; }

        [AlsoNotifyFor(nameof(IsBoardEnabled))]
        public bool IsCpuBusy { get; set; }

        [AlsoNotifyFor(nameof(IsBoardEnabled))]
        public bool IsGameOver { get; set; }
        public bool IsBoardEnabled => !IsGameOver && !IsCpuBusy;
        public Piece Winner { get; set; }
        public string MartiniStatus => UpdateMartiniStatus();

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey(NavigationConstants.Reset))
            {
                Reset();
            }
        }

        private void PlacePiece(int column)
        {
            if (IsCpuBusy)
            {
                return;
            }

            MakeMove(column, Piece.ONE);
            if (IsGameOver)
            {
                _ = FinishGame();
                return;
            }

            IsCpuBusy = true;
            Task.Run(CpuMove);
        }

        private Task CpuMove()
        {
            var cpuMove = Martini.GetNextMove(Board, Piece.TWO);
            MakeMove(cpuMove, Piece.TWO);
            if (IsGameOver)
            {
                _ = FinishGame();
            }

            IsCpuBusy = false;
            return Task.CompletedTask;
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
            if (winningPiece.IsNotPlayerPiece())
            {
                return;
            }

            Winner = winningPiece;
            IsGameOver = true;
        }

        private Task FinishGame()
        {
            IsGameOver = true;
            var name = string.Format(ConnectFourRegister.CF_PLAYER, Winner.ToString().Humanize(LetterCasing.Title));
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

        private string UpdateMartiniStatus()
        {
            return IsCpuBusy
                ? string.Format(ConnectFourRegister.CF_ENGINE_BUSY, Martini.Name)
                : string.Format(ConnectFourRegister.CF_ENGINE_IDLE, Martini.Name);
        }
    }
}