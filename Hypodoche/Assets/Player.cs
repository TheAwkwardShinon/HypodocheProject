using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidBody.velocity = new Vector3(horizontal * speed, vertical * speed, 0);

    }
}
