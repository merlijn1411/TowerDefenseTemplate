using UnityEngine;

public class TCAnimaton : NpcAnimationController
{
    private void Start()
    {
        animator = GetComponent<Animator>();
        
        LastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
