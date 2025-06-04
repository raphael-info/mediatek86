using MediaTek86.vue;
using System;
using System.Windows.Forms;

namespace MediaTek86.vue
{
    public class FrmAccueil : Form
    {
        public FrmAccueil()
        {
            this.Text = "Accueil - MediaTek86";
            this.Width = 400;
            this.Height = 300;

            Label lbl = new Label()
            {
                Text = "Bienvenue dans MediaTek86",
                AutoSize = true,
                Top = 40,
                Left = 100
            };

            Button btnPersonnel = new Button()
            {
                Text = "Gérer le personnel",
                Top = 100,
                Left = 100,
                Width = 180
            };
            btnPersonnel.Click += (s, e) =>
            {
                FrmPersonnel frm = new FrmPersonnel();
                frm.ShowDialog();
            };

            this.Controls.Add(lbl);
            this.Controls.Add(btnPersonnel);
        }
    }
}
