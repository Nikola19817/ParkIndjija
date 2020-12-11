using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InformacijeScript : MonoBehaviour
{
    public GameObject content;
    GameObject canvas;
    GameObject informacijePanel;
    GameObject prodavnicaPanel;
    List<string> selektovaneProdavnice;
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
            informacijePanel.SetActive(false);
            prodavnicaPanel.SetActive(true);
            string imeObjekta = selektovaneProdavnice[selektovaneProdavnice.Count-1];
            GameObject toggle = content.transform.Find(imeObjekta).gameObject;
            this.transform.Find("Text").gameObject.GetComponent<TMP_Text>().text = toggle.transform.Find("Label").gameObject.GetComponent<Text>().text;
        }
        else
        {
            informacijePanel.SetActive(true);
            prodavnicaPanel.SetActive(false);
            this.transform.Find("Text").gameObject.GetComponent<TMP_Text>().text = "Informacije";
        }
    }
}
