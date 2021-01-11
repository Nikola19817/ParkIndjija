using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lokal
{
    public int lokalID { get; set; }
    public string lokalNaziv { get; set; }
    public string lokalOpis { get; set; }
    public byte[] lokalLogo { get; set; }
    public byte[] lokalSlika { get; set; }
    public string lokalPopust { get; set; }

    public Lokal(int lokalID, string lokalNaziv, string lokalOpis, byte[] lokalLogo, byte[] lokalSlika, string lokalPopust)
    {
        this.lokalID = lokalID;
        this.lokalNaziv = lokalNaziv;
        this.lokalOpis = lokalOpis;
        this.lokalLogo = lokalLogo;
        this.lokalSlika = lokalSlika;
        this.lokalPopust = lokalPopust;
    }
}
