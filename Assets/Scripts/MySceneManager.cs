using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

namespace Art_VR
{
    public class MySceneManager : MonoBehaviour
    {
        XRIDefaultInputActions inputActions;
        InputAction mainMenu;
        public void LoadCreativeScene()
        {
            LoadScene("Creative");
        }
        public void LoadAnarchyScene()
        {
            LoadScene("Anarchy");
        }
        public void QuitApplication()
        {
            Application.Quit();
        }
        private void OnEnable()
        {
            inputActions = new XRIDefaultInputActions();
            mainMenu = inputActions.XRILeftHandInteraction.MainMenu;
            mainMenu.Enable();
            mainMenu.performed += MainMenu_performed;
        }
        private void OnDisable()
        {
            inputActions = new XRIDefaultInputActions();
            mainMenu = inputActions.XRILeftHandInteraction.MainMenu;
            mainMenu.Disable();
            mainMenu.performed -= MainMenu_performed;
        }


        private void MainMenu_performed(InputAction.CallbackContext obj)
        {
            LoadScene("Main Menu");
        }

        public void LoadScene(string sceneName)
        {
            if (this != null)
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }

        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            // Load the scene asynchronously in the background
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            // Wait until the scene is fully loaded
            while (!asyncOperation.isDone)
            {
                yield return null;
            }
        }
    }
} 
    
     

  
 


