using UnityEngine;
using System.Collections;

public class CSky : MonoBehaviour {

    Animator _animator;

    void Awake() {
        _animator = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (CGameManager.IsGameStop)
        {
            _animator.speed = 0;
        }

	}
}
