using System;
using Microsoft.Maui.Controls;

namespace MoedaApp
{
    public partial class MainPage : ContentPage
    {
        private Random random = new Random();
        private int acertos = 0;
        private int erros = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (EscolhaPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Escolha necessária", "Selecione 'Cara' ou 'Coroa' antes de lançar.", "OK");
                return;
            }

            string escolhaJogador = EscolhaPicker.SelectedItem.ToString().ToLower();

            // Animação visual de giro (trocando a imagem rapidamente)
            for (int i = 0; i < 10; i++)
            {
                MoedaImage.Source = (i % 2 == 0) ? "cara.png" : "coroa.png";
                await Task.Delay(80); // Velocidade do giro
            }

            // Sorteio real
            bool deuCara = random.Next(2) == 0;
            string resultado = deuCara ? "cara" : "coroa";

            MoedaImage.Source = deuCara ? "cara.png" : "coroa.png";
            Resultado.Text = $"Saiu: {(deuCara ? "Cara" : "Coroa")}";

            if (escolhaJogador == resultado)
                acertos++;
            else
                erros++;

            AtualizarEstatisticas();
        }

        private void AtualizarEstatisticas()
        {
            Estatisticas.Text = $"Acertos: {acertos} | Erros: {erros}";
        }
    }
}