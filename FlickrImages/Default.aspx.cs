using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlickrImages
{
    public partial class _Default : Page
    {

        string flickrKey = "f5e04efeea970bef40fa5fadb43b014b";
        string sharedSecret = "87e4edc04e08aae2";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string defaultKeyword = "LandMarks";
                SearchTextBox.Text = defaultKeyword;
                GetPhotos(defaultKeyword);

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
            PhotoSearchOptions options = new PhotoSearchOptions();
            options.PerPage = 12;
            options.Page = 1;
            options.SortOrder = PhotoSearchSortOrder.DatePostedDescending;
            options.MediaType = MediaType.Photos;
            options.Extras = PhotoSearchExtras.All;
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
        }

    }
}