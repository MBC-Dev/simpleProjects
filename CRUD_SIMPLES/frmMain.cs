using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD_SIMPLES
{
    public partial class frmMain : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        int ID = 0;
        public frmMain()
        {
            InitializeComponent();
            DisplayData();
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            if (txt_Nome.Text != "" && txt_Estado.Text != "")
            {
                cmd = new SqlCommand("insert into tbl_Record(Nome,Estado) values(@nome,@estado)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@nome", txt_Nome.Text);
                cmd.Parameters.AddWithValue("@estado", txt_Estado.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registro inserido com sucesso!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Por favor preencha os campos!");
            }
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from tbl_Record", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void ClearData()
        {
            txt_Nome.Text = "";
            txt_Estado.Text = "";
            ID = 0;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_Nome.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Estado.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_Nome.Text != "" && txt_Estado.Text != "")
            {
                cmd = new SqlCommand("update tbl_Record set Nome=@nome,Estado=@estado where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@nome", txt_Nome.Text);
                cmd.Parameters.AddWithValue("@estado", txt_Estado.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro alterado com sucesso!");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Por favor selecione um registro para alterar");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete tbl_Record where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registro apagado com sucesso");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Por favor selecione um registro para apagar");
            }
        }
    }
}
