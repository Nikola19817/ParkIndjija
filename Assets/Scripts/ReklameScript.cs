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

    Image poster;
    VideoPlayer player;
    float timer=0f;
    float timerDuration=30;
    int brojReklame=0;
    bool timerActive=true;
    Reklama trenutnaReklama;
    private void Start()
    {
        player = this.transform.Find("Video").Find("VideoPlayer").gameObject.GetComponent<VideoPlayer>();
        player.playOnAwake = false;
        player.Stop();
    }
    void FixedUpdate()
    {
        if (timerActive) timer += Time.deltaTime;
        if (statusApp == StatusAplikacije.aplikacija){
            if (timerActive && timer >= inactivityTime)
                PustiReklame();
        }
        else if (statusApp == StatusAplikacije.reklama){
        }
        this.transform.Find("DebugTimer").GetComponent<Text>().text = timer.ToString();
    }
    void PustiReklame()
    {
        foreach(Transform t in this.transform)
        {
            t.gameObject.SetActive(true);
        }
        ResetTimer();
        if (brojReklame>=DBconnection.reklame.Count)
            brojReklame=0;
        trenutnaReklama = DBconnection.reklame[brojReklame];
        timerDuration = trenutnaReklama.reklamaDuration;

        if(trenutnaReklama.reklamaTip=="png" || trenutnaReklama.reklamaTip == "jpg" || trenutnaReklama.reklamaTip == "jpeg")
        {
            this.transform.Find("Video").Find("ReklamaSource").GetComponent<RawImage>().texture = (Texture2D)DBconnection.ByteToTexture(File.ReadAllBytes(trenutnaReklama.reklamaPath));
            player.Stop();
            timerActive = true;
        }
        else if (trenutnaReklama.reklamaTip == "mp4")
        {
            this.transform.Find("Video").Find("ReklamaSource").GetComponent<RawImage>().texture = texture;
            player.url = trenutnaReklama.reklamaPath;            
            timerActive = false;
            player.Play();
        }
        statusApp = StatusAplikacije.reklama;
        brojReklame++;
    }
    void ResetTimer()
    {
        timer = 0;
        timerActive = true;
    }
}
