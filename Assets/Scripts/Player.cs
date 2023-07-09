using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _layerMaskGround;
    [SerializeField] private Transform _groundChecker1;
    [SerializeField] private Transform _groundChecker2;

    private int _currentSpeed;
    private int _runSpeedModifier = 2;
    private Vector2 _direction;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private float _groundRadius = 0.01f;

    private bool IsGrounded()
    {
        return 
            Physics2D.OverlapCircle
            (_groundChecker1.position, _groundRadius, _layerMaskGround)
            ||
            Physics2D.OverlapCircle
            (_groundChecker2.position, _groundRadius, _layerMaskGround);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            Jump();
    }

    private void FixedUpdate()
    {
        _direction.x = Input.GetAxisRaw("Horizontal") * _currentSpeed;
        _direction.y = _rigidbody.velocity.y;

        if (Input.GetKey(KeyCode.LeftShift) && IsGrounded())
        {
            _animator.SetBool("IsRun", true);
            _currentSpeed = _speed * _runSpeedModifier;
        }
        else
        {
            _animator.SetBool("IsRun", false);
            _currentSpeed = _speed;
        }

        Move(_direction);
    }

    public void Jump()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void Move(Vector2 direction)
    {
        _rigidbody.velocity = direction;

        if (direction.x != 0)
            _animator.SetBool("IsWalk", true);
        else
            _animator.SetBool("IsWalk", false);

        if (direction.x > 0)
            _spriteRenderer.flipX = false;

        if (direction.x < 0)
            _spriteRenderer.flipX = true;
    }
}