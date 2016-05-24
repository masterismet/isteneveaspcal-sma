using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BaglantiVeritabani
/// </summary>
public class BaglantiVeritabani
{
    protected Baglanti _baglanti = new Baglanti();
    public BaglantiVeritabani()
    {
        if (_baglanti == null)
            _baglanti = new Baglanti();
    }

}