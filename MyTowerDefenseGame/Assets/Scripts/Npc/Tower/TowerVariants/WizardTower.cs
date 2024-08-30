using UnityEngine;
using UnityEditor;

public class WizardTower : Tower
{
    private AudioSource _shootAudioSource;

    private void OnDrawGizmos()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position,transform.forward, TowerData.AttackRange);
    }
    
    private void Start()
    {
        _shootAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Target = FindNearestEnemy(TowerData.AttackRange);
        
        if (Target&& Time.time - LastAttackTime >= TowerData.AttackCooldown)
        {
            _shootAudioSource.Play();
            Shoot();
            LastAttackTime = Time.time;
        }
    }
    
    private void Shoot()
    {
        var projectille = Instantiate(TowerData.ProjectillePrefab, FirePoint.position, FirePoint.rotation);
        var projectilleScript = projectille.GetComponent<Fireball>();

        projectilleScript?.Seek(Target);
    }
}
