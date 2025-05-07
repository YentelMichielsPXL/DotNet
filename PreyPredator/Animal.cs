using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PreyPredator.Contracts;


namespace PreyPredator
{
    internal abstract class Animal : IAnimal
    {
        private static Random _randomGenerator = new Random();

        protected int _age;
        protected int _maxAge;
        protected Ellipse _ellipse;
        protected Canvas _canvas;

        public Position position { get; set; }
        public Color color { get; set; }
        public bool IsDead()
        {
            if (_age >= _maxAge)
            {
                return true;
            }
            return false;
        }

        public abstract IAnimal TryBreed();

        protected Animal(int maxAge, Color color)

            : this(maxAge,color, new Position(_randomGenerator.Next(20), _randomGenerator.Next(20))) { }
       
        protected Animal(int maxAge,Color color, Position position)
        {
            _maxAge = maxAge;
            this.color = color;
            this.position = position;
            _age = 0;
            
        }
        public void DisplayOn(Canvas canvas)
        {
            _canvas = canvas;
            _ellipse = new Ellipse
            {
                Width = 5,
                Height = 5,
                Fill = new SolidColorBrush(color),
            };
            canvas.Children.Add(_ellipse);
            UpdateDisplay();
        }
        public void UpdateDisplay()
        {
             if (_ellipse != null)
            {
                Canvas.SetLeft(_ellipse, position.X * 10);
                Canvas.SetTop(_ellipse, position.Y * 10);
            }
        }
        public void StopDisplaying()
        {
            if (_canvas != null && _ellipse != null) {
                _canvas.Children.Remove(_ellipse);
            } 
        }
        public void Move()
        {
            _age++;
            if (IsDead())
            {
                StopDisplaying();
                return;
            }
            int direction = _randomGenerator.Next(4);
            switch (direction)
            {
                case 0: position.MoveUp(); break;
                case 1: position.MoveDown(); break;
                case 2: position.MoveLeft(); break;
                case 3: position.MoveRight(); break;
            }
        }

    }
}
