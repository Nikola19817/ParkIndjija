using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenadzerScena : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            UcitajAplikaciju();
    }
    public void UcitajAplikaciju()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
            SceneManager.LoadScene(1);
        else if (SceneManager.GetActiveScene().buildIndex == 1)
            SceneManager.LoadScene(0);

    }
}
