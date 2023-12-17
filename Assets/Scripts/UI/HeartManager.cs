using UnityEngine;
using UnityEngine.UIElements;

public class HeartManager : MonoBehaviour
{
    private Button HeartOneContainer;
    private Button HeartTwoContainer;
    private Button HeartThreeContainer;
    private Button ShieldContainer;
    
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        
        this.HeartOneContainer = root.Q<Button>("HeartOne");
        this.HeartTwoContainer = root.Q<Button>("HeartTwo");
        this.HeartThreeContainer = root.Q<Button>("HeartThree");
        this.ShieldContainer = root.Q<Button>("Shield");
    }

    private void FixedUpdate()
    {
        int health = GameManager.Instance.GetPlayerHealth();
        bool shield = GameManager.Instance.GetPlayerShield();

        this.ShieldContainer.visible = shield;

        switch (health)
        {
            case 2:
                this.HeartThreeContainer.visible = false;
                break;
            case 1:
                this.HeartTwoContainer.visible = false;
                break;
            case 0:
                this.HeartOneContainer.visible = false;
                break;
        }
    }
}
