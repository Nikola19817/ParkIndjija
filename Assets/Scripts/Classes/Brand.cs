using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brand
{
    public int brandID { get; set; }
    public string brandNaziv { get; set; }
    public string brandKategorija { get; set; }
    public Brand(int brandID, string brandNaziv, string brandKategorija)
    {
        this.brandID = brandID;
        this.brandNaziv = brandNaziv;
        this.brandKategorija = brandKategorija;
    }
}
