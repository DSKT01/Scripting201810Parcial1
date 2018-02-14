using UnityEngine;

public class Ball : MonoBehaviour
{
    private new Rigidbody rigidbody;
    bool follow = false;
    public Rigidbody Rigidbody
    {
        get { return rigidbody; }
    }
    Transform paddle;
    LifeController vida;
    Vector3 latPos;
    // Use this for initialization
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        if (rigidbody != null)
        {
            rigidbody.AddForce(Vector3.down * 5F, ForceMode.Impulse);
        }

        paddle = GameObject.Find("Paddle").GetComponent<Transform>();
        vida = GetComponent<LifeController>();
        Reiniciar();
        latPos = transform.position;
    }
     void Update()
    {

        if (follow)
        {
            transform.localPosition = new Vector3(paddle.localPosition.x, paddle.localPosition.y + 1, paddle.localPosition.z);
            if (Input.GetButtonDown("Jump"))
            {
                rigidbody.AddForce(Vector3.up * 14.8F, ForceMode.VelocityChange);
                follow = false;
            }
        }
        if (vida.Puntos >= 10)
        {
            rigidbody.AddForce((transform.position - latPos) * 1.2f, ForceMode.VelocityChange);
        }

        latPos = transform.position;
    }

    void Reiniciar()
    {
        rigidbody.velocity = Vector3.zero;
        transform.localRotation = Quaternion.identity;
     
        follow = true;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DeathTrigger")
        {
            Reiniciar();
            vida.Vidas = 1;
        }
    }
}