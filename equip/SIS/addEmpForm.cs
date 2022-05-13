using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIS
{
    public partial class addEmpForm : Form
    {
        Boolean DataLoaded = false;
        char delimiter;
        AdminScript script = new AdminScript();
        string sql = "INSERT INTO tbl_emp (tbl_emp_id,tbl_emp_name,tbl_emp_group_id) VALUES ";
        public addEmpForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:";
            openFileDialog1.Filter = "CSV files (*.csv)|*.CSV";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.ShowDialog();

            FileImportText.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //new addEmpForm().Show();
            //this.Dispose(false);
            if (FileImportText.Text != "")
            {
                FileImportText.Clear();
                dataGridView1.Rows.Clear();
            }
            else
            {
                string[] fileDataField = { "รหัสพนักงาน", "ชื่อ-สกุล", "ตำแหน่ง(ตัวเลข)" };
                for (int i = 0; i <= 2; i++)
                {
                    DataGridViewTextBoxColumn columnDataGridTextBox = new DataGridViewTextBoxColumn();
                    columnDataGridTextBox.Name = fileDataField[i];
                    columnDataGridTextBox.HeaderText = fileDataField[i];
                    if (i == 1) { columnDataGridTextBox.Width = 290; }
                    else { columnDataGridTextBox.Width = 120; }
                    dataGridView1.Columns.Add(columnDataGridTextBox);
                }
                button3.Enabled = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ยืนยันที่จะบันทึกข้อมูล?", "ยืนยัน?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    delimiter = Convert.ToChar(",");
                }
                catch (Exception exceptionObject)
                {
                    MessageBox.Show(exceptionObject.ToString());
                    this.Close();
                }

                try
                {
                    string columnHeaderText = "";

                    //Writing DataGridView Header in File
                    int countColumn = dataGridView1.ColumnCount - 1;

                    if (countColumn >= 0)
                    {
                        columnHeaderText = dataGridView1.Columns[0].HeaderText;
                    }

                    for (int i = 1; i <= countColumn; i++)
                    {
                        columnHeaderText = columnHeaderText + delimiter + dataGridView1.Columns[i].HeaderText;
                    }

                    //fileWriter.WriteLine(columnHeaderText);

                    //Writing Data in File
                    string dataFromGrid = "";

                    int count = 1;
                    foreach (DataGridViewRow dataRowObject in dataGridView1.Rows)
                    {
                        if (!dataRowObject.IsNewRow)
                        {
                            dataFromGrid = dataRowObject.Cells[0].Value.ToString();

                            for (int i = 1; i <= countColumn; i++)
                            {
                                dataFromGrid = dataFromGrid + delimiter + "'" + dataRowObject.Cells[i].Value.ToString() + "'";
                            }

                            if (count == 1)
                            {
                                sql += "(" + dataFromGrid + ")";
                            }
                            else
                            {
                                sql += ",(" + dataFromGrid + ")";
                            }
                            count++;
                            //fileWriter.WriteLine(dataFromGrid);
                        }
                    }

                    if (script.InsertUpdae_SQL(sql))
                    {
                        MessageBox.Show("บันทึกข้อมูลสำเร็จ","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        button5.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("!!!Error : บันทึกข้อมูล ล้มเหลว ลองใหม่อีกครั้ง","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }

                }
                catch (Exception exceptionObject)
                {
                    MessageBox.Show(exceptionObject.ToString());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fileRow;
            string[] fileDataField;
            int count = 0;
            if (DataLoaded == false)
            {
                try
                {
                    delimiter = Convert.ToChar(",");
                }
                catch (Exception exceptionObject)
                {
                    MessageBox.Show(exceptionObject.ToString());
                    this.Close();
                }

                try
                {
                    if (System.IO.File.Exists(FileImportText.Text))
                    {
                        System.IO.StreamReader fileReader = new StreamReader(FileImportText.Text);

                        if (fileReader.Peek() != -1)
                        {
                            fileRow = fileReader.ReadLine();
                            fileDataField = fileRow.Split(delimiter);
                            count = fileDataField.Count();
                            count = count - 1;

                            //Reading Header information
                            for (int i = 0; i <= count; i++)
                            {
                                DataGridViewTextBoxColumn columnDataGridTextBox = new DataGridViewTextBoxColumn();
                                columnDataGridTextBox.Name = fileDataField[i];
                                columnDataGridTextBox.HeaderText = fileDataField[i];
                                if (i == 1) { columnDataGridTextBox.Width = 290; }
                                else { columnDataGridTextBox.Width = 120; }
                                dataGridView1.Columns.Add(columnDataGridTextBox);
                            }
                            button3.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("ไม่พบข้อมูลในไฟล์");
                        }
                        //Reading Data
                        while (fileReader.Peek() != -1)
                        {
                            fileRow = fileReader.ReadLine();
                            fileDataField = fileRow.Split(delimiter);
                            dataGridView1.Rows.Add(fileDataField);
                        }

                        fileReader.Close();
                    }
                    else
                    {
                        MessageBox.Show("กรุณาเลือกไฟล์!!!");
                    }

                    DataLoaded = true;

                }
                catch (Exception exceptionObject)
                {
                    MessageBox.Show(exceptionObject.ToString());
                }
            }
            else
            {
                MessageBox.Show("Clear DataGridView First!!");
            }
        }

        private void addEmpForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string sql = "select * from tbl_emp_group order by tbl_emp_group_id";
            MySqlDataReader rs = script.Select_SQL(sql);
            while (rs.Read())
            {
                listBox1.Items.Add(rs.GetString("tbl_emp_group_id") + " " + rs.GetString("tbl_emp_group_name"));
            }
            rs.Close();
            script.conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ยืนยันที่จะส่งข้อมูลไปที่ด่านฯ?", "ยืนยัน?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string data = "";
                string name = "";
                MySqlDataReader rs = script.Select_SQL("SELECT * FROM tbl_cpoint where tbl_cpoint_status = '0' order by tbl_cpoint_id");
                int i = 1;
                while (rs.Read())
                {
                    if (i == 1)
                    {
                        data += rs.GetString("tbl_cpoint_id");
                        name += rs.GetString("tbl_cpoint_name");
                    }
                    else
                    {
                        data += "," + rs.GetString("tbl_cpoint_id");
                        name += "," + rs.GetString("tbl_cpoint_name");
                    }
                    i++;
                }
                rs.Close();
                script.conn.Close();

                string[] cpoint = data.Split(',');
                string[] cpointName = name.Split(',');
                for (i = 0; i < cpoint.Length; i++)
                {
                    MySqlConnection conn = script.getConn(cpoint[i]);
                    if (script.InsertUpdae_SQL(sql, conn))
                    {
                        MessageBox.Show("ส่งข้อมูลไปด่านฯ "+cpointName[i]+" สำเร็จ","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("!!!Error : ส่งข้อมูลไปด่านฯ " + cpointName[i] + " ล้มเหลว กรุณาตรวสอบกานเชื่อมต่อ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                }
            }
        }
    }
}
