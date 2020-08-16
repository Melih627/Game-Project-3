using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogrutxt, yanlistxt, puantxt;

    [SerializeField]
    private GameObject yildiz1, yildiz2, yildiz3;

    public void SonuclariYazdir(int dogruA,int yanlisA,int puan)
    {
        dogrutxt.text = dogruA.ToString();
        yanlistxt.text = yanlisA.ToString();
        puantxt.text = puan.ToString();

        yildiz1.SetActive(false);
        yildiz2.SetActive(false);
        yildiz3.SetActive(false);
        if (dogruA == 1)
        {
            yildiz1.SetActive(true);
        }
        else if (dogruA == 2)
        {
            yildiz1.SetActive(true);
            yildiz2.SetActive(true);

        }
        else
        {
            yildiz1.SetActive(true);
            yildiz2.SetActive(true);
            yildiz3.SetActive(true);
        }
    }
}
