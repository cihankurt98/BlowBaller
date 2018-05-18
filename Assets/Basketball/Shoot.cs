using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject ball;
    private GameObject ballClone;
    public GameObject meter;
    public GameObject arrow;

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
}
