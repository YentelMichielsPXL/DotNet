using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DominationGame
{
    public enum Player { Red, Blue, None }

    class Board
    {
        private Block[,] _blocks;

        public Board(int margin, int size, int row)
        {
            _blocks = new Block[row, row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    _blocks[i, j] = new Block(margin, size, i, j);
                }
            }
        }
        public void DisplayBoardOnCanvas(Canvas paperCanvas)
        {
            foreach (Block block in _blocks)
            {
                block.DisplayBlockOnCanvas(paperCanvas);
            }
        }

        public void ClaimBlocks(int row, int column, Player player)
        {
            if (_blocks[row, column].Owner != Player.None)
            {
                throw new DominationException("Block isn't free");
            }
            else if (player == Player.Red)
            {
                if (row +1 < _blocks.GetLength(0) &&   _blocks[row + 1, column].Owner == Player.None)
                {
                    _blocks[row, column].Owner = player;
                    _blocks[row + 1, column].Owner = player;
                }
                else
                {
                    throw new DominationException("Block under isn't free");
                }
            }
            else if (player == Player.Blue)
            {
                if (column +1 < _blocks.GetLength(1) && _blocks[row, column + 1].Owner == Player.None)
                {
                    _blocks[row, column].Owner = player;
                    _blocks[row, column + 1].Owner = player;
                }
                else
                {
                    throw new DominationException("Block right isn't free");
                }
            }
        }
        public bool hasMovesLeft(Player player)
        {
            if (player == Player.Red)
            {
                for (int j = 0; j < _blocks.GetLength(0); j++)
                {
                    for (int i = 0; i < _blocks.GetLength(1) - 1; i++)
                    {
                        if (_blocks[i, j].Owner == Player.None && _blocks[i,j+1].Owner==Player.None)
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(_blocks.GetLength(0));
                for (int i = 0; i < _blocks.GetLength(0); i++)
                {
                    for (int j = 0; j < _blocks.GetLength(1) - 1; j++)
                    {
                        if (_blocks[i, j].Owner == Player.None && _blocks[i,j+1].Owner == Player.None)
                        {
                            return true;
                        }
                    }
                }

            }
            return false;
        }

    }

}

