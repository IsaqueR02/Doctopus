using Doctopus.Aplication.Data;
using Doctopus.Aplication.Models;
using System;
using System.Windows;

namespace Doctopus.Aplication.Views
{
    public partial class CadastroPaciente : Window
    {
        public CadastroPaciente()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            // 1. Validação Simples
            if (string.IsNullOrWhiteSpace(txtNome.Text) || dpNascimento.SelectedDate == null)
            {
                MessageBox.Show("Por favor, preencha pelo menos o Nome e a Data de Nascimento.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // 2. Conectar ao Banco
                using (var contexto = new AppDbContext())
                {
                    // 3. Criar o objeto Paciente com os dados da tela
                    var novoPaciente = new Paciente
                    {
                        NomeCompleto = txtNome.Text,
                        DataNascimento = dpNascimento.SelectedDate.Value,
                        NomeResponsavel = txtResponsavel.Text,
                        Diagnostico = txtDiagnostico.Text,
                        PlanoSaude = txtPlano.Text,
                        NumeroCarteirinha = txtCarteirinha.Text,
                        Interesses = txtInteresses.Text,
                        SensibilidadeSensorial = txtSensibilidade.Text
                    };

                    // 4. Adicionar e Salvar
                    contexto.Pacientes.Add(novoPaciente);
                    contexto.SaveChanges(); // Aqui o INSERT acontece no MySQL
                }

                MessageBox.Show("Paciente cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); // Fecha a janela após salvar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
