using UnityEngine;

public class BackgroundScollingScript : MonoBehaviour
{
    public float speed;
    public Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);

        if (transform.position.x < -26f)
        {
            transform.position = startPos;
        }
    }
}
