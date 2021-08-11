using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockPrefab : MonoBehaviour
{
    [Range(0, 200)]
    [HideInInspector]
    public float MoveSpeed;
    [HideInInspector]
    public float RotationSpeed;
    public GameObject ExplosionParticles;

    private void Start()
    {
        MoveSpeed = Random.Range(.5f, 1f);
        RotationSpeed = Random.Range(0, 150);
    }
    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerScript>() != null)
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, FindObjectOfType<PlayerScript>().transform.position, Time.deltaTime * MoveSpeed);
            transform.Rotate(new Vector3(0, 0, -1) * RotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag.Equals("PlayerTag"))
        {
            FindObjectOfType<AudioManager>().Play("EnemyKill");
            GameObject explosion = Instantiate(ExplosionParticles, transform.position, Quaternion.identity);
            GameObject explosion2 = Instantiate(ExplosionParticles, col.collider.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(col.gameObject);
            Destroy(explosion, 1f);
            Destroy(explosion2, 1f);


        }
    }
}
