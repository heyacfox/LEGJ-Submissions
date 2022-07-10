using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenething : MonoBehaviour
{
    public void goscene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
