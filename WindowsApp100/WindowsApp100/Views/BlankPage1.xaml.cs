using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApp100.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        private void AppBarButton1_Click(object sender, RoutedEventArgs e) {

        } // end AppBarButton1_Click
        private void AppBarButton2_Click(object sender, RoutedEventArgs e) {

        } // end AppBarButton2_Click
        private void AppBarButton3_Click(object sender, RoutedEventArgs e) {

        } // end AppBarButton3_Click

        private async void AppBarButton_Delete(object sender, RoutedEventArgs e)
        {
            ContentDialog notifyDelete = new ContentDialog()
            {
                Title = "Confirm delete?",
                Content = "The item will be deleted",
                PrimaryButtonText = "Confirm Delete",
                SecondaryButtonText = "Cancel"

            };

            ContentDialogResult result = await notifyDelete.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                // Terms of use were accepted.
            }
            else
            {
                // User pressed Cancel or the back arrow.
                // Terms of use were not accepted.
            }

        } // end void

        private async void StartRecognizing_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of SpeechRecognizer.
            var speechRecognizer = new Windows.Media.SpeechRecognition.SpeechRecognizer();

            // Compile the dictation grammar by default.
            await speechRecognizer.CompileConstraintsAsync();

            // Start recognition.
            Windows.Media.SpeechRecognition.SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeWithUIAsync();
            ContentDialog notifyDelete = new ContentDialog()
            {
                Title = "Confirm delete?",
                Content = speechRecognitionResult.Text,
                PrimaryButtonText = "Save Note",
                SecondaryButtonText = "Cancel"

            };

            ContentDialogResult result = await notifyDelete.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                tbNote.Text = speechRecognitionResult.Text;
            }
            else
            {
                // User pressed Cancel or the back arrow.
                // Terms of use were not accepted.
            }
            // Do something with the recognition result.
            //var messageDialog = new Windows.UI.Popups.MessageDialog(speechRecognitionResult.Text, "Text spoken");
            //await messageDialog.ShowAsync();
        } // end StartRecognizing_Click


    } // end class
} // end namespace
