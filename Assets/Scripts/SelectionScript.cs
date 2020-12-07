using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectionScript : MonoBehaviour
{
    Dictionary<int, string> listaProdavnica;
    public List<string> selektovaneProdavnice;
    public GameObject mapa;
    public GameObject Content;
    public GameObject togglePrefab;
    
    void Start()
    {
        listaProdavnica = new Dictionary<int, string>();
        selektovaneProdavnice = new List<string>();
        
        for(int i = 0; i < 67; i++) { listaProdavnica.Add(i + 1, "Prodavnica " + (i + 1).ToString()); }
        foreach(Transform t in mapa.transform){ t.GetComponent<Button>().onClick.AddListener(delegate { SelectPrekoMape(t.name); }); }
        popuniSpisakProdavnica();
    }
    void popuniSpisakProdavnica()
    {
        foreach (Transform t in Content.transform){ Destroy(t.gameObject); }
        for(int i = 0; i < listaProdavnica.Count; i++){
            GameObject temp = Instantiate(togglePrefab, Content.transform);
            temp.GetComponent<Toggle>().isOn = false;
            temp.name = listaProdavnica.ElementAt(i).Key.ToString();
            temp.transform.Find("Label").GetComponent<Text>().text = listaProdavnica.ElementAt(i).Value;
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
                    if (selektovaneProdavnice.Contains("31")) selektovaneProdavnice.Remove("31");
                    if (selektovaneProdavnice.Contains("32")) selektovaneProdavnice.Remove("32");
                }
                else{ 
                    zaSelektovanje.GetComponent<Image>().color = Color.red;
                    if (selektovaneProdavnice.Contains(toggle.name)) selektovaneProdavnice.Remove(toggle.name);
                    else selektovaneProdavnice.Add(toggle.name);
                }

            }
            else if(brProdavnice == 38 || brProdavnice == 39 || brProdavnice == 40){
                zaSelektovanje = mapa.transform.Find("38 - 40").gameObject;
                GameObject tridesetOsam = Content.transform.Find("38").gameObject;
                GameObject tridesetDevet = Content.transform.Find("39").gameObject;
                GameObject cetrdeset = Content.transform.Find("40").gameObject;

                if (!tridesetOsam.GetComponent<Toggle>().isOn && !tridesetDevet.GetComponent<Toggle>().isOn && !cetrdeset.GetComponent<Toggle>().isOn){
                    zaSelektovanje.GetComponent<Image>().color = new Color(243, 243, 243, 255);
                    if (selektovaneProdavnice.Contains("38")) selektovaneProdavnice.Remove("38");
                    if (selektovaneProdavnice.Contains("39")) selektovaneProdavnice.Remove("39");
                    if (selektovaneProdavnice.Contains("40")) selektovaneProdavnice.Remove("40");
                }
                else{
                    zaSelektovanje.GetComponent<Image>().color = Color.red;
                    if (selektovaneProdavnice.Contains(toggle.name)) selektovaneProdavnice.Remove(toggle.name);
                    else selektovaneProdavnice.Add(toggle.name);
                }
            }
            else{
                zaSelektovanje = mapa.transform.Find(brProdavnice.ToString()).gameObject;
                if (zaSelektovanje.name == ""){ Debug.Log("Greska! Nije pronadjena prodavnica"); return; }
                else{
                    if (toggle.GetComponent<Toggle>().isOn){
                        zaSelektovanje.GetComponent<Image>().color = Color.red;
                        selektovaneProdavnice.Add(toggle.name);
                    }
                    else{
                        zaSelektovanje.GetComponent<Image>().color = new Color(243, 243, 243, 255);
                        selektovaneProdavnice.Remove(toggle.name);
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
                if(!selektovaneProdavnice.Contains("31") && !selektovaneProdavnice.Contains("32")){
                    Content.transform.Find("31").gameObject.GetComponent<Toggle>().isOn = true;
                    Content.transform.Find("32").gameObject.GetComponent<Toggle>().isOn = true;
                }
                else{
                    Content.transform.Find("31").gameObject.GetComponent<Toggle>().isOn = false;
                    Content.transform.Find("32").gameObject.GetComponent<Toggle>().isOn = false;
                }
            }
            else if(brProdavnice == "38 - 40"){   
                if(!selektovaneProdavnice.Contains("38") && !selektovaneProdavnice.Contains("39") && !selektovaneProdavnice.Contains("40")){
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
}
