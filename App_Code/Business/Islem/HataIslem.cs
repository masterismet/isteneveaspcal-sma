using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HataIslem
/// </summary>
public class HataIslem : HataVeritabani
{
    public void HataEkle(Hata hata)
    {
        base.HataEkle(hata);
    }
    public DataTable HataListele()
    {
        return base.HataListele();
    }
}