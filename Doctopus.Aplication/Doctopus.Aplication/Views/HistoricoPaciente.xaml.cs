using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore; // IMPORTANTE: Necessário para usar o .Include()
using LiveCharts; // Para o gráfico
using LiveCharts.Wpf; // Para as linhas do gráfico
using Doctopus.Aplication.Data;
using Doctopus.Aplication.Models;
using System.Collections.Generic;

namespace Doctopus.Aplication.Views
{
    public partial class HistoricoPaciente : Window
    {
        public HistoricoPaciente(Paciente paciente)
        {
            InitializeComponent();
            lblTitulo.Text = $"Histórico Clínico: {paciente.NomeCompleto}";
            CarregarDados(paciente.Id);

        }
        private void CarregarDados(int pacienteId)
        {
            using (var context = new AppDbContext())
            {
                // 1. Buscar evoluções do banco com os dados do profissional junto
                var historico = context.Evolucoes
                                       .Include(e => e.Profissional) // O pulo do gato!
                                       .Where(e => e.PacienteId == pacienteId)
                                       .OrderBy(e => e.DataAtendimento) // Ordenar por data (antigo -> novo)
                                       .ToList();

                // 2. Preencher a Tabela (DataGrid) na parte de baixo
                // Inverto a ordem para mostrar o mais recente primeiro na lista
                GridHistorico.ItemsSource = historico.OrderByDescending(e => e.DataAtendimento);

                // 3. Preencher o Gráfico
                ConfigurarGrafico(historico);
            }
        }
        private void ConfigurarGrafico(List<Evolucao> dados)
        {
            // Se não tiver dados, não desenha nada
            if (dados.Count == 0) return;
            // Criar uma Linha no Gráfico
            var linha = new LineSeries
            {
                Title = "Participação",
                Values = new ChartValues<int>(), // Valores do eixo Y (Notas)
                PointGeometrySize = 15 // Tamanho da bolinha no gráfico
            };

            // Lista para guardar as datas (Eixo X)
            var datas = new List<string>();

            foreach (var item in dados)
            {
                linha.Values.Add(item.NotaParticipacao); // Adiciona a nota (1 a 5)
                datas.Add(item.DataAtendimento.ToString("dd/MM")); // Adiciona a data (Ex: 27/11)
            }

            // Adiciona a linha ao componente visual
            GraficoEvolucao.Series = new SeriesCollection { linha };

            // Define os textos do Eixo X
            EixoXDatas.Labels = datas;
        }
    }
}