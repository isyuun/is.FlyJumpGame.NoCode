using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Google Play Game
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class CGooglePlayGameServiceManager : _MonoBehaviour
{

    GameObject _callback;

    // 구글 플레이 게임즈 인증 요청
    public void GooglePlayActivate(GameObject callback)
    {
        if (callback == null) return;

        _callback = callback;


        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        /*GooglePlayGames.*/PlayGamesPlatform.DebugLogEnabled = true;
        
        // 구글 플레이 게임즈 활성화
        PlayGamesPlatform.Activate();

        // 구글 플레이 게임즈 인증
        Social.localUser.Authenticate(GooglePlayGamesLoginCallBack);
    }

    void GooglePlayGamesLoginCallBack(bool sucess, string result)
    {
        Debug.LogWarning(this.GetMethodName() + ":" + sucess + "," + result);
        _callback.SendMessage("GooglePlayGamesResult", result);
        // 인증에 성공 했다면
        if (result)
        {
            // 구글로 로그인 타입을 설정함
            CSocialNetworkManager.accountType = CSocialNetworkManager.ACCOUNT_TYPE.GOOGLE;

            // 계정 이름 : Social.localUser.userName;
            // 계정 아이다 : Social.localUser.id;

            // 구글 플레이 계정 로그인 성공
            _callback.SendMessage("GooglePlayGamesLoginSuccess", Social.localUser.id);
        }
        else
        {
            // 구글 플레이 계정 로그인 실패
            _callback.SendMessage("GooglePlayGamesLoginFail");
        }
    }

    //// 구글 플레이 게임즈 인증 콜백 함수
    //void GooglePlayGamesLoginCallBack(bool result)
    //{
    //    // 인증에 성공 했다면
    //    if (result)
    //    {
    //        // 구글로 로그인 타입을 설정함
    //        CSocialNetworkManager.accountType =
    //            CSocialNetworkManager.ACCOUNT_TYPE.GOOGLE;

    //        // 계정 이름 : Social.localUser.userName;
    //        // 계정 아이다 : Social.localUser.id;

    //        // 구글 플레이 계정 로그인 성공
    //        _callback.SendMessage("GooglePlayGamesLoginSuccess", Social.localUser.id);
    //    }
    //    else
    //    {
    //        // 구글 플레이 계정 로그인 실패
    //        _callback.SendMessage("GooglePlayGamesLoginFail");
    //    }
    //}

    // 구글 업적 UI를 실행함
    public void GooglePlayGamesAchievementUI()
    {
        Social.ShowAchievementsUI();
    }

    // 구글 순위 UI를 실행함
    public void GooglePlayGamesLeaderBoardUI()
    {
        Social.ShowLeaderboardUI();
    }

    // 구글 플레이 게임즈 인증 해제 요청
    public void GooglePlayDeActive()
    {
        PlayGamesPlatform play = (PlayGamesPlatform)Social.Active;

        if (play != null)
        {
            // 구글 게임즈 플레이로 인증 했을 경우 인증을 해제함
            play.SignOut();
        }
    }

    void AchievementSetCallback(bool result)
    {

    }

    // 구글 업적과 리더보드를 갱신함
    public void GooglePlayGamesAchievementAndLeaderboardCheck(int starCount)
    {
        if (starCount >= 25)
        {
            Social.ReportProgress(CGPGSIds.achievement_star25,
                100f, AchievementSetCallback);
        }
        else if (starCount >= 20)
        {
            Social.ReportProgress(CGPGSIds.achievement_star20,
                100f, AchievementSetCallback);
        }
        else if (starCount >= 15)
        {
            Social.ReportProgress(CGPGSIds.achievement_star15,
                100f, AchievementSetCallback);
        }
        else if (starCount >= 10)
        {
            Social.ReportProgress(CGPGSIds.achievement_star10,
                100f, AchievementSetCallback);
        }
        else if (starCount >= 5)
        {
            Social.ReportProgress(CGPGSIds.achievement_star5,
                100f, AchievementSetCallback);
        }

        // 리더 보드를 갱신함
        Social.ReportScore(starCount, CGPGSIds.leaderboard_isflyjumpgamenocode, LeaderBoardScoreSetCallback);
    }

    void LeaderBoardScoreSetCallback(bool result)
    {

    }
}
