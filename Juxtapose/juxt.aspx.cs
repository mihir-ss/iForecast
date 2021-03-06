﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Linq;


public partial class juxt : System.Web.UI.Page
{
    public string json = "1";

    protected void Page_Load(object sender, EventArgs e)
    {
        string title1 = Request["s1"];
        string title2 = Request["s2"];

        double threshold = double.Parse(Request["th"]);

        string file1 = File.ReadAllText(Server.MapPath("..\\Data\\" + title1 + "\\main.csv"));
        string file2 = File.ReadAllText(Server.MapPath("..\\Data\\" + title2 + "\\main.csv"));

        string[] rec1 = file1.Split(new char[] { '\n' });
        string[] rec2 = file2.Split(new char[] { '\n' });

        string[] rect1_temp = rec1.SubArray(1, rec1.Length - 2);
        double[] dat1 = rect1_temp.Select(x => double.Parse(x.Split(new char[] { ',' })[1])).ToArray();

        string[] rect2_temp = rec2.SubArray(1, rec1.Length - 2);
        double[] dat2 = rect2_temp.Select(x => double.Parse(x.Split(new char[] { ',' })[1])).ToArray();

        Juxtapose jux = new Juxtapose(dat1, dat2, threshold);
        json = jux.GetJSON();
    }
}