using UnityEngine;

public class FollowWP : MonoBehaviour
{
    float speed = 5.0f;
    public Transform target;

    void Start()
    {
        // Inicialmente, apunta a la posición del primer waypoint
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    void Update()
    {
        // Mueve hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Calcula la distancia hasta el siguiente waypoint
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Si está lo suficientemente cerca del waypoint, cambia al siguiente
        if (distanceToTarget < 0.2f)
        {
            // Obtén el siguiente waypoint desde el componente WP
            SetNextWaypoint();
        }
    }

    void SetNextWaypoint()
    {
        // Encuentra el siguiente waypoint usando el componente WP
        WP waypointComponent = target.GetComponent<WP>();

        if (waypointComponent != null)
        {
            target = waypointComponent.nexPoint;
            // Ajusta la rotación para mirar hacia el nuevo objetivo
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
        else
        {
            Debug.LogError("El objeto actual no tiene el componente WP.");
        }
    }
}

//using UnityEngine;


/*public class FollowWP : MonoBehaviour {
    // Array of way points
    public GameObject[] waypoints;
    // waypoint index
    int currentWP = 0;
    // Tank speed
    public float speed = 2.0f;
    // Tank rotation speed
    public float rotSpeed = 2.0f;
    // Limit how far the tracker moves in front of the tank
    public float lookAhead = 10.0f;

    // Store a tracker that the tanks will follow
    GameObject tracker;

    public Transform player;
    public float damage;
    public float pushForce = 4.0f;

    void Start() {

        // Create a cylinder for visual purposes
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        // Destroy the cylinder collider so it doesn'y cuase any issues with physics
        DestroyImmediate(tracker.GetComponent<Collider>());
        // Disable the trackers mesh renderer so you can't see it in the game
        tracker.GetComponent<MeshRenderer>().enabled = false;
        // Rotate and place the tracker
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }

    void ProcessTracker() {

        // Check the tracker doesn't get to far ahead of the tank
        if (Vector3.Distance(tracker.transform.position, this.transform.position) > lookAhead) return;

        // Check if the tank has reached a certain distance from the current waypoint
        if (Vector3.Distance(tracker.transform.position, waypoints[currentWP].transform.position) < 3.0f) {

            // Select next waypoint
            currentWP++;
        }

        // Check we haven't reached the last waypoint
        if (currentWP >= waypoints.Length) {

            // Reset if we have
            currentWP = 0;
        }

        // Aim the tracker at the current waypoint
        tracker.transform.LookAt(waypoints[currentWP].transform);
        // Move the tracker towards the waypoint
        tracker.transform.Translate(0.0f, 0.0f, (speed + 20.0f) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update() {

        // Call the ProcessTracker method to move the tracker
        ProcessTracker();

        // Create a Quaternion to look at a Vector
        Quaternion lookAtWP = Quaternion.LookRotation(tracker.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookAtWP, rotSpeed * Time.deltaTime);
        // Move the tank
        this.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                // Calcula la dirección opuesta a la colisión.
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;

                // Aplica una fuerza para empujar al jugador hacia atrás.
                playerRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);

                PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.TakeDamage(damage);
                }
            }
        }
    }
}*/
