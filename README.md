# .net5-trace-bug (node-v14.21.3)

> 範例網址 :  [https://tomz-trace-bug.herokuapp.com/taskdashboard](https://tomz-trace-bug.herokuapp.com/taskdashboard)
> 

測試帳號密碼如下:

```csharp
LoginUser { UserId = "admin", Password = "admin", Name = "管理員", RoleNo = 4 },
LoginUser { UserId = "ts001", Password = "ts001", Name = "王曉明", RoleNo = 1 },
LoginUser { UserId = "ts002", Password = "ts002", Name = "劉俊麟", RoleNo = 3 },
LoginUser { UserId = "ts003", Password = "ts003", Name = "金城武", RoleNo = 2 },
LoginUser { UserId = "ts004", Password = "ts004", Name = "彭于晏", RoleNo = 1 },
LoginUser { UserId = "ts005", Password = "ts005", Name = "兆祐廷", RoleNo = 2 });
```

## Phase I Requirement:

LoginUser 需要區分身分(RD，QA)

> **RoleNo : 定義身分，用來確認權限，QA可刪除，RD只能解決。**
> 

```csharp
public class LoginUser
    {
        [Key]
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        **public int RoleNo { get; set; }**
    }
```

> **QA 增加 派出任務 ，且可以 刪除 任務。**
> 

![螢幕擷取畫面 2021-09-30 144740.jpg](net5-trace-bug%203edf55c4296e4369a46640401aa13062/%E8%9E%A2%E5%B9%95%E6%93%B7%E5%8F%96%E7%95%AB%E9%9D%A2_2021-09-30_144740.jpg)

![螢幕擷取畫面 2021-09-30 144804.jpg](net5-trace-bug%203edf55c4296e4369a46640401aa13062/%E8%9E%A2%E5%B9%95%E6%93%B7%E5%8F%96%E7%95%AB%E9%9D%A2_2021-09-30_144804.jpg)

## Phase II Requirement:

> **PM**
> 

![螢幕擷取畫面 2021-09-30 145741.jpg](net5-trace-bug%203edf55c4296e4369a46640401aa13062/%E8%9E%A2%E5%B9%95%E6%93%B7%E5%8F%96%E7%95%AB%E9%9D%A2_2021-09-30_145741.jpg)

> **QA**
> 

![螢幕擷取畫面 2021-09-30 145403.jpg](net5-trace-bug%203edf55c4296e4369a46640401aa13062/%E8%9E%A2%E5%B9%95%E6%93%B7%E5%8F%96%E7%95%AB%E9%9D%A2_2021-09-30_145403.jpg)

> **加入Administrator ， 管理員可以處理所有表單，且可新增帳號。**
> 

![螢幕擷取畫面 2021-09-30 145313.jpg](net5-trace-bug%203edf55c4296e4369a46640401aa13062/%E8%9E%A2%E5%B9%95%E6%93%B7%E5%8F%96%E7%95%AB%E9%9D%A2_2021-09-30_145313.jpg)

![螢幕擷取畫面 2021-09-30 145204.jpg](net5-trace-bug%203edf55c4296e4369a46640401aa13062/%E8%9E%A2%E5%B9%95%E6%93%B7%E5%8F%96%E7%95%AB%E9%9D%A2_2021-09-30_145204.jpg)

![螢幕擷取畫面 2021-09-30 145625.jpg](net5-trace-bug%203edf55c4296e4369a46640401aa13062/%E8%9E%A2%E5%B9%95%E6%93%B7%E5%8F%96%E7%95%AB%E9%9D%A2_2021-09-30_145625.jpg)