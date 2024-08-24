using UnityEngine;

public class NpcAnimationController : MonoBehaviour
{
    private Animator animator;
    private Vector3 lastPosition;
    
    private string _up = "MoveUp";
    private string _down = "MoveDown";
    private string _left = "MoveLeft";
    private string _right = "MoveRight";

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        lastPosition = transform.position;
    }

    private void Update()
    {
        var direction = (transform.position - lastPosition).normalized;
        NpcDirectionMvtTrigger(direction);
    }

    private void NpcDirectionMvtTrigger(Vector3 direction)
    {
        if (direction.magnitude > 0.01f)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                    SetDirectionTrigger(_right);
                else
                    SetDirectionTrigger(_left);
            }
            else
            {
                if (direction.y > 0)
                    SetDirectionTrigger(_up);
                else
                    SetDirectionTrigger(_down);
            }
        }
        else
        {
            Debug.LogWarning("The animation want to do a Idle");
        }
    }
    
    private void SetDirectionTrigger(string direction)
    {
        lastPosition = transform.position;
        
        animator.ResetTrigger(_up);
        animator.ResetTrigger(_down);
        animator.ResetTrigger(_left);
        animator.ResetTrigger(_right);
        
        animator.SetTrigger(direction);
    }
}
