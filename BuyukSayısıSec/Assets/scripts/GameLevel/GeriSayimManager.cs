using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GeriSayimManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gerisayimobje;
    [SerializeField]
    private Text gerisayimtext;

    GameManager gameManager;
    SureManager sureManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
        sureManager = FindObjectOfType<SureManager>();
    }

    void Start()
    {
        StartCoroutine(gerisayim());
    }

    IEnumerator gerisayim()
    {
        gerisayimtext.text = "3";
        yield return new WaitForSeconds(0.5f);

        gerisayimobje.transform.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        gerisayimobje.transform.GetComponent<RectTransform>().DOScale(0, 0.6f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(1f);

        gerisayimtext.text = "2";
        gerisayimobje.transform.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        gerisayimobje.transform.GetComponent<RectTransform>().DOScale(0, 0.6f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(1f);

        gerisayimtext.text = "1";
        gerisayimobje.transform.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        gerisayimobje.transform.GetComponent<RectTransform>().DOScale(0, 0.6f).SetEase(Ease.InBack);

        StopAllCoroutines();

        gameManager.OyunaBasla();
        StartCoroutine(sureManager.sureSayac());
    }
   
}
