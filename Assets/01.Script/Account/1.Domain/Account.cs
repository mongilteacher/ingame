using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class Account
{
    public readonly string Email;
    public readonly string Nickname;
    public readonly string Password;

    // 이메일 정규표현식
    private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    // 닉네임: 한글 또는 영어로 구성, 2~7자
    private static readonly Regex NicknameRegex = new Regex(@"^[가-힣a-zA-Z]{2,7}$", RegexOptions.Compiled);

    // 금지된 닉네임 (비속어 등)
    private static readonly string[] ForbiddenNicknames = { "바보", "멍청이", "운영자", "김홍일" };

    public Account(string email, string nickname, string password)
    {
        // 이메일 검증
        if (string.IsNullOrEmpty(email))
        {
            throw new Exception("이메일은 비어있을 수 없습니다.");
        }

        if (!EmailRegex.IsMatch(email))
        {
            throw new Exception("올바른 이메일 형식이 아닙니다.");
        }

        // 닉네임 검증
        if (string.IsNullOrEmpty(nickname))
        {
            throw new Exception("닉네임은 비어있을 수 없습니다.");
        }

        if (!NicknameRegex.IsMatch(nickname))
        {
            throw new Exception("닉네임은 2자 이상 7자 이하의 한글 또는 영문이어야 합니다.");
        }

        foreach (var forbidden in ForbiddenNicknames)
        {
            if (nickname.Contains(forbidden))
            {
                throw new Exception($"닉네임에 부적절한 단어가 포함되어 있습니다: {forbidden}");
            }
        }

        // 비밀번호 검증
        if (string.IsNullOrEmpty(password))
        {
            throw new Exception("비밀번호는 비어있을 수 없습니다.");
        }

        if (password.Length < 6 || password.Length > 12)
        {
            throw new Exception("비밀번호는 6자 이상 12자 이하이어야 합니다.");
        }

        Email = email;
        Nickname = nickname;
        Password = password;
    }
}