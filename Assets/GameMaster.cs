using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [Header("Ball settings")]
    public Vector3 ballThrowSpeed;
    public Vector3 ballGravity;
    [Header("Meter settings")]
    public float arrowSpeed;
    public static GameMaster instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
    }



    void Start()
    {

    }


}