using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour
{
    private Vector3 startPosition;

    IEnumerator ResetWait()
    {
        yield return new WaitForSeconds(5.0f);
        ResetBall();
    }

    public Vector3 getStartPosition()
    {
        return startPosition;
    }

    void Start()
    {
        Physics.gravity = new Vector3(0,0,0);
        startPosition = transform.position;
    }

    public void ShootBall(float sliderValue)
    {
        Physics.gravity = GameMaster.instance.getBallGravity();
        Vector3 tempThrowSpeed;
        tempThrowSpeed = new Vector3(GameMaster.instance.getBallThrowSpeed().x + sliderValue, GameMaster.instance.getBallThrowSpeed().y
            + sliderValue, GameMaster.instance.getBallThrowSpeed().z);
        GetComponent<Rigidbody>().AddForce(tempThrowSpeed, ForceMode.Impulse);
        GetComponent<AudioSource>().Play(); //play shoot sound
        StartCoroutine(ResetWait());
    }

    public void ResetBall()
    {
        Physics.gravity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = startPosition;
    }
}