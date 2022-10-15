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
        }

        public IBoard Board { get; set; }
        public ICommand PlacePieceCommand { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public bool UpdateButtons { get; set; }
        public bool Player { get; set; }


        private void PlacePiece(int column)
        {
            var player = Player ? 1 : 2;
            Board.PlacePiece(player, column);
            UpdateButtons = !UpdateButtons;
            Player = !Player;
        }

        private void InitializeBoard()
        {
            Columns = 4;
            Rows = 4;
            Board = new Board();
            Board.Setup(Rows, Columns);
        }
    }
}