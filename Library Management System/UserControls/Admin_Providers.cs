using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Library_Management_System.UserControls
{
    public partial class Admin_Providers : UserControl
    {
        void updateData(String commandString)
        {
            using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
            {
                try
                {
                    connection.Open();
                    OracleDataAdapter datAd = new OracleDataAdapter(commandString, connection);
                    DataTable dt = new DataTable();
                    datAd.Fill(dt);
                    continutTab.DataSource = dt;

                    continutTab.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    continutTab.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    connection.Close();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }
        }
        public Admin_Providers()
        {
            InitializeComponent();
            using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
            {
                try
                {
                    connection.Open();
                    String commandString = String.Format(@"create or replace view furnizori_carti_complex as
                                                            select nume_furnizor, count(car.id_carte) carti_furnizate
                                                            from furnizori furn left join carti car on furn.id_furnizor = car.id_furnizor
                                                            where (select count(scr.id_autor)
                                                                from scrie scr
                                                                where scr.id_carte = car.id_carte) > 1
                                                            group by nume_furnizor");

                    var cmd = new OracleCommand(commandString, connection);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();

                    commandString = String.Format(@"select *from furnizori_carti_complex order by 1");
                    updateData(commandString);
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            String commandString;
            if (!string.IsNullOrEmpty(search.Text.ToString()))
            {
                commandString = String.Format(@"select * from furnizori_carti_complex
                                                    where trim(lower(titlu) like '%{0}%' ", search.Text.ToString());
            }
            else
            {
                commandString = String.Format(@"select * from furnizori_carti_complex");
            }
            updateData(commandString);
        }
    }
}
