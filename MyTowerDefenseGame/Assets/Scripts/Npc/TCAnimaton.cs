using UnityEngine;

public class TCAnimaton : NpcAnimationController
{
    private ArcherTower _archerTower;
    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        _archerTower = GetComponent<ArcherTower>();
        
        LastPosition = _archerTower.target.position;
    }
    
    private void Update()
    {
        var direction = (LastPosition - _archerTower.target.position).normalized;
        NpcDirectionMvtTrigger(direction);
    }
}
