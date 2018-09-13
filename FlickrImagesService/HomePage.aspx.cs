using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services.Description;
using System.Drawing;
using System.Drawing.Imaging;
using FlickrImagesService;

namespace FlickrImagesService
{
    public partial class HomePage : System.Web.UI.Page
    {

        string flickrKey = "f5e04efeea970bef40fa5fadb43b014b";
        string sharedSecret = "87e4edc04e08aae2";
        string location = string.Empty;
        string query = "Landscape";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                SearchTextBox.Text = location;
                GetPhotos(location);
                Literal HiddenPhotoId =
                   ThumbnailsList.Items[0].FindControl("HiddenPhotoId") as Literal;
                Literal HiddenPhotoUrl =
                   ThumbnailsList.Items[0].FindControl("HiddenPhotoUrl") as Literal;
                string photoId = HiddenPhotoId.Text;
                string photoUrl = HiddenPhotoUrl.Text;
                PreviewImage.ImageUrl = photoUrl;
                GetDescription(photoId);
            }
        }

        private void GetPhotos(string tag)
        {
            // get the images for the location specified 
            PhotoSearchOptions options = new PhotoSearchOptions();
            options.PerPage = 30;
            options.Page = 30;
            options.SortOrder = PhotoSearchSortOrder.Relevance;
            options.MediaType = MediaType.Photos;
            options.Extras = PhotoSearchExtras.All;
            options.Text = query;
            options.Tags = tag;

            Flickr flickr = new Flickr(flickrKey, sharedSecret);
            PhotoCollection photos = flickr.PhotosSearch(options);

            ThumbnailsList.DataSource = photos;
            ThumbnailsList.DataBind();
        }


        private void GetDescription(string photoId)
        {
            Flickr flickr = new Flickr(flickrKey, sharedSecret);
            PhotoInfo info = flickr.PhotosGetInfo(photoId);

            PhotoDescription.Text = info.Description;
            PhotoMetadata.Text = info.DateTaken.ToString("MMMM dd,  yyyy");

        }

        protected void GoButton_Click(object sender, EventArgs e)
        {
            string keyword = SearchTextBox.Text.Trim();
            GetPhotos(keyword);
        }

        protected void ThumbnailsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Literal HiddenPhotoId =
               ThumbnailsList.SelectedItem.FindControl("HiddenPhotoId") as Literal;
            Literal HiddenPhotoUrl =
               ThumbnailsList.SelectedItem.FindControl("HiddenPhotoUrl") as Literal;

            string photoId = HiddenPhotoId.Text;
            string photoUrl = HiddenPhotoUrl.Text;

            PreviewImage.ImageUrl = photoUrl;
            GetDescription(photoId);
            insert(photoId);
        }
        public string AddImageDetail(ImageDetails imgDetail)
        {

            //SQL database Connection String 
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                                      
                    SqlCommand com = new SqlCommand("usp_UploadImage", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ImgID", imgDetail.id);
                    com.Parameters.AddWithValue("@ImgName", imgDetail.ImageName);
                    com.Parameters.AddWithValue("@ImageData", imgDetail.ImageData);
                    com.Parameters.AddWithValue("@ImageDescription", imgDetail.ImageDescription);
                    com.Parameters.AddWithValue("@ImageDate", imgDetail.ImageDate);
                    com.Parameters.AddWithValue("@ImageLocation", imgDetail.ImageLocation);

                    con.Open();
                    int i = com.ExecuteNonQuery();
                    con.Close();
                   return lblErrors.Text = "Image Added Successfully";
                    
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

        public void insert(string photoId)
        {

            //Save the Image selected to the database 
            List<ImageDetails> detailList = new List<ImageDetails>();
            Flickr flickr = new Flickr(flickrKey, sharedSecret);
            PhotoInfo info = flickr.PhotosGetInfo(photoId);

            ImageDetails imgDetail = new ImageDetails();
            imgDetail.id = info.PhotoId;
            imgDetail.ImageName = info.Title;
            imgDetail.ImageDescription = info.Description;
            imgDetail.ImageData = info.SmallUrl;
            imgDetail.ImageDate = info.DatePosted;
            imgDetail.ImageLocation = SearchTextBox.Text.ToString();

            detailList.Add(imgDetail);
            AddImageDetail(imgDetail);
        }
    }
}