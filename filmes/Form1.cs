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




namespace filmes
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        public int valueMax = 0;

        public Form1()
        {
            InitializeComponent();
            formatListView();
            if (File.Exists(db.existsDB + "\\" + db.nomeBase) == true)
            {
                listViewLoad();
            }
                
        }

        private void formatListView()
        {
            lv_filmes.Columns.Add("ID", 80).TextAlign = HorizontalAlignment.Center;
            lv_filmes.Columns.Add("Filme", 160).TextAlign = HorizontalAlignment.Center;
            lv_filmes.Columns.Add("Descrição", 300).TextAlign = HorizontalAlignment.Center;
            lv_filmes.Columns.Add("Categoria", 80).TextAlign = HorizontalAlignment.Center;
            lv_filmes.View = View.Details;
        }
        
        public void listViewLoad()
        {
            lv_filmes.Items.Clear();
            string vQueryListView = string.Format(@"
                SELECT 
                    *
                FROM
                    tb_filmes
            ");
            dt = db.dql(vQueryListView);

            string[] values = new string[4];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                values[0] = dt.Rows[i].Field<Int64>("idFilme").ToString();
                values[1] = dt.Rows[i].Field<string>("nome");
                values[2] = dt.Rows[i].Field<string>("descricao");
                values[3] = dt.Rows[i].Field<Int64>("idCat").ToString();
                lv_filmes.Items.Add(new ListViewItem(values));

            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(db.existsDB + "\\" + db.nomeBase) == false)
            {

                DirectoryInfo dic = new DirectoryInfo(db.existsDB);
                dic.Create();

                StreamWriter sw = new StreamWriter(db.existsDB + "\\" + db.nomeBase);
                MessageBox.Show("Banco Criado");
            }
            

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F12)
            {
                autenticacao Aut = new autenticacao(this);
                Aut.Show();
                
            }
        }

        private void btn_banco_Click(object sender, EventArgs e)
        {
            if(File.Exists(db.existsDB + "\\" + db.nomeBase))
            {
                if (MessageBox.Show("Deseja criar um novo banco?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.createTables();
                }
                MessageBox.Show("Rotina Realizada com sucesso!");
            }
            else
            {
                MessageBox.Show("Não foi possivel encontrar o arquvio de banco de dados!");
            }
        }

        private void btn_cadCat_Click(object sender, EventArgs e)
        {
            cadCat CadCat = new cadCat();
            CadCat.Show();
        }

        private void btn_cadFilme_Click(object sender, EventArgs e)
        {
            string vQueryIdFilme = string.Format(@"
                SELECT MAX(idFilme)
                FROM
                    tb_filmes
            ");
            dt = db.dql(vQueryIdFilme);
            valueMax = int.Parse(dt.Rows[0].Field<Int64>("MAX(idFilme)").ToString());

            cadFilmes CadFilmes = new cadFilmes(this);
            CadFilmes.Show();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lv_filmes.Items)
            {
                if(tb_search.Text == item.SubItems[1].Text)
                {
                    item.Selected = true;
                    break;
                }

                if(tb_search.Text == item.SubItems[0].Text)
                {
                    item.Selected = true;
                    break;
                }
            }
        }

        private void tb_search_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                foreach (ListViewItem item in lv_filmes.Items)
                {
                    if (tb_search.Text == item.SubItems[1].Text)
                    {
                        item.Selected = true;
                        break;
                    }

                    if (tb_search.Text == item.SubItems[0].Text)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }
    }
}
