using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TekrarOyna : MonoBehaviour
{
    public void yenidenOyna()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
