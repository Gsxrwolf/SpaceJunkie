using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private FlyAnimation FlyAnimation;
    [SerializeField] private GameObject CargoBayIntro;

    private void Start()
    {
        Invoke("StartAnimation", 0.5f);
    }

    private void StartAnimation()
    {
        this.FlyAnimation.PlayIntroAnimation();
    }

    public void StartGame()
    {
        this.FlyAnimation.PlayOutroAnimation(1);
    }

    public void Scoreboard()
    {
        Debug.Log("Scoreboard");
        this.FlyAnimation.PlayOutroAnimation(2);
    }

    public void CloseGame()
    {
        if (this.CargoBayIntro.transform.position.y < -4.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.1f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -3.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.15f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -2.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.2f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= -1.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.25f, 0);
            return;
        }

        if (this.CargoBayIntro.transform.position.y <= 10.0f)
        {
            this.CargoBayIntro.transform.position = this.CargoBayIntro.transform.position + new Vector3(0, 0.30f, 0);
            return;
        }

        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
