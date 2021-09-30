# .net5-tracebug
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
