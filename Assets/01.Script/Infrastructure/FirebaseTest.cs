using System;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseTest : MonoBehaviour
{
    private FirebaseApp _app;
    private FirebaseAuth _auth;

    private void Start()
    {
        Init();
    }


    // 파이어베이스 내 프로젝트에 연결
    private void Init()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                Debug.Log("파이어베이스 연결에 성공했습니다.");
                _app = FirebaseApp.DefaultInstance;
                _auth = FirebaseAuth.DefaultInstance;

                Login();
            }
            else
            {
                Debug.LogError($"파이어베이스 연결 실패했습니다. ${dependencyStatus}");
            }
        });
    }

    private void Register()
    {
        var email = "teemo@gmail.com";
        var password = "123456";

        _auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError($"회원가입에 실패했습니다: ${task.Exception.Message}");
                return;
            }

            // Firebase user has been created.
            var result = task.Result;
            Debug.LogFormat("회원가입에 성공했습니다: {0} ({1})", result.User.DisplayName, result.User.UserId);
        });
    }

    private void Login()
    {
        var email = "teemo@gmail.com";
        var password = "123456";

        _auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError($"로그인에 실패했습니다: {task.Exception.Message}");
                return;
            }

            var result = task.Result;
            Debug.LogFormat("로그인에 성공했습니다: {0} ({1})", result.User.DisplayName, result.User.UserId);
            
            NicknameChange();
        });
    }

    private void NicknameChange()
    {
        var user = _auth.CurrentUser;

        if (user == null) return;
        
        var profile = new UserProfile
        {
            DisplayName = "teemo",
        };
        
        user.UpdateUserProfileAsync(profile).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError($"닉네임 변경에 실패했습니다: {task.Exception.Message}");
                return;
            }
            
            Debug.Log("닉네임 변경에 성공했습니다.");
        });
    }

    private void GetProfile()
    {
        Firebase.Auth.FirebaseUser user = _auth.CurrentUser;
        if (user == null) return;
        
        string nickname = user.DisplayName;
        string email = user.Email;

        Account account = new Account(email, nickname, "firebase");
    }
}