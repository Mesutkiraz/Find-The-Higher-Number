using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrueFalseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trueIcon, falseIcon;
    void Start()
    {
        Scalekapa();
    }

    public void Scaleac(bool acilsinmi)
    {
       
        if (acilsinmi)
        {
            trueIcon.GetComponent<RectTransform>().DOScale(1, .2f);
            falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        else
        {
            falseIcon.GetComponent<RectTransform>().DOScale(1, .2f);
            trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        Invoke("Scalekapa", .4f);
    }
    public void Scalekapa()
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
   
}
