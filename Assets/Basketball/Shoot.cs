using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    private GameObject ballClone;

    public Vector3 ballPos;
    private Vector3 throwSpeed;

    // Use this for initialization
    void Start()
    {
        /* Increase Gravity */
        Physics.gravity = GameMaster.instance.getBallGravity(); //new Vector3(0, -20, 0);
        throwSpeed = GameMaster.instance.getBallThrowSpeed();
    }

    void FixedUpdate() //Performance. Memory management for iPad.
    {
  
    }

    public void ShootBall(float sliderValue)
    {
        ballClone = Instantiate(GameMaster.instance.getBall(), ballPos, transform.rotation);
        throwSpeed.y = throwSpeed.y + sliderValue;
        throwSpeed.z = throwSpeed.z + sliderValue;
        ballClone.GetComponent<Rigidbody>().AddForce(throwSpeed, ForceMode.Impulse);
        GetComponent<AudioSource>().Play(); //play shoot sound
    }
}