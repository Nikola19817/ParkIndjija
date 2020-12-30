using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectionScript : MonoBehaviour
{
    [SerializeField]
    public List<Lokal> selektovaneProdavnice;
    public GameObject mapa;
    public GameObject Content;
    public GameObject togglePrefab;
    
    void Start()
    {
        selektovaneProdavnice = new List<Lokal>();
        
        foreach(Transform t in mapa.transform){ t.GetComponent<Button>().onClick.AddListener(delegate { SelectPrekoMape(t.name); }); }
        DBconnection.GetData();
        popuniSpisakProdavnica();
    }
    void popuniSpisakProdavnica()
    {
        //ucitavanje iz baze

        foreach (Transform t in Content.transform){ Destroy(t.gameObject); }
        for(int i = 0; i < DBconnection.lokali.Count; i++){
            GameObject temp = Instantiate(togglePrefab, Content.transform);
            temp.GetComponent<Toggle>().isOn = false;
            temp.name = DBconnection.lokali[i].lokalID.ToString();
            temp.transform.Find("Naziv").GetComponent<Text>().text = DBconnection.lokali[i].lokalNaziv;
            temp.GetComponent<Toggle>().onValueChanged.AddListener(delegate { SelectPrekoSpiska(temp); });}
    }
    void SelectPrekoSpiska(GameObject toggle)
    {
        int brProdavnice = 0;
        brProdavnice = Convert.ToInt32(toggle.name);
        if(brProdavnice != 0)
        {
            GameObject zaSelektovanje;
            if (brProdavnice == 31 || brProdavnice == 32){
                zaSelektovanje = mapa.transform.Find("31 - 32").gameObject;
                GameObject tridesetJedan = Content.transform.Find("31").gameObject;
                GameObject tridesetDva = Content.transform.Find("32").gameObject;

                if (!tridesetJedan.GetComponent<Toggle>().isOn && !tridesetDva.GetComponent<Toggle>().isOn){
                    zaSelektovanje.GetComponent<Image>().color = new Color(243, 243, 243, 255);
                    IEnumerable<Lokal> temp = DBconnection.lokali.Where(x => x.lokalID == 31 || x.lokalID == 32);
                    foreach(Lokal l in temp) { selektovaneProdavnice.Remove(l); }
                }
                else{ 
                    zaSelektovanje.GetComponent<Image>().color = Color.red;
                    Lokal temp = DBconnection.lokali.Where(x => x.lokalID == Convert.ToInt32(toggle.name)).FirstOrDefault();
                    if (selektovaneProdavnice.Contains(temp)) selektovaneProdavnice.Remove(temp);
                    else selektovaneProdavnice.Add(temp);
                }

            }
            else if(brProdavnice == 38 || brProdavnice == 39 || brProdavnice == 40){
                zaSelektovanje = mapa.transform.Find("38 - 40").gameObject;
                GameObject tridesetOsam = Content.transform.Find("38").gameObject;
                GameObject tridesetDevet = Content.transform.Find("39").gameObject;
                GameObject cetrdeset = Content.transform.Find("40").gameObject;

                if (!tridesetOsam.GetComponent<Toggle>().isOn && !tridesetDevet.GetComponent<Toggle>().isOn && !cetrdeset.GetComponent<Toggle>().isOn){
                    zaSelektovanje.GetComponent<Image>().color = new Color(243, 243, 243, 255);
                    IEnumerable<Lokal> temp = DBconnection.lokali.Where(x => x.lokalID == 38 || x.lokalID == 39 || x.lokalID==40);
                    foreach (Lokal l in temp) { selektovaneProdavnice.Remove(l); }
                }
                else{
                    zaSelektovanje.GetComponent<Image>().color = Color.red;
                    Lokal temp = DBconnection.lokali.Where(x => x.lokalID == Convert.ToInt32(toggle.name)).FirstOrDefault();
                    if (selektovaneProdavnice.Contains(temp)) selektovaneProdavnice.Remove(temp);
                    else selektovaneProdavnice.Add(temp);
                }
            }
            else{
                zaSelektovanje = mapa.transform.Find(brProdavnice.ToString()).gameObject;
                if (zaSelektovanje.name == ""){ Debug.Log("Greska! Nije pronadjena prodavnica"); return; }
                else{
                    if (toggle.GetComponent<Toggle>().isOn){
                        zaSelektovanje.GetComponent<Image>().color = Color.red;
                        selektovaneProdavnice.Add(DBconnection.lokali.Where(x => x.lokalID == Convert.ToInt32(toggle.name)).FirstOrDefault());
                    }
                    else{
                        zaSelektovanje.GetComponent<Image>().color = new Color(243, 243, 243);
                        selektovaneProdavnice.Remove(DBconnection.lokali.Where(x => x.lokalID == Convert.ToInt32(toggle.name)).FirstOrDefault());
                    }
                }
            }            
        }
        else{ Debug.Log("Greska! Nije poslat dobar broj prodavnice"); }
    }
    public void SelectPrekoMape(string brProdavnice)
    {
        if(brProdavnice != ""){
            if (brProdavnice == "31 - 32"){
                if(!selektovaneProdavnice.Contains(DBconnection.lokali.Where(x=> x.lokalID==31).FirstOrDefault()) 
                        && !selektovaneProdavnice.Contains(DBconnection.lokali.Where(x => x.lokalID == 31).FirstOrDefault())){
                    Content.transform.Find("31").gameObject.GetComponent<Toggle>().isOn = true;
                    Content.transform.Find("32").gameObject.GetComponent<Toggle>().isOn = true;
                }
                else{
                    Content.transform.Find("31").gameObject.GetComponent<Toggle>().isOn = false;
                    Content.transform.Find("32").gameObject.GetComponent<Toggle>().isOn = false;
                }
            }
            else if(brProdavnice == "38 - 40"){
                if (!selektovaneProdavnice.Contains(DBconnection.lokali.Where(x => x.lokalID == 38).FirstOrDefault())
                        && !selektovaneProdavnice.Contains(DBconnection.lokali.Where(x => x.lokalID == 39).FirstOrDefault())
                        && !selektovaneProdavnice.Contains(DBconnection.lokali.Where(x => x.lokalID == 40).FirstOrDefault()))
                {
                    Content.transform.Find("38").gameObject.GetComponent<Toggle>().isOn = true;
                    Content.transform.Find("39").gameObject.GetComponent<Toggle>().isOn = true;
                    Content.transform.Find("40").gameObject.GetComponent<Toggle>().isOn = true;
                }
                else{
                    Content.transform.Find("38").gameObject.GetComponent<Toggle>().isOn = false;
                    Content.transform.Find("39").gameObject.GetComponent<Toggle>().isOn = false;
                    Content.transform.Find("40").gameObject.GetComponent<Toggle>().isOn = false;
                }
            }
            else Content.transform.Find(brProdavnice).gameObject.GetComponent<Toggle>().isOn = !Content.transform.Find(brProdavnice).gameObject.GetComponent<Toggle>().isOn;            
        }
        else Debug.Log("Greska! Nije prosledjen broj prodavnice!");
    }
    public void ResetujSelekcije()
    {
        if(selektovaneProdavnice.Count > 0)
            Content.transform.Find(selektovaneProdavnice[0].lokalID.ToString()).GetComponent<Toggle>().isOn=false;
        if (selektovaneProdavnice.Count > 0)
            ResetujSelekcije();
    }
}
