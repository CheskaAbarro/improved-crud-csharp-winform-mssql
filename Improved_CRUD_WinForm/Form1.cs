using System.Configuration;
using System.Data;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;

namespace Improved_CRUD_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //varibles
        string connectionString = ConfigurationManager.ConnectionStrings["SensorConnectionString"].ConnectionString;


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadRecords();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }


        //Save to DB
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtSensorName.Text) && !string.IsNullOrWhiteSpace(txtSensorType.Text))
                {
                    //SQL
                    string sqlQuery = "INSERT INTO tbl_Sensor (SensorName, SensorType) VALUES (@sensorname, @sensortype)";

                    //assigning SQL variables
                    SqlConnection conn = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                    //SQL parameters (to improve DB security)
                    //for Sensor Name
                    var sensorNameParameter = new SqlParameter("sensorname", System.Data.SqlDbType.VarChar);
                    sensorNameParameter.Value = txtSensorName.Text;
                    cmd.Parameters.Add(sensorNameParameter);
                    //for Sensor Type
                    var sensorTypeParameter = new SqlParameter("sensortype", System.Data.SqlDbType.VarChar);
                    sensorTypeParameter.Value = txtSensorType.Text;
                    cmd.Parameters.Add(sensorTypeParameter);

                    //Open conn, execute sql and close conn
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    //Reload records
                    MessageBox.Show("Data saved!");
                }
                else
                {
                    MessageBox.Show("Fill out all text box!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Cell click data bind
        private void dataRecordsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    //select entire row
                    dataRecordsView.Rows[e.RowIndex].Selected = true;

                    //retrieve data of selected row
                    DataGridViewRow selectedRow = dataRecordsView.Rows[e.RowIndex];

                    //bind data to textboxes
                    idLabel.Text = selectedRow.Cells["ID"].Value.ToString();
                    txtSensorName.Text = selectedRow.Cells["SensorName"].Value.ToString();
                    txtSensorType.Text = selectedRow.Cells["SensorType"].Value.ToString();

                    //enable buttons
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Update records
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataRecordsView.SelectedRows.Count > 0)
                {
                    //retrieve ID from table
                    int selectedId = Convert.ToInt32(dataRecordsView.SelectedRows[0].Cells["ID"].Value);

                    //check if textbox is empty
                    if (!string.IsNullOrWhiteSpace(txtSensorName.Text) && !string.IsNullOrWhiteSpace(txtSensorType.Text))
                    {
                        //SQL
                        string sqlQuery = "UPDATE tbl_Sensor SET SensorName=@SensorName, SensorType=@SensorType WHERE ID = @ID";

                        //assign sql connection and query
                        SqlConnection conn = new SqlConnection(connectionString);
                        SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                        //assign value from form to query 
                        cmd.Parameters.AddWithValue("@ID", idLabel.Text);
                        cmd.Parameters.AddWithValue("@SensorName", txtSensorName.Text);
                        cmd.Parameters.AddWithValue("@SensorType", txtSensorType.Text);

                        //Open conn, execute sql and close conn
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Record successfully updated!");

                        //clear out textbox
                        idLabel.Text = string.Empty;
                        txtSensorName.Text = string.Empty;
                        txtSensorType.Text = string.Empty;

                        //enable buttons
                        btnDelete.Enabled = false;
                        btnUpdate.Enabled = false;

                        //reload records
                        LoadRecords();
                    }
                    else
                    {
                        MessageBox.Show("Fill out all boxes!");
                    }
                }
                else
                {
                    MessageBox.Show("No selected data!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Delete records
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataRecordsView.SelectedRows.Count > 0)
                {
                    //retrieve ID from records
                    int selectedId = Convert.ToInt32(dataRecordsView.SelectedRows[0].Cells["ID"].Value);

                    //Confirm deletion
                    DialogResult resultConfirm = MessageBox.Show(
                        "Are you sure you want to delete this record?",
                        "Confirm Deletion", MessageBoxButtons.YesNo);

                    //if user chose Yes
                    if (resultConfirm == DialogResult.Yes)
                    {
                        //SQL
                        string sqlQuery = "DELETE FROM tbl_Sensor WHERE ID = @ID";

                        //SQL connection and strings
                        SqlConnection conn = new SqlConnection(connectionString);
                        SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                        //assign value from form to query 
                        cmd.Parameters.AddWithValue("@ID", idLabel.Text);

                        //Open conn, execute sql and close conn
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Record successfully deleted!");

                        //clear out textbox
                        idLabel.Text = string.Empty;
                        txtSensorName.Text = string.Empty;
                        txtSensorType.Text = string.Empty;

                        //enable buttons
                        btnDelete.Enabled = false;
                        btnUpdate.Enabled = false;

                        //reload records
                        LoadRecords();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //Methods
        //retrieve all records
        private void LoadRecords()
        {
            try
            {
                //SQL
                string sqlQuery = "SELECT * FROM tbl_Sensor";

                //connection and execution
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                //display data to datagrid
                adapter.Fill(dataTable);
                dataRecordsView.DataSource = dataTable;

                //datagrid design
                dataRecordsView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataRecordsView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataRecordsView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
