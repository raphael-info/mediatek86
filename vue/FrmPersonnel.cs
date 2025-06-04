using MediaTek86.dal;
using MediaTek86.modele;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MediaTek86.vue
{
    public class FrmPersonnel : Form
    {
        private DataGridView dgv;
        private List<Personnel> personnelList;
        private Button btnAjouter, btnModifier, btnSupprimer, btnAbsences;

        public FrmPersonnel()
        {
            this.Text = "Liste du personnel";
            this.Width = 700;
            this.Height = 500;

            dgv = new DataGridView()
            {
                Dock = DockStyle.Top,
                Height = 300,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            btnAjouter = new Button() { Text = "Ajouter", Left = 30, Top = 320, Width = 100 };
            btnModifier = new Button() { Text = "Modifier", Left = 150, Top = 320, Width = 100 };
            btnSupprimer = new Button() { Text = "Supprimer", Left = 270, Top = 320, Width = 100 };
            btnAbsences = new Button() { Text = "Absences", Left = 390, Top = 320, Width = 100 };

            btnAjouter.Click += BtnAjouter_Click;
            btnModifier.Click += BtnModifier_Click;
            btnSupprimer.Click += BtnSupprimer_Click;
            btnAbsences.Click += BtnAbsences_Click;

            this.Controls.Add(dgv);
            this.Controls.Add(btnAjouter);
            this.Controls.Add(btnModifier);
            this.Controls.Add(btnSupprimer);
            this.Controls.Add(btnAbsences);

            this.Load += FrmPersonnel_Load;
        }

        private void FrmPersonnel_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            personnelList = PersonnelDAL.GetAll();
            dgv.DataSource = null;
            dgv.DataSource = personnelList;
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            FrmAjoutPersonnel frm = new FrmAjoutPersonnel(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                Personnel selected = (Personnel)dgv.SelectedRows[0].DataBoundItem;
                FrmAjoutPersonnel frm = new FrmAjoutPersonnel(selected);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un personnel.");
            }
        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                Personnel selected = (Personnel)dgv.SelectedRows[0].DataBoundItem;
                DialogResult result = MessageBox.Show("Confirmer la suppression ?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    PersonnelDAL.Delete(selected.IdPersonnel);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un personnel.");
            }
        }

        private void BtnAbsences_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un personnel.");
                return;
            }

            Personnel personnel = (Personnel)dgv.SelectedRows[0].DataBoundItem;
            FrmAbsences frmAbsences = new FrmAbsences(personnel);
            frmAbsences.ShowDialog();
        }
    }
}
