using System;
using System.Linq;
using System.Windows;
using Doctopus.Aplication.Data;
using Doctopus.Aplication.Models;

namespace Doctopus.Aplication.Views
{
    public partial class RegistroEvolucao : Window
    {
        private Paciente _pacienteAtual;
        public RegistroEvolucao(Paciente pacienteRecebido)
        {
            InitializeComponent();
            _pacienteAtual = pacienteRecebido;
            lblNomePaciente.Text = _pacienteAtual.NomeCompleto;
            dpData.SelectedDate = DateTime.Now;

            CarregarProfissionais();
        }
        private void CarregarProfissionais()
        {
            using (var context = new AppDbContext())
            {
                // Busca lista de profs para preencher o ComboBox
                var listaProfs = context.Profissionais.ToList();
                cbProfissional.ItemsSource = listaProfs;
            }
        }
        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (cbProfissional.SelectedValue == null || string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Selecione o profissional e escreva a descrição.", "Atenção");
                return;
            }

            try
            {
                using (var context = new AppDbContext())
                {
                    var novaEvolucao = new Evolucao
                    {
                        PacienteId = _pacienteAtual.Id,
                        // Convertemos o valor selecionado (SelectedValue) para int (ID)
                        ProfissionalId = (int)cbProfissional.SelectedValue,
                        DataAtendimento = dpData.SelectedDate.Value,
                        Descricao = txtDescricao.Text,
                        NotaParticipacao = (int)sliderNota.Value
                    };

                    context.Evolucoes.Add(novaEvolucao);
                    context.SaveChanges();
                }

                MessageBox.Show("Evolução registrada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}