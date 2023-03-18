using System;
using System.Linq;
using System.Windows.Forms;

namespace PhRandom
{
    public partial class Editor : Form
    {
        private Action<string[]> _saveFunction;

        public Editor(Action<string[]> _saveFn, string[] items)
        {
            InitializeComponent();
            _saveFunction = _saveFn;
            TextBoxItems.Lines = items;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _saveFunction.Invoke(TextBoxItems.Lines.Where(item => !string.IsNullOrEmpty(item)).Distinct().ToArray());
            Close();
        }
    }
}
