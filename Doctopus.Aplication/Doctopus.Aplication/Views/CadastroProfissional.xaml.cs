using System;
using System.Windows;
using System.Windows.Controls;
using Doctopus.Aplication.Data;
using Doctopus.Aplication.Models;

namespace Doctopus.Aplication.Views
{
    /// <summary>
    /// Interaction logic for CadastroProfissional.xaml
    /// </summary>
    public partial class CadastroProfissional : Window
    {
        public CadastroProfissional()
        {
            InitializeComponent();
        }

        private void BtnSalvarProfissional_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeProfissional.Text) || cbEspecialidade.SelectedItem == null)
            {
                MessageBox.Show("Preencha o Nome e a Especialidade.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var context = new AppDbContext())
                {
                    // Pegar a cor selecionada (Logica para extrair a Tag)
                    string corEscolhida = "#CCCCCC"; // Cor padrão cinza se nada for escolhido

                    if (cbCor.SelectedItem is ComboBoxItem itemSelecionado && itemSelecionado.Tag != null)
                    {
                        corEscolhida = itemSelecionado.Tag.ToString();
                    }

                    // Criar Objeto
                    var novoProf = new Profissional
                    {
                        NomeCompleto = txtNomeProfissional.Text,
                        Especialidade = cbEspecialidade.Text, // Pega o texto do item selecionado
                        RegistroProfissional = txtRegistro.Text,
                        CorIdentificacao = corEscolhida
                    };

                    // Salvar
                    context.Profissionais.Add(novoProf);
                    context.SaveChanges();
                }

                MessageBox.Show("Profissional adicionado à equipe!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }
    }
}

