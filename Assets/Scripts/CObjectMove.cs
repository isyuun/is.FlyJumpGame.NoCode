using UnityEngine;
using System.Collections;

public class CObjectMove : MonoBehaviour {

    Rigidbody2D _rigidbody2d;

    public float _speed; // 컬럼 이동 속도

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();    
    }

	// Use this for initialization
	void Start () {

        // 왼쪽 방향으로 지정한 속도를 부여함
        _rigidbody2d.velocity = new Vector2(-_speed, 0f);

	}
	
	// Update is called once per frame
	void Update () {
	
        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }

        if (CGameManager.IsGameStop)
        {
            _rigidbody2d.velocity = Vector2.zero;
        }

	}
}
