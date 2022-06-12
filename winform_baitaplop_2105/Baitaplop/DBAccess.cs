using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplop
{
    public class DBAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;

        static SqlConnection sqlConnection { get; set; }
        SqlCommand cmd { get; set; }
        SqlDataReader reader { get; set; }

        string query;

        ConnectionState isOpen = ConnectionState.Open;

        public DBAccess()
        {
            if(sqlConnection == null)
            {
                sqlConnection = new SqlConnection(connectionString);
                connect();
            }
        }

        public void connect()
        {
            if(sqlConnection.State != isOpen)
                sqlConnection.Open();
            else
            {
                disconnect();
                connect();
            }
        }

        public static void disconnect()
        {
            sqlConnection.Close();
        }

        public bool isAdmin = false;

        public bool login(string username, string password)
        {
            query = "select * from account where username='" + username 
                                            + "' and pass='" + password + "'";
            try
            {
                connect();
                Console.WriteLine(query);
                cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader rd = cmd.ExecuteReader();
                bool isReaderHasData = rd.Read();
                if (isReaderHasData) isAdmin = (bool)rd["isAdmin"];
                return isReaderHasData;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw new Exception("SqlException: fail to connect to SQL Server" + e.Message);
            }
            catch(Exception eg)
            {
                Console.WriteLine(eg.StackTrace);
                throw new Exception("Exception: fail to connect to SQL Server" + eg.Message);
            }
        }

        public static SqlConnection KetNoi()
        {
            sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

        public static DataTable LayDuLieu(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, KetNoi());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static string sql;
        public static string TaoMa(string FieldName, string Table)
        {
            long num = 1;
            sql = "Select Top 1 " + FieldName + " From " + Table + " Order By " + FieldName + " Desc";
            DataTable dt = LayDuLieu(sql);
            if (dt.Rows.Count > 0)
                num = long.Parse(dt.Rows[0][FieldName].ToString()) + 1;
            return num.ToString("0000000000");
        }

        public static void GanNguonDataGridView(DataGridView dgName, string sql)
        {
            dgName.DataSource = LayDuLieu(sql);
        }

        public static void checkFolder()
        {
            string folderName = Application.StartupPath + "\\Export";
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
        }
        public static void XuatFileExcel(DataGridView dataGridView1, string fileName)
        {
            /*khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
                - vào menu Project / chọn add reference..
                - chọn mục COM
                - tìm và tích chọn Microsoft Excel [xx.x] Object Library
                - nếu trước cài bản office cao hơn và bị báo lỗi Unable to cast COM object of type 'Microsoft.Office.Interop.Excel.ApplicationClass' to interface type 'Microsoft.Office.Interop.Excel._Application'. This operation failed because the QueryInterface call on the COM component for the interface with IID '{000208D5-0000-0000-C000-000000000046}
                    + vào run, gõ regedit để mở thanh ghi
                    + Computer\HKEY_CLASSES_ROOT\TypeLib\{00020813-0000-0000-C000-000000000046} xóa thư mục 1.9 giữ lại mục có nội dung Microsoft Excel [xx.x] Object Library
                    + Computer\HKEY_CLASSES_ROOT\TypeLib\{00020905-0000-0000-C000-000000000046} giữ lại mục có nội dung Microsoft Word xx.x Object Library
            */
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                excel.DisplayAlerts = false;

                workbook = excel.Workbooks.Add(Type.Missing);//tạo mới một Workbooks bằng phương thức add()
                worksheet = null;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                //xuất danh sách tiêu đề cột
                for (int i = 0; i < dataGridView1.ColumnCount; i++)//tạo dòng tiêu đề từ cột trong DataGridView
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                //xuất danh sách nội dung dòng
                for (int i = 0; i < dataGridView1.RowCount; i++)//xuất nội dung các dòng tiếp theo
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = "'" + dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                //thay đổi độ rộng cột theo dữ liệu - tạo đường khung viền cho bảng
                excelCellrange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[dataGridView1.RowCount + 1, dataGridView1.ColumnCount]];
                excelCellrange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;
                //tô màu chữ, màu nền cho dòng đầu tiên
                excelCellrange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dataGridView1.ColumnCount]];
                excelCellrange.Interior.Color = System.Drawing.Color.Blue;
                excelCellrange.Font.Color = System.Drawing.Color.White;
                
                //lưu tập tin
                workbook.SaveAs(Application.StartupPath + "\\Export\\" + DateTime.Now.ToString("yyyyMMdd_HHmmss_") + fileName);
                ////đóng tập tin
                //workbook.Close();
                ////thoát khỏi excel
                //excel.Quit();
                ////mở tập tin trên máy qua đường dẫn
                //Process.Start("Explorer.exe", fileName);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                worksheet = null;
                workbook = null;
            }
        }

    }
}
