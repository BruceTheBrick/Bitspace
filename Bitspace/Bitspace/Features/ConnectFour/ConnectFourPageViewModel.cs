using System.Windows.Input;
using Bitspace.Services;
using Xamarin.Forms;

namespace Bitspace.Features
{
    public class ConnectFourPageViewModel : BasePageViewModel
    {
        private readonly IBoard _board;
        public ConnectFourPageViewModel(IBaseService baseService, IBoard board)
            : base(baseService)
        {
            _board = board;
            _board.Setup();
            BoardString = _board.ToString();
            ColumnIsFull = _board.ColumnIsFull(0) ? "True" : "False";
            PlacePieceCommand = new Command(PlacePiece);
        }

        public ICommand PlacePieceCommand { get; set; }
        public string BoardString { get; set; }
        public string ColumnIsFull { get; set; }

        private void PlacePiece()
        {
            _board.PlacePiece(1, 1);
            BoardString = _board.ToString();
        }
    }
}