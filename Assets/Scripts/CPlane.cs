using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CPlane : MonoBehaviour {

    Rigidbody2D _rigidbody2d;

    public float _riseForce;

    public Text _itemCountText;

    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
        // 비행체가 화면을 넘어갔다면
        if (transform.position.y > 5.5f || transform.position.y < -5.5f)
        {
            // 게임 정지
            CGameManager.IsGameStop = true;
        }

        if (transform.position.y < -5.5f)
        {
            GameEnd();
        }

        if (Input.anyKeyDown && !CGameManager.IsGameStop)
        {
            // 비행체의 속도를 0으로 초기화해 줌
            _rigidbody2d.velocity = Vector2.zero;
            _rigidbody2d.AddForce(new Vector2(0, _riseForce));
        }

	}

    // 충돌 시작 이벤트 (IsTrigger == false 일때 발생함)
    void OnCollisionEnter2D(Collision2D collision)
    // void OnCollisionStay2D(..) : 충돌 중 (IsTrigger == false 일때 발생함)
    // void OnCollisionExit2D(..) : 충돌 끝 (IsTrigger == false 일때 발생함)
    {
        if (collision.gameObject.tag == "Column")
        {
            CGameManager.IsGameStop = true;
            Invoke("GameEnd", 3f);
        }
    }

    void GameEnd()
    {
        // 종료 씬으로 이동함
        SceneManager.LoadScene("End");
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Item")
        {
            Destroy(collider.gameObject);

            int score = int.Parse(_itemCountText.text);
            score++;
            _itemCountText.text = score.ToString();
        }
    }
} 
