using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ReklameScript : MonoBehaviour
{
    public enum StatusAplikacije { aplikacija,reklama }
    public static StatusAplikacije statusApp=StatusAplikacije.aplikacija;
    
    public float inactivityTime = 10f;
    public RenderTexture texture;

    Animator animator;
    VideoPlayer player;
    float timer=0f;
    int brojReklame=0;
    bool timerActive=true;
    Reklama trenutnaReklama;
    Reklama proslaRekalama;
    private void Start()
    {
        player = this.transform.Find("VideoPlayer").gameObject.GetComponent<VideoPlayer>();
        player.playOnAwake = false;
        player.Stop();
        animator = this.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (timerActive) timer += Time.deltaTime;
        if (Input.touches.Length > 0 || Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) UgasiReklame();
        else animator.ResetTrigger("KrajReklama");
        if (statusApp == StatusAplikacije.aplikacija){
            if (timerActive && timer >= inactivityTime) PustiReklame();
        }
        else if (statusApp == StatusAplikacije.reklama){
            if (timerActive && timer >= trenutnaReklama.reklamaDuration) PustiReklame();
            if (!player.isPlaying && trenutnaReklama.reklamaDuration == 0 && trenutnaReklama.reklamaTip=="mp4") PustiReklame();
        }
        this.transform.Find("DebugTimer").GetComponent<Text>().text = timer.ToString();
    }
    void UgasiReklame()
    {
        ResetTimer(); 
        statusApp = StatusAplikacije.aplikacija;
        animator.SetTrigger("KrajReklama");
    }
    void PustiReklame()
    {
        ResetTimer();
        if (brojReklame>=DBconnection.reklame.Count)
            brojReklame=0;
        trenutnaReklama = DBconnection.reklame[brojReklame];
        int brojProsleReklame = brojReklame - 1;
        if (brojProsleReklame < 0) brojProsleReklame = DBconnection.reklame.Count-1;
        proslaRekalama = DBconnection.reklame[brojProsleReklame];

        if (trenutnaReklama.reklamaTip=="png" || trenutnaReklama.reklamaTip == "jpg" || trenutnaReklama.reklamaTip == "jpeg")
        {
            this.transform.Find("ReklamaSource").GetComponent<RawImage>().texture = (Texture2D)DBconnection.ByteToTexture(File.ReadAllBytes(trenutnaReklama.reklamaPath));
            player.Stop();
            timerActive = true;
        }
        else if (trenutnaReklama.reklamaTip == "mp4")
        {
            this.transform.Find("ReklamaSource").GetComponent<RawImage>().texture = texture;
            player.url = trenutnaReklama.reklamaPath;
            player.Play();
        }

        AnimacijeReklama();
        statusApp = StatusAplikacije.reklama;
        brojReklame++;
    }
    void ResetTimer()
    {
        timer = 0;
        timerActive = true;
    }
    void AnimacijeReklama()
    {
        if (statusApp == StatusAplikacije.aplikacija)
        {
            animator.SetTrigger("PrvaReklama");
        }
        else if (statusApp == StatusAplikacije.reklama)
        {
            if (proslaRekalama.reklamaTip != "mp4")
                this.transform.Find("ReklamaSourceSledeca").GetComponent<RawImage>().texture = (Texture2D)DBconnection.ByteToTexture(File.ReadAllBytes(proslaRekalama.reklamaPath));
            else
                this.transform.Find("ReklamaSourceSledeca").GetComponent<RawImage>().texture = texture;
            animator.SetTrigger("SledecaReklama");
        }
    }
}
