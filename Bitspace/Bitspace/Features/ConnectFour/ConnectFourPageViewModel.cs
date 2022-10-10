using System.Diagnostics;
using Bitspace.Services;

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
        }
        
        public string BoardString { get; set; }
    }
}