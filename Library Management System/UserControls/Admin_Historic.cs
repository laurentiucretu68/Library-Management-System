using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Library_Management_System.UserControls
{
    public partial class Admin_Historic : UserControl
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

        public Admin_Historic()
        {
            InitializeComponent();
            String commandString = String.Format(@"select prenume_cititor || ' ' || nume_cititor as Cititor, count(car.id_carte) as Numar_imprumuturi, 
                                                    sum(nvl(numar_pagini,0)) as Pagini_citite
                                                    from cititori cit join imprumuta imp on cit.id_cititor = imp.id_cititor
                                                    join carti car on imp.id_carte = car.id_carte
                                                    group by prenume_cititor, nume_cititor
                                                    having count(car.id_carte) >= 2 and sum(nvl(numar_pagini,0)) >= 500
                                                    order by 2");
            updateData(commandString);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String commandString;
            if (!string.IsNullOrEmpty(textBox1.Text.ToString()))
            {
                commandString = String.Format(@"select prenume_cititor || ' ' || nume_cititor as Cititor, count(car.id_carte) as Numar_imprumuturi, 
                                                    sum(nvl(numar_pagini,0)) as Pagini_citite
                                                    from cititori cit join imprumuta imp on cit.id_cititor = imp.id_cititor
                                                    join carti car on imp.id_carte = car.id_carte
                                                    where trim(lower(cit.prenume_cititor)) like '%{0}%'
                                                    or trim(lower(cit.nume_cititor)) like '%{0}%'
                                                    group by prenume_cititor, nume_cititor
                                                    having count(car.id_carte) >= 2 and sum(nvl(numar_pagini,0)) >= 500
                                                    order by 2", textBox1.Text.ToLower().ToString());
            }
            else
            {
                commandString = String.Format(@"select prenume_cititor || ' ' || nume_cititor as Cititor, count(car.id_carte) as Numar_imprumuturi, 
                                                    sum(nvl(numar_pagini,0)) as Pagini_citite
                                                    from cititori cit join imprumuta imp on cit.id_cititor = imp.id_cititor
                                                    join carti car on imp.id_carte = car.id_carte
                                                    group by prenume_cititor, nume_cititor
                                                    having count(car.id_carte) >= 2 and sum(nvl(numar_pagini,0)) >= 500
                                                    order by 2");
            }
            updateData(commandString);
        }
    }
}
