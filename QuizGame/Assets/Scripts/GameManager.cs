 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public Soru[] sorular;
    private static List<Soru> cevaplanmamis_Sorular;
    private Soru gecerli_Soru;

    [SerializeField]
    private Text soruText;
    [SerializeField]
    private GameObject dogruBtn, yanlisBtn;

    [SerializeField]
    private Text dogruTxt, yanlisTxt;

    [SerializeField]
    private GameObject sonucPanel;

    SonucManager sonucManager;

    int dogruAdet, yanlisAdet;

    int toplamPuan;
    // Start is called before the first frame update
    void Start()
    {
        toplamPuan = 0;
        
        if(cevaplanmamis_Sorular==null || cevaplanmamis_Sorular.Count == 0)
        {
            cevaplanmamis_Sorular = sorular.ToList<Soru>();
        }
        yanlisAdet = 0;
        dogruAdet = 0;

        RastgeleSoruSec();
    }
    void RastgeleSoruSec()
    {
        dogruBtn.GetComponent<RectTransform>().DOLocalMoveX(-289,.2f);
        yanlisBtn.GetComponent<RectTransform>().DOLocalMoveX(289, .2f);


        int randomSoru_index = Random.Range(0, cevaplanmamis_Sorular.Count);
        gecerli_Soru = cevaplanmamis_Sorular[randomSoru_index];
        soruText.text = gecerli_Soru.soru;

        if (gecerli_Soru.dogrumu)
        {
            dogruTxt.text = "DOĞRU CEVAPLADINIZ";
            yanlisTxt.text = "YANLIŞ CEVAPLADINIZ";
        }
        else
        {
            dogruTxt.text = "YANLIŞ CEVAPLADINIZ";
            yanlisTxt.text = "DOĞRU CEVAPLADINIZ";
        }
    }

    IEnumerator SorularArasiBekleRoutine()
    {
        cevaplanmamis_Sorular.Remove(gecerli_Soru);
        yield return new WaitForSeconds(1f);

        if (cevaplanmamis_Sorular.Count<=0)
        {

            sonucPanel.SetActive(true);

            sonucManager = Object.FindObjectOfType<SonucManager>();
            sonucManager.SonuclariYazdir(dogruAdet, yanlisAdet, toplamPuan);
        }
        else
        {
            RastgeleSoruSec();
    
        }
       
    }

    public void DogruButonaBasildi()
    {
        if (gecerli_Soru.dogrumu)
        {
            dogruAdet++;
            toplamPuan += 100;
        }
        else
        {
            yanlisAdet++;
        }
        yanlisBtn.GetComponent<RectTransform>().DOLocalMoveX(1000, 0.2f);
        StartCoroutine(SorularArasiBekleRoutine());
    }

    public void yanlisButonaBasildi()
    {
        if (!gecerli_Soru.dogrumu)
        {
            toplamPuan += 100;
            dogruAdet++;
        }
        else
        {
            yanlisAdet++;    
        }
        dogruBtn.GetComponent<RectTransform>().DOLocalMoveX(-1000, 0.2f);
         StartCoroutine(SorularArasiBekleRoutine());
    }

    

}
