using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DomainPCL
{
    public class GameBoardModel : ViewModelBase
    {
        public const string Player1 = "X";
        public const string Player2 = "O";

        private GamePiece _piece00 = new GamePiece();
        private GamePiece _piece01 = new GamePiece();
        private GamePiece _piece02 = new GamePiece();
        private GamePiece _piece10 = new GamePiece();
        private GamePiece _piece11 = new GamePiece();
        private GamePiece _piece12 = new GamePiece();
        private GamePiece _piece20 = new GamePiece();
        private GamePiece _piece21 = new GamePiece();
        private GamePiece _piece22 = new GamePiece();
        private string _currentPlayer;
        private int _xWins;
        private int _yWins;
        private int _draws;
        private bool _isGameOver;

        public GamePiece Piece_0_0
        {
            get { return _piece00; }
            set
            {
                _piece00 = value;
                RaisePropertyChanged();
            }
        }
        public GamePiece Piece_0_1
        {
            get { return _piece01; }
            set
            {
                _piece01 = value;
                RaisePropertyChanged();
            }
        }
        public GamePiece Piece_0_2
        {
            get { return _piece02; }
            set
            {
                _piece02 = value;
                RaisePropertyChanged();
            }
        }
        public GamePiece Piece_1_0
        {
            get { return _piece10; }
            set
            {
                _piece10 = value;
                RaisePropertyChanged();
            }
        }
        public GamePiece Piece_1_1
        {
            get { return _piece11; }
            set
            {
                _piece11 = value;
                RaisePropertyChanged();
            }
        }
        public GamePiece Piece_1_2
        {
            get { return _piece12; }
            set
            {
                _piece12 = value;
                RaisePropertyChanged();
            }
        }

        public GamePiece Piece_2_0
        {
            get { return _piece20; }
            set
            {
                _piece20 = value;
                RaisePropertyChanged();
            }
        }
        public GamePiece Piece_2_1
        {
            get { return _piece21; }
            set
            {
                _piece21 = value;
                RaisePropertyChanged();
            }
        }
        public GamePiece Piece_2_2
        {
            get { return _piece22; }
            set
            {
                _piece22 = value;
                RaisePropertyChanged();
            }
        }

        public string CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
                _currentPlayer = value;
                RaisePropertyChanged();
            }
        }
        public int XWins
        {
            get { return _xWins; }
            set
            {
                _xWins = value; 
                RaisePropertyChanged();
            }
        }
        public int YWins
        {
            get { return _yWins; }
            set
            {
                _yWins = value; 
                RaisePropertyChanged();
            }
        }
        public int Draws
        {
            get { return _draws; }
            set
            {
                _draws = value;
                RaisePropertyChanged();
            }
        }
        public bool IsGameOver
        {
            get { return _isGameOver; }
            set
            {
                _isGameOver = value; 
                RaisePropertyChanged();
            }
        }

        public RelayCommand<GamePiece> SelectPieceCommand { get; private set; }
        public void SetRandomCurrentPlayer()
        {
            var random = new Random();
            CurrentPlayer = random.Next() % 2 > 0 ? Player1 : Player2;
        }

        public void SwitchCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
        }

        public GameBoardModel()
        {
            SetRandomCurrentPlayer();
            IsGameOver = false;
            XWins = 0;
            YWins = 0;
            Draws = 0;
            SelectPieceCommand = new RelayCommand<GamePiece>(SelectPiece);          
        }

        public void SelectPiece(GamePiece selected)
        {
            if (selected.Content == null)
            {
                selected.Content = CurrentPlayer;                
            }
            bool isDraw = false;
            if (GameOver(out isDraw))
            {
                EndGame(isDraw);
            }
            else
            {
                SwitchCurrentPlayer();
            }
        }

        public void EndGame(bool isDraw)
        {
            IsGameOver = false;
            //winnerTextBlock.Text = isDraw ? "Draw!" : CurrentPlayer + " Wins!";
            if (CurrentPlayer == Player1)
            {
                XWins++;
            }
            else if (CurrentPlayer == Player2)
            {
                YWins++;
            }
            else
            {
                Draws++;
            }
            LockGameControll();
        }

        private bool GameOver(out bool isDraw)
        {
            isDraw = false;
            var gameOver = false;
            if (CheckRows() || CheckColumns() || CheckDiags())
            {
                gameOver = true;
            }
            else if (IsDraw())
            {
                isDraw = true;
                gameOver = true;
            }
            return gameOver;
        }

        private bool CheckDiags()
        {
            return (
                Piece_0_0.Content != null && 
                Piece_1_1.Content != null && 
                Piece_2_2.Content != null &&
                Piece_0_0.Content == Piece_1_1.Content &&
                Piece_0_0.Content == Piece_2_2.Content) ||
                   (Piece_0_2.Content != null &&
                    Piece_1_1.Content != null &&
                    Piece_2_0.Content != null &&
                    Piece_0_2.Content == Piece_1_1.Content &&
                    Piece_0_2.Content == Piece_2_0.Content);
        }

        private bool CheckColumns()
        {
            return 
                (
                    Piece_0_0.Content != null && 
                    Piece_1_0.Content != null &&
                    Piece_2_0.Content != null &&
                    Piece_0_0.Content == Piece_1_0.Content &&
                    Piece_0_0.Content == Piece_2_0.Content) ||
                (Piece_0_1.Content != null && 
                 Piece_1_1.Content != null && 
                 Piece_2_1.Content != null &&
                 Piece_0_1.Content == Piece_1_1.Content &&
                 Piece_0_1.Content == Piece_2_1.Content) ||
                (Piece_0_2.Content != null &&
                 Piece_1_2.Content != null &&
                 Piece_2_2.Content != null &&
                 Piece_0_2.Content == Piece_1_2.Content &&
                 Piece_0_2.Content == Piece_2_2.Content);
        }

        private bool CheckRows()
        {
            return (
                Piece_0_0.Content != null && 
                Piece_0_1.Content != null && 
                Piece_0_2.Content != null &&
                Piece_0_0.Content == Piece_0_1.Content &&
                Piece_0_0.Content == Piece_0_2.Content) ||
                   (Piece_1_0.Content != null && 
                    Piece_1_1.Content != null && 
                    Piece_1_2.Content != null &&
                    Piece_1_0.Content == Piece_1_1.Content &&
                    Piece_1_0.Content == Piece_1_2.Content) ||
                   (Piece_2_0.Content != null && 
                    Piece_2_1.Content != null && 
                    Piece_2_2.Content != null &&
                    Piece_2_0.Content == Piece_2_1.Content &&
                    Piece_2_0.Content == Piece_2_2.Content);
        }

        private bool IsDraw()
        {
            return Piece_0_0.Content != null &&
                   Piece_0_1.Content != null &&
                   Piece_0_2.Content != null &&
                   Piece_1_0.Content != null &&
                   Piece_1_1.Content != null &&
                   Piece_1_2.Content != null &&
                   Piece_2_0.Content != null &&
                   Piece_2_1.Content != null &&
                   Piece_2_2.Content != null;

        }

        public void LockGameControll()
        {
            Piece_0_0.IsEnabled = false;
            Piece_0_1.IsEnabled = false;
            Piece_0_2.IsEnabled = false;
            Piece_1_0.IsEnabled = false;
            Piece_1_1.IsEnabled = false;
            Piece_1_2.IsEnabled = false;
            Piece_2_0.IsEnabled = false;
            Piece_2_1.IsEnabled = false;
            Piece_2_2.IsEnabled = false;
        }

        public void EnableGameControll()
        {
            Piece_0_0.IsEnabled = true;
            Piece_0_1.IsEnabled = true;
            Piece_0_2.IsEnabled = true;
            Piece_1_0.IsEnabled = true;
            Piece_1_1.IsEnabled = true;
            Piece_1_2.IsEnabled = true;
            Piece_2_0.IsEnabled = true;
            Piece_2_1.IsEnabled = true;
            Piece_2_2.IsEnabled = true;
        }

    }
}