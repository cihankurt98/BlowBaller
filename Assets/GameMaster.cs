using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [Header("Basket settings")]
    [SerializeField]
    private GameObject basket;
    [SerializeField]
    private float basketSpeed;
    [SerializeField]
    private Vector3 basketStartPosition;
    [Header("Ball settings")]
    [SerializeField]
    private GameObject ball;
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

    public float getBasketSpeed()
    {
        return basketSpeed;
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

    public Vector3 getBasketStartPosition()
    {
        return basketStartPosition;
    }

    public void updateSlider()
    {
        if (ball.transform.position == ball.GetComponent<BallManager>().getStartPosition())
        {
            slider.value = (float)System.Math.Round(DeviceManager.Instance.FlowLMin, 1);
            if (slider.value == slider.maxValue)
            {
                ball.GetComponent<BallManager>().ShootBall(slider.value);
                basket.GetComponent<Basket>().Reset();
                slider.value = 0;
            }
        }
    }



}