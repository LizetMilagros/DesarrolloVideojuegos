
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2;
    int index = 0;
    public bool isLoop = true;
    
    void Start(){

    }
    private void Update(){
        Vector3 destination = waypoints[index].transform.position;
        destination.y = transform.position.y;
        transform.LookAt(destination);
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed *Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if(distance <= 0.05){
            if(index < waypoints.Count-1){
                index ++;
            }else{
                if(isLoop){
                    index =0;
                }
            }
            // Actualiza el valor de "IsWalking" en el Animator Controller
        GetComponent<Animator>().SetBool("IsWalking", IsWalking());
        }
    }
    bool IsWalking(){
        float distance = Vector3.Distance(transform.position, waypoints[index].transform.position);
        return distance > 0.05;
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2;
    int index = 0;
    public bool isLoop = true;
    public GameObject player;
    public float chaseDistance = 5f;

    void Start(){

    }

    void Update()
    {
        // Si el jugador está cerca, el enemigo detiene su movimiento
        if (Vector3.Distance(transform.position, player.transform.position) <= chaseDistance)
        {
            transform.position = newPos;
            return;
        }

        Vector3 destination = waypoints[index].transform.position;
        destination.y = transform.position.y;
        transform.LookAt(destination);
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            if (index < waypoints.Count - 1)
            {
                index++;
            }
            else
            {
                if (isLoop)
                {
                    index = 0;
                }
            }
            // Actualiza el valor de "IsWalking" en el Animator Controller
            GetComponent<Animator>().SetBool("IsWalking", IsWalking());
        }
    }

    bool IsWalking()
    {
        float distance = Vector3.Distance(transform.position, waypoints[index].transform.position);
        return distance > 0.05;
    }
}*/