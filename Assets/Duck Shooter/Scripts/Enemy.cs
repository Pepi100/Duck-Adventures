using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public System.Action killed;

    //public Animator animator;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            //animator.setFloat("dead", 1);
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
