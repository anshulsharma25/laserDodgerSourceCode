using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mancontroller : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private FixedJoystick _joystick;
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    bool isGrounded = false;
    [SerializeField]
    private AudioSource audio;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = new Vector3(_joystick.Horizontal*_speed,_rb.velocity.y,_joystick.Vertical*_speed);
        if(_joystick.Horizontal!=0&& _joystick.Vertical!=0)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
            _anim.SetBool("run", true);

        }
        else
        {
            _anim.SetBool("run", false);
        }
       
    }
   public void jumpingbyButton()
    {
        if (_rb.velocity.y<0.1f)
        {
            _rb.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);

            _anim.SetTrigger("jump");
            audio.Play();
 
        }
        else
        {

        }
    }
   

}
