using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlickrImagesService
{
    public partial class SavedImages : System.Web.UI.Page
    {
        string location = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string SearchImage()
        {

            //SQL database Connection String 
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {

                    con.Open();
                    location = SearchTextBox.Text;
                    //SqlCommand com = con.CreateCommand();
                    //com.CommandType = CommandType.Text;
                    //com.CommandText = "SELECT ImageData FROM tblImageDetail WHERE ImageLocation =" + location;
                    SqlCommand com = new SqlCommand("usp_GetImageById", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ImageLocation", location);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt);
                    ThumbnailsList.DataSource = dt;
                    ThumbnailsList.DataBind();
                    con.Close();
                    return lblErrors.Text = "Uploaded Image";
                }
            }

            catch (SqlException ex)
            {

                // display error fot duplicate images 
                string str;
                str = "Source:" + ex.Source;
                str += "\n" + "Message:" + ex.Message;

                lblErrors.Text = str + "Database Exception";
                return lblErrors.Text = str + "Database Exception";
            }
        }

        protected void searchLoc_Click(object sender, EventArgs e)
        {
           // SearchTextBox.Text = location;
            SearchImage();
          
        }
    }
}