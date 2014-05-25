using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();

        Response.Write("Hello world!");

        var input = Request.InputStream;
        input.Seek(0, System.IO.SeekOrigin.Begin);
        string text = new StreamReader(input).ReadToEnd();

        Response.Write(text);

        Response.End();
    }
}