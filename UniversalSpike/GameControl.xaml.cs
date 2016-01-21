using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UniversalSpike
{
    public sealed partial class GameControl : UserControl
    {
        public const string Player1 = "X";
        public const string Player2 = "O";

        private string _currentPlayer;

        private string CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
                _currentPlayer = value;
                CurrentPlayerLabel.Text = _currentPlayer;
            }
        }

        public int XWins { get; set; }
        public int YWins { get; set; }
        public int Draws { get; set; }

        private bool IsGameOver { get; set; }
        public GameControl()
        {
            this.InitializeComponent();
            SetRandomCurrentPlayer();
            IsGameOver = false;
            XWins = 0;
            YWins = 0;
            Draws = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsGameOver)
            {
                return;
            }
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                if (clickedButton.Content == null)
                {
                    clickedButton.Content = CurrentPlayer;
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
        }
        
        private void SwitchCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
            CurrentPlayerLabel.Text = CurrentPlayer;
        }

        private void SetRandomCurrentPlayer()
        {
            var random = new Random();
            CurrentPlayer =  random.Next() % 2>0 ? Player1 : Player2;
        }

        private void EndGame(bool isDraw)
        {
            IsGameOver = false;
            winnerTextBlock.Text = isDraw ? "Draw!" : CurrentPlayer + " Wins!";
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
            FlyoutBase.ShowAttachedFlyout(this);
            LockGameControll();

        }

        public void LockGameControll()
        {
            Button_0_0.IsEnabled=false;
            Button_0_1.IsEnabled = false;
            Button_0_2.IsEnabled = false;
            Button_1_0.IsEnabled = false;
            Button_1_1.IsEnabled = false;
            Button_1_2.IsEnabled = false;
            Button_2_0.IsEnabled = false;
            Button_2_1.IsEnabled = false;
            Button_2_2.IsEnabled = false;
        }

        public void EnableGameControll()
        {
            Button_0_0.IsEnabled = true;
            Button_0_1.IsEnabled = true;
            Button_0_2.IsEnabled = true;
            Button_1_0.IsEnabled = true;
            Button_1_1.IsEnabled = true;
            Button_1_2.IsEnabled = true;
            Button_2_0.IsEnabled = true;
            Button_2_1.IsEnabled = true;
            Button_2_2.IsEnabled = true;
        }

        private bool GameOver(out bool isDraw)
        {
            isDraw = false;
            var gameOver = false;
            if (CheckRows() || CheckColumns() || CheckDiags())
            {                
                gameOver= true;
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
            return (Button_0_0.Content != null && Button_1_1.Content != null && Button_2_2.Content != null &&
                    Button_0_0.Content.ToString() == Button_1_1.Content.ToString() &&
                    Button_0_0.Content.ToString() == Button_2_2.Content.ToString()) ||
                    (Button_0_2.Content != null && Button_1_1.Content != null && Button_2_0.Content != null &&
                    Button_0_2.Content.ToString() == Button_1_1.Content.ToString() &&
                    Button_0_2.Content.ToString() == Button_2_0.Content.ToString());
        }

        private bool CheckColumns()
        {
            return (Button_0_0.Content != null && Button_1_0.Content != null && Button_2_0.Content != null &&
                    Button_0_0.Content.ToString() == Button_1_0.Content.ToString() &&
                    Button_0_0.Content.ToString() == Button_2_0.Content.ToString()) ||
                   (Button_0_1.Content != null && Button_1_1.Content != null && Button_2_1.Content != null &&
                    Button_0_1.Content.ToString() == Button_1_1.Content.ToString() &&
                    Button_0_1.Content.ToString() == Button_2_1.Content.ToString()) ||
                   (Button_0_2.Content != null && Button_1_2.Content != null && Button_2_2.Content != null &&
                    Button_0_2.Content.ToString() == Button_1_2.Content.ToString() &&
                    Button_0_2.Content.ToString() == Button_2_2.Content.ToString());
        }

        private bool CheckRows()
        {
            return (Button_0_0.Content != null && Button_0_1.Content != null && Button_0_2.Content != null &&
                    Button_0_0.Content.ToString() == Button_0_1.Content.ToString() &&
                    Button_0_0.Content.ToString() == Button_0_2.Content.ToString()) ||
                   (Button_1_0.Content != null && Button_1_1.Content != null && Button_1_2.Content != null &&
                    Button_1_0.Content.ToString() == Button_1_1.Content.ToString() &&
                    Button_1_0.Content.ToString() == Button_1_2.Content.ToString()) ||
                   (Button_2_0.Content != null && Button_2_1.Content != null && Button_2_2.Content != null &&
                    Button_2_0.Content.ToString() == Button_2_1.Content.ToString() &&
                    Button_2_0.Content.ToString() == Button_2_2.Content.ToString());
        }

        private bool IsDraw()
        {
            return Button_0_0.Content != null &&
                    Button_0_1.Content != null &&
                    Button_0_2.Content != null &&
                    Button_1_0.Content != null &&
                    Button_1_1.Content != null &&
                    Button_1_2.Content != null &&
                    Button_2_0.Content != null &&
                    Button_2_1.Content != null &&
                    Button_2_2.Content != null;

        }

        public void NewGame()
        {
            Button_0_0.Content = null;
            Button_0_1.Content = null;
            Button_0_2.Content = null;
            Button_1_0.Content = null;
            Button_1_1.Content = null;
            Button_1_2.Content = null;
            Button_2_0.Content = null;
            Button_2_1.Content = null;
            Button_2_2.Content = null;
            EnableGameControll();
        }
    }
}
