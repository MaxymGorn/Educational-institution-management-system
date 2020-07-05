using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    public partial class Form1 : Form
    {
        private string path1,path2;
        public Form1()
        {
         
            InitializeComponent();
            path1 = @"..\..\Data\Facultety.xml";
            path2 = @"..\..\Data\Department.xml";
            dataGridView1.MultiSelect = false;
            dataGridView2.MultiSelect = false;
            dataGridView3.MultiSelect = false;
            numericUpDown1.Maximum = dataGridView1.Rows.Count;
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            dataSet1.ReadXml(path1);
            dataGridView1.DataSource = dataSet1.Tables[0];

            dataSet2.ReadXml(path2);
            dataGridView2.DataSource = dataSet2.Tables[0];
            dataGridView3.DataSource = dataSet2.Tables[0];
            numericUpDown1.Maximum = dataGridView1.Rows.Count;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (textBox1.Text.Length == 0)
                {
                    throw new Exception("Eror facultety!");
                }
                int k = dataSet1.Tables[0].Rows.Count;
                dataSet1.Tables[0].Rows.Add();
                dataSet1.Tables[0].Rows[k].SetField(0, k+1);
                dataSet1.Tables[0].Rows[k].SetField(1, textBox1.Text);
                textBox1.Clear();
                dataSet1.WriteXml(path1);
                numericUpDown1.Maximum = dataGridView1.Rows.Count;
            }
            catch(Exception eror)
            {
                MessageBox.Show(eror.Message, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length == 0)
                {
                    throw new Exception("Eror facultety!");
                }
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    throw new Exception("Eror selected!");
                }
                var rows = dataGridView1.SelectedRows;
                dataSet1.Tables[0].Rows[rows[0].Cells[0].RowIndex][1] = textBox1.Text;
                dataSet1.WriteXml(path1);
            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            var rows = dataGridView1.SelectedRows;
            int k = rows.Count;
            if (k > 0)
            {

                textBox1.Text = rows[0].Cells[1].Value.ToString();






            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.SelectedRows.Count != 1)
                {
                    throw new Exception("Eror selected!");
                }
                var rows = dataGridView1.SelectedRows;
                dataSet1.Tables[0].Rows.RemoveAt(rows[0].Cells[0].RowIndex);
                dataSet1.WriteXml(path1);
                numericUpDown1.Maximum = dataGridView1.Rows.Count;
            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            var rows2 = dataGridView2.SelectedRows;
            if (rows2.Count > 0)
            {
         
                textBox2.Text = rows2[0].Cells[0].Value.ToString();
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            var rows = dataGridView3.SelectedRows;
            int k = rows.Count;
            if (k > 0)
            {
                numericUpDown1.Value = int.Parse(rows[0].Cells[0].Value.ToString());
                textBox2.Text = rows[0].Cells[1].Value.ToString();






            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length == 0)
                {
                    throw new Exception("Eror department!");
                }
                int k = dataSet2.Tables[0].Rows.Count;
                dataSet2.Tables[0].Rows.Add();
                dataSet2.Tables[0].Rows[k].SetField(0, numericUpDown1.Value.ToString());
                dataSet2.Tables[0].Rows[k].SetField(1, textBox2.Text);
                dataSet2.Tables[0].Rows[k].SetField(2, k + 1);
                textBox2.Clear();
                dataSet2.WriteXml(path2);
            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length == 0)
                {
                    throw new Exception("Eror department!");
                }
                if (dataGridView3.SelectedRows.Count != 1)
                {
                    throw new Exception("Eror selected!");
                }
                var rows = dataGridView3.SelectedRows;
                dataSet2.Tables[0].Rows[rows[0].Cells[0].RowIndex][1] = textBox2.Text;
                dataSet2.Tables[0].Rows[rows[0].Cells[0].RowIndex][0] = numericUpDown1.Value;
                dataSet2.WriteXml(path2);
            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView3.SelectedRows.Count != 1)
                {
                    throw new Exception("Eror selected!");
                }
                var rows = dataGridView3.SelectedRows;
                dataSet2.Tables[0].Rows.RemoveAt(rows[0].Cells[0].RowIndex);
                dataSet2.WriteXml(path2);
             
            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;
            numericUpDown1.Value = 1;
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            dataGridView3.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
            DataTable dat = new DataTable();
            dataGridView2.DataSource = dat;
            var rows = dataGridView1.SelectedRows;
            DataRow[] res = dataSet2.Tables[0].Select($"fid={rows[0].Cells[0].Value}");
            dat.Columns.Add("fid");
            dat.Columns.Add("name");
            dat.Columns.Add("id");
            for (int i=0;i<res.Length;i++)
            {
                string id = res[i].Field<string>(0);
                string name = res[i].Field<string>(1);
                string fname = res[i].Field<string>(2);
                dat.Rows.Add();

                dat.Rows[i].SetField(0, id);
                dat.Rows[i].SetField(1, name);
                dat.Rows[i].SetField(2, fname);

            }

            dataGridView2.DataSource = dat;

        }
            
    }
}
