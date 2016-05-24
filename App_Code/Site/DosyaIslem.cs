using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;

/// <summary>
/// Summary description for dosyaYukle
/// </summary>
public class DosyaIslem
{
	public DosyaIslem()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string Kaydet(FileUpload isim, string yol,string fileGroup)
    {
        string filename = "";
        HttpPostedFile postedFile = isim.PostedFile;
        if (postedFile != null && postedFile.ContentLength > 0)
        {
            string filePath = postedFile.FileName; //ilk olarak desktop olarak filename alır
            FileInfo clientFileInfo = new FileInfo(filePath);
            string dosyaAdi = clientFileInfo.Name;
            filename = fileGroup + dosyaAdi.Remove(0, dosyaAdi.Length - 4); // Dosya adı

            string serverPath = HttpContext.Current.Server.MapPath("."); // Ana Dizinimiz
            string yeniPath = serverPath + "/" + yol + "/" + filename; // Yeni Yolumuz
            postedFile.SaveAs(yeniPath);
        }
        return filename;
    }
}
