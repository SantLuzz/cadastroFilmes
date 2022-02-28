namespace filmes
{
    partial class autenticacao
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
            this.tb_senha = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_senha
            // 
            this.tb_senha.Location = new System.Drawing.Point(12, 48);
            this.tb_senha.Name = "tb_senha";
            this.tb_senha.PasswordChar = '#';
            this.tb_senha.Size = new System.Drawing.Size(332, 20);
            this.tb_senha.TabIndex = 0;
            this.tb_senha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_senha_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Logar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // autenticacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 132);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_senha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "autenticacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acesso Restrito";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.autenticacao_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_senha;
        private System.Windows.Forms.Button button1;
    }
}