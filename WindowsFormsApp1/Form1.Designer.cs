namespace WindowsFormsApp1
{
    partial class frmMotus
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMotus));
            this.labelTailleMot = new System.Windows.Forms.Label();
            this.buttonTailleMotOuvrir = new System.Windows.Forms.Button();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.textBoxChoix = new System.Windows.Forms.TextBox();
            this.buttonValider = new System.Windows.Forms.Button();
            this.dataGridViewMotus = new System.Windows.Forms.DataGridView();
            this.buttonJouer = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.buttonQuitter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMotus)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTailleMot
            // 
            this.labelTailleMot.AutoSize = true;
            this.labelTailleMot.Location = new System.Drawing.Point(234, 30);
            this.labelTailleMot.Name = "labelTailleMot";
            this.labelTailleMot.Size = new System.Drawing.Size(126, 13);
            this.labelTailleMot.TabIndex = 0;
            this.labelTailleMot.Text = "Choisir une liste de mots :";
            // 
            // buttonTailleMotOuvrir
            // 
            this.buttonTailleMotOuvrir.Location = new System.Drawing.Point(572, 25);
            this.buttonTailleMotOuvrir.Name = "buttonTailleMotOuvrir";
            this.buttonTailleMotOuvrir.Size = new System.Drawing.Size(75, 23);
            this.buttonTailleMotOuvrir.TabIndex = 1;
            this.buttonTailleMotOuvrir.Text = "Ouvrir";
            this.buttonTailleMotOuvrir.UseVisualStyleBackColor = true;
            this.buttonTailleMotOuvrir.Click += new System.EventHandler(this.buttonTailleMotOuvrir_Click);
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(366, 27);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(200, 20);
            this.textBoxFile.TabIndex = 2;
            // 
            // textBoxChoix
            // 
            this.textBoxChoix.Location = new System.Drawing.Point(301, 71);
            this.textBoxChoix.Name = "textBoxChoix";
            this.textBoxChoix.Size = new System.Drawing.Size(200, 20);
            this.textBoxChoix.TabIndex = 3;
            this.textBoxChoix.TextChanged += new System.EventHandler(this.textBoxChoix_TextChanged);
            this.textBoxChoix.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxChoix_KeyDown);
            // 
            // buttonValider
            // 
            this.buttonValider.Location = new System.Drawing.Point(507, 69);
            this.buttonValider.Name = "buttonValider";
            this.buttonValider.Size = new System.Drawing.Size(75, 23);
            this.buttonValider.TabIndex = 4;
            this.buttonValider.Text = "Valider";
            this.buttonValider.UseVisualStyleBackColor = true;
            this.buttonValider.Click += new System.EventHandler(this.buttonValider_Click);
            // 
            // dataGridViewMotus
            // 
            this.dataGridViewMotus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMotus.Location = new System.Drawing.Point(188, 111);
            this.dataGridViewMotus.Name = "dataGridViewMotus";
            this.dataGridViewMotus.Size = new System.Drawing.Size(500, 280);
            this.dataGridViewMotus.TabIndex = 5;
            // 
            // buttonJouer
            // 
            this.buttonJouer.Location = new System.Drawing.Point(201, 423);
            this.buttonJouer.Name = "buttonJouer";
            this.buttonJouer.Size = new System.Drawing.Size(150, 50);
            this.buttonJouer.TabIndex = 7;
            this.buttonJouer.Text = "Jouer";
            this.buttonJouer.UseVisualStyleBackColor = true;
            this.buttonJouer.Click += new System.EventHandler(this.buttonJouer_Click);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Location = new System.Drawing.Point(357, 423);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(150, 50);
            this.buttonAnnuler.TabIndex = 8;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);
            // 
            // buttonQuitter
            // 
            this.buttonQuitter.Location = new System.Drawing.Point(513, 423);
            this.buttonQuitter.Name = "buttonQuitter";
            this.buttonQuitter.Size = new System.Drawing.Size(150, 50);
            this.buttonQuitter.TabIndex = 9;
            this.buttonQuitter.Text = "Quitter";
            this.buttonQuitter.UseVisualStyleBackColor = true;
            this.buttonQuitter.Click += new System.EventHandler(this.buttonQuitter_Click);
            // 
            // frmMotus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(864, 502);
            this.Controls.Add(this.buttonQuitter);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonJouer);
            this.Controls.Add(this.dataGridViewMotus);
            this.Controls.Add(this.buttonValider);
            this.Controls.Add(this.textBoxChoix);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.buttonTailleMotOuvrir);
            this.Controls.Add(this.labelTailleMot);
            this.MaximumSize = new System.Drawing.Size(880, 540);
            this.MinimumSize = new System.Drawing.Size(880, 540);
            this.Name = "frmMotus";
            this.Text = "Motus";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMotus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTailleMot;
        private System.Windows.Forms.Button buttonTailleMotOuvrir;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.TextBox textBoxChoix;
        private System.Windows.Forms.Button buttonValider;
        private System.Windows.Forms.DataGridView dataGridViewMotus;
        private System.Windows.Forms.Button buttonJouer;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.Button buttonQuitter;
    }
}

