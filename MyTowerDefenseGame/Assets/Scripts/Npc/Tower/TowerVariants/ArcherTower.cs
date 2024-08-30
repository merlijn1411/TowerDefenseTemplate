using UnityEngine;
using UnityEditor;
public class ArcherTower : Tower 
{
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
        var projectille = Instantiate(TowerData.ProjectillePrefab, FirePoint.position, FirePoint.rotation);
        var projectilleScript = projectille.GetComponent<Arrow>();

        projectilleScript?.Seek(Target);
    }
}