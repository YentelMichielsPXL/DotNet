using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DominationGame
{

    class Block
    {
        private Rectangle _rectangle;
        private Player _owner;

        public Block(int margin, int size, int row, int column)
        {
            _rectangle = new Rectangle()
            {
                Height = size,
                Width = size,
                Margin = new Thickness(margin + (size * column), margin + (size * row), 0, 0),
                Stroke = new SolidColorBrush(Colors.Black)
            };
            _owner = Player.None;

            
            
        }

        public Player Owner { get { return _owner; } set { _owner = value; 
                if (_owner == Player.Red)
                {
                    _rectangle.Fill = new SolidColorBrush(Colors.Red);
                }
                else if (_owner == Player.Blue)
                {
                    _rectangle.Fill = new SolidColorBrush(Colors.Blue);
                }
            } 
        }


        public void DisplayBlockOnCanvas(Canvas paperCanvas)
        {
            paperCanvas.Children.Add(_rectangle);
        }
    }
    

}
