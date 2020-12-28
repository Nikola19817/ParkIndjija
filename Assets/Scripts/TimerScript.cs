using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    // Polja za timer interakcije
    float vremeOdPoslednjeInterakcije = 0f;
    float duzinaInterakcije = 60f;
    bool timerInterakcijeAktivan = true;

    // Polja za timer reklama
    int brojReklame = 0;
    Object[] reklame;
    float vremeOdPustanjaReklame = 0f;
    float duzinaTrajanjaReklame = 10f;
    bool timerReklameAktivan = false;

    // Polja za animacjie
    public Animator animator;

    private void Start()
    {
        timerInterakcijeAktivan = true;
        this.transform.Find("Prelaz").gameObject.SetActive(false);
        this.transform.Find("Reklama").gameObject.SetActive(false);
        reklame = Resources.LoadAll("Reklame", typeof(Sprite));
        this.transform.Find("Reklama").gameObject.GetComponent<Image>().sprite = (Sprite)reklame[brojReklame];
    }
    private void Update()
    {
        if (Input.touches.Length > 0 || Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            UgasiReklame();
            ResetTimerInterakcije();
        }
        else animator.ResetTrigger("UgasiReklamu");
        
    }
    void FixedUpdate()
    {
        if (timerInterakcijeAktivan)
        {
            if (vremeOdPoslednjeInterakcije >= duzinaInterakcije - 5 && vremeOdPoslednjeInterakcije < duzinaInterakcije) this.transform.Find("Prelaz").gameObject.SetActive(true);
            if (vremeOdPoslednjeInterakcije >= duzinaInterakcije) {
                ResetTimerInterakcije();
                PustiReklame();
                DeaktivirajTimerInterakcije();
            }
            vremeOdPoslednjeInterakcije += Time.deltaTime;
        }
        else if(timerReklameAktivan)
        {
            if(vremeOdPustanjaReklame >= duzinaTrajanjaReklame) SledecaReklama();
            vremeOdPustanjaReklame += Time.deltaTime;
        }
    }
    public void AktivirajTimerInterakcije()
    {
        timerInterakcijeAktivan = true;
    }
    public void DeaktivirajTimerInterakcije()
    {
        timerInterakcijeAktivan = false;
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
        if(reklame.Length<=0) reklame = Resources.LoadAll("Reklame", typeof(Sprite));
        this.transform.Find("Reklama").gameObject.GetComponent<Image>().sprite = (Sprite)reklame[brojReklame];
        animator.SetTrigger("PustiReklamu");
        this.transform.parent.Find("Aplikacija").GetComponent<SelectionScript>().ResetujSelekcije();
    }
    public void UgasiReklame()
    {
        this.transform.Find("Prelaz").gameObject.SetActive(false);
        this.transform.Find("Reklama").gameObject.SetActive(false);
        animator.SetTrigger("UgasiReklamu");
        DeaktivirajTimerReklame();
        ResetTimerReklame();        
    }
    public void SledecaReklama()
    {
        DeaktivirajTimerReklame();
        brojReklame++;
        if (brojReklame >= reklame.Length)
        {
            brojReklame = 0;
        }
        this.transform.Find("Sledeca").gameObject.GetComponent<Image>().sprite = (Sprite)reklame[brojReklame];
        animator.SetTrigger("ReklamaTransition");
    }
    public void ZameniReklamePosleAnimacije()
    {
        animator.ResetTrigger("ReklamaTransition");
        this.transform.Find("Reklama").gameObject.GetComponent<Image>().sprite = this.transform.Find("Sledeca").gameObject.GetComponent<Image>().sprite;
        ResetTimerReklame();
        AktivirajTimerReklame();
    }
    public void AktivirajTimerReklame()
    {
        timerReklameAktivan = true;
    }
    public void DeaktivirajTimerReklame()
    {
        timerReklameAktivan = false;
    }
    public void ResetTimerReklame()
    {
        vremeOdPustanjaReklame = 0f;
    }
    public void ResetPosleReklama()
    {
        animator.ResetTrigger("PustiReklamu");
        animator.ResetTrigger("ReklamaTransition");
        animator.ResetTrigger("UgasiReklamu");
        ResetTimerInterakcije();
        AktivirajTimerInterakcije();
    }
}
