using UnityEngine;


public class PlayerLogic : MonoBehaviour
{
    [SerializeField]
    private ScriptableObjectLogic InitialHealth;
    
    [SerializeField]
    private ScriptableObjectLogic Health;

    [SerializeField]
    private GameObject enemy;

    private Animator animator;
    private Rigidbody RB;
    public Camera camera;

    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform lookObj = null;
    public float LookDistance = 5f;
    //public float PickUPDistance = 1f;
    private float dist;

    private void Start()
    {
        Health.Value = InitialHealth.Value;
        animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();


    }
    private void Update()
    {
        dist = Vector3.Distance(transform.position, enemy.transform.position);
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
        if (Health.Value <= 0)
        {
            Time.timeScale = 0f;
        }
    }

    void OnGUI()
    {

        GUI.Label(new Rect(220, 10, 100, 30),"Health Point: " + Health.Value.ToString());
    }
    void OnAnimatorIK()
    {
        if (animator)
        {

            if (ikActive)
            {
               
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                

                if (LookDistance >= dist)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                }

                else
                {
                    
                    animator.SetLookAtWeight(0);
                }


            }
        }
    }

}
