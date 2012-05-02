using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BountyBanditsAnimationViewer
{
    public partial class UI : Form
    {
        private Game1 game;

        public UI(Game1 game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                game.loadController(openFileDialog1.FileName);
        }

        private void animCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            game.setAnimation( ((ComboBox)sender).Text );
        }
    }
}
