using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook;
using System.Web.Script.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        var accessToken = "CAACEdEose0cBABbdD47ft0UZBjVFl7Ck88KvBi7lZAfyhi7h06thszhqTb3MyZApFXMx76sxVAZAmGJ0s8oa58r59utJNstSCNpzzoCqR83MZApB8Dhnux3ATypVA3ShlfwXcNUr3M6ZBprXtyI8RIEK0JyzwZCEVWs2HoaRXCQbAZDZD";
        //var client = new FacebookClient(accessToken);
        //dynamic me = client.Get("me");
        
        //dynamic albums = client.Get("me/albums");
        //foreach (dynamic albumInfo in albums.data)
        //{

        //    string folderName = albumInfo.name;

        //    Response.Write(folderName);

        //    dynamic albumsPhotos = client.Get(albumInfo.id + "/photos");
            
        //    foreach (dynamic photo in albumsPhotos)
        //    {


        //    }


        //} 

        #region JSON.Net Friends

        //Friends URL
        string url;

        //url = "https://graph.facebook.com/me/friends?access_token=" + accessToken;
        url = "https://graph.facebook.com/me/friends?access_token=" + accessToken;

        JObject myFriends = JObject.Parse(requestFBData(url));

        string id = "";
        string name = "";

        //Loop through the returned friends
        foreach (var i in myFriends["data"].Children())
        {
            id = i["id"].ToString().Replace("\"", "");
            name = i["name"].ToString().Replace("\"", "");
            lblFriends.Text = lblFriends.Text + "<br/> " + "id: " + id + " name: " + name + "<img src=" + "https://graph.facebook.com/" + id + "/picture>";
        }

        #endregion


        ////#region JSON.Net Friends

        //////Friends URL
        ////string url;

        ////url = "https://graph.facebook.com/10151398906921930?access_token=" + accessToken;

        ////JObject myCurrentAlbum = JObject.Parse(requestFBData(url));

        ////string id = "";
        ////string name = "";

        //////Loop through the returned friends
        ////foreach (var i in myCurrentAlbum["images"].Children())
        ////{
        ////    try
        ////    {
        ////        id = i["source"].ToString().Replace("\"", "");
        ////        lblFriends.Text = lblFriends.Text + "<br/> " + "<img src=" + id + ">";
        
        ////    }
        ////    catch (Exception)
        ////    {
                
        ////     //   throw;
        ////    }

        //// }

        ////#endregion
    }


    public string requestFBData(string action)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(action);
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

        StreamReader sr = new StreamReader(resp.GetResponseStream());
        string results = sr.ReadToEnd();
        sr.Close();

        return results;
        }
}