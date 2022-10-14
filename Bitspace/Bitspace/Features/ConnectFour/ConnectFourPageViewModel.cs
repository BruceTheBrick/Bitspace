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
            Board = new Board();
            Board.Setup();
            BoardString = Board.ToString();
            ColumnIsFull = Board.ColumnIsFull(0) ? "True" : "False";

            Columns = 7;
            Rows = 6;
            PlacePieceCommand = new Command<int>(PlacePiece);
        }

        public IBoard Board { get; set; }
        public ICommand PlacePieceCommand { get; set; }
        public string BoardString { get; set; }
        public string ColumnIsFull { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public bool UpdateButtons { get; set; }

        private void PlacePiece(int column)
        {
            Board.PlacePiece(1, column);
            UpdateButtons = !UpdateButtons;
            BoardString = Board.ToString();
        }
    }
}