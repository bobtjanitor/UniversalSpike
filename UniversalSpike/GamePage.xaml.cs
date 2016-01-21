using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using Windows.Storage.Pickers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UniversalSpike
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        public GameControl Game { get; set; }
        public GamePage()
        {
            this.InitializeComponent();
            NewGame();
        }
        private void NewGame()
        {
            if (Game == null)
            {
                Game = new GameControl();
                Grid.SetRow(GameContainer, 0);
                Grid.SetColumn(GameContainer, 0);
                GameContainer.Children.Add(Game);
            }
            Game.NewGame();
           
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private async void ExportButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            var export = new ExcelExport();
            var fileData = await export.ExportWins(Game.XWins, Game.YWins);
            var picker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            picker.FileTypeChoices.Add("Excel", new List<string> { ".xlsx" });
            picker.DefaultFileExtension = ".xlsx";
            picker.SuggestedFileName = "winnnings";
            StorageFile file = await picker.PickSaveFileAsync();
            {
                await Windows.Storage.FileIO.WriteBytesAsync(file, fileData);
                //status.Text = "Your File Successfully Saved";
            }

        }

    }
}
