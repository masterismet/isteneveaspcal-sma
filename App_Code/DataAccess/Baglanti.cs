using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Baglanti
/// </summary>
public class Baglanti : IDisposable
{
    #region Const

    private const string _sunucu = ".\\sql2008r2";
    private const string _veritabani = "IstenEve";

    #endregion

    #region Degiskenler

    private SqlConnection _baglanti;
    private SqlCommand _komut;
    private SqlDataReader _veriOku;
    private DataTable _tablo;
    private IslemSonuc _islemSonuc;

    #endregion

    #region Constructors

    public Baglanti()
    {
        string baglantiCumlesi = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=true", _sunucu, _veritabani);
        _baglanti = new SqlConnection(baglantiCumlesi);
    }

    #endregion

    public string SpAdi
    {
        set
        {
            _komut = new SqlCommand(value, _baglanti);
            _komut.CommandType = CommandType.StoredProcedure;
        }
    }
    public string Komut
    {
        set
        {
            _komut = new SqlCommand(value, _baglanti);
        }
    }

    public void ParametreEkle(string parametreAd, SqlDbType tur, object deger)
    {
        _komut.Parameters.Add(parametreAd, tur).Value = deger;
    }

    public DataTable SorguCalistirTablo()
    {
        BaglantiyiAc();
        _veriOku = null;
        _veriOku = _komut.ExecuteReader();
        _tablo = new DataTable();
        _tablo.Load(_veriOku);
        _baglanti.Close();
        return _tablo;
    }

    public object SorguCalistirBirKayit()
    {
        BaglantiyiAc();
        return _komut.ExecuteScalar();
    }

    public int SorguCalistir()
    {
        BaglantiyiAc();
        return _komut.ExecuteNonQuery();
    }

    #region Private Functions

    private void BaglantiyiAc()
    {
        if (_baglanti.State == ConnectionState.Closed)
            _baglanti.Open();
    }



    #endregion

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
