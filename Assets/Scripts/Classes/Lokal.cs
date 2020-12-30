using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lokal
{
    public int lokalID { get; set; }
    public string lokalNaziv { get; set; }
    public string lokalOpis { get; set; }
    public string lokalLogo { get; set; }
    public string lokalSlika { get; set; }
    public string lokalPopust { get; set; }

    public Lokal(int lokalID, string lokalNaziv, string lokalOpis, string lokalLogo, string lokalSlika, string lokalPopust)
    {
        this.lokalID = lokalID;
        this.lokalNaziv = lokalNaziv;
        this.lokalOpis = lokalOpis;
        this.lokalLogo = lokalLogo;
        this.lokalSlika = lokalSlika;
        this.lokalPopust = lokalPopust;
    }
}
