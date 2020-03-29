using UnityEngine;

public class balas_controller_script : MonoBehaviour
{
    public float speed = 100;
    public int damage = 700;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        Physics.IgnoreLayerCollision(12, 11);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 3);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            collision.gameObject.GetComponent<enemig_healthManager_script>().HurtEnemy(damage);
            Destroy(gameObject);


            //si el daño ejercido elimina al esbirro se suman los puntos al jugador
            if (damage >= collision.gameObject.GetComponent<enemig_healthManager_script>().currentHealth)
            {
                this.player = GameObject.FindGameObjectWithTag("Player2");
                this.player.GetComponent<jugador_scoreManager_script>().puntuacion += collision.gameObject.GetComponent<enemig_healthManager_script>().points;
            }
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
