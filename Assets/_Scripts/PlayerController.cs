using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody _rigidBody;
    [SerializeField, Tooltip("Ускорение")] 
    private float _movementAcceleration = 2;
    
    [SerializeField, Tooltip("Максимальная скорость")] 
    private float _movementVelocityMax = 2;
    
    [SerializeField, Tooltip("Замедление")] 
    private float _movementFriction = 0.1f;
    
    [SerializeField] private float _jumpVelocity = 20;
    [SerializeField] private float _extraGravity = 40;
    [SerializeField] GameObject _bulletToSpawn;
    
    [SerializeField, Tooltip("Игрок на земле?")]
    private bool _isGrounded = false;
    [SerializeField, Tooltip("Основная фигура столкновений игрока.")]
    Collider _myCollider = null;

    [Tooltip("Направление игрока")]
    Vector3 _curFacing = new Vector3(1, 0, 0);

    //Анимация

    bool _moveInput = false;
    Animator _myAnimator;


    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _myCollider = GetComponent<Collider>();
        _myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 curSpeed = _rigidBody.velocity;

        _moveInput = false;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _moveInput = true;
            curSpeed.x += (_movementAcceleration * Time.deltaTime);
            _curFacing.x = 1;
            _curFacing.z = 0;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _moveInput = true;
            curSpeed.x -= (_movementAcceleration * Time.deltaTime);
            _curFacing.x = -1;
            _curFacing.z = 0;

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _moveInput = true;
            curSpeed.z += (_movementAcceleration * Time.deltaTime);
            _curFacing.z = 1;
            _curFacing.x = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _moveInput = true;
            curSpeed.z -= (_movementAcceleration * Time.deltaTime);
            _curFacing.z = -1;
            _curFacing.x = 0;
        }

        //if(curSpeed.x != 0 && curSpeed.z != 0)
        //{
        //    _curFacing = curSpeed.normalized;
        //}

        // Выстрелить?
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject newBullet = Instantiate(_bulletToSpawn, transform.position,
                Quaternion.identity);
            Bullet bullet = newBullet.GetComponent<Bullet>();
            if (bullet)
            {
                bullet.SetDirection(new Vector3(_curFacing.x, 0f, _curFacing.z));
            }
        }


        if (Input.GetKey(KeyCode.RightArrow) == Input.GetKey(KeyCode.LeftArrow))
            curSpeed.x -= (_movementFriction * curSpeed.x);

        if (Input.GetKey(KeyCode.UpArrow) == Input.GetKey(KeyCode.DownArrow))
           curSpeed.z -= (_movementFriction * curSpeed.z);

        //if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(curSpeed.y) < 1)
        if (Input.GetKeyDown(KeyCode.Space) && CalcIsGrounded())
            curSpeed.y += _jumpVelocity;
        else
            curSpeed.y -= _extraGravity * Time.deltaTime;

        transform.LookAt(transform.position - new Vector3(_curFacing.x, 0f, _curFacing.z));

        UpdateAnimation(); ;

        curSpeed.x = Mathf.Clamp(curSpeed.x, _movementVelocityMax * -1, _movementVelocityMax);
        curSpeed.z = Mathf.Clamp(curSpeed.z, _movementVelocityMax * -1, _movementVelocityMax);

        _rigidBody.velocity = curSpeed;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PickUpItem>())
        {
            PickUpItem item = other.gameObject.GetComponent<PickUpItem>();
            item.OnPickeUp(this.gameObject);
        }
    }

    void UpdateAnimation()
    {
        if (_myAnimator == null)
            return;
        if (_moveInput)
        {
            _myAnimator.Play("Run");
        }
        else
        {
            _myAnimator.Play("Idle");
        }
    }

    /// <summary>
    /// Выполняется проверка ниже объекта игрока.
    /// Если игрок стоит на твердом предмете, он может прыгнуть
    /// и выполнить другие действия, недоступные в воздухе.
    /// </summary>

    bool CalcIsGrounded()
    {
        float offset = 0.1f;
        Vector3 pos = _myCollider.bounds.center;
        pos.y = _myCollider.bounds.min.y - offset;
        _isGrounded = Physics.CheckSphere(pos, offset);
        return _isGrounded;
    }
}
