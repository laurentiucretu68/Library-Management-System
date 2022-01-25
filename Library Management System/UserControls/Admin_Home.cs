using Oracle.ManagedDataAccess.Client;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Globalization;

namespace Library_Management_System.UserControls
{
    public partial class Admin_Home : UserControl
    {
        public Admin_Home()
        {
            InitializeComponent();
            using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
            {
                try
                {
                    connection.Open();

                    var today = DateTime.Today;
                    var month = new DateTime(today.Year, today.Month, 1);
                    var first = month.AddMonths(-1);
                    var last = month.AddDays(-1);

                    titluStatistica.Text = "Statistici luna " + first.ToString("MMMM", new CultureInfo("ro-RO"));

                    String lunaSelect, anSelect;
                    if (DateTime.Now.ToString("MMMM", new CultureInfo("ro-RO")) == "ianuarie")
                    {
                        lunaSelect = first.ToString("MMMM", CultureInfo.InvariantCulture).ToLower();
                        anSelect = first.ToString("yyyy", CultureInfo.InvariantCulture).ToLower();
                    }
                    else
                    {
                        lunaSelect = first.ToString("MMMM", CultureInfo.InvariantCulture).ToLower();
                        anSelect = DateTime.Now.ToString("yyyy", CultureInfo.InvariantCulture).ToLower();
                    }
                 
                    String commandString = String.Format(@"select count(*) from imprumuta where trim(lower(to_char(data_imprumut, 'month'))) = '{0}' and trim(lower(to_char(data_imprumut, 'yyyy'))) = '{1}'", lunaSelect, anSelect);
                    var cmd = new OracleCommand(commandString, connection);
                    var dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                        imprumuturi.Text = dr.GetString(0);

                    commandString = String.Format(@"select count(*) from imprumuta where trim(lower(to_char(data_imprumut, 'month'))) = '{0}' and trim(lower(to_char(data_imprumut, 'yyyy'))) = '{1}' and data_returnare is null", lunaSelect, anSelect);
                    cmd = new OracleCommand(commandString, connection);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                        nereturnate.Text = dr.GetString(0);

                    commandString = String.Format(@"select count(*) from cititori where trim(lower(to_char(data_inscrierii, 'month'))) = '{0}' and trim(lower(to_char(data_inscrierii, 'yyyy'))) = '{1}'", lunaSelect, anSelect);
                    cmd = new OracleCommand(commandString, connection);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                        cititori.Text = dr.GetString(0);


                    int[] imprumuturiLuni = new int[12];

                    anSelect = first.ToString("yyyy", CultureInfo.InvariantCulture).ToLower();
                    commandString = String.Format(@"select to_char(data_imprumut, 'mm'), count(*) from imprumuta where trim(lower(to_char(data_imprumut, 'yyyy'))) = trim(lower('{0}')) group by EXTRACT(month FROM data_imprumut), to_char(data_imprumut, 'mm') order by EXTRACT(month FROM data_imprumut)", anSelect);
                    cmd = new OracleCommand(commandString, connection);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr.GetString(0) == "01")
                                imprumuturiLuni[0] = Int32.Parse(dr.GetString(1));

                            if (dr.GetString(0) == "02")
                                imprumuturiLuni[1] = Int32.Parse(dr.GetString(1));

                            if (dr.GetString(0) == "03")
                                imprumuturiLuni[2] = Int32.Parse(dr.GetString(1));

                            if (dr.GetString(0) == "04")
                                imprumuturiLuni[3] = Int32.Parse(dr.GetString(1));

                            if (dr.GetString(0) == "05")
                                imprumuturiLuni[4] = Int32.Parse(dr.GetString(1));

                            if (dr.GetString(0) == "06")
                                imprumuturiLuni[5] = Int32.Parse(dr.GetString(1));

                            if (dr.GetString(0) == "07")
                                imprumuturiLuni[6] = Int32.Parse(dr.GetString(1));

                            if (dr.GetString(0) == "08")
                                imprumuturiLuni[7] = Int32.Parse(dr.GetString(1));

                            if (dr.GetString(0) == "09")
                                imprumuturiLuni[8] = Int32.Parse(dr.GetString(1));

                            if (dr.GetString(0) == "10")
                                imprumuturiLuni[9] = Int32.Parse(dr.GetString(1));

                            if (dr.GetString(0) == "11")
                                imprumuturiLuni[10] = Int32.Parse(dr.GetString(1));

                            if (dr.GetString(0) == "12")
                                imprumuturiLuni[11] = Int32.Parse(dr.GetString(1));
                        }

                    }

                    graficImprumuturi.AxisX.Add(new LiveCharts.Wpf.Axis
                    {
                        Labels = new[] { "Ianuarie", "Februarie", "Martie", "Aprilie", "Mai", "Iunie", "Iulie", "August", "Septembrie", "Octombrie", "Noiembrie", "Decembrie" },
                    });

                    SolidColorBrush color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(73, 42, 109));
                    color.Opacity = 0.2;

                    graficImprumuturi.AxisY.Clear();

                    graficImprumuturi.AxisY.Add(
                    new Axis
                    {
                        MinValue = 0
                    });


                    graficImprumuturi.Series.Add(new LineSeries
                    {
                        Values = new ChartValues<int>(imprumuturiLuni),
                        StrokeThickness = 3,
                        Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(73, 42, 109)),
                        PointGeometrySize = 10,
                        Fill = color,
                        PointForeground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(73, 42, 109)),
                        Title = "Nr. imprumuturi:"
                    });

                    

                    commandString = "select count(*) from carti";
                    cmd = new OracleCommand(commandString, connection);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        totalCarti.Value = Int32.Parse(dr.GetString(0));
                        totalCarti.Text = dr.GetString(0);
                    }

                    commandString = "select count(*) from carti where id_furnizor is null";
                    cmd = new OracleCommand(commandString, connection);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        cartiDonate.Value = Int32.Parse(dr.GetString(0));
                        cartiDonate.Text = dr.GetString(0);
                    }

                    cmd.Dispose();
                    dr.Dispose();
                    connection.Close();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Eroare("+ ex.ToString() +")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }

        }

        private void Admin_Home_Load(object sender, EventArgs e)
        {
            
        }
    }
}
