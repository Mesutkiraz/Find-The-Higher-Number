using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SureManager : MonoBehaviour
{
    [SerializeField]
    private Text sureText;
   

    
   
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
       
    }

    int kalanSure;
    bool sureBitti=true;


    void Start()
    {
        kalanSure = 3; 
      
    }
    public IEnumerator sureSayac()
    {
        while (sureBitti)
        {
            yield return new WaitForSeconds(1f);
            if (kalanSure<10)
            {
                sureText.text = "0" + kalanSure;
            }
            else
            {
                sureText.text = kalanSure.ToString();
            }
            if (kalanSure<=0)
            {
                sureBitti = false;
                sureText.fontSize = 15;
                sureText.text = "Oyun Bitti";
                gameManager.Oyunubitir();

            }
            kalanSure--;
        }
    }

   
}
