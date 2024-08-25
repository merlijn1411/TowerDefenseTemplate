using UnityEngine;

public class NpcAnimationController : MonoBehaviour
{
    [HideInInspector]public Animator animator;
    [HideInInspector]public Vector3 LastPosition;
    
    private string _up = "MoveUp";
    private string _down = "MoveDown";
    private string _left = "MoveLeft";
    private string _right = "MoveRight";
    
    protected void NpcDirectionMvtTrigger(Vector3 direction)
    {
        if (direction.magnitude > 0.01f)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                SetDirectionTrigger(direction.x > 0 ? _right : _left);
            }
            else
            {
                SetDirectionTrigger(direction.y > 0 ? _up : _down);
            }
        }
        else
        {
            Debug.LogWarning("The animation want to do a Idle");
        }
    }
    
    private void SetDirectionTrigger(string direction)
    {
        LastPosition = transform.position;
        
        animator.ResetTrigger(_up);
        animator.ResetTrigger(_down);
        animator.ResetTrigger(_left);
        animator.ResetTrigger(_right);
        
        animator.SetTrigger(direction);
    }
}
