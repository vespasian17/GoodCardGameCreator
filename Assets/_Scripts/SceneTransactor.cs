using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransactor : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
