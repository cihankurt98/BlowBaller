using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour
{

    private Vector3 startPosition;
    private Vector3 throwSpeed;

    IEnumerator ResetWait()
    {
            yield return new WaitForSeconds(2.0f);
            ResetBall();
    }

    void Awake()
    {
        startPosition = transform.position;
    }

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
        //transform.position = = Instantiate(GameMaster.instance.getBall(), ballPos, transform.rotation);
        throwSpeed.y = throwSpeed.y + sliderValue;
        throwSpeed.z = throwSpeed.z + sliderValue;
        GetComponent<Rigidbody>().AddForce(throwSpeed, ForceMode.Impulse);
        GetComponent<AudioSource>().Play(); //play shoot sound
        StartCoroutine(ResetWait());
    }

    public void ResetBall()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        throwSpeed.y = 0;
        throwSpeed.z = 0;
        transform.position = startPosition;
    }
}