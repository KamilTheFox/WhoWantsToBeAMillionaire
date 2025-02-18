using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WhoWantsToBeAMillionaire
{
    public class AudienceHelper : IHelper
    {
        private GameForm gameForm;

        public AudienceHelper(GameForm game)
        {
            gameForm = game;
        }

        private Random random = new Random();
        private Button myButton;

        public Dictionary<string, int> GetAudienceVotes(string[] answers, string correctAnswer, int totalVotes = 100)
        {
            var votes = new Dictionary<string, int>();

            double correctWeight = 0.6;
            int correctVotes = (int)(totalVotes * correctWeight);
            int remainingVotes = totalVotes - correctVotes;

            foreach (string answer in answers)
            {
                if (answer == correctAnswer)
                    votes[answer] = correctVotes;
                else
                    votes[answer] = 0;
            }

            while (remainingVotes > 0)
            {
                string randomAnswer = answers[random.Next(answers.Length)];
                if (randomAnswer != correctAnswer)
                {
                    votes[randomAnswer]++;
                    remainingVotes--;
                }
            }

            return votes;
        }

        private void DrawVotesChart(Dictionary<string, int> votes)
        {
            var chart = new Chart();
            chart.Dock = DockStyle.Fill;

            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            var series = new Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Голоса зала"
            };

            foreach (var vote in votes)
            {
                series.Points.AddXY(vote.Key, vote.Value);
            }

            chart.Series.Add(series);
            chart.Palette = ChartColorPalette.Bright;

            chart.Titles.Add(new Title("Помощь зала"));
            chartArea.AxisX.Title = "Варианты ответов";
            chartArea.AxisY.Title = "Количество голосов";

            Form form = new Form();

            form.Controls.Add(chart);

            form.ShowDialog();

            chart.Click += (obj, e) => gameForm.Controls.Remove(chart);

            chart.Focus();
        }
        public void ActivateHelp()
        {
            myButton.Enabled = false;
            string[] answers = gameForm.currentQuest.Answers;
            string correctAnswer = gameForm.currentQuest.Answers[gameForm.currentQuest.RightAnswer-1];

            var votes = GetAudienceVotes(answers, correctAnswer);
            DrawVotesChart(votes);
        }

        public void Dispose()
        {
            myButton.Enabled = true;
        }

        public Button GetControl()
        {
            Button button = new Button()
            {
                Text = "Зал",
            };
            button.Click += (obj, e) => ActivateHelp();
            myButton = button;
            return button;
        }
    }
}
