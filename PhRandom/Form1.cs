using System;
using System.Linq;
using System.Windows.Forms;

namespace PhRandom
{
    public partial class Form1 : Form
    {
        #region Приватные методы

        private string _file = "params.data";
        private Random _rnd = new Random();
        private PhParameters ph;

        private static void FillCombo(ComboBox box, string[] items)
        {
            box.Items.Clear();
            box.Items.Add("");

            foreach (var item in items)
            {
                box.Items.Add(item);
            }
        }

        private void RefillCombos()
        {
            PhParameters.Save(_file, ph);
            FillCombo(MapCombo, ph.Maps.ToArray());
            FillCombo(DiffCombo, ph.Difficulty.ToArray());
            FillCombo(ChallengeCombo, ph.Challenge.ToArray());
        }

        private string[] GenerateValues(int count)
        {
            var map = MapCombo.Items.Cast<string>().Where(item => !string.IsNullOrEmpty(item)).ToArray();
            var diff = DiffCombo.Items.Cast<string>().Where(item => !string.IsNullOrEmpty(item)).ToArray();
            var chlg = ChallengeCombo.Items.Cast<string>().Where(item => !string.IsNullOrEmpty(item)).ToArray();
            var rFn = new Func<string, string[], string>((current, items) =>
            {
                if (current.Equals(""))
                {
                    if (items.Length > 0)
                    {
                        return items[_rnd.Next(0, items.Length)];
                    }
                    return "?";
                }
                return current;
            });

            var lines = Enumerable.Range(0, count)
                .Select(item => $"{rFn(MapCombo.Text, map)} ({rFn(DiffCombo.Text, diff)}) => {rFn(ChallengeCombo.Text, chlg)}")
                .ToArray();
            return lines;
        }

        #endregion

        private void EditFormOpen(string formTitle, ComboBox box, Action<string[]> act)
        {
            var itemsForEdit = box.Items.Cast<string>().Where(item => !string.IsNullOrEmpty(item)).ToArray();
            var result = new Editor(items => { act(items); RefillCombos(); }, itemsForEdit) { Text = formTitle }.ShowDialog();
        }

        public Form1() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            ph = PhParameters.Load(_file);
            RefillCombos();
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            RandomList.DataSource = GenerateValues(5);
        }

        private void MapChange_Click(object sender, EventArgs e)
        {
            EditFormOpen("Редактор карт", MapCombo, items => ph.Maps = items);
        }

        private void DiffChange_Click(object sender, EventArgs e)
        {
            EditFormOpen("Редактор уровней сложности", DiffCombo, items => ph.Difficulty = items);
        }

        private void ChaChange_Click(object sender, EventArgs e)
        {
            EditFormOpen("Редактор испытаний", ChallengeCombo, items => ph.Challenge = items);
        }
    }
}
