using System;
using System.Windows;
using ViewModel;

namespace Lab_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        // # Properties
        public ThisViewActions ProvidedActions { get; set; }
        public ViewData ViewModel { get; set; }
        public bool IsMeasured { get; set; }
        public bool IsSplined { get; set; }

        // # MainWindow
        public MainWindow()
        {
            try
            {
                ProvidedActions = new();
                ViewModel = new(ProvidedActions);

                DataContext = this;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            InitializeComponent();

            // Combobox setup
            Func.ItemsSource = Enum.GetValues(typeof(Model.SPf));
        }

        // Commands
        private CommandBasic commandMeasure;
        public CommandBasic CommandMeasure
        {
            get
            {
                return commandMeasure ??
                    (commandMeasure = new CommandBasic(ViewModel.ActionMeasure, ViewModel.ActionMeasure_CanExecute));
            }
        }

        private CommandBasic commandSplines;
        public CommandBasic CommandSplines
        {
            get
            {
                return commandSplines ??
                    (commandSplines = new CommandBasic(ViewModel.ActionSplines, ViewModel.ActionSplines_CanExecute));
            }
        }
    }
}
