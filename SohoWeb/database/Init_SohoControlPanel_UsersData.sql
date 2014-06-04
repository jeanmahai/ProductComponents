SET IDENTITY_INSERT [Users] ON
Insert Into [Users] ([SysNo],[UserID],[UserName],[Password],[UserAuthCode],[Status],[InDate],[InUserName],[InUserSysNo],[EditDate],[EditUserName],[EditUserSysNo]) Values('1003','sohoadmin','soho管理员','310fa523a9c8ae53518e5027dc00419d','7fdc6c89-7490-40f1-a91a-47d768999a1f','100','2014-05-12 21:19:35','System','0',null,null,null)
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [LogCategorys] ON
Insert Into [LogCategorys] ([SysNo],[ParentSysNo],[CategoryName],[Status]) Values('1001','0','控制面板','100')
Insert Into [LogCategorys] ([SysNo],[ParentSysNo],[CategoryName],[Status]) Values('1002','1001','用户模块','100')
Insert Into [LogCategorys] ([SysNo],[ParentSysNo],[CategoryName],[Status]) Values('1003','1001','角色模块','100')
Insert Into [LogCategorys] ([SysNo],[ParentSysNo],[CategoryName],[Status]) Values('1004','1001','权限模块','100')
Insert Into [LogCategorys] ([SysNo],[ParentSysNo],[CategoryName],[Status]) Values('1005','1002','登录日志','100')
SET IDENTITY_INSERT [LogCategorys] OFF