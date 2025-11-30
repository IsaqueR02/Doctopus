using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Doctopus.Aplication.Data;
using Doctopus.Aplication.Views;


namespace Doctopus.Aplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CarregarPacientes();
        }

        private void BtnNovoPaciente_Click(object sender, RoutedEventArgs e)
        {
            var janelaCadastro = new CadastroPaciente();

            // ShowDialog pausa este código até a outra janela fechar
            janelaCadastro.ShowDialog();

            // Quando a janela de cadastro fecha, recarregamos a lista para ver o novo paciente
            CarregarPacientes();
        }

        private void CarregarPacientes()
        {
            using (var contexto = new AppDbContext())
            {
                var lista = contexto.Pacientes.ToList();

                // Joga a lista dentro do Grid
                GridPacientes.ItemsSource = lista;
            }
        }

        private void TxtBusca_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textoDigitado = txtBusca.Text.ToLower();

            using (var contexto = new AppDbContext())
            {
                var listaFiltrada = contexto.Pacientes
                                            .Where(p => p.NomeCompleto.ToLower().Contains(textoDigitado))
                                            .ToList();

                GridPacientes.ItemsSource = listaFiltrada;
            }
        }
        private void BtnAtender_Click(object sender, RoutedEventArgs e)
        {
            // Pega o item da linha clicada
            var pacienteSelecionado = ((FrameworkElement)sender).DataContext as Models.Paciente;

            if (pacienteSelecionado != null)
            {
                // 2. Criar a janela de Evolução PASSANDO o paciente
                var janelaEvolucao = new RegistroEvolucao(pacienteSelecionado);

                // 3. Mostrar a janela
                janelaEvolucao.ShowDialog();
            }
        }
        private void BtnEquipe_Click(object sender, RoutedEventArgs e)
        {
            var janelaProf = new CadastroProfissional();
            janelaProf.ShowDialog();
        }

        private void BtnHistorico_Click(object sender, RoutedEventArgs e)
        {
            var paciente = ((FrameworkElement)sender).DataContext as Models.Paciente;
            if (paciente != null)
            {
                // Abre a tela de gráficos passando o paciente selecionado
                var janela = new HistoricoPaciente(paciente);
                janela.Show(); // Show() permite deixar aberto enquanto mexe no resto, ShowDialog() bloqueia.
            }
        }


    }
}