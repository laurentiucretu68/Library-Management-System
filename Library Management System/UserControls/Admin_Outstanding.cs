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
    public partial class Admin_Outstanding : UserControl
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
        public Admin_Outstanding()
        {
            InitializeComponent();
            String commandString = String.Format(@"select cit.id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_inscrierii, 
                                                    round( MONTHS_BETWEEN(SYSDATE, data_nasterii)/12) || ' ani' Varsta, 
                                                        case count(imp.id_cititor)
                                                        when 0 then 'niciuna'
                                                        else to_char(count(imp.id_cititor))
                                                        end as Carti_imprumutate
                                                    from cititori cit left
                                                    join imprumuta imp on cit.id_cititor = imp.id_cititor
                                                    group by cit.id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii
                                                    order by 1");
            updateData(commandString);
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            String commandString;
            if (!string.IsNullOrEmpty(search.Text.ToString()))
            {
                commandString = String.Format(@"select cit.id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_inscrierii, 
                                                    round( MONTHS_BETWEEN(SYSDATE, data_nasterii)/12) || ' ani' Varsta, 
                                                        case count(imp.id_cititor)
                                                        when 0 then 'niciuna'
                                                        else to_char(count(imp.id_cititor))
                                                        end as Carti_imprumutate
                                                    from cititori cit left
                                                    join imprumuta imp on cit.id_cititor = imp.id_cititor
                                                    where trim(lower(cit.prenume_cititor)) like '%{0}%'
                                                    or trim(lower(cit.nume_cititor)) like '%{0}%'
                                                    or trim(lower(cit.email_cititor)) like '%{0}%'
                                                    or trim(lower(cit.telefon_cititor)) like '%{0}%'
                                                    group by cit.id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii
                                                    order by 1", search.Text.ToLower().ToString());
            }
            else
            {
                commandString = String.Format(@"select cit.id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_inscrierii, 
                                                    round( MONTHS_BETWEEN(SYSDATE, data_nasterii)/12) || ' ani' Varsta, 
                                                        case count(imp.id_cititor)
                                                        when 0 then 'niciuna'
                                                        else to_char(count(imp.id_cititor))
                                                        end as Carti_imprumutate
                                                    from cititori cit left
                                                    join imprumuta imp on cit.id_cititor = imp.id_cititor
                                                    group by cit.id_cititor, nume_cititor, prenume_cititor, telefon_cititor, email_cititor, data_nasterii, data_inscrierii
                                                    order by 1");
            }
            updateData(commandString);
        }
    }
}
