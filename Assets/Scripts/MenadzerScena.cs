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
        if (Input.GetKey(KeyCode.Alpha2))
            UcitajAdminScenu();
    }
    public void UcitajAplikaciju()
    {
        SceneManager.LoadScene(0);
    }
    public void UcitajAdminScenu()
    {
        SceneManager.LoadScene(1);
    }
}
