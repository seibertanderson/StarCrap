using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Range(100, 200)]
    public float RotationSpeed;
    [Range(.5f, 1f)]
    public float MoveSpeed;
    public GameObject BulletPrefab;
    public GameObject ShootParticles;
    public Transform BulletSpawnPoint;
    [Range(0, 0.1f)]
    public float BulletVelocity;
    Vector3 screenBorder;// = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

    // Use this for initialization
    void Start()
    {
        screenBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, 1) * RotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -1) * RotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 1, 0) * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Play("PlayerShoot");
            GameObject shootParticles = Instantiate(ShootParticles, BulletSpawnPoint.transform.position, Quaternion.identity);
            GameObject bulletInstance = Instantiate(BulletPrefab, BulletSpawnPoint.transform.position, Quaternion.Euler(new Vector3(0, 0, transform.localEulerAngles.z)));
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(transform.up * BulletVelocity);

            Destroy(shootParticles, .5f);
            Destroy(bulletInstance, 4);
        }
        CheckBorder();
    }

    /// <summary>
    /// Verfica se o player está passado da borda da tela e faz com que ele retorne para o cenario
    /// nao permitindo que ultrapasse as bordas da tela
    /// </summary>
    public void CheckBorder()
    {
        if (transform.position.x >= screenBorder.x)
        {
            transform.position = new Vector2(screenBorder.x - .5f, transform.position.y);
        }
        if (transform.position.x <= -screenBorder.x)
        {
            transform.position = new Vector2(-screenBorder.x + .5f, transform.position.y);
        }
        if (transform.position.y >= screenBorder.y)
        {
            transform.position = new Vector2(transform.position.x, screenBorder.y - .5f);
        }
        if (transform.position.y <= -screenBorder.y)
        {
            transform.position = new Vector2(transform.position.x, -screenBorder.y + .5f);
        }
    }
}
