using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDatabaseClasses 
{
    public List<Lokal> lokali;
    public List<Brand> brandovi;
    public List<BrandLokal> brand_lokal;
    public List<Reklama> reklame;
    public List<User> users;

    public AllDatabaseClasses(List<Lokal> lokali, List<Brand> brandovi, List<BrandLokal> brand_lokal, List<Reklama> reklame, List<User> users)
    {
        this.lokali = lokali;
        this.brandovi = brandovi;
        this.brand_lokal = brand_lokal;
        this.reklame = reklame;
        this.users = users;
    }
}
