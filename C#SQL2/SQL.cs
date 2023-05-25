using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C_SQL2
{
    public partial class SQL : Form
    {
        public SQL()
        {
            InitializeComponent();
        }
      

    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1E6RFA7;Initial Catalog=\"VS check\";Integrated Security=True");
        private void SQL_Load(object sender, EventArgs e)
        {
            bind_data();
        }
        private void bind_data()
        {
            SqlCommand cmd1 = new SqlCommand("Select IdNo,Id_Description,Id_Position,Status from VsCheck", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd1;
            DataTable dt = new DataTable();
            dt.Clear();
            dataAdapter.Fill(dt);
            DataGridView.DataSource = dt;
        }

        private void AddBTN_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Insert into VsCheck(IdNo,Id_Description,Id_Position,Status)Values(@IdNo,@Id_Description,@Id_Position,@Status)", conn);
            cmd2.Parameters.AddWithValue("IdNo", textBox1.Text);
            cmd2.Parameters.AddWithValue("Id_Description", textBox2.Text);
            cmd2.Parameters.AddWithValue("Id_Position", textBox3.Text);
            cmd2.Parameters.AddWithValue("Status", textBox4.Text);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
            bind_data();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index;
            index=e.RowIndex;
            DataGridViewRow selectedrow = DataGridView.Rows[index];
            textBox1.Text = selectedrow.Cells[0].Value.ToString();
            textBox2.Text = selectedrow.Cells[1].Value.ToString();
            textBox3.Text = selectedrow.Cells[2].Value.ToString();
            textBox4.Text = selectedrow.Cells[3].Value.ToString();
           
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("update VsCheck set Id_Description=@Id_Description,Id_Position=@Id_Position,Status=@Status where IdNo=@IdNo",conn);
            cmd3.Parameters.AddWithValue("IdNo", textBox1.Text);
            cmd3.Parameters.AddWithValue("Id_Description", textBox2.Text);
            cmd3.Parameters.AddWithValue("Id_Position", textBox3.Text);
            cmd3.Parameters.AddWithValue("Status", textBox4.Text);
            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();
            bind_data();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("Delete from VsCheck where IdNo=@IdNo", conn);
            cmd4.Parameters.AddWithValue("IdNo", textBox1.Text);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
            bind_data();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("Select IdNo,Id_Description,Id_Position,Status from VsCheck where Id_Description Like @Id_Description", conn);
            cmd5.Parameters.AddWithValue("Id_Description", textBox5.Text);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd5;
            DataTable dt = new DataTable();
            dt.Clear();
            dataAdapter.Fill(dt);
            DataGridView.DataSource = dt;
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DataGridView.GridColor = Color.BlueViolet;
        }

       

        private void PrintBTN_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void printDocument1_printpage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Bitmap imagebmp = new Bitmap(DataGridView.Width, DataGridView.Height);
            DataGridView.DrawToBitmap(imagebmp, new Rectangle(0, 0, DataGridView.Width, DataGridView.Height));
            e.Graphics.DrawImage(imagebmp, 120, 20);
        }
    }
}
