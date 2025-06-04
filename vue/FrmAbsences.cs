using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.dal;
using MediaTek86.modele;

namespace MediaTek86.vue
{
    public partial class FrmAbsences : Form
    {
        private readonly Personnel personnel;
        private DataGridView dgvAbsences;
        private Button btnAjouter;
        private Button btnModifier;
        private Button btnSupprimer;

        public FrmAbsences(Personnel personnel)
        {
            this.personnel = personnel;
            InitializeComponent();
            AfficherAbsences();
        }

        private void InitializeComponent()
        {
            this.Text = "Liste des absences";
            this.Width = 700;
            this.Height = 400;

            dgvAbsences = new DataGridView
            {
                Left = 10,
                Top = 10,
                Width = 660,
                Height = 250,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            btnAjouter = new Button { Text = "Ajouter", Left = 50, Top = 300 };
            btnModifier = new Button { Text = "Modifier", Left = 150, Top = 300 };
            btnSupprimer = new Button { Text = "Supprimer", Left = 250, Top = 300 };

            btnAjouter.Click += BtnAjouter_Click;
            btnModifier.Click += BtnModifier_Click;
            btnSupprimer.Click += BtnSupprimer_Click;

            this.Controls.Add(dgvAbsences);
            this.Controls.Add(btnAjouter);
            this.Controls.Add(btnModifier);
            this.Controls.Add(btnSupprimer);
        }

        private void AfficherAbsences()
        {
            dgvAbsences.DataSource = AbsenceDAL.GetByPersonnel(personnel.IdPersonnel);
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FrmAbsence frmAjout = new FrmAbsence(personnel);
            frmAjout.ShowDialog();
            AfficherAbsences();
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.SelectedRows.Count > 0)
            {
                Absence absence = (Absence)dgvAbsences.SelectedRows[0].DataBoundItem;
                FrmAbsence frmModif = new FrmAbsence(personnel);
                frmModif.ShowDialog();
                AbsenceDAL.Update(absence, absence.DateDebut);
                AfficherAbsences();
            }
        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.SelectedRows.Count > 0)
            {
                Absence absence = (Absence)dgvAbsences.SelectedRows[0].DataBoundItem;
                AbsenceDAL.Delete(absence.IdPersonnel, absence.DateDebut);
                AfficherAbsences();
            }
        }
    }
}