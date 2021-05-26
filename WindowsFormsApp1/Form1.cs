using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class frmMotus : Form
    {
        // Defini la reponse
        string reponse;                
        int nbessai, nbessaimax = 7;

        //==============================================================================

        public frmMotus()
        {
            InitializeComponent();
        }

        //==============================================================================

        private void Form1_Load(object sender, EventArgs e)
        {

            // Fond des controls transparent
            labelTailleMot.BackColor = Color.Transparent;
            labelTailleMot.ForeColor = Color.White;

            // Desactive les éléments
            buttonValider.Enabled = false;
            textBoxChoix.Enabled = false;
            buttonAnnuler.Enabled = false;
            dataGridViewMotus.Visible = false;

            // Defini les specs du tableau
            dataGridViewMotus.ColumnHeadersVisible = false;
            dataGridViewMotus.Enabled = false;
            dataGridViewMotus.RowHeadersVisible = false;
            dataGridViewMotus.AllowUserToResizeColumns = false;
            dataGridViewMotus.AllowUserToResizeRows = false;
            dataGridViewMotus.ScrollBars = ScrollBars.None;
            dataGridViewMotus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        //==============================================================================
        
        private void textBoxChoix_TextChanged(object sender, EventArgs e)
        {
            // Converti en majuscule
            textBoxChoix.CharacterCasing = CharacterCasing.Upper;
            textBoxChoix.MaxLength = Convert.ToInt16(reponse.Length);
            // Test la taille
            if (textBoxChoix.Text.Length == reponse.Length)
            {
                buttonValider.Enabled = true;
            }
            else
            {
                buttonValider.Enabled = false;
            }


        }

        private void textBoxChoix_KeyDown(object sender, KeyEventArgs e)
        {
            // Efface les caracteres interdit
            if (((int)e.KeyCode >= 1 && (int)e.KeyCode <= 7)
            || ((int)e.KeyCode >= 9 && (int)e.KeyCode <= 36)
            || ((int)e.KeyCode >= 40 && (int)e.KeyCode <= 45)
            || ((int)e.KeyCode >= 47 && (int)e.KeyCode <= 64)
            || ((int)e.KeyCode == 38)
            || ((int)e.KeyCode > 90)
            )
            {
                e.SuppressKeyPress = true;
            }
           


        }

        //==============================================================================

        private void buttonTailleMotOuvrir_Click(object sender, EventArgs e)
        {
            // Recupere le fichier de mots
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFile.Text = fileDialog.FileName;
            }
            fileDialog.Dispose();
        }

        //==============================================================================

        private void buttonJouer_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBoxFile.Text))
            {
                MessageBox.Show("Aucune liste de mot n'a été sélectionner !", "Motus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Efface le tableau
            dataGridViewMotus.Rows.Clear();
            dataGridViewMotus.Columns.Clear();

            // Nombre de colonne
            string[] lines = File.ReadAllLines(textBoxFile.Text);
            Random random = new Random();
            reponse = lines[random.Next(0, lines.Count())].ToUpper();
            dataGridViewMotus.ColumnCount = reponse.Length;
            dataGridViewMotus.RowCount = 7;


            // Affiche le et déplace et resize tableau
            dataGridViewMotus.Visible = true;

            dataGridViewMotus.Left = 880 / 2 - reponse.Length * 40 / 2 - 8;
            dataGridViewMotus.Top = 110;

            dataGridViewMotus.Height = 7 * 40;
            dataGridViewMotus.Width = reponse.Length * 40;


            // Change la taille des colonnes
            for (int i = 0; i < dataGridViewMotus.ColumnCount; i++)
            {
                dataGridViewMotus.Columns[i].Width = 40;
            }
            // Change la taille des lignes
            for (int i = 0; i < dataGridViewMotus.RowCount; i++)
            {
                dataGridViewMotus.Rows[i].Height = 40;
            }

            // Debloque les controls
            textBoxChoix.Enabled = true;
            buttonAnnuler.Enabled = true;
            dataGridViewMotus.Visible = true;

            textBoxFile.Enabled = false;
            buttonTailleMotOuvrir.Enabled = false;
            buttonJouer.Enabled = false;

            // Efface ça
            textBoxChoix.Text = "";

            // Affiche le premier caractere
            dataGridViewMotus.Rows[0].Cells[0].Value = reponse[0];           
            // Init le nb d'essai
            nbessai = 0;
            for (int i = 0; i < 7; i++)
            {
                dataGridViewMotus.Rows[i].Cells[0].Value = reponse[0];
           
            }
            textBoxChoix.Text = Convert.ToString(reponse[0]);

            for (int i = 0; i < 7; i++)
            {
                dataGridViewMotus.Rows[i].Cells[0].Value = reponse[0];
            }
        }

        //==============================================================================

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //==============================================================================

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            // Cache le tableau
            dataGridViewMotus.Visible = false;

            // Bloque les controls
            buttonValider.Enabled = false;
            textBoxChoix.Enabled = false;
            buttonAnnuler.Enabled = false;
            dataGridViewMotus.Visible = false;

            textBoxFile.Enabled = true;
            buttonTailleMotOuvrir.Enabled = true;
            buttonJouer.Enabled = true;
        }

        //==============================================================================

        private void buttonValider_Click(object sender, EventArgs e)
        {
           
            String tmp = "";
            for (int i = 0; i < reponse.Length; i++)
            {
                dataGridViewMotus.Rows[nbessai].Cells[i].Value = textBoxChoix.Text[i];

                // Affiche en rouge si bon emplacement
                if (reponse[i] == textBoxChoix.Text[i])
                {
                    dataGridViewMotus.Rows[nbessai].Cells[i].Style.BackColor = Color.Red;
                    tmp += textBoxChoix.Text[i];
                }
                else
                {
                    // Verifi que la suite du mot ne contient pas le caractere (sinon le traiter plus tard), et que le caractere ne soit pas deja ajouter trop de fois
                    if ((!(reponse.Substring(i).Contains(textBoxChoix.Text[i]))) && ((tmp.Split(textBoxChoix.Text[i]).Length - 1) < (reponse.Split(textBoxChoix.Text[i]).Length - 1)))
                    {
                        dataGridViewMotus.Rows[nbessai].Cells[i].Style.BackColor = Color.Yellow;
                        tmp += textBoxChoix.Text[i];
                    }
                }
            }
           
            nbessai++;
            if ((nbessai == nbessaimax) || (reponse == textBoxChoix.Text))
            {
                // Affiche le message
                if (reponse == textBoxChoix.Text)
                {
                    MessageBox.Show("Vous avez gagné ! Le mot est bien : " + reponse + ".", "Motus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Vous avez perdu... Le mot est : " + reponse + ".", "Motus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Cache le tableau
                dataGridViewMotus.Visible = false;

                // Bloque les controls
                buttonValider.Enabled = false;
                textBoxChoix.Enabled = false;
                buttonAnnuler.Enabled = false;
                dataGridViewMotus.Visible = false;

                textBoxFile.Enabled = true;
                buttonTailleMotOuvrir.Enabled = true;
                buttonJouer.Enabled = true;
               
            }
           
            textBoxChoix.Text = "";
        }
       
        //==============================================================================
    }
}
