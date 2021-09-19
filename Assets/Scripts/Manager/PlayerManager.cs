using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private new Rigidbody rigidbody;

    private float _horizontalValue;

    [SerializeField] private float speedHorizontal, speedForward;

    // Start is called before the first frame update
    private void Start()
    {
        InputManager.Instance.onHorizontalValueChanged += OnHorizontalValueChanged;
    }

    private void FixedUpdate()
    {

        ForwardMovement();

        HorizontalMovement();
    }

    private void HorizontalMovement()
    {
        rigidbody.velocity += new Vector3(_horizontalValue * speedHorizontal * Time.fixedDeltaTime, 0, 0);
    }

    private void ForwardMovement()
    {
        rigidbody.velocity = new Vector3(0, 0, speedForward);
    }

    private void OnHorizontalValueChanged(float val)
    {
        _horizontalValue = val;
    }
}
