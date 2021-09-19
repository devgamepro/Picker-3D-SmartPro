using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{

    #region Singleton
    public static InputManager Instance;
    #endregion


    public UnityAction<float> onHorizontalValueChanged = delegate { };

    private float _horizontalValue;
    private float _mousePos, _currentVelocity;
    private Vector2? _mousePosition; //ref type
    private Vector3 _moveVector; //ref type

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseDeltaPos = (Vector2)Input.mousePosition - _mousePosition.Value;


            if (mouseDeltaPos.x > 1.25f)
                _moveVector.x = 1.25f / 10f * mouseDeltaPos.x;
            else if (mouseDeltaPos.x < -1.25f)
                _moveVector.x = -1.25f / 10f * -mouseDeltaPos.x;
            else
                _moveVector.x = Mathf.SmoothDamp(_moveVector.x, 0f, ref _currentVelocity,
                    .007f);

            _mousePosition = Input.mousePosition;
        }
        _horizontalValue = Input.GetAxisRaw("Mouse X");
        onHorizontalValueChanged?.Invoke(_moveVector.x);
    }
}
