using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Reklama
{
    public int reklamaID { get; set; }
    public string reklamaNaziv { get; set; }
    public byte[] reklamaData { get; set; }
    public float reklamaDuration { get; set; }
    public string reklamaVlasnik { get; set; }
    public string reklamaTip { get; set; }
    public string reklamaPath { get; set; }

    public Reklama(int reklamaID, string reklamaNaziv, byte[] reklamaData, float reklamaDuration, string reklamaVlasnik, string reklamaTip)
    {
        this.reklamaID = reklamaID;
        this.reklamaNaziv = reklamaNaziv;
        this.reklamaDuration = reklamaDuration;
        this.reklamaVlasnik = reklamaVlasnik;
        this.reklamaTip = reklamaTip;
        this.reklamaData = reklamaData;
        
        SacuvajReklamu(reklamaTip, reklamaData);
    }
    private void SacuvajReklamu(string extension,byte[] reklamaData)
    {
        this.reklamaPath = Application.persistentDataPath + @"\Reklame\" + reklamaNaziv + "." + reklamaTip;
        File.WriteAllBytes(this.reklamaPath, reklamaData);
    }
}
