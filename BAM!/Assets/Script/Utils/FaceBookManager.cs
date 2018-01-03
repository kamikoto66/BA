using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Facebook.Unity;

public class FaceBookManager : MonoBehaviour {

    //public static FaceBookManager instance;
    //List<string> perms = new List<string>() { "public_profile", "email", "user_friends" };

    //string userid;

    //public static FaceBookManager Instnace()
    //{
    //    return instance;
    //}

    //// Use this for initialization
    //void Awake()
    //{
    //    instance = this;

    //    if (!FB.IsInitialized)
    //    {
    //        FB.Init(FBInit, HideUnity);
    //    }
    //    else
    //    {
    //        FB.ActivateApp();
    //    }

    //    DontDestroyOnLoad(this);
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void FBInit()
    //{
    //    if (FB.IsInitialized)
    //    {
    //        FB.ActivateApp();
    //    }
    //    else
    //    {
    //        Debug.Log("Failed to Initialize the Facebook SDK");
    //    }
    //}

    //private void HideUnity(bool isGame)
    //{
    //    if (!isGame)
    //    {
    //        Time.timeScale = 0;
    //    }
    //    else
    //    {
    //        Time.timeScale = 1;
    //    }
    //}



    //private void AuthCallback(ILoginResult result)
    //{
    //    if (FB.IsLoggedIn)
    //    {
    //        // AccessToken class will have session details
    //        var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
    //        //current access token's User ID
    //        Debug.Log(aToken.UserId);
    //        userid = aToken.UserId;

    //        Debug.Log(perms);
    //    }
    //    else
    //    {
    //        Debug.Log("User cancelled login");
    //    }
    //}

    //public void Login()
    //{
    //    FB.LogInWithReadPermissions(perms, AuthCallback);
    //}

    //public void Logout()
    //{
    //    FB.LogOut();
    //}
}


