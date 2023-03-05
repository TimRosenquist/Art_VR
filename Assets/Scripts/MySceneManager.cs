using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

namespace Art_VR
{
    public class MySceneManager : MonoBehaviour
    {
        XRIDefaultInputActions inputActions;
        InputAction mainMenu;
        public void LoadCreativeScene()
        {
            LoadSceneAsync("Creative");
        }
        public void LoadAnarchyScene()
        {
            LoadSceneAsync("Anarchy");
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
            LoadSceneAsync("Main Menu");
        }

        public async void LoadSceneAsync(string sceneName)
        {
            // Load the scene asynchronously in the background
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            // Wait until the scene is fully loaded
            while (!asyncOperation.isDone)
            {
                await Task.Yield();
            }
        }

        /*public async void UnloadSceneAsync(string sceneName)
        {
            // Unload the scene asynchronously in the background
            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);

            // Wait until the scene is fully unloaded
            while (!asyncOperation.isDone)
            {
                await Task.Yield();
            }*/
    }
}   

  
 


