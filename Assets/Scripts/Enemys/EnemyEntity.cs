using System;
using System.Collections;
using System.Drawing;
using UnityEngine;
using static PlayerController;
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(EnemyAI))]
public class EnemyEntity : MonoBehaviour
{
    
    //[SerializeField] private EnemySO _enemySO;
    public Animator anim;
    private AudioSource _audioSourse;

    public event EventHandler OnTakeHit;
    public event EventHandler OnDeath;

    [SerializeField] private int _maxHealth;
    public int _currentHealth;

    private PolygonCollider2D _polygonCollider2D;
    private BoxCollider2D _boxCollider2D;
    private EnemyAI _enemyAI;

    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _enemyAI = GetComponent<EnemyAI>();
        _audioSourse = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _audioSourse.Play();
            anim.SetTrigger("attack");
            Debug.Log("Attack");
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("hit");
        _currentHealth -= damage;
        OnTakeHit?.Invoke(this, EventArgs.Empty);
        
        DetectDeath();
    }

    public void PolygonColliderTurnOff()
    {
        _polygonCollider2D.enabled = false;
    }

    public void PolygonColliderTurnOn()
    {
        _polygonCollider2D.enabled = true;
    }

    private void DetectDeath()
    {
        if (_currentHealth <= 0)
        {
            
            
            Debug.Log("diiiiie");
            _boxCollider2D.enabled = false;
            _polygonCollider2D.enabled = false;
            anim.SetTrigger("death");
            _enemyAI.SetDeathState();
           
            OnDeath?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject, 5);
        }
    }
}
