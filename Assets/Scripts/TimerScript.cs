using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    float vremeOdPoslednjeInterakcije = 0f;
    float duzinaInterakcije = 30f;
    bool timerAktivan = true;
    public GameObject testPolje;

    private void Start()
    {
        timerAktivan = true;
        this.transform.Find("Prelaz").gameObject.SetActive(false);
        this.transform.Find("Reklama").gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.touches.Length > 0 || Input.GetMouseButtonDown(0))
        {
            ResetTimerInterakcije();
            AktivirajTimerInterakcije();
        }
    }
    void FixedUpdate()
    {
        if (timerAktivan)
        {
            if (vremeOdPoslednjeInterakcije >= duzinaInterakcije - 5 && vremeOdPoslednjeInterakcije < duzinaInterakcije)
                this.transform.Find("Prelaz").gameObject.SetActive(true);
            if (vremeOdPoslednjeInterakcije >= duzinaInterakcije)
            {
                ResetTimerInterakcije();
                PustiReklame();
                DeaktivirajTimerInterakcije();
                testPolje.GetComponent<Text>().text = vremeOdPoslednjeInterakcije.ToString();
            }
            vremeOdPoslednjeInterakcije += Time.deltaTime;
            testPolje.GetComponent<Text>().text = vremeOdPoslednjeInterakcije.ToString();
        }
    }
    public void AktivirajTimerInterakcije()
    {
        timerAktivan = true;
    }
    public void DeaktivirajTimerInterakcije()
    {
        timerAktivan = false;
    }
    public void ResetTimerInterakcije()
    {
        vremeOdPoslednjeInterakcije = 0;
        this.transform.Find("Prelaz").gameObject.SetActive(false);
        this.transform.Find("Reklama").gameObject.SetActive(false);
    }
    public void PustiReklame()
    {
        this.transform.Find("Prelaz").gameObject.SetActive(false);
        this.transform.Find("Reklama").gameObject.SetActive(true);
    }
    
}
