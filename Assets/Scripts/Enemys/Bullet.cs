using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    [SerializeField] bool enemyBullet;
    public LayerMask whatIsSolid;
    public GameObject destroyEffect;

    
    private void Start()
    {
        Invoke("Destroybullet", lifetime);
    }

    private void Update()

    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);

        if (hitInfo.collider != null)

        {

            
            if (hitInfo.collider.CompareTag("Player") && enemyBullet)

            {

                //hitInfo.collider.GetComponent<Player>().ChangeHealth(-damage);

            }
            DestroyBullet();
            

        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }
    public void DestroyBullet()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
