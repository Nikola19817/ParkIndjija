using System;

[Serializable]
public class Shop 
{
    public string brProdavnice;
    public string name;
    public string description;
    public string disscount;
    public byte[] Logo;
    public byte[] Image;

    public Shop(string brProdavnice, string name, string description, string disscount, byte[] logo, byte[] image)
    {
        this.brProdavnice = brProdavnice;
        this.name = name;
        this.description = description;
        this.disscount = disscount;
        Logo = logo;
        Image = image;
    }
}
