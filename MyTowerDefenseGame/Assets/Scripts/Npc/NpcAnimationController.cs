using UnityEngine;

public class NpcAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Vector3 _lastPosition;
    
    private string _up = "MoveUp";
    private string _down = "MoveDown";
    private string _left = "MoveLeft";
    private string _right = "MoveRight";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        
        _lastPosition = transform.position;
    }

    private void Update()
    {
        var direction = (transform.position - _lastPosition).normalized;
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
        _lastPosition = transform.position;
        
        _animator.ResetTrigger(_up);
        _animator.ResetTrigger(_down);
        _animator.ResetTrigger(_left);
        _animator.ResetTrigger(_right);
        
        _animator.SetTrigger(direction);
    }
}
