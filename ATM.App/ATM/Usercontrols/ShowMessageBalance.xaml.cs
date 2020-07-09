using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATM.Usercontrols
{
    /// <summary>
    /// Interaction logic for ShowMessageBalance.xaml
    /// </summary>
    public partial class ShowMessageBalance : UserControl
    {
        public ShowMessageBalance()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.ShowAndHideUC("Login", null);
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {


        }
        //    private void FrmExport_Load(object sender, EventArgs e)
        //    {
        //        SqlConnection sqlCon;
        //        string conString = null;
        //        string sqlQuery = null;

        //        conString = "Data Source=.;Initial Catalog=DemoTest;Integrated Security=SSPI;";
        //        sqlCon = new SqlConnection(conString);
        //        sqlCon.Open();
        //        sqlQuery = "SELECT * FROM tblEmployee";
        //        SqlDataAdapter dscmd = new SqlDataAdapter(sqlQuery, sqlCon);
        //        DataTable dtData = new DataTable();
        //        dscmd.Fill(dtData);
        //        //dataGridView1.DataSource = dtData;
        //    }
        //    private void btnPdf_Click(object sender, EventArgs e)
        //    {
        //        //if (dataGridView1.Rows.Count > 0)
        //        {
        //            SaveFileDialog sfd = new SaveFileDialog();
        //            sfd.Filter = "PDF (*.pdf)|*.pdf";
        //            sfd.FileName = "Output.pdf";
        //            bool fileError = false;
        //            if (sfd.ShowDialog() == DialogResult.OK)
        //            {
        //                if (File.Exists(sfd.FileName))
        //                {
        //                    try
        //                    {
        //                        File.Delete(sfd.FileName);
        //                    }
        //                    catch (IOException ex)
        //                    {
        //                        fileError = true;
        //                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
        //                    }
        //                }
        //                if (!fileError)
        //                {
        //                    try
        //                    {
        //                        PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
        //                        pdfTable.DefaultCell.Padding = 3;
        //                        pdfTable.WidthPercentage = 100;
        //                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

        //                        foreach (DataGridViewColumn column in dataGridView1.Columns)
        //                        {
        //                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
        //                            pdfTable.AddCell(cell);
        //                        }

        //                        foreach (DataGridViewRow row in dataGridView1.Rows)
        //                        {
        //                            foreach (DataGridViewCell cell in row.Cells)
        //                            {
        //                                pdfTable.AddCell(cell.Value.ToString());
        //                            }
        //                        }

        //                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
        //                        {
        //                            Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
        //                            PdfWriter.GetInstance(pdfDoc, stream);
        //                            pdfDoc.Open();
        //                            pdfDoc.Add(pdfTable);
        //                            pdfDoc.Close();
        //                            stream.Close();
        //                        }

        //                        MessageBox.Show("Data Exported Successfully !!!", "Info");
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        MessageBox.Show("Error :" + ex.Message);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("No Record To Export !!!", "Info");
        //        }
        //    }
        //}
    }
}
