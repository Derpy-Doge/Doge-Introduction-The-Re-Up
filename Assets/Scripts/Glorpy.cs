using UnityEngine;



[System.Serializable]
public struct squeak
{
    public Transform layerTransform;
    [Tooltip("0 = Moves with camera (infinity far), 1 = Stays stationary (foreground)")]
    public float parallaxSpeed;
}

public class Glorpy : MonoBehaviour
{
    public bool jester;

    [Header("graPe")]
    public Transform camTransform;
    public squeak[] ryx;

    private Vector3 _lastCamPos;


    [Header("shrimp")]
    public Transform player;
    private RectTransform _rectTransform;

    [Header("Zirconium")]
    public float parallaxMul = .1f;

    private Vector3 _lastPLayerPos;

    void Start()
    {
        if (jester)
        {
            if (camTransform == null)
            {
                camTransform = Camera.main.transform;
            }
            _lastCamPos = camTransform.position;
        }
        else
        {
            _rectTransform = GetComponent<RectTransform>();
            if (player == null)
            {
                GameObject playr = GameObject.FindGameObjectWithTag("TIM");
                if (playr != null) player = playr.transform;
            }

            if (player != null)
            {
                _lastPLayerPos = player.position;
            }
        }  
    }

    void LateUpdate()
    {
        if (jester)
        {
            Vector3 deltaMovement = camTransform.position - _lastCamPos;

            for (int i = 0; i < ryx.Length; i++)
            {
                Vector3 movement = new Vector3(deltaMovement.x * ryx[i].parallaxSpeed, deltaMovement.y * ryx[i].parallaxSpeed, 0);
                ryx[i].layerTransform.position += movement;
            }

            _lastCamPos = camTransform.position;
        }
        else
        {
            if (player == null) return;

            Vector3 green = player.position - _lastPLayerPos;

            Vector2 turtle = new Vector2(green.x, green.y) * parallaxMul;
            _rectTransform.anchoredPosition -= turtle;

            _lastPLayerPos = player.position;
        }

    } 
}
