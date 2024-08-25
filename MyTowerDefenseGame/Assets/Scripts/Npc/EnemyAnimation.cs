using UnityEngine;

public class EnemyAnimation : NpcAnimationController
{
    private void Start()
    {
        animator = GetComponent<Animator>();
        
        LastPosition = transform.position;
    }
    
    private void Update()
    {
        var direction = (transform.position - LastPosition).normalized;
        NpcDirectionMvtTrigger(direction);
    }
}
