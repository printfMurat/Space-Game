using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StageOperations : MonoBehaviour
{
    public GameObject PlayPanel;


    private void Start()
    {
        PlayPanel?.SetActive(true);
    }
    public void RestartScene()
    { 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void NextPage()
    {
       PlayPanel.SetActive(false);
    }
    public void PreviousPage()
    {
        PlayPanel?.SetActive(true);
    }
    public void NextGame()
    {
        SceneManager.LoadScene(1);
    }
    public void PreviousGame()
    {
        SceneManager.LoadScene(0);
    }
}
