using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject ball;
    private GameObject ballClone;

    public Vector3 ballPos;
    private Vector3 throwSpeed;
    private float arrowSpeed;

    // Use this for initialization
    void Start()
    {
        /* Increase Gravity */
        Physics.gravity = GameMaster.instance.ballGravity; //new Vector3(0, -20, 0);
        throwSpeed = GameMaster.instance.ballThrowSpeed;
        arrowSpeed = GameMaster.instance.arrowSpeed;
    }

    void FixedUpdate() //Performance. Memory management for iPad.
    {
  
    }

    public void ShootBall(int controllerValue)
    {
        ballClone = Instantiate(ball, ballPos, transform.rotation);
        throwSpeed.y = throwSpeed.y + controllerValue;
        throwSpeed.z = throwSpeed.z + controllerValue;
        ballClone.GetComponent<Rigidbody>().AddForce(throwSpeed, ForceMode.Impulse);
        GetComponent<AudioSource>().Play(); //play shoot sound
    }
}