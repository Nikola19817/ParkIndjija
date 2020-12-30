using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrandLokal
{
    public int agregacijaID { get; set; }
    public int brandID { get; set; }
    public int lokalID { get; set; }

    public BrandLokal(int agregacijaID, int brandID, int lokalID)
    {
        this.agregacijaID = agregacijaID;
        this.brandID = brandID;
        this.lokalID = lokalID;
    }
}
