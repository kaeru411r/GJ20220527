using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullett2 : BaseBurret
{
    //弾のスピード
    [SerializeField] float m_speed = 3f;
    /// <summary>弾の生存期間（秒）</summary>
    [SerializeField] float m_lifeTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Hit();
            Destroy(this.gameObject);
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
        rb.velocity = Vector2.left * m_speed * 10;


    }

}
