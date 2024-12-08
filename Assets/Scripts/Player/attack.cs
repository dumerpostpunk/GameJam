using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform attackCircle;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private int damage;
    [SerializeField] public PlayerController player;

    private bool canAttack = true;
    public float cooldownTime = 1.0f;

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        attackPoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            Attack();
            StartCoroutine(Cooldown());
        }
    }

    private void Attack()
    {
        anim.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackCircle.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyEntity>().TakeDamage(damage);

            if (enemy.GetComponent<EnemyEntity>()._currentHealth < 5)
            {
                player.hasWings = true;
            }
        }

    }
    private IEnumerator Cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldownTime);
        canAttack = true;
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackCircle.position, attackRange);
    }

    
}
