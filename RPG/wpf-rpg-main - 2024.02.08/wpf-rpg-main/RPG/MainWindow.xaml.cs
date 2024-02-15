﻿using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RPG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CurrentMainWindow.Instance = this;
            //NavigateToEditingPage(CharacterHelper.GetDefaultCharacter());
            Main.LoadResources();
        }
        public void NavigateToEditingPage(Character character)
        {
            Frame.NavigationService.Navigate(new CharacterEditingPage(character));
        }

        private void ManageCharactersButton_Click(object sender, RoutedEventArgs e)
        {
            TitleLabel.Visibility = Visibility.Hidden;
            NewGameButton.Visibility = Visibility.Hidden;
            LoadGameButton.Visibility = Visibility.Hidden;
            ManageCharactersButton.Visibility = Visibility.Hidden;
            QuitButton.Visibility = Visibility.Hidden;

            CharacterListPage listPage;
            if (CurrentCharacterListPage.Instance != null)
            {
                listPage = CurrentCharacterListPage.Instance;

                listPage.AddCharacterButton.Visibility = Visibility.Visible;
                listPage.CharacterGrid.Visibility = Visibility.Visible;
                listPage.characterButtonPanel.Visibility = Visibility.Visible;
                listPage.BackButton.Visibility = Visibility.Visible;
            }
            else
            {
                listPage = new CharacterListPage();
            }
            Frame.NavigationService.Navigate(listPage);
        }

        private void QuitButton_MouseEnter(object sender, MouseEventArgs e) => QuitLabel.Foreground = new SolidColorBrush(Colors.Black);

        private void QuitButton_MouseLeave(object sender, MouseEventArgs e) => QuitLabel.Foreground = new SolidColorBrush(Colors.White);

        private void QuitButton_Click(object sender, RoutedEventArgs e) => Close();

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            var x = new ChooseToFight
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            x.Show();
            this.Close();
        }
    }

    public static class CurrentMainWindow
    {
        private static MainWindow? instance;

        public static MainWindow? Instance { get => instance; set => instance = value; }
    }
}