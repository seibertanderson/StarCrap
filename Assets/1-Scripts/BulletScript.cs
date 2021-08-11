using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject ExplosionParticles;


    private void OnCollisionEnter2D(Collision2D col)
    {        
        if (col.collider.tag.Equals("EnemyTag"))
        {
            FindObjectOfType<AudioManager>().Play("EnemyKill");
            GameObject explosionParticles = Instantiate(ExplosionParticles, transform.position, Quaternion.identity);
            Destroy(explosionParticles, 1f);
            Destroy(gameObject);
            Destroy(col.collider.gameObject);
            FindObjectOfType<GameManager>().points += 10;
            return;
        }
    }
}
