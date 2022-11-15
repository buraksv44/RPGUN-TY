using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class EnemyHealth : MonoBehaviour
{
    [HideInInspector] public float currentHealth;
    Animator anim;
    public float maxHealth = 100f;
    [SerializeField] private Image EnemyHealthBar;
    private SphereCollider targetCollider;
    public int ExpAmount = 10;
    public static event Action<int> OnDeath;
    
    private void Awake()
    {
        currentHealth = maxHealth;
        targetCollider = GetComponentInChildren<SphereCollider>();
        anim = GetComponent<Animator>();
    }
    public void TakeDamge(float amount)
    {
        currentHealth -= amount;
        EnemyHealthBar.fillAmount = currentHealth / maxHealth;
        if(currentHealth > 0)
        {
            if (this.gameObject.tag == "Boss")
            {
                AudioManager.instance.PlaySfx(6);
            }
            else if (this.gameObject.tag == "Enemy")
            {
                AudioManager.instance.PlaySfx(3);
            }
            anim.SetTrigger("Hit");
        }
        if (currentHealth <= 0)
        {
            GetComponent<CapsuleCollider>().enabled = false;
            Canvas canvas = EnemyHealthBar.gameObject.GetComponentInParent<Canvas>();
            OnDeath(ExpAmount);
            if(targetCollider.gameObject.activeInHierarchy)
            {
                targetCollider.gameObject.SetActive(false);
            }
            
            if(canvas.gameObject.activeInHierarchy)
            {
                canvas.gameObject.SetActive(false);
            }
            
        }
     }   
       
    
    
    private void update()
    {
       // print(currentHealth);
    }
}
