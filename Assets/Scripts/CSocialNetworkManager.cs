using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSocialNetworkManager : _MonoBehaviour
{
    // 계정 타입
    public enum ACCOUNT_TYPE { GEUST, GOOGLE };
    public static ACCOUNT_TYPE accountType = ACCOUNT_TYPE.GEUST;

    // 기본 게임 서버 URL
    public static string baseUrl = "http://192.168.0.29/game";

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
