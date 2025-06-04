using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.modele;
using MediaTek86.dal;

namespace MediaTek86.vue
{
    public partial class FrmAbsence : Form
    {
        private readonly Personnel personnel;
        private ComboBox cbMotif;
        private DateTimePicker dtpDebut;
        private DateTimePicker dtpFin;
        private Button btnValider;

        public FrmAbsence(Personnel personnel)
        {
            this.personnel = personnel;
            InitializeComponent();
            LoadMotifs();
        }

        private void InitializeComponent()
        {
            this.Text = "Ajout d'une absence";
            this.Width = 400;
            this.Height = 250;

            Label lblDebut = new Label { Text = "Date début", Left = 20, Top = 20 };
            dtpDebut = new DateTimePicker { Left = 150, Top = 20, Width = 200 };

            Label lblFin = new Label { Text = "Date fin", Left = 20, Top = 60 };
            dtpFin = new DateTimePicker { Left = 150, Top = 60, Width = 200 };

            Label lblMotif = new Label { Text = "Motif", Left = 20, Top = 100 };
            cbMotif = new ComboBox { Left = 150, Top = 100, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            btnValider = new Button { Text = "Valider", Left = 150, Top = 150, Width = 100 };
            btnValider.Click += BtnValider_Click;

            this.Controls.Add(lblDebut);
            this.Controls.Add(dtpDebut);
            this.Controls.Add(lblFin);
            this.Controls.Add(dtpFin);
            this.Controls.Add(lblMotif);
            this.Controls.Add(cbMotif);
            this.Controls.Add(btnValider);
        }

        private void LoadMotifs()
        {
            List<Motif> motifs = MotifDAL.GetAll();
            cbMotif.DataSource = motifs;
            cbMotif.DisplayMember = "Libelle";
            cbMotif.ValueMember = "IdMotif";
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            DateTime debut = dtpDebut.Value;
            DateTime fin = dtpFin.Value;
            int idMotif = (int)cbMotif.SelectedValue;

            Absence absence = new Absence(personnel.IdPersonnel, debut, fin, idMotif);
            AbsenceDAL.Add(absence);

            MessageBox.Show("Absence ajoutée avec succès.");
            this.Close();
        }
    }
}