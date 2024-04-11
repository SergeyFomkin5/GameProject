using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _moveVector;

    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _fallVelocity;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpForce;
    void Start()
    {
       _characterController=GetComponent<CharacterController>(); 
    }
    void Update()
    {
        PlayerManager();
    }
    private void FixedUpdate()
    {

        _fallVelocity += _gravity * Time.fixedDeltaTime;
        _characterController.Move(_moveVector * _playerSpeed * Time.fixedDeltaTime);
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;

        }
    }
    void PlayerManager()
    {
        _moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -_jumpForce;
        }
        }

}
