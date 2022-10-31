using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject puanSurePaneli;
    [SerializeField]
    private GameObject puanKapYaziPaneli;
    [SerializeField]
    private GameObject buyukSecYaziPaneli;
    [SerializeField]
    private GameObject ustDikdortgen;
    [SerializeField]
    private GameObject altDikdortgen;
    [SerializeField]
    private Text ustText, altText,puanText;
    [SerializeField]
    private GameObject yesiltop;
    [SerializeField]
    private GameObject pausepaneli;
    [SerializeField]
    private GameObject sonucpanel;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip oyunaBasla, oyunBitis, dogruSes, yanlýsSes;

    int kacinciOyun=0, oyunSayac=0;
    int ustsayi, altsayi,enbuyuk,butondeger,toplampuan,puanartýs,dogruAdet,yanlýsAdet;

    DaireManager daireManager;
    TrueFalseManager trueFalseManager;

    private void Awake()
    {
        audioSource=GetComponent<AudioSource>();
        daireManager = GameObject.FindObjectOfType<DaireManager>();
        trueFalseManager =GameObject.FindObjectOfType<TrueFalseManager>();
    }
    void Start()
    {
        ustText.text = "";
        altText.text = "";
        puanText.text = "0";
        toplampuan = 0;
        dogruAdet = 0;
        yanlýsAdet = 0;

        surePaneliniGuncelle();
    }

    void surePaneliniGuncelle()
    {
        puanSurePaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        puanKapYaziPaneli.transform.GetComponent<RectTransform>().DOLocalMoveY(-262f, 1f).SetEase(Ease.OutBack);
        ustDikdortgen.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        altDikdortgen.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
    }
    public void OyunaBasla()
    {
        audioSource.PlayOneShot(oyunaBasla);
        puanKapYaziPaneli.GetComponent<CanvasGroup>().DOFade(0, .2f);
        buyukSecYaziPaneli.GetComponent<CanvasGroup>().DOFade(1, .3f);
        
        Kacincioyun();
    }    
    void Kacincioyun()
    {
        if (oyunSayac<5)
        {
            kacinciOyun = 1;
            puanartýs = 25;
        }
        else if (oyunSayac>=5 && oyunSayac<10)
        {
            kacinciOyun = 2;
            puanartýs = 50;
        }
        else if (oyunSayac >= 10 && oyunSayac < 15)
        {
            kacinciOyun = 3;
            puanartýs = 75;
        }
        else if (oyunSayac >= 15 && oyunSayac < 20)
        {
            kacinciOyun = 4;
            puanartýs = 100;
        }
        else if (oyunSayac >= 20 && oyunSayac < 25)
        {
            kacinciOyun = 5;
            puanartýs = 125;
        }
        else
        {
            kacinciOyun = Random.Range(1, 6);
            puanartýs = 150;
        }
        switch (kacinciOyun)
        {
            case 1:
                BirinciOyun();
                break;
            case 2:
                IkinciOyun();
                break;
            case 3:
                UcuncuOyun();
                break;
            case 4:
                DorduncuOyun();
                break;
            case 5:
                BesinciOyun();
                break;
        }
    }

    void BirinciOyun()
    {
        
        int buyuk = Random.Range(1, 50);
        if (buyuk<25)
        {
            ustsayi = Random.Range(1, 25);
            altsayi = ustsayi+ Random.Range(1, 10);
        }
        else
        {
            ustsayi = Random.Range(1, 25);
            altsayi = Mathf.Abs( ustsayi - Random.Range(1, 10));
        }
        if (ustsayi>altsayi)
        {
            enbuyuk = ustsayi;
        }
        else if (altsayi>ustsayi)
        {
            enbuyuk = altsayi;
        }

        if (ustsayi==altsayi)
        {
            BirinciOyun();
            return;
        }

        ustText.text = ustsayi.ToString();
        altText.text = altsayi.ToString();
    }

    void IkinciOyun()
    {
        int birincisayi = Random.Range(1, 20);
        int ikincisayi = Random.Range(1, 10);
        int ucuncusayi = Random.Range(1, 20);
        int dorduncusayi = Random.Range(1, 10);

         ustsayi = birincisayi + ikincisayi;
         altsayi = ucuncusayi + dorduncusayi;

        if (ustsayi>altsayi)
        {
            enbuyuk = ustsayi;
        }
        else if (altsayi>ustsayi)
        {
            enbuyuk = altsayi;
        }
        
        if (ustsayi == altsayi)
        {
            IkinciOyun();
            return;
        }
        ustText.text = birincisayi + " + " + ikincisayi;
        altText.text = ucuncusayi + " + " + dorduncusayi;
    }

    void UcuncuOyun()
    {
        int birincisayi = Random.Range(11, 30);
        int ikincisayi = Random.Range(1, 10);
        int ucuncusayi = Random.Range(11, 40);
        int dorduncusayi = Random.Range(1, 10);

        ustsayi = birincisayi - ikincisayi;
        altsayi = ucuncusayi - dorduncusayi;

        if (ustsayi > altsayi)
        {
            enbuyuk = ustsayi;
        }
        else if (altsayi > ustsayi)
        {
            enbuyuk = altsayi;
        }

        if (ustsayi == altsayi)
        {
            UcuncuOyun();
            return;
        }
        ustText.text = birincisayi + " - " + ikincisayi;
        altText.text = ucuncusayi + " - " + dorduncusayi;
    }

    void DorduncuOyun()
    {
        int birincisayi = Random.Range(1, 10);
        int ikincisayi = Random.Range(1, 10);
        int ucuncusayi = Random.Range(1, 10);
        int dorduncusayi = Random.Range(1, 10);

        ustsayi = birincisayi * ikincisayi;
        altsayi = ucuncusayi * dorduncusayi;

        if (ustsayi > altsayi)
        {
            enbuyuk = ustsayi;
        }
        else if (altsayi > ustsayi)
        {
            enbuyuk = altsayi;
        }

        if (ustsayi == altsayi)
        {
            DorduncuOyun();
            return;
        }
        ustText.text = birincisayi + " x " + ikincisayi;
        altText.text = ucuncusayi + " x " + dorduncusayi;
    }

    void BesinciOyun()
    {
        int bolen1 = Random.Range(1, 10);
        ustsayi = Random.Range(1, 10);

        int bolunen1 = bolen1 * ustsayi;

        int bolen2 = Random.Range(1, 10);
        altsayi = Random.Range(1, 10);

        int bolunen2 = bolen2 * altsayi;

        if (ustsayi > altsayi)
        {
            enbuyuk = ustsayi;
        }
        else if (altsayi > ustsayi)
        {
            enbuyuk = altsayi;
        }

        if (ustsayi == altsayi)
        {
            BesinciOyun();
            return;
        }
        ustText.text = bolunen1 + " / " + bolen1;
        altText.text = bolunen2 + " / " + bolen2;



    }
    public void ButonaBas(string butonadi)
    {
        if (butonadi == "ustButon")
        {
            butondeger = ustsayi;
        }
        else if(butonadi=="altButon")
        {
            butondeger = altsayi;
        }

        if (enbuyuk==butondeger)
        {
            audioSource.PlayOneShot(dogruSes);
            trueFalseManager.Scaleac(true);
            toplampuan += puanartýs;
            puanText.text = toplampuan.ToString();
            daireManager.scaleac(oyunSayac%5);
            oyunSayac++;
            dogruAdet++;
            Kacincioyun();
         
        }
        else
        {
            audioSource.PlayOneShot(yanlýsSes);
            trueFalseManager.Scaleac(false);
            yanlýsAdet++;
            HatayaGoreAzalt();
            Kacincioyun();
        }

        void HatayaGoreAzalt()
        {
            oyunSayac -= (oyunSayac % 5 + 5);
            if (oyunSayac<0)
            {
                oyunSayac = 0;
            }
            daireManager.scalekapa();
        }
    }
    public void Pausepaneliniac()
    {
        pausepaneli.SetActive(true);
    }
    public void Oyunubitir()
    {
        audioSource.PlayOneShot(oyunBitis);
        sonucpanel.SetActive(true);
        sonucpanel.transform.GetChild(5).GetComponent<Text>().text = dogruAdet.ToString();
        sonucpanel.transform.GetChild(6).GetComponent<Text>().text = yanlýsAdet.ToString();
        sonucpanel.transform.GetChild(7).GetComponent<Text>().text = toplampuan.ToString();
    }
    
}
