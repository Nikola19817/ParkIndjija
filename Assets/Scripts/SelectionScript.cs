using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectionScript : MonoBehaviour
{
    Dictionary<int, string> listaProdavnica;
    public GameObject mapa;
    public GameObject Content;
    public GameObject togglePrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        
        listaProdavnica = new Dictionary<int, string>();
        listaProdavnica.Add(1, "Nike");
        listaProdavnica.Add(10, "Adidas");
        listaProdavnica.Add(15, "Puma");
        listaProdavnica.Add(20, "Fila");
        listaProdavnica.Add(31, "TEST 31");
        listaProdavnica.Add(32, "TEST 32");
        listaProdavnica.Add(33, "TEST 33");
        listaProdavnica.Add(25, "Gigatron");
        listaProdavnica.Add(30, "Bershka");
        listaProdavnica.Add(38, "TEST 38");
        listaProdavnica.Add(39, "TEST 39");
        listaProdavnica.Add(40, "TEST 40");
        
        popuniSpisakProdavnica();
    }

    void popuniSpisakProdavnica()
    {
        foreach (Transform t in Content.transform)
        {
            Destroy(t.gameObject);
        }
        for(int i = 0; i < listaProdavnica.Count; i++)
        {
            GameObject temp = Instantiate(togglePrefab, Content.transform);
            temp.GetComponent<Toggle>().isOn = false;
            temp.name = listaProdavnica.ElementAt(i).Key.ToString();
            temp.transform.Find("Label").GetComponent<Text>().text = listaProdavnica.ElementAt(i).Value;
            temp.GetComponent<Toggle>().onValueChanged.AddListener(delegate { SelektujNaMapi(temp); });
        }
    }
    void SelektujNaMapi(GameObject toggle)
    {
        //Debug.Log(toggle.transform.Find("Label").GetComponent<Text>().text);
        int brProdavnice = 0;
        brProdavnice = Convert.ToInt32(toggle.name);
        if(brProdavnice != 0)
        {
            GameObject zaSelektovanje;
            if (brProdavnice == 31 || brProdavnice == 32)
            {
                zaSelektovanje = mapa.transform.Find("31 - 32").gameObject;
            }
            else if(brProdavnice == 38 || brProdavnice == 39 || brProdavnice == 40)
            {
                zaSelektovanje = mapa.transform.Find("38 - 40").gameObject;
            }
            else
            {
                zaSelektovanje = mapa.transform.Find(brProdavnice.ToString()).gameObject;
            }

            if (zaSelektovanje.name == "")
            {
                Debug.Log("Greska! Nije pronadjena prodavnica");
                return;
            }
            else if (zaSelektovanje.name == "31 - 32")
            {
                GameObject tridesetJedan = Content.transform.Find("31").gameObject;
                GameObject tridesetDva = Content.transform.Find("32").gameObject;
                if(!tridesetJedan.GetComponent<Toggle>().isOn && !tridesetDva.GetComponent<Toggle>().isOn)
                    zaSelektovanje.GetComponent<Image>().color = new Color(243, 243, 243, 255);
                else
                    zaSelektovanje.GetComponent<Image>().color = Color.red;
            }
            else if (zaSelektovanje.name == "38 - 40")
            {
                GameObject tridesetOsam = Content.transform.Find("38").gameObject;
                GameObject tridesetDevet = Content.transform.Find("39").gameObject;
                GameObject cetrdeset = Content.transform.Find("40").gameObject;
                if (!tridesetOsam.GetComponent<Toggle>().isOn && !tridesetDevet.GetComponent<Toggle>().isOn && !cetrdeset.GetComponent<Toggle>().isOn)
                    zaSelektovanje.GetComponent<Image>().color = new Color(243, 243, 243, 255);
                else
                    zaSelektovanje.GetComponent<Image>().color = Color.red;
            }
            else
            {
                if (toggle.GetComponent<Toggle>().isOn)
                    zaSelektovanje.GetComponent<Image>().color = Color.red;
                else
                    zaSelektovanje.GetComponent<Image>().color = new Color(243, 243, 243, 255);
            }
        }
        else
        {
            Debug.Log("Greska! Nije poslat dobar broj prodavnice");
        }
    }
}
