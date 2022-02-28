namespace filmes
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_banco = new System.Windows.Forms.Button();
            this.btn_cadFilme = new System.Windows.Forms.Button();
            this.btn_cadCat = new System.Windows.Forms.Button();
            this.lv_filmes = new System.Windows.Forms.ListView();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.btn_pesquisar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_banco
            // 
            this.btn_banco.Location = new System.Drawing.Point(541, 484);
            this.btn_banco.Name = "btn_banco";
            this.btn_banco.Size = new System.Drawing.Size(133, 35);
            this.btn_banco.TabIndex = 0;
            this.btn_banco.Text = "Criar Banco";
            this.btn_banco.UseVisualStyleBackColor = true;
            this.btn_banco.Visible = false;
            this.btn_banco.Click += new System.EventHandler(this.btn_banco_Click);
            // 
            // btn_cadFilme
            // 
            this.btn_cadFilme.Location = new System.Drawing.Point(12, 484);
            this.btn_cadFilme.Name = "btn_cadFilme";
            this.btn_cadFilme.Size = new System.Drawing.Size(133, 35);
            this.btn_cadFilme.TabIndex = 1;
            this.btn_cadFilme.Text = "Cadastrar Filmes";
            this.btn_cadFilme.UseVisualStyleBackColor = true;
            this.btn_cadFilme.Click += new System.EventHandler(this.btn_cadFilme_Click);
            // 
            // btn_cadCat
            // 
            this.btn_cadCat.Location = new System.Drawing.Point(178, 484);
            this.btn_cadCat.Name = "btn_cadCat";
            this.btn_cadCat.Size = new System.Drawing.Size(133, 35);
            this.btn_cadCat.TabIndex = 2;
            this.btn_cadCat.Text = "Cadastrar Categorias";
            this.btn_cadCat.UseVisualStyleBackColor = true;
            this.btn_cadCat.Click += new System.EventHandler(this.btn_cadCat_Click);
            // 
            // lv_filmes
            // 
            this.lv_filmes.FullRowSelect = true;
            this.lv_filmes.HideSelection = false;
            this.lv_filmes.Location = new System.Drawing.Point(12, 79);
            this.lv_filmes.MultiSelect = false;
            this.lv_filmes.Name = "lv_filmes";
            this.lv_filmes.Size = new System.Drawing.Size(662, 370);
            this.lv_filmes.TabIndex = 3;
            this.lv_filmes.UseCompatibleStateImageBehavior = false;
            this.lv_filmes.View = System.Windows.Forms.View.Details;
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(12, 41);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(510, 20);
            this.tb_search.TabIndex = 4;
            this.tb_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_search_KeyDown);
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.Location = new System.Drawing.Point(541, 33);
            this.btn_pesquisar.Name = "btn_pesquisar";
            this.btn_pesquisar.Size = new System.Drawing.Size(133, 35);
            this.btn_pesquisar.TabIndex = 5;
            this.btn_pesquisar.Text = "Pesquisar";
            this.btn_pesquisar.UseVisualStyleBackColor = true;
            this.btn_pesquisar.Click += new System.EventHandler(this.btn_pesquisar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 531);
            this.Controls.Add(this.btn_pesquisar);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.lv_filmes);
            this.Controls.Add(this.btn_cadCat);
            this.Controls.Add(this.btn_cadFilme);
            this.Controls.Add(this.btn_banco);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filmes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btn_banco;
        public System.Windows.Forms.Button btn_cadFilme;
        public System.Windows.Forms.Button btn_cadCat;
        private System.Windows.Forms.TextBox tb_search;
        public System.Windows.Forms.Button btn_pesquisar;
        public System.Windows.Forms.ListView lv_filmes;
    }
}

