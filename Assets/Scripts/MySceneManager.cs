using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Art_VR
{
    public class MySceneManager : MonoBehaviour
    {

        public void LoadCreativeScene()
        {
            SceneManager.LoadScene("Creative");
        }
        public void LoadAnarchyScene()
        {
            SceneManager.LoadScene("Anarchy");
        }
    }

}
