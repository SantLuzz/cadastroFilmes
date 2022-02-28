using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filmes
{
    public partial class autenticacao : Form
    {
        Form1 form;
        public const string SENHA = "1";
        public autenticacao(Form1 f)
        {
            InitializeComponent();
            form = f;
        }

        private void autenticacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tb_senha.Text == SENHA)
            {
                form.btn_banco.Visible = true;
                this.Close();
            }
        }

        private void tb_senha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_senha.Text == SENHA)
                {
                    form.btn_banco.Visible = true;
                    this.Close();
                }
            }
        }
    }
}
