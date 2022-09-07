using UnityEngine;


public class PlayerLogic : MonoBehaviour
{
    [SerializeField]
    private ScriptableObjectLogic InitialHealth;
    
    [SerializeField]
    private ScriptableObjectLogic Health;

    private Animator animator;
    private Rigidbody RB;
    public Camera camera;

    private void Start()
    {
        Health.Value = InitialHealth.Value;
        animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        Moving();
    }
    void Moving()
    {
        animator.SetInteger("VelocityY", ((int)camera.velocity.x));
        if (RB.velocity.magnitude > 0)
            animator.SetFloat("Speed", RB.velocity.magnitude);
        

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
