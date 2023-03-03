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
            SceneManager.LoadScene("Creative");
        }
        public void LoadAnarchyScene()
        {
            SceneManager.LoadScene("Anarchy");
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
        private void MainMenu_performed(InputAction.CallbackContext obj)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
