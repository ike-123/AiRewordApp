using Google.GenAI;
using Google.GenAI.Types;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AiRewordApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			//string sentence = "The quick brown fox jumps over the lazy dog.";

			//ensure textbox is not empty before button click
			if (InputTextBox.Text != "")
			{



				string sentence = InputTextBox.Text;

				//reset textbox after button click
				InputTextBox.Text = "";

				//Disable button after click to prevent multiple clicks
				GenerateButton.IsEnabled = false;

				string ParaphrasedText = await GenerateGeminiContent(sentence);


				GenerateButton.IsEnabled = true;


				ParaphrasedTextBox.Text = ParaphrasedText;

			}


		}


		public async Task<string> GenerateGeminiContent(string text)
		{
			//Client gets API key from environment variable

			var client = new Client();

			var response = await client.Models.GenerateContentAsync(model: "gemini-2.5-flash", contents: $"Paraphrase the following sentence: {text}. Only paraphrase once");



			return response.Text;
		
		}
	}
}