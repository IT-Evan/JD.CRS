开源不易，请点个star支持一下吧．

参考博客园
ABP开发手记
https://www.cnblogs.com/IT-Evan/p/ABP0.html

 **JD.CRS** 

 **介绍** 

ABP开发示例 - 排班系统(Crew Rostering System).

 **软件架构** 

ABP / ASP.NET Core / MVC / EF Core / SQLServer / Bootstrap / jQuery / Log4Net / AutoMapper / xUnit / Shouldly

 **安装教程** 

1. 打开项目:
Visual Studio打开JD.CRS.sln.
2. 创建数据库:
Visual Studio/工具/NuGet包管理器/程序包管理器控制台, 依次执行两条命令.
PM> Add-Migration 'Initial'
PM> Update-Database
可以打开SQL Server, 查看数据库.
3. 运行项目:
F5运行即可.
用户:admin
密码:123qwe

 **使用说明** 

项目功能菜单:
1. 主页: 
仪表板/工作台.
2. 基础数据: 
办公室信息 |
院系信息 |
课程信息 |
教职员信息 |
学生信息
3. 综合服务: 
教职员办公室分配 |
院系主任设置 |
院系课程设置 |
教职员课程分配 |
学生选课
4. 管理报表: 
办公室报表 |
院系报表 |
课程报表 |
教职员报表 |
学生报表
5. 系统设置: 
租户管理 |
用户管理 |
角色管理
6. 关于: 
系统相关介绍

 **参与贡献** 

1. Fork 本仓库
2. 新建 Feat_xxx 分支
3. 提交代码
4. 新建 Pull Request


 **效果预览** 

登录
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231430_a2dc7880_2265734.png "CRS1.png")
首页
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231547_0f227baa_2265734.png "CRS2.png")
办公室信息
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231555_87a30d0a_2265734.png "CRS3.png")
院系信息
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231604_411867d5_2265734.png "CRS4.png")
课程信息
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231613_d1e09627_2265734.png "CRS5.png")
教职员信息
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231623_f8b6902b_2265734.png "CRS6.png")
学生信息
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231630_14fb422f_2265734.png "CRS7.png")
新增
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231640_bf44a5d9_2265734.png "CRS8.png")
修改
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231647_7703457d_2265734.png "CRS9.png")
删除
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231654_57a1fdc3_2265734.png "CRS10.png")
查询
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231701_26aac2aa_2265734.png "CRS11.png")
复制
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231752_e16c87ad_2265734.png "CRS12.png")
导出
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231800_daede9df_2265734.png "CRS13.png")
打印
![输入图片说明](https://images.gitee.com/uploads/images/2019/1015/231807_df32c8a5_2265734.png "CRS14.png")