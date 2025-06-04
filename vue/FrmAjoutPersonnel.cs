using MediaTek86.modele;
using MediaTek86.dal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MediaTek86.vue
{
    public class FrmAjoutPersonnel : Form
    {
        private TextBox txtNom, txtPrenom, txtTel, txtMail;
        private ComboBox cbService;
        private Button btnEnregistrer;

        private Personnel personnel;

        public FrmAjoutPersonnel(Personnel personnel)
        {
            this.personnel = personnel;
            this.Text = personnel == null ? "Ajout d'un personnel" : "Modification d'un personnel";
            this.Width = 400;
            this.Height = 300;

            Label lblNom = new Label { Text = "Nom", Left = 20, Top = 20 };
            txtNom = new TextBox { Left = 120, Top = 20, Width = 200 };

            Label lblPrenom = new Label { Text = "Prénom", Left = 20, Top = 60 };
            txtPrenom = new TextBox { Left = 120, Top = 60, Width = 200 };

            Label lblTel = new Label { Text = "Téléphone", Left = 20, Top = 100 };
            txtTel = new TextBox { Left = 120, Top = 100, Width = 200 };

            Label lblMail = new Label { Text = "Mail", Left = 20, Top = 140 };
            txtMail = new TextBox { Left = 120, Top = 140, Width = 200 };

            Label lblService = new Label { Text = "Service", Left = 20, Top = 180 };
            cbService = new ComboBox { Left = 120, Top = 180, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            btnEnregistrer = new Button { Text = "Enregistrer", Left = 120, Top = 220, Width = 200 };
            btnEnregistrer.Click += BtnEnregistrer_Click;

            this.Controls.AddRange(new Control[] { lblNom, txtNom, lblPrenom, txtPrenom, lblTel, txtTel, lblMail, txtMail, lblService, cbService, btnEnregistrer });

            LoadServices();

            if (personnel != null)
            {
                txtNom.Text = personnel.Nom;
                txtPrenom.Text = personnel.Prenom;
                txtTel.Text = personnel.Tel;
                txtMail.Text = personnel.Mail;
                cbService.SelectedValue = personnel.IdService;
            }
        }

        private void LoadServices()
        {
            List<Service> services = ServiceDAL.GetAll();
            cbService.DataSource = services;
            cbService.DisplayMember = "Nom";
            cbService.ValueMember = "IdService";
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string tel = txtTel.Text.Trim();
            string mail = txtMail.Text.Trim();
            int idservice = (int)cbService.SelectedValue;

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom))
            {
                MessageBox.Show("Nom et prénom obligatoires.");
                return;
            }

            if (personnel == null)
            {
                PersonnelDAL.Add(new Personnel(0, nom, prenom, tel, mail, idservice));
            }
            else
            {
                personnel.Nom = nom;
                personnel.Prenom = prenom;
                personnel.Tel = tel;
                personnel.Mail = mail;
                personnel.IdService = idservice;
                PersonnelDAL.Update(personnel);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
