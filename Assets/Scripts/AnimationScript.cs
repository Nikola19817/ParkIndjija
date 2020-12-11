using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    void PozoviZameniReklameMetodu()
    {
        this.transform.Find("Reklame").GetComponent<TimerScript>().ZameniReklamePosleAnimacije();
    }
}
