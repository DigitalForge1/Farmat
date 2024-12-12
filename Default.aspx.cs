using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmat
{
    public partial class farmat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                createBase();
        }


        private DataTable createBase()
        {
            string connectionString = "Data Source=192.168.0.97;Initial Catalog = oktell; Persist Security Info=True;User ID = root; Password=web";
            string zapros = "select number, city, address, brand, legalFace, WorkingHours, phone from BasePharmacyFarmat order by address";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString)) 
            {
                using (SqlCommand cmd = new SqlCommand(zapros))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                   
                        
                            sda.Fill(dt);
                           GridView1.DataSource = dt;
                           GridView1.DataBind();
                        
                    }
                }
            }
            return dt;
        }

        protected void select_OnClick_linkBtn(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            // GridView1.Rows[gvrow.RowIndex].Cells[2].Text
            

            string connectionString = "Data Source=192.168.0.97;Initial Catalog = oktell; Persist Security Info=True;User ID = root; Password=web";
            string zapros = $"select phone from BasePharmacyFarmat where number = '{GridView1.Rows[gvrow.RowIndex].Cells[0].Text}'";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(zapros, con))
                {
                    con.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        //string phone = sqlDataReader["phone"].ToString();
                        //System.Diagnostics.Debug.WriteLine(phone);
                        phoneTB.Text = sqlDataReader["phone"].ToString();
                    }
                    sqlDataReader.Close();
                    con.Close();
                }
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            var chainid = HttpContext.Current.Request.QueryString["Chainid"];
            var s = sender.GetType();
            var button = (Button)sender;
            GridViewRow row = (GridViewRow)button.Parent.Parent;
            string forwardingNumber = "";
            try
            {
                forwardingNumber = row.Cells[6].Text;
            }
            catch (Exception)
            {

                //throw;
            }
            if (!string.IsNullOrEmpty(forwardingNumber))
                SetFil(forwardingNumber, chainid);
        }

        private void SetFil(string forwardingNumber, string Chainid)
        {
            string connectionString = "Data Source=192.168.0.97;Initial Catalog = oktell; Persist Security Info=True;User ID = root; Password=web";

            string zapros = $"update ApteknayAsetFarmatek set forwardingNumber ='{forwardingNumber}' where Chainid ='{Chainid}'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(zapros))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

            protected void Button1_Click(object sender, EventArgs e)
        {
           DataTable dt =  createBase();
            if (TextBox1.Text.Length != 0)
            {
                if (TextBox1.Text.Substring(TextBox1.Text.Length - 1) == " ")
                {
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
                }

                string searchString =  TextBox1.Text.ToLower().Replace('ё', 'е'); //получить слова запроса

                var sortedRows = dt.AsEnumerable()
                    .Where(row => row.Field<string>("address").ToLower().Split(' ')
                        .Any(word => word.Contains(searchString)))
                    .OrderByDescending(row => row.Field<string>("address").Split(' ')
                        .Any(word => word.Equals(searchString, StringComparison.OrdinalIgnoreCase)));

                // Выполнение поиска и сортировка результатов
                if (sortedRows.Any())
                {
                    // Найдены соответствующие строки
                    GridView1.DataSource = sortedRows.CopyToDataTable();
                }
                else
                {
                    // Не найдено соответствующих строк
                    GridView1.DataSource = string.Empty; // Или другое представление пустой строки
                }

                GridView1.DataBind();
            }
            else
            {
                TextBox1.BorderColor = System.Drawing.Color.Red;
            }
        }


    }
}