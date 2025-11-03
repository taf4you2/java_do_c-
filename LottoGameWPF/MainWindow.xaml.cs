using System.Windows;
using LottoWPF.controller;

namespace LottoWPF
{
    /// <summary>
    /// Main window view for the Lotto game application
    /// Handles user interface and interaction
    /// </summary>
    /// <author>Wojciech Węglorz</author>
    /// <version>1.0</version>
    public partial class MainWindow : Window
    {
        private Controller controller;

        /// <summary>
        /// Initializes the main window and controller
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller(this);
        }

        /// <summary>
        /// Handles the generate button click event
        /// </summary>
        /// <param name="sender">Button that triggered the event</param>
        /// <param name="e">Event arguments</param>
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            string gameType = ((System.Windows.Controls.ComboBoxItem)GameTypeComboBox.SelectedItem)
                .Content.ToString().ToLower();
            controller.GenerateGame(gameType);
        }

        /// <summary>
        /// Displays the game results in the UI
        /// </summary>
        /// <param name="gameName">Name of the game</param>
        /// <param name="numbers">Generated numbers as string</param>
        public void DisplayResults(string gameName, string numbers)
        {
            ErrorTextBlock.Text = string.Empty;
            GameNameTextBlock.Text = gameName;
            NumbersTextBlock.Text = numbers;
        }

        /// <summary>
        /// Displays an error message in the UI
        /// </summary>
        /// <param name="message">Error message to display</param>
        public void DisplayError(string message)
        {
            GameNameTextBlock.Text = string.Empty;
            NumbersTextBlock.Text = string.Empty;
            ErrorTextBlock.Text = message;
        }
    }
}