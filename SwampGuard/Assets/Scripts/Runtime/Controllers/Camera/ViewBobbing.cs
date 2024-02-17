using UnityEngine;

public class ViewBobbing : MonoBehaviour
{
    [SerializeField] private float effectIntensity;
    [SerializeField] private float effectIntensitX;
    [SerializeField] private float effectSpeed;

    private PositionFollower _positionFollower;
    private Vector3 _originalOffset;
    private float sinTime;

    private void Awake()
    {
        _positionFollower = GetComponent<PositionFollower>();
        _originalOffset = _positionFollower.Offset;
    }


    private void Update()
    {
        Vector2 input = InputManager.Instance.GetMovementInput();

        if(input.magnitude > 0.1f)
        {
            sinTime += Time.deltaTime * effectSpeed;
    
        }
        else
        {
            sinTime = 0;
        }
        float sinAmountY =  -Mathf.Abs(effectIntensity * Mathf.Sin(sinTime));
        Vector3 sinAmountX = _positionFollower.transform.right * effectIntensity * Mathf.Cos(sinTime) * effectIntensitX;
            _positionFollower.Offset = new Vector3{
            x = _originalOffset.x,
            y = _originalOffset.y + sinAmountY,
            z = _originalOffset.z
        }; 

        _positionFollower.Offset += sinAmountX; 
    }
}
