using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [Header("Ball settings")]
    [SerializeField]
    private Vector3 ballThrowSpeed;
    [SerializeField]
    private Vector3 ballGravity;
    [Header("Meter settings")]
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float arrowSpeed;
    [Header("Controller settings")]
    [SerializeField]
    private DeviceManager.DeviceType deviceType;
    [SerializeField]
    private GameObject ball;





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
        DeviceManager.Instance.SetDeviceType(deviceType);
    }

    void FixedUpdate()
    {
        updateSlider();
    }

    public GameObject getBall()
    {
        return ball;
    }

    public Vector3 getBallThrowSpeed()
    {
        return ballThrowSpeed;
    }

    public Vector3 getBallGravity()
    {
        return ballGravity;
    }

    public void updateSlider()
    {
        slider.value = (float)System.Math.Round(DeviceManager.Instance.FlowLMin, 1);
        if (slider.value == slider.maxValue)
        {
            ball.GetComponent<BallManager>().ShootBall(slider.value);
        }
     }



}