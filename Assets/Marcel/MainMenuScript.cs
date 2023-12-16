using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        
        Button buttonStart = root.Q<Button>("buttonStartGame");
        buttonStart.clicked += StartGame;
        
        Button buttonClose = root.Q<Button>("buttonCloseGame");
        buttonClose.clicked += CloseGame;
    }
    
    private void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene(1);
    }
    
    private void CloseGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
