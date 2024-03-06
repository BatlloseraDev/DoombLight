using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void ChargeScene(int scene)
    {
        if(SceneManager.GetSceneByBuildIndex(scene)!=null)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
