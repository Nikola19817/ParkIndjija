using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reklama
{
    public int reklamaID { get; set; }
    public string reklamaNaziv { get; set; }
    public string reklamaPath { get; set; }
    public float reklamaDuration { get; set; }
    public string reklamaVlasnik { get; set; }

    public Reklama(int reklamaID, string reklamaNaziv, string reklamaPath, float reklamaDuration, string reklamaVlasnik)
    {
        this.reklamaID = reklamaID;
        this.reklamaNaziv = reklamaNaziv;
        this.reklamaPath = reklamaPath;
        this.reklamaDuration = reklamaDuration;
        this.reklamaVlasnik = reklamaVlasnik;
    }
}
