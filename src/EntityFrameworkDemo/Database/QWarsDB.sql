USE [QWars]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 05/03/2010 11:23:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[Difficulty] [int] NOT NULL,
	[Reward] [int] NOT NULL,
	[XP] [int] NOT NULL,
	[Gang_Id] [int] NULL,
	[ExecutedByPlayer_Id] [int] NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 05/03/2010 11:23:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Money] [int] NOT NULL,
	[XP] [int] NOT NULL,
	[JoinedGang_Id] [int] NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gangs]    Script Date: 05/03/2010 11:23:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gangs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Money] [int] NOT NULL,
	[Boss_Id] [int] NOT NULL,
 CONSTRAINT [PK_Gangs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayerWeapon]    Script Date: 05/03/2010 11:23:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerWeapon](
	[Player_Id] [int] NOT NULL,
	[Weapons_Id] [int] NOT NULL,
 CONSTRAINT [PK_PlayerWeapon] PRIMARY KEY NONCLUSTERED 
(
	[PlayerWeapon_Weapon_Id] ASC,
	[Weapons_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Weapons]    Script Date: 05/03/2010 11:23:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Weapons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[XpBonus] [float] NOT NULL,
	[Price] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Weapons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_PlayerGang]    Script Date: 05/03/2010 11:23:33 ******/
ALTER TABLE [dbo].[Gangs]  WITH CHECK ADD  CONSTRAINT [FK_PlayerGang] FOREIGN KEY([Boss_Id])
REFERENCES [dbo].[Players] ([Id])
GO
ALTER TABLE [dbo].[Gangs] CHECK CONSTRAINT [FK_PlayerGang]
GO
/****** Object:  ForeignKey [FK_GangPlayer]    Script Date: 05/03/2010 11:23:33 ******/
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_GangPlayer] FOREIGN KEY([JoinedGang_Id])
REFERENCES [dbo].[Gangs] ([Id])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_GangPlayer]
GO
/****** Object:  ForeignKey [FK_PlayerWeapon_Player]    Script Date: 05/03/2010 11:23:33 ******/
ALTER TABLE [dbo].[PlayerWeapon]  WITH CHECK ADD  CONSTRAINT [FK_PlayerWeapon_Player] FOREIGN KEY([PlayerWeapon_Weapon_Id])
REFERENCES [dbo].[Players] ([Id])
GO
ALTER TABLE [dbo].[PlayerWeapon] CHECK CONSTRAINT [FK_PlayerWeapon_Player]
GO
/****** Object:  ForeignKey [FK_PlayerWeapon_Weapon]    Script Date: 05/03/2010 11:23:33 ******/
ALTER TABLE [dbo].[PlayerWeapon]  WITH CHECK ADD  CONSTRAINT [FK_PlayerWeapon_Weapon] FOREIGN KEY([Weapons_Id])
REFERENCES [dbo].[Weapons] ([Id])
GO
ALTER TABLE [dbo].[PlayerWeapon] CHECK CONSTRAINT [FK_PlayerWeapon_Weapon]
GO
/****** Object:  ForeignKey [FK_GangTask]    Script Date: 05/03/2010 11:23:33 ******/
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_GangTask] FOREIGN KEY([Gang_Id])
REFERENCES [dbo].[Gangs] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_GangTask]
GO
/****** Object:  ForeignKey [FK_PlayerTask]    Script Date: 05/03/2010 11:23:33 ******/
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_PlayerTask] FOREIGN KEY([ExecutedByPlayer_Id])
REFERENCES [dbo].[Players] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_PlayerTask]
GO

CREATE PROCEDURE [dbo].[DeleteGang] 
	@gangId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	
	
	declare @gangMoney int
	declare @bossId int
			
    select @gangMoney = money, @bossId = Boss_Id from Gangs where Id = @gangId 
    
    update Players set Money = Money + @gangMoney where Id = @bossId 
	
	update Players set JoinedGang_Id = NULL where JoinedGang_Id =@gangId
	
	update Tasks set Gang_Id = NULL where Gang_Id = @gangId
	
	delete from Gangs where Id=@gangId
END


GO


