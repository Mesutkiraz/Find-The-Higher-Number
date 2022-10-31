using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DaireManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] dairelerDizisi;


    public void scalekapa()
    {
        foreach (GameObject daire in dairelerDizisi)
        {
            daire.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }

    void Start()
    {
        scalekapa();
    }

    public void scaleac(int hangidaire)
    {
        dairelerDizisi[hangidaire].GetComponent<RectTransform>().DOScale(1, 0.3f);
        if (hangidaire%5==0)
        {
            scalekapa();
        }
    }
   
}
