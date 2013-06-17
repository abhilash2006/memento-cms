using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //http://facebooksdk.net/docs/web/getting-started/

        //var client = new FacebookClient();
        //dynamic me = client.Get("abhilasht");

        //string firstName = me.first_name;
        //string lastName = me.last_name;

        //Response.Write(firstName);
        //Response.Write(lastName);

            //dynamic albums = app.Get("me/albums");
            //foreach(dynamic albumInfo in albums.data)
            //{
            //   //Get the Pictures inside the album this gives JASON objects list that has photo attributes 
            //   // described here http://developers.facebook.com/docs/reference/api/photo/
            //   dynamic albumsPhotos = app.Get(albumInfo.id +"/photos");
            //}


        //var accessToken = "CAAGB8T5qUZA0BANBOnbmxwTANOaf10TrKHuOoLo6JnMqSbFoG9jveS727VB4DopxUfnes9zF3Bt1EqC11fGsinVYevyiX00ZBO4q2ZAse7WQbgFFZBIpy8XGKZBeiQZCeoV2UhPJHaLbsQKuMZCZBFRrrSdZAixnl7IfRQwqX26dciwZDZD";
        //var client = new FacebookClient(accessToken);
        //dynamic me = client.Get("me");
        //string aboutMe = me.about;

        //dynamic albums = client.Get("me/albums");
        //foreach (dynamic albumInfo in albums.data)
        //{
        //    //Get the Pictures inside the album this gives JASON objects list that has photo attributes 
        //    // described here http://developers.facebook.com/docs/reference/api/photo/
        //    dynamic albumsPhotos = client.Get(albumInfo.id + "/photos");
        //}


        //var fb = new Facebook.FacebookClient(token);
        //dynamic result = fb.Query(
        //    "SELECT uid2 FROM friend WHERE uid1=me()",
        //    "SELECT uid, name, pic_square, affiliations, birthday_date, sex, relationship_status, hometown_location, current_location, education_history, work_history, contact_email" +
        //    " FROM user WHERE (sex='male') AND uid IN (SELECT uid2 FROM #query0)"
        //);



    }
}