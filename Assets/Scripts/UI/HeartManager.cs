using UnityEngine;
using UnityEngine.UIElements;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private GameObject HeartOneContainer;
    [SerializeField] private GameObject HeartTwoContainer;
    [SerializeField] private GameObject HeartThreeContainer;
    [SerializeField] private GameObject ShieldContainer;

    private void Start()
    {
        this.HeartOneContainer.SetActive(true);
        this.HeartTwoContainer.SetActive(true);
        this.HeartThreeContainer.SetActive(true);
        this.ShieldContainer.SetActive(false);

    }

    private void FixedUpdate()
    {
        int health = GameManager.Instance.GetPlayerHealth();
        bool shield = GameManager.Instance.GetPlayerShield();

        this.ShieldContainer.SetActive(shield);

        switch (health)
        {
            case 2:
                this.HeartThreeContainer.SetActive(false);
                break;
            case 1:
                this.HeartTwoContainer.SetActive(false);
                break;
            case 0:
                this.HeartOneContainer.SetActive(false);
                break;
        }
    }
}
