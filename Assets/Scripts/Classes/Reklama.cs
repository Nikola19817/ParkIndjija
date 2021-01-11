using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reklama
{
    public int reklamaID { get; set; }
    public string reklamaNaziv { get; set; }
    public byte[] reklamaData { get; set; }
    public float reklamaDuration { get; set; }
    public string reklamaVlasnik { get; set; }

    public Reklama(int reklamaID, string reklamaNaziv, byte[] reklamaData, float reklamaDuration, string reklamaVlasnik)
    {
        this.reklamaID = reklamaID;
        this.reklamaNaziv = reklamaNaziv;
        this.reklamaData = reklamaData;
        this.reklamaDuration = reklamaDuration;
        this.reklamaVlasnik = reklamaVlasnik;
    }
}
