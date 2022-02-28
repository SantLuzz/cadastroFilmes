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
    public partial class cadCat : Form
    {
        DataTable dt = new DataTable();
        int idCat = 0;
        int mod = 0; //1 = novo, 2 = edição
        string vQueryDGV = "";

        public cadCat()
        {
            InitializeComponent();
        }

        private void cadCat_Load(object sender, EventArgs e)
        {
            vQueryDGV = String.Format(@"
                SELECT 
                    idCat as 'ID',
                    nome as 'Nome'
                FROM tb_categoria
            ");
            dgv_cat.DataSource = db.dql(vQueryDGV);
            dgv_cat.Columns[0].Width = 100;
            dgv_cat.Columns[1].Width = 360;
            
        }

        private void dgv_cat_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int rows = dgv.SelectedRows.Count;

            if(rows > 0)
            {
                mod = 0;
                idCat = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());
                string vQuerySelectChanged = string.Format(@"
                SELECT 
                    idCat,
                    nome,
                    descricao
                FROM 
                    tb_categoria
                WHERE
                    idCat = {0}
                ", idCat);
                dt = db.dql(vQuerySelectChanged);
                tb_nomeCat.Text = dt.Rows[0].Field<string>("nome");
                tb_dscCat.Text = dt.Rows[0].Field<string>("descricao");
            }
          
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            tb_nomeCat.Clear();
            tb_dscCat.Clear();
            mod = 1;
            btn_delete.Enabled = false;
            btn_salvar.Enabled = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            string vQueryBtnSave = "";
            string msgOk = "";
            string msgError = "";
            int row = dgv_cat.SelectedRows[0].Index;
           if(mod != 0)
            {
                if (mod == 1)
                {
                    msgOk = "Categoria Cadastrada Com Cucesso!";
                    msgError = "Não Foi Possível Cadastrar A Categoria!";
                    vQueryBtnSave = string.Format(@"
                    INSERT INTO
                        tb_categoria
                        (nome,descricao)
                    VALUES
                        ('{0}','{1}')
                ", tb_nomeCat.Text, tb_dscCat.Text);
                }
                else
                {
                    msgOk = "Categoria Atualizada com Sucesso!";
                    msgError = "Não Foi Possível Atualizar A Categoria!";
                    vQueryBtnSave = string.Format(@"
                    UPDATE
                        tb_categoria
                    SET
                        nome = '{0}',
                        descricao = '{1}'
                    WHERE
                        idCat = {2}
                ", tb_nomeCat.Text, tb_dscCat.Text, idCat);
                }
                db.dml(vQueryBtnSave, msgOk, msgError);
                if (mod == 2)
                {
                    dgv_cat[1, row].Value = tb_nomeCat.Text;
                }
                else
                {
                    dgv_cat.DataSource = db.dql(vQueryDGV);
                }
                btn_delete.Enabled = true;
            }
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string msgOk = "Categoria Deletada com Sucesso!";
            string msgError = "Não Foi Possível Deletar a Categoria!";

            if(MessageBox.Show("Deseja Realmente Excluir?","Excluir",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string vQueryDelete = string.Format(@"DELETE FROM tb_categoria WHERE idCat = {0}", idCat);
                db.dml(vQueryDelete, msgOk, msgError);
                dgv_cat.Rows.Remove(dgv_cat.CurrentRow);
                tb_nomeCat.Clear();
                tb_dscCat.Clear();
            }
        }

        private void tb_nomeCat_TextChanged(object sender, EventArgs e)
        {
            if(mod == 0)
            {
                mod = 2;
            }
                
        }

        private void tb_dscCat_TextChanged(object sender, EventArgs e)
        { 
            if(mod == 0)
            {
                mod = 2;
            }
        }
    }
}
