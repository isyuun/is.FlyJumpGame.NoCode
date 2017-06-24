using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Google Play Game
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using System;

public class CIntroManager : _MonoBehaviour
{
    public Text _msgText;

    private CGooglePlayGameServiceManager _googlePlayManager;

    private void Start()
    {
        _googlePlayManager = GameObject.Find("GPGSManager").GetComponent<CGooglePlayGameServiceManager>();
    }

    public void OnGooglePlayLoginButtonClick()
    {
        _googlePlayManager.GooglePlayActivate(gameObject);
    }

    public void GooglePlayGamesResult(string message)
    {
        _msgText.text = message;
    }

    public void GooglePlayGamesLoginSuccess(string loginId)
    {
        _msgText.text = "Try Google Id Login." + ":" + loginId;
        //StartCoroutine(JoinOrLoginNetCoroutine(loginId));
    }

    private IEnumerator JoinOrLoginNetCoroutine(string loginId)
    {
        throw new NotImplementedException();
    }

    public void GooglePlayGamesLoginFail(string message)
    {
        _msgText.text = "Fail Google Id Login." + ":" + message;
    }

}
