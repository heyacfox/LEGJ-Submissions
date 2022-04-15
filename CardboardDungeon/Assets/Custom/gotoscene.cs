using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoscene : MonoBehaviour
{
    public void gothere()
    {
        SceneManager.LoadScene("Scene1");
    }
}
