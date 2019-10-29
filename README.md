# ruanmouHomework
.Net高级班第12期第一次作业，核心考核泛型+反射

作业内容是做一个控制台程序，作业内容如下：

1 建立一个数据库，然后执行-下面-的数据库脚本，会增加两张表 User Company，大家可以去表里面自己多加入一些数据

2 建立数据库表映射的基类BaseModel，包括 Id属性
  建立两个子类Model：公司和用户，按照表结构来

3 提供两个泛型的数据库访问方法，用 BaseModel约束
一个是用id去查询单个实体，(只有这一个参数)
一个是查询出数据表的全部数据列表查询(没有参数)

提示：用DataReader去访问数据库，将得到的结果通过反射生成实体对象/集合返回；

4 封装一个方法，能控制台输出任意实体的全部属性和属性值；

5 进阶需求：提供泛型的数据库实体插入、实体更新、ID删除数据的数据库访问方法；

6 进阶需求（可选）：欢迎小伙伴儿写个实体自动生成器；

7 进阶需求（可选）：将数据访问层抽象，使用简单工厂+配置文件+反射的方式，来提供对数据访问层的使用

8 进阶需求（可选）：每个实体类的基础增删改查SQL语句是不变的，用泛型缓存试试！


注意命名规范、异常处理、合理定义接口、合理封装类 and so on
作业前最好把下面这个异常处理的专题看一遍
链接：http://pan.baidu.com/s/1kVNorpd 密码：pyhv


作业要求发到邮箱：57265177@qq.com


作业用压缩包的形式发给我，压缩包名称命名以群里的昵称开头，然后有更新的话，在昵称后面加上_update1这样子
第一次提交是：   1258-烧锅开水-男-重庆_homework_第一周.rar
第二次提交是：   1258-烧锅开水-男-重庆_homework_第一周_Update1.rar
第三次提交是：   1258-烧锅开水-男-重庆_homework_第一周_Update2.rar

压缩包中希望包含作业说明文档，包含自己完成了几个点
可以是完成过程中的问题、思路、解决方案、学习感悟、笔记都可以了，，
如果作业有更新，则必须把更新的内容写入文档


然后越早交作业的  老师会单独批改，一对一指导，不限时间了。。。





CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreatorId] [int] NOT NULL,
	[LastModifierId] [int] NULL,
	[LastModifyTime] [datetime] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
																																						
																																						
INSERT INTO [dbo].[Company]
           ([Name]
           ,[CreateTime]
           ,[CreatorId]
           ,[LastModifierId]
           ,[LastModifyTime])
     VALUES
           ('百捷'
           ,'2015-12-10'
           ,1
           ,1
           ,'2015-12-10')
																																						
																																						
INSERT INTO [dbo].[Company]
           ([Name]
           ,[CreateTime]
           ,[CreatorId]
           ,[LastModifierId]
           ,[LastModifyTime])
     VALUES
           ('东莞'
           ,'2015-12-10'
           ,1
           ,1
           ,'2015-12-10')
																																						
																																						
INSERT INTO [dbo].[Company]
           ([Name]
           ,[CreateTime]
           ,[CreatorId]
           ,[LastModifierId]
           ,[LastModifyTime])
     VALUES
           ('东风日产'
           ,'2018-12-10'
           ,1
           ,1
           ,'2018-12-10')
																																						

																																						
																																						
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Account] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Email] [varchar](200) NULL,
	[Mobile] [varchar](30) NULL,
	[CompanyId] [int] NULL,
	[CompanyName] [nvarchar](500) NULL,
	[State] [int] NOT NULL,
	[UserType] [int] NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreatorId] [int] NOT NULL,
	[LastModifierId] [int] NULL,
	[LastModifyTime] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
																																						
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户状态  0正常 1冻结 2删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'State'
GO
																																						
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户类型  1 普通用户 2管理员 4超级管理员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'UserType'
GO
																
					
																																						
INSERT INTO [dbo].[User]
           ([Name]
           ,[Account]
           ,[Password]
           ,[Email]
           ,[Mobile]
           ,[CompanyId]
           ,[CompanyName]
           ,[State]
           ,[UserType]
           ,[LastLoginTime]
           ,[CreateTime]
           ,[CreatorId]
           ,[LastModifierId]
           ,[LastModifyTime])
     VALUES
           ('小新'
           ,'admin'
           ,'e10adc3949ba59abbe56e057f20f883e'
           ,'12'
           ,'133'	
           ,'1'	
           ,'百捷'	
           ,0
           ,2
           ,'2018-12-12'	
           ,'2018-12-12'
           ,1
           ,1
           ,'2018-12-12')
GO