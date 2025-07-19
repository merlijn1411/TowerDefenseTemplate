using UnityEngine;
using UnityEditor;
public class ArcherTower : Tower
{
    [SerializeField] private float trajectoryMaxHeight;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private AnimationCurve axisCorrectionAnimationCurve;
    
    private TCAnimaton _tCAnimaton;
    
    private AudioSource _shootAudioSource;
    

    private void OnDrawGizmos()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position,transform.forward, TowerData.AttackRange);
    }
    
    private void Start()
    {
        _tCAnimaton = GetComponentInChildren<TCAnimaton>();
        _shootAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Target = FindNearestEnemy(TowerData.AttackRange);
    
        if (Target&& Time.time - LastAttackTime >= TowerData.AttackCooldown)
        {
            _tCAnimaton.StartAnimation(Target);
            _shootAudioSource.Play();
            Shoot();
            LastAttackTime = Time.time;
        }
        else 
            _tCAnimaton.StartAnimation(null); 
        
    }
    
    private void Shoot()
    {
        var projectile = Instantiate(TowerData.ProjectillePrefab, transform.position, Quaternion.identity);
        var projectileScript = projectile.GetComponent<Arrow>();

        projectileScript.InitializeProjectile(Target, TowerData.ProjectileSpeed, trajectoryMaxHeight);
        projectileScript.InitializeAnimationCurve(animationCurve, axisCorrectionAnimationCurve);
    }
}