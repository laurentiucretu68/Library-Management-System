using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Library_Management_System.UserControls
{
    public partial class User_BorrowedBooks : UserControl
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
        public User_BorrowedBooks(int userId)
        {
            InitializeComponent();
            String commandString = String.Format(@"select titlu, data_imprumut, data_returnare
                                                    from imprumuta imp left join cititori cit on imp.id_cititor = cit.id_cititor
                                                    join carti cart on imp.id_carte = cart.id_carte
                                                    where imp.id_cititor='{0}' order by data_imprumut desc", userId);
            updateData(commandString);
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            String commandString;
            if (!string.IsNullOrEmpty(search.Text.ToString()))
            {
                commandString = String.Format(@"select titlu, data_imprumut, data_returnare
                                                    from imprumuta imp left join cititori cit on imp.id_cititor = cit.id_cititor
                                                    join carti cart on imp.id_carte = cart.id_carte
                                                    where imp.id_cititor='{0}'
                                                    and trim(lower(titlu) like '%{1}%'
                                                    order by data_imprumut desc", idCititor.Text.ToString(), search.Text.ToString());
            }
            else
            {
                commandString = String.Format(@"select titlu, data_imprumut, data_returnare
                                                    from imprumuta imp left join cititori cit on imp.id_cititor = cit.id_cititor
                                                    join carti cart on imp.id_carte = cart.id_carte
                                                    where imp.id_cititor='{0}' order by data_imprumut desc", idCititor.Text.ToString());
            }
            updateData(commandString);
        }

        private void User_BorrowedBooks_Load(object sender, EventArgs e)
        {
            
        }
    }
}
