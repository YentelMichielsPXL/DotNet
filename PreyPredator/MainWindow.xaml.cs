using System.Windows;
using PreyPredator.Contracts;

namespace PreyPredator
{
    public partial class MainWindow : Window
    {
        private IAnimalWorld _insectWorld;
        public MainWindow()
        {
            InitializeComponent();

            _insectWorld = new AnimalWorld(paperCanvas);

            for (int i =0; i< 3; i++)
            {
                _insectWorld.AddAnimal(new Louse());
            }
            for (int i =0; i <3; i++)
            {
                _insectWorld.AddAnimal(new LadyBug());
            }

            DispalyStatistics();
        }

        private void nextRoundButton_Click(object sender, RoutedEventArgs e)
        {
            _insectWorld.ProcessRound();
            DispalyStatistics();
        }

        private void DispalyStatistics()
        {
            int ladyBugsCount = 0;
            int louseCount = 0;
            
            foreach( IAnimal animal in _insectWorld.Animals )
            {
                if (animal is Louse)
                {
                    louseCount++;
                }
                else
                {
                    ladyBugsCount++;
                }
            }
            roundLabel.Content = _insectWorld.CurrentRoundNumber;
            ladyBugLabel.Content = ladyBugsCount.ToString();
            louseLabel.Content = louseCount.ToString();
        }
    }
}