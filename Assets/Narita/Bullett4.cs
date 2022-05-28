using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullett4 : BaseBurret
{

    //弾のスピード
    [SerializeField] float m_speed = 3f;

    float _t = 10;

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Hit();
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //rb.velocity = Vector2.left * m_speed ;

        //rb.velocity=Vector2.left + Vector2.up * m_speed ;

        rb.velocity = new Vector2(-m_speed, Mathf.Sin(_t));
        _t += Time.deltaTime * 10;
    }
}