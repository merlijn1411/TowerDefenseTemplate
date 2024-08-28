using UnityEditor;
using UnityEngine;

public class ArcherTower : TowerShootCalculation
{
    [SerializeField] private TowerData towerData;
    [SerializeField] private Transform firePoint; 

    private Transform target; 
    private float lastAttackTime;

    private TCAnimaton _tCAnimaton;

    private AudioSource _shootAudioSource;

    private void OnDrawGizmos()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position,transform.forward, towerData.AttackRange);
    }

    private void Start()
    {
        _tCAnimaton = GetComponentInChildren<TCAnimaton>();
        _shootAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        target = FindNearestEnemy(towerData.AttackRange);
    
        if (target&& Time.time - lastAttackTime >= towerData.AttackCooldown)
        {
            _tCAnimaton.StartAnimation(target);
            _shootAudioSource.Play();
            Shoot();
            lastAttackTime = Time.time;
        }
        else 
            _tCAnimaton.StartAnimation(null); 
        
    }
    
    private void Shoot()
    {
        var projectille = Instantiate(towerData.ProjectillePrefab, firePoint.position, firePoint.rotation);
        var projectilleScript = projectille.GetComponent<Arrow>();

        projectilleScript?.Seek(target);
    }
}