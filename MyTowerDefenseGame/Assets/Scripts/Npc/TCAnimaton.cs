using UnityEngine;

//TC stands for Tower Character.
public class TCAnimaton : NpcAnimationController
{
    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    public void StartAnimation(Transform targetsTransform)
    {
        if (targetsTransform)
        {
            var direction = targetsTransform.position - transform.position;
        
            NpcDirectionMvtTrigger(direction);
        }
        else
            NpcDirectionMvtTrigger(Vector3.zero);
        
    }
}
