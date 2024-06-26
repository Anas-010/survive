using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    public int health;

    public Animator mAnimator;

    // .
    private void Start()
    {
        health = maxHealth;
        mAnimator = ZombieMovement.FindAnyObjectByType<Animator>();
    }

    //.
    public IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    // .
    public void ZombieDamage(int damage)
    {
        health -= damage;
        mAnimator.SetTrigger("isHit");

        if (health <= 0)
        {
            mAnimator.SetTrigger("isDead");
            Wait(2);
            Destroy(gameObject);
        }
    }
}