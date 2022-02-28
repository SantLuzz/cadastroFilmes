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
    public partial class cadFilmes : Form
    {
        DataTable dt = new DataTable();
        string vQueryDGV = "";
        int mod = 0; //1 = INSERT, 2 = UPDATE
        int idFilm = 0;

        Form1 form;
        public cadFilmes(Form1 f)
        {
            InitializeComponent();
            form = f;
        }

        private void cadFilmes_Load(object sender, EventArgs e)
        {
            vQueryDGV = String.Format(@"
                SELECT 
                    idFilme as 'ID',
                    nome as 'Nome',
                    descricao as 'Descrição'
                FROM
                    tb_filmes
            ");
            dgv_film.DataSource = db.dql(vQueryDGV);
            dgv_film.Columns[0].Width = 60;
            dgv_film.Columns[1].Width = 150;
            dgv_film.Columns[2].Width = 240;

           // idFilm = int.Parse(dgv_film.Rows[dgv_film.SelectedRows[0].Index].Cells[0].Value.ToString());
            tb_nomeFilme.Text = dgv_film.Rows[dgv_film.SelectedRows[0].Index].Cells[1].Value.ToString();

            string vQueryCat = String.Format(@"
                SELECT 
                    idCat as 'ID',
                    nome as 'Nome'
                FROM 
                    tb_categoria
            ");
            cb_categoria.Items.Clear();
            cb_categoria.DataSource = db.dql(vQueryCat);
            cb_categoria.DisplayMember = "Nome";
            cb_categoria.ValueMember = "ID";
           // cb_categoria.SelectedValue = 
        }

        private void dgv_film_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int countRows = dgv.SelectedRows.Count;

            if(countRows > 0)
            {
                mod = 0;
                idFilm = int.Parse(dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString());
                tb_nomeFilme.Text = dgv_film.Rows[dgv_film.SelectedRows[0].Index].Cells[1].Value.ToString();

                string vQuerySelectedChanged = string.Format(@"
                    SELECT
                        idFilme,
                        nome,
                        descricao,
                        idCat
                    FROM
                        tb_filmes
                    WHERE
                        idFilme = {0}
                ",idFilm);
                dt = db.dql(vQuerySelectedChanged);
                tb_nomeFilme.Text = dt.Rows[0].Field<string>("nome");
                tb_dscFilme.Text = dt.Rows[0].Field<string>("descricao");
                cb_categoria.SelectedValue = dt.Rows[0].Field<Int64>("idCat");
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            mod = 1;
            tb_nomeFilme.Clear();
            tb_dscFilme.Clear();
            cb_categoria.SelectedIndex = -1;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja Excluir o Filme Selecionado?","Excluir",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string msgOk = "Filme Deletado Com Sucesso";
                string msgError = "Não Foi Possível Excluir O Filme";
                string idLVSelected = "";

                string vQueryDelete = string.Format(@"
                DELETE FROM tb_filmes WHERE idFilme = {0}
                ", idFilm);
                db.dml(vQueryDelete, msgOk, msgError);
                tb_nomeFilme.Clear();
                tb_dscFilme.Clear();
                cb_categoria.SelectedIndex = -1;
                dgv_film.Rows.Remove(dgv_film.CurrentRow);

                /*foreach (ListViewItem item in form.lv_filmes.Items)
                {
                    if (idFilm.ToString() == item.SubItems[0].Text)
                    {
                        string msg = "Item encontrado: " + idFilm.ToString() + " = " + item.SubItems[0].Text.ToString() + "!";
                        MessageBox.Show(msg);
                        idLVSelected = item.SubItems[0].Text.ToString();
                        form.lv_filmes.Items.RemoveAt(idFilm);
                    }
                    
                }*/

            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if(mod != 0)
            {
                string vQueryBtnSave = "";
                string msgOk = "";
                string msgError = "";
                int row = dgv_film.SelectedRows[0].Index;

                if(mod == 1)
                {
                    vQueryBtnSave = string.Format(@"
                        INSERT INTO
                            tb_filmes
                            (nome,descricao,idCat)
                        VALUES
                            ('{0}','{1}',{2})
                    ",tb_nomeFilme.Text,tb_dscFilme.Text,cb_categoria.SelectedValue);
                    msgOk = "Filme Cadastrado com Sucesso!";
                    msgError = "Não Foi Possível Cadastrar o Filme!";
                }
                else
                {
                    vQueryBtnSave = string.Format(@"
                        UPDATE
                            tb_filmes
                        SET
                            nome = '{0}',
                            descricao = '{1}',
                            idCat = {2}
                        WHERE
                            idFilme = {3}
                    ",tb_nomeFilme.Text,tb_dscFilme.Text,cb_categoria.SelectedValue,idFilm);
                    msgOk = "Filme Atualizado com Sucesso!";
                    msgError = "Não Foi Possível Atualizar o Filme!";
                }
                db.dml(vQueryBtnSave, msgOk, msgError);
                if(mod == 1)
                {
                    dgv_film.DataSource = db.dql(vQueryDGV);
                }
                else
                {
                    dgv_film[1, row].Value = tb_nomeFilme.Text;
                    dgv_film[2, row].Value = tb_dscFilme.Text;
                }
            }
        }

        private void cadFilmes_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*string vQueryClose = string.Format(@"SELECT * FROM tb_filmes ORDER BY idFilme DESC");

            dt = db.dql(vQueryClose);
            int idAdd = int.Parse(dt.Rows[0].Field<Int64>("idFilme").ToString());
            if (idAdd > form.valueMax)
            {
                string[] list = new string[4];
                list[0] = dt.Rows[0].Field<Int64>("idFilme").ToString();
                list[1] = dt.Rows[0].Field<string>("nome");
                list[2] = dt.Rows[0].Field<string>("descricao");
                list[3] = dt.Rows[0].Field<Int64>("idCat").ToString();
                form.lv_filmes.Items.Add(new ListViewItem(list));
            }

            if(mod == 2)
            {
                string[] list = new string[4];
                list[0] = dt.Rows[0].Field<Int64>("idFilme").ToString();
                list[1] = dt.Rows[0].Field<string>("nome");
                list[2] = dt.Rows[0].Field<string>("descricao");
                list[3] = dt.Rows[0].Field<Int64>("idCat").ToString();
                form.lv_filmes.Items.Add(new ListViewItem(list));
            }*/
            form.listViewLoad();
        }
        private void tb_nomeFilme_TextChanged(object sender, EventArgs e)
        {
            if(mod == 0)
            {
                mod = 2;
            }
        }

        private void tb_dscFilme_TextChanged(object sender, EventArgs e)
        {
            if(mod == 0)
            {
                mod = 2;
            }
        }

        private void cb_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(mod == 0)
            {
                mod = 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
