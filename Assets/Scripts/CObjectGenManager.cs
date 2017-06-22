using UnityEngine;
using System.Collections;

public class CObjectGenManager : MonoBehaviour {

    // 생성 오브젝트
    public Object _objectPrefab;

    // 생성 위치
    public Transform _createPos;

    // 생성 y위치 (위, 아래)
    public float _topCreatePosY;
    public float _bottomCreatePosY;

    // 생성 지연 시간
    public float _createStartDelayTime;
    public float _createDelayTime;

	// Use this for initialization
	void Start () {
        // InvokeRepeating를 이용한 타이머 시작
        InvokeRepeating("ObjectCreateInvoke", _createStartDelayTime, _createDelayTime);

        // CancelInvoke("ObjectCreateInvoke"); // 타이머 취소
    }

    // Update is called once per frame
    void Update () {

	    // 게임이 끝났으면
        if (CGameManager.IsGameStop)
        {
            // 타이머를 취소함
            CancelInvoke("ObjectCreateInvoke");
        }

	}

    // 오브젝트 생성
    public void ObjectCreateInvoke()
    {
        // 오브젝트 생성 위치(Y)를 랜덤하게 설정함
        float randYPos = Random.Range(_topCreatePosY, _bottomCreatePosY);

        // 오브젝트 생성 위치를 설정함
        Vector2 pos = new Vector2(
            _createPos.position.x, _createPos.position.y + randYPos);

        // 오브젝트 생성
        Instantiate(_objectPrefab, pos, Quaternion.identity);
    }
}
