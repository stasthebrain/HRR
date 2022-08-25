using UnityEngine;


public class PlayerLogic : MonoBehaviour
{
    [SerializeField]
    private ScriptableObjectLogic InitialHealth;
    
    [SerializeField]
    private ScriptableObjectLogic Health;
    private void Start()
    {
        Health.Value = InitialHealth.Value;
    }
    
    private void Die()
    {
        if (Health.Value < 0)
        {
            Time.timeScale = 0f;
        }
    }

    void OnGUI()
    {

        GUI.Label(new Rect(220, 10, 100, 30),"Health Point: " + Health.Value.ToString());
    }

}
