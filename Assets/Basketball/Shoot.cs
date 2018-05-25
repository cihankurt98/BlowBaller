using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public Vector3 ballPos;
    private Vector3 throwSpeed;

    // Use this for initialization

    void Awake()
    {
        FixedUpdate();
    }
    void FixedUpdate()
    {
        Physics.gravity = GameMaster.instance.getBallGravity(); //new Vector3(0, -20, 0);
        throwSpeed = GameMaster.instance.getBallThrowSpeed();
    }

    public void ShootBall(float sliderValue)
    {
        throwSpeed.y = throwSpeed.y + sliderValue;
        throwSpeed.z = throwSpeed.z + sliderValue;
        transform.GetComponent<Rigidbody>().AddForce(throwSpeed, ForceMode.Impulse);
        GetComponent<AudioSource>().Play(); //play shoot sound
    }
}