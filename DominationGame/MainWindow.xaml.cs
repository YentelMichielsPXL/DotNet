using System.Windows;
using System.Windows.Input;

namespace DominationGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player _currentPlayer;
        private int _sizeBlock;
        private int _margin = 5;
        private Board _board;
        private int _gridSize = 6;

        public MainWindow()
        {
            InitializeComponent();
            Random random = new Random();
            _currentPlayer = (Player)random.Next(2);
            playerTurnLabel.Content = $"The current player is: {_currentPlayer}";
            _sizeBlock = (int)((paperCanvas.Width - _margin * 2) / _gridSize);
            _board = new Board(_margin, _sizeBlock, _gridSize);
            _board.DisplayBoardOnCanvas(paperCanvas);

        }

        private void startGameMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void movesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exitMenuItem_click(object sender, RoutedEventArgs e)
        {

        }

        private void paperCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Point position = e.GetPosition(paperCanvas);
                int column = (int)((position.X - _margin) / _sizeBlock);
                int row = (int)((position.Y - _margin) / _sizeBlock);
                positionXLabel.Content = $"Position X: {(int)position.X}, row: ${row}";
                positionYLabel.Content = $"Position Y: {(int)position.Y}, column: ${column}";
                _board.ClaimBlocks(row,column, _currentPlayer);
                if (_board.hasMovesLeft(_currentPlayer))
                {
                    if (_currentPlayer == Player.Red)
                    {
                        _currentPlayer = Player.Blue;
                        playerTurnLabel.Content = $"The current player is: {_currentPlayer}";
                    }
                    else
                    {
                        _currentPlayer = Player.Red;
                        playerTurnLabel.Content = $"The current player is: {_currentPlayer}";
                    }
                }
                else
                {
                    MessageBox.Show($"{_currentPlayer} has lost the game!");
                    paperCanvas.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message );
            }

        }
    }
}