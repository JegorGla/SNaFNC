using UnityEngine;

public class WoodAnimation : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

        // Check if any movement key is pressed
        if (isMoving)
        {
            animator.SetTrigger("Wood");
        }
        else
        {
            animator.SetTrigger("StopWood");
        }
    }
}
