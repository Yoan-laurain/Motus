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
        //==============================================================================

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
            labelTailleMot.BackColor = Color.Transparent;
            labelTailleMot.ForeColor = Color.White;

            textBoxFile.Text = "..\\..\\..\\mots8.txt";

            // Desactive les éléments//

            buttonValider.Enabled = false;
            textBoxChoix.Enabled = false;
            buttonAnnuler.Enabled = false;
            dataGridViewMotus.Visible = false;

            // Defini les paramètres du tableau//

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
            //Convertion des entrées en majuscules//

            textBoxChoix.CharacterCasing = CharacterCasing.Upper;
            textBoxChoix.MaxLength = Convert.ToInt16(reponse.Length);

            //Verification de la taille du mot entrée//

            if (textBoxChoix.Text.Length == reponse.Length)
            {
                buttonValider.Enabled = true;
            }
            else
            {
                buttonValider.Enabled = false;
            }
        }

        //==============================================================================

        //==============================================================================

        private void textBoxChoix_KeyDown(object sender, KeyEventArgs e)
        {
            // Efface les caracteres interdit//

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

        //==============================================================================

        private void buttonTailleMotOuvrir_Click(object sender, EventArgs e)
        {
            // Recupère le fichier de mots// 

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

        //==============================================================================

        private void buttonJouer_Click(object sender, EventArgs e)
        {
            //Si le fichier n'existe pas //

            if (!File.Exists(textBoxFile.Text))
            {
                MessageBox.Show("Aucune liste de mot n'a été sélectionner !", "Motus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Efface le tableau//

            dataGridViewMotus.Rows.Clear();
            dataGridViewMotus.Columns.Clear();

            //Récup les lignes du fichier//

            string[] lines = File.ReadAllLines(textBoxFile.Text);

            /*Prend un nombre aléatoire compris entre le nombre de lignes du fichier pour récupération d'un 
             * mot puis mise en majuscule et en fin affectation de la longueur du tableau en proportion de 
             * la longueur du mot */

            Random random = new Random();
            reponse = lines[random.Next(0, lines.Count())].ToUpper();
            dataGridViewMotus.ColumnCount = reponse.Length;

            //Paramètres du tableau//

            dataGridViewMotus.RowCount = 7;
            dataGridViewMotus.Visible = true;
            dataGridViewMotus.Left = 880 / 2 - reponse.Length * 40 / 2 - 8;
            dataGridViewMotus.Top = 110;
            dataGridViewMotus.Height = 7 * 40;
            dataGridViewMotus.Width = reponse.Length * 40;

            //Change la taille des colonnes//

            for (int i = 0; i < dataGridViewMotus.ColumnCount; i++)
            {
                dataGridViewMotus.Columns[i].Width = 40;
            }

            //Change la taille des lignes//

            for (int i = 0; i < dataGridViewMotus.RowCount; i++)
            {
                dataGridViewMotus.Rows[i].Height = 40;
            }

            //Debloque les controles//

            textBoxChoix.Enabled = true;
            buttonAnnuler.Enabled = true;
            dataGridViewMotus.Visible = true;

            textBoxFile.Enabled = false;
            buttonTailleMotOuvrir.Enabled = false;
            buttonJouer.Enabled = false;

            textBoxChoix.Text = "";

            //Affiche le premier caractère//

            dataGridViewMotus.Rows[0].Cells[0].Value = reponse[0];     
            
            nbessai = 0;

            //Affiche le premier caractère sur toutes les lignes//

            for (int i = 0; i < 7; i++)
            {
                dataGridViewMotus.Rows[i].Cells[0].Value = reponse[0];
            }

            //Ecrit la première lettre dans la proposition//

            textBoxChoix.Text = Convert.ToString(reponse[0]);
        }

        //==============================================================================

        //==============================================================================

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //==============================================================================

        //==============================================================================

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            dataGridViewMotus.Visible = false;
            buttonValider.Enabled = false;
            textBoxChoix.Enabled = false;
            buttonAnnuler.Enabled = false;
            dataGridViewMotus.Visible = false;

            textBoxFile.Enabled = true;
            buttonTailleMotOuvrir.Enabled = true;
            buttonJouer.Enabled = true;
        }

        //==============================================================================

        //==============================================================================

        private void buttonValider_Click(object sender, EventArgs e)
        {
            //Variables contenant toutes les lettres jaunes trouver//

            String LettreJaune = "";
            String LettreRouge = "";

            //Parcours de la réponse pour les lettres rouges//

            for (int i = 0; i < reponse.Length; i++)
            {
                //Remplie le dgv avec les valeurs du mot essayé//

                dataGridViewMotus.Rows[nbessai].Cells[i].Value = textBoxChoix.Text[i];

                // Affiche en rouge si bon emplacement//

                if (reponse[i] == textBoxChoix.Text[i])
                {
                    dataGridViewMotus.Rows[nbessai].Cells[i].Style.BackColor = Color.Red;
                    LettreRouge += textBoxChoix.Text[i];
                    LettreJaune += textBoxChoix.Text[i];
                }       
            }

            //Parcours de la réponse pour les lettres Jaunes//

            for (int i=1; i<reponse.Length; i++)
            {
                //Si la lettre actuel est contenue dans les lettres rouges 

                if(LettreRouge.Contains(textBoxChoix.Text[i]))
                {
                    if (NbFoisLettreDansMot(reponse, textBoxChoix.Text[i]) > NbFoisLettreDansMot(LettreJaune, textBoxChoix.Text[i]))
                    {
                        if(dataGridViewMotus.Rows[nbessai].Cells[i].Style.BackColor != Color.Red)
                        {
                            dataGridViewMotus.Rows[nbessai].Cells[i].Style.BackColor = Color.Yellow;
                            LettreJaune += textBoxChoix.Text[i];
                        }
                    }
                }
                else
                {
                    //Si la lettre actuel est dejà contenue dans les lettres jaunes

                    if(LettreJaune.Contains(textBoxChoix.Text[i]))
                    {
                        //Verfie que il y ait d'autre occurence de la même lettre qui ne soit pas encore jaune
                        /*
                         * Exemple : Reponse : Bannanes Mot proposé : Bastilla-> Si le premier A est dejà jaune et que on est sur le 2 ème A
                         * On verifie que dans la réponse il y est un 2ème A pas déja jaune 
                         * Ducoup si oui -> jaune Sinon -> Sa veut dire que la lettre en cours est déja jaune autre part mais n'apparait
                         * une autre fois dans le mot donc on ne l'a met pas en jaune
                         */
                        if (NbFoisLettreDansMot(reponse, textBoxChoix.Text[i]) > NbFoisLettreDansMot(LettreJaune, textBoxChoix.Text[i]))
                        {
                            dataGridViewMotus.Rows[nbessai].Cells[i].Style.BackColor = Color.Yellow;
                            LettreJaune += textBoxChoix.Text[i];

                            MessageBox.Show("La lettre : " + textBoxChoix.Text[i] + "est : " + NbFoisLettreDansMot(reponse, textBoxChoix.Text[i]) + " dans la réponse ");
                            MessageBox.Show("La lettre : " + textBoxChoix.Text[i] + "est : " + NbFoisLettreDansMot(LettreJaune, textBoxChoix.Text[i]) + " dans les lettres jaunes ");
                        }
                    }
                    else
                    {
                        //Parcours le mot entier pour trouver d'autres correspondances//

                        for (int t = 0; t < reponse.Length; t++)
                        {
                            //Si la lettre actuel se situe sur une autre case//

                            if (textBoxChoix.Text[i] == reponse[t])
                            {
                                //Passe la cellule en jaune//

                                dataGridViewMotus.Rows[nbessai].Cells[i].Style.BackColor = Color.Yellow;

                                //Pour arretter la boucle//

                                t = reponse.Length;

                                //Ajout de la lettre à la liste de lettre jaunes//

                                LettreJaune += textBoxChoix.Text[i];
                            }
                        }
                    }
                }
            }

            nbessai++;

            if ((nbessai == nbessaimax) || (reponse == textBoxChoix.Text))
            {
                //Affiche le message//

                if (reponse == textBoxChoix.Text)
                {
                    MessageBox.Show("Vous avez gagné ! Le mot est bien : " + reponse + ".", "Motus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Vous avez perdu... Le mot est : " + reponse + ".", "Motus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dataGridViewMotus.Visible = false;

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

        public int NbFoisLettreDansMot(string chaine, char lettre)
        {
            int nb = 0;
            foreach (char c in chaine)
            {
                if (c == lettre) nb++;
            }
            return nb;  
        }
    }
}
