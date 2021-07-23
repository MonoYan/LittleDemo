using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public Transform xLeft, xRight,yTop,yBottom;

    Animator animator;
    Vector3 movement;
    Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        Move();
        Boundary();
    }

    /// <summary>
    /// 行走
    /// </summary>
    void Move() 
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        movement = new Vector3(MoveX * Time.deltaTime * speed, MoveY * Time.deltaTime * speed, 0);
        //movement = new Vector3(Mathf.Clamp(MoveX * Time.deltaTime * speed, xMin, xMax), Mathf.Clamp(MoveY * Time.deltaTime * speed, yMin, yMax), 0);
        transform.Translate(movement);//移动

        if (movement != Vector3.zero)//动画
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        if (movement.x > 0)//翻转 right
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            animator.SetBool("isLeft", false);
        }
        if (movement.x < 0)
        { 
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
            animator.SetBool("isLeft", true);
        }

    }
    /// <summary>
    /// 边界限制
    /// </summary>
    void Boundary() 
    {
        //左边界
        if (transform.position.x < xLeft.position.x)
        {
            transform.position = new Vector3(xLeft.position.x, transform.position.y, 0);
        }
        //右边界
        if (transform.position.x > xRight.position.x)
        {
            transform.position = new Vector3(xRight.position.x, transform.position.y, 0);
        }
        //上边界
        if (transform.position.y > yTop.position.y)
        {
            transform.position = new Vector3(transform.position.x, yTop.position.y, 0);
        }
        //下边界
        if (transform.position.y < yBottom.position.y)
        {
            transform.position = new Vector3(transform.position.x, yBottom.position.y, 0);
        }

    }
}
