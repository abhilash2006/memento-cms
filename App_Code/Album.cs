﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Album
/// </summary>
public class Album
{

    public string name {get;set;}

    public string permalink {get;set;}
    
    public string cover_image_url {get;set;}
    
    public int id {get;set;}

    public string artist_name { get; set; } 
}

public class Albums
{
    List<Album> albums { get; set; }
}