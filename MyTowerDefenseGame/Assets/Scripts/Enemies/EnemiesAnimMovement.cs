using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAnimMovement : MonoBehaviour
{
    public Animator animator;
    private Vector3 lastPosition; 
    

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 direction = (transform.position - lastPosition).normalized;
        
        lastPosition = transform.position;
        
        if (direction.magnitude > 0.01f)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                    SetDirectionTrigger("MoveRight");
                else
                    SetDirectionTrigger("MoveLeft");
            }
            else
            {
                if (direction.y > 0)
                    SetDirectionTrigger("MoveUp");
                else
                    SetDirectionTrigger("MoveDown");
            }
        }
        else
        {
            Debug.LogWarning("The animation want to do a Idle");
        }
    }
    void SetDirectionTrigger(string direction)
    {
        animator.ResetTrigger("MoveUp");
        animator.ResetTrigger("MoveDown");
        animator.ResetTrigger("MoveLeft");
        animator.ResetTrigger("MoveRight");
        
        animator.SetTrigger(direction);
    }
}
