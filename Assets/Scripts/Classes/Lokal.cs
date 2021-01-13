using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Lokal
{
    public int lokalID { get; set; }
    public string lokalNaziv { get; set; }
    public string lokalOpis { get; set; }
    public byte[] lokalLogo { get; set; }
    public byte[] lokalSlika { get; set; }
    public string logoPath { get; set; }
    public string slikaPath { get; set; }
    public string lokalPopust { get; set; }

    public Lokal(int lokalID, string lokalNaziv, string lokalOpis, byte[] lokalLogo, byte[] lokalSlika, string lokalPopust)
    {
        this.lokalID = lokalID;
        this.lokalNaziv = lokalNaziv;
        this.lokalOpis = lokalOpis;
        this.lokalLogo = lokalLogo;
        this.lokalSlika = lokalSlika;
        this.lokalPopust = lokalPopust;


        this.logoPath = Application.persistentDataPath + @"\Lokali\" + lokalNaziv + "-LOGO.png";
        File.WriteAllBytes(this.logoPath, lokalLogo);                                                   // UVESTI DA PRIHVATA I DRUGE FORMATE SEM PNG
        this.slikaPath = Application.persistentDataPath + @"\Lokali\" + lokalNaziv + "-SLIKA.png";
        File.WriteAllBytes(this.slikaPath, lokalSlika);

    }
}
