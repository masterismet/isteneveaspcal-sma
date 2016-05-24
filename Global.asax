<%@ Application Language="C#" %>

<script runat="server">

    void Application_BeginRequest(Object sender, EventArgs e)
    {
        string DosyaYolu = Request.RawUrl;

        string url = HttpContext.Current.Request.RawUrl;


        if (url.Contains("Ilan-"))
        {
            string Hamisim = url.Substring(url.IndexOf("Ilan-") + 5);
            int Slashindex = Hamisim.IndexOf("-");
            string id = Hamisim.Substring(0, Slashindex);
            HttpContext.Current.RewritePath("~/IlanDetay.aspx?IlanId=" + id, false);
        }
        else if (url.Contains("UyeDetay-"))
        {
            string Hamisim = url.Substring(url.IndexOf("UyeDetay-") + 9);
            int Slashindex = Hamisim.IndexOf("-");
            string id = Hamisim.Substring(0, Slashindex);
            HttpContext.Current.RewritePath("~/Uye.aspx?Uye=" + id, false);
        }
        else if (url.Contains("UyeIlan-"))
        {
            string Hamisim = url.Substring(url.IndexOf("UyeIlan-") + 8);
            int Slashindex = Hamisim.IndexOf("-");
            string id = Hamisim.Substring(0, Slashindex);
            HttpContext.Current.RewritePath("~/UyeIlanlar.aspx?Uye=" + id, false);
        }
        else if (url.Contains("IstenEveSayfa-"))
        {
            string Hamisim = url.Substring(url.IndexOf("IstenEveSayfa-") + 14);
            int Slashindex = Hamisim.IndexOf("-");
            string id = Hamisim.Substring(0, Slashindex);
            HttpContext.Current.RewritePath("~/SiteSayfa.aspx?id=" + id, false);
        }
        
        else if (url.Contains("Soru-Cevap-"))
        {
            string Hamisim = url.Substring(url.IndexOf("Soru-Cevap-") + 11);
            int Slashindex = Hamisim.IndexOf("-");
            string id = Hamisim.Substring(0, Slashindex);
            HttpContext.Current.RewritePath("~/Soru.aspx?id=" + id, false);
        }
        else if (url.Contains("Soru-Sor"))
        {
            HttpContext.Current.RewritePath("~/SoruSor.aspx", false);
        }
        else if (url.Contains("Ilanlar-Isveren"))
        {
            HttpContext.Current.RewritePath("~/Ilanlar.aspx?ilantip=1", false);
        }
        else if (url.Contains("Ilanlar-Is-Arayan"))
        {
            HttpContext.Current.RewritePath("~/Ilanlar.aspx?ilantip=2", false);
        }
    }

    
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
