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
        private readonly IConnectFourDifficultyService _difficultyService;
        public ConnectFourPageViewModel(IBaseService baseService, IConnectFourDifficultyService difficultyService)
            : base(baseService)
        {
            _difficultyService = difficultyService;

            SetupBoardAndEngine();

            PlacePieceCommand = new Command<int>(PlacePiece);
            UndoCommand = new Command(Undo);
            ResetCommand = new Command(Reset);
        }

        public ICommand PlacePieceCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand ResetCommand { get; }
        public IBoard Board { get; set; }
        public IConnectFourEngine Martini { get; set; }
        public int Columns { get; set; } = 7;
        public int Rows { get; set; } = 6;
        public bool UpdateButtons { get; set; }
        public bool IsCpuBusy { get; set; }
        public bool IsGameOver { get; set; }

        [DependsOn(nameof(IsCpuBusy), nameof(IsGameOver))]
        public bool IsBoardEnabled => !IsGameOver && !IsCpuBusy;
        public string MartiniStatus => UpdateMartiniStatus();
        public Piece HumanPiece { get; set; }
        public Piece CpuPiece { get; set; }
        public Piece Winner { get; set; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey(NavigationConstants.Reset))
            {
                Reset();
            }
        }

        private void SetupBoardAndEngine()
        {
            HumanPiece = Piece.One;
            CpuPiece = Piece.Two;

            Board = new Board(Rows, Columns);

            var scoringService = _difficultyService.GetScoringServiceFromDifficulty(Difficulty.Easy);
            Martini = new ConnectFourEngine(scoringService);
            Martini.SetPlayer(CpuPiece);
        }

        private void PlacePiece(int column)
        {
            if (IsCpuBusy)
            {
                return;
            }

            MakeMove(column, HumanPiece);
            if (IsGameOver)
            {
                _ = FinishGame();
                return;
            }

            IsCpuBusy = true;
            Task.Run(CpuMove);
        }

        private void MakeMove(int column, Piece player)
        {
            if (IsGameOver)
            {
                return;
            }

            Board.PlacePiece(column, player);
            var winningPiece = Board.GetWinner();
            UpdateButtons = !UpdateButtons;
            if (winningPiece.IsNotPlayerPiece())
            {
                return;
            }

            Winner = winningPiece;
            IsGameOver = true;
        }

        private Task CpuMove()
        {
            var cpuMove = Martini.GetNextMove(Board);
            MakeMove(cpuMove, CpuPiece);
            if (IsGameOver)
            {
                _ = FinishGame();
            }

            IsCpuBusy = false;
            return Task.CompletedTask;
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