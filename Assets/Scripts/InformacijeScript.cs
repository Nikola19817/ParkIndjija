using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformacijeScript : MonoBehaviour
{
    public GameObject content;
    GameObject canvas;
    GameObject informacijePanel;
    GameObject prodavnicaPanel;
    List<Lokal> selektovaneProdavnice;
    Lokal poslednjiSelektovan;
    void Start()
    {
        canvas = this.transform.parent.gameObject;
        informacijePanel = this.transform.Find("NacinKoriscenja").gameObject;
        prodavnicaPanel = this.transform.Find("Prodavnica").gameObject;
        selektovaneProdavnice = canvas.GetComponent<SelectionScript>().selektovaneProdavnice;
    }

    // Update is called once per frame
    void Update()
    {
        selektovaneProdavnice = canvas.GetComponent<SelectionScript>().selektovaneProdavnice;
        if (selektovaneProdavnice.Count > 0)
        {
            if(poslednjiSelektovan!=selektovaneProdavnice[selektovaneProdavnice.Count-1])
            {
                informacijePanel.SetActive(false);
                prodavnicaPanel.SetActive(true);
                int imeObjekta = selektovaneProdavnice[selektovaneProdavnice.Count - 1].lokalID;
                GameObject toggle = content.transform.Find(imeObjekta.ToString()).gameObject;
                this.transform.Find("Text").gameObject.GetComponent<TMP_Text>().text = selektovaneProdavnice[selektovaneProdavnice.Count - 1].lokalNaziv;
                this.transform.Find("Prodavnica").Find("Opis").Find("Opis").gameObject.GetComponent<TMP_Text>().text = selektovaneProdavnice[selektovaneProdavnice.Count - 1].lokalOpis;
                this.transform.Find("Prodavnica").Find("SlikaLevo").Find("Image").gameObject.GetComponent<Image>().sprite = DBconnection.ByteToSprite(selektovaneProdavnice[selektovaneProdavnice.Count - 1].lokalLogo);
                this.transform.Find("Prodavnica").Find("SlikaDesno").Find("Image").gameObject.GetComponent<Image>().sprite = DBconnection.ByteToSprite(selektovaneProdavnice[selektovaneProdavnice.Count - 1].lokalSlika);

                string temp = selektovaneProdavnice[selektovaneProdavnice.Count - 1].lokalPopust;
                temp = temp.Replace(@",", "\n");

                this.transform.Find("Prodavnica").Find("Popusti").Find("Popusti").gameObject.GetComponent<TMP_Text>().text = temp;

                poslednjiSelektovan = selektovaneProdavnice[selektovaneProdavnice.Count - 1];
            }            
        }
        else
        {
            informacijePanel.SetActive(true);
            prodavnicaPanel.SetActive(false);
            this.transform.Find("Text").gameObject.GetComponent<TMP_Text>().text = "Informacije";
            poslednjiSelektovan = null;
        }
    }
}
