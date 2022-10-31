using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
   public void Yenidenoyna()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void Anasayfa()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}
