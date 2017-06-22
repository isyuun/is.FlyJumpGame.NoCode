using UnityEngine;
using System.Collections;

public class COjbectGenManager : MonoBehaviour {

    public Object _columnPrefab;

    public Transform _createPos;

    public float _createDelayTime;

	// Use this for initialization
	void Start () {
        // InvokeRepeating를 이용한 타이머 시작
        InvokeRepeating("ColumnCreateInvoke", _createDelayTime, _createDelayTime);

        // CancelInvoke("ColumnCreateInvoke"); // 타이머 취소
	}
	
	// Update is called once per frame
	void Update () {

	    // 게임이 끝났으면
        if (CGameManager.IsGameStop)
        {
            // 타이머를 취소함
            CancelInvoke("ColumnCreateInvoke");
        }

	}

    // 컬럼 생성
    public void ColumnCreateInvoke()
    {
        // 컬럼 생성 위치(Y)를 랜덤하게 설정함
        float randYPos = Random.Range(2.4f, -2.4f);

        // 컬럼 생성 위치를 설정함
        Vector2 pos = new Vector2(
            _createPos.position.x, _createPos.position.y + randYPos);

        // 컬럼 생성
        Instantiate(_columnPrefab, pos, Quaternion.identity);
    }
}
