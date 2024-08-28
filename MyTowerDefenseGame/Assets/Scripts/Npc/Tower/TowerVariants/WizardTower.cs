using UnityEngine;

public class WizardTower : TowerShootCalculation
{
    [SerializeField] private TowerData towerData;
    [SerializeField] private Transform firePoint;

    private Transform target;
    private float lastAttackTime;

    private AudioSource _shootAudioSource;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, towerData.AttackRange);
    }

    private void Start()
    {
        _shootAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        target = FindNearestEnemy(towerData.AttackRange);
        
        if (target&& Time.time - lastAttackTime >= towerData.AttackCooldown)
        {
            _shootAudioSource.Play();
            Shoot();
            lastAttackTime = Time.time;
        }
    }
    
    private void Shoot()
    {
        var projectille = Instantiate(towerData.ProjectillePrefab, firePoint.position, firePoint.rotation);
        var projectilleScript = projectille.GetComponent<Fireball>();

        projectilleScript?.Seek(target);
    }
}
