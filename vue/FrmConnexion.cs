using System;
using System.Windows.Forms;
using MediaTek86.bddmanager;
using MySql.Data.MySqlClient;

namespace MediaTek86.vue
{
    public class FrmConnexion : Form
    {
        private TextBox txtLogin;
        private TextBox txtMdp;
        private Button btnConnexion;

        public FrmConnexion()
        {
            this.Text = "Connexion";
            this.Width = 300;
            this.Height = 150;

            Label lblLogin = new Label { Text = "Login", Left = 20, Top = 10 };
            txtLogin = new TextBox { Left = 20, Top = 30, Width = 240 };

            Label lblMdp = new Label { Text = "Mot de passe", Left = 20, Top = 60 };
            txtMdp = new TextBox { Left = 20, Top = 80, Width = 240, PasswordChar = '*' };

            btnConnexion = new Button { Text = "Connexion", Left = 20, Top = 110, Width = 240 };
            btnConnexion.Click += BtnConnexion_Click;

            this.Controls.Add(lblLogin);
            this.Controls.Add(txtLogin);
            this.Controls.Add(lblMdp);
            this.Controls.Add(txtMdp);
            this.Controls.Add(btnConnexion);
        }

        private void BtnConnexion_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string mdp = txtMdp.Text.Trim();

            try
            {
                BddManager.OpenConnection();
                string query = "SELECT * FROM responsable WHERE login=@login AND pwd=SHA2(@pwd, 256)";
                MySqlCommand cmd = new MySqlCommand(query, BddManager.GetConnection());
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@pwd", mdp);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    BddManager.CloseConnection();
                    FrmAccueil accueil = new FrmAccueil();
                    accueil.Show();
                    this.Hide();
                }
                else
                {
                    reader.Close();
                    BddManager.CloseConnection();
                    MessageBox.Show("Login ou mot de passe incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
    }
}
