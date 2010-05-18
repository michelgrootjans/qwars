USE QWars

SET IDENTITY_INSERT [dbo].[Weapons] ON
INSERT [dbo].[Weapons] ([Id], [XpBonus], [Price], [Name]) VALUES (1, 0.05, 50, N'Club')
INSERT [dbo].[Weapons] ([Id], [XpBonus], [Price], [Name]) VALUES (2, 0.1, 120, N'Knife')
INSERT [dbo].[Weapons] ([Id], [XpBonus], [Price], [Name]) VALUES (3, 0.2, 350, N'Taser')
INSERT [dbo].[Weapons] ([Id], [XpBonus], [Price], [Name]) VALUES (4, 0.45, 750, N'Gun')
INSERT [dbo].[Weapons] ([Id], [XpBonus], [Price], [Name]) VALUES (5, 0.25, 1500, N'Bomb')
SET IDENTITY_INSERT [dbo].[Weapons] OFF

SET IDENTITY_INSERT [dbo].[Players] ON
INSERT [dbo].[Players] ([Id], [Name], [Money], [XP], [JoinedGang_Id]) VALUES (1, N'Hans', 10000, 1000, NULL)
INSERT [dbo].[Players] ([Id], [Name], [Money], [XP], [JoinedGang_Id]) VALUES (2, N'Tony', 200000, 5000, NULL)
INSERT [dbo].[Players] ([Id], [Name], [Money], [XP], [JoinedGang_Id]) VALUES (3, N'Jhonny', 750, 750, NULL)
INSERT [dbo].[Players] ([Id], [Name], [Money], [XP], [JoinedGang_Id]) VALUES (4, N'Anthony', 2500, 500, NULL)
INSERT [dbo].[Players] ([Id], [Name], [Money], [XP], [JoinedGang_Id]) VALUES (5, N'Paulie', 500, 800, NULL)
INSERT [dbo].[Players] ([Id], [Name], [Money], [XP], [JoinedGang_Id]) VALUES (6, N'Silvio', 3000, 2000, NULL)
SET IDENTITY_INSERT [dbo].[Players] OFF

SET IDENTITY_INSERT [dbo].[Gangs] ON
INSERT [dbo].[Gangs] ([Id], [Name], [Money], [Boss_Id]) VALUES (1, N'Sopranos', 2000000, 2)
SET IDENTITY_INSERT [dbo].[Gangs] OFF

UPDATE [dbo].[Players] SET [JoinedGang_Id] = 1 WHERE [Id] = 3
UPDATE [dbo].[Players] SET [JoinedGang_Id] = 1 WHERE [Id] = 4
UPDATE [dbo].[Players] SET [JoinedGang_Id] = 1 WHERE [Id] = 5
UPDATE [dbo].[Players] SET [JoinedGang_Id] = 1 WHERE [Id] = 6

SET IDENTITY_INSERT [dbo].[Tasks] ON
INSERT [dbo].[Tasks] ([Id], [Description], [Difficulty], [Reward], [XP], [Gang_Id], [ExecutedByPlayer_Id]) VALUES (1, N'Kill Tony Mascarponi', 5, 10, 5, 1, 4)
INSERT [dbo].[Tasks] ([Id], [Description], [Difficulty], [Reward], [XP], [Gang_Id], [ExecutedByPlayer_Id]) VALUES (2, N'Rob money transport', 10, 250, 20, 1, 4)
INSERT [dbo].[Tasks] ([Id], [Description], [Difficulty], [Reward], [XP], [Gang_Id], [ExecutedByPlayer_Id]) VALUES (3, N'Steal car from Pino', 2, 5, 5, 1, 5)
INSERT [dbo].[Tasks] ([Id], [Description], [Difficulty], [Reward], [XP], [Gang_Id], [ExecutedByPlayer_Id]) VALUES (4, N'Kidnap Maggie', 1, 5, 7, 1, 6)
SET IDENTITY_INSERT [dbo].[Tasks] OFF

INSERT [dbo].[PlayerWeapon] ([Player_Id], [Weapons_Id]) VALUES (1, 2)
INSERT [dbo].[PlayerWeapon] ([Player_Id], [Weapons_Id]) VALUES (1, 3)
INSERT [dbo].[PlayerWeapon] ([Player_Id], [Weapons_Id]) VALUES (1, 4)
INSERT [dbo].[PlayerWeapon] ([Player_Id], [Weapons_Id]) VALUES (1, 5)
INSERT [dbo].[PlayerWeapon] ([Player_Id], [Weapons_Id]) VALUES (2, 3)
INSERT [dbo].[PlayerWeapon] ([Player_Id], [Weapons_Id]) VALUES (3, 4)
INSERT [dbo].[PlayerWeapon] ([Player_Id], [Weapons_Id]) VALUES (3, 5)
INSERT [dbo].[PlayerWeapon] ([Player_Id], [Weapons_Id]) VALUES (4, 2)
INSERT [dbo].[PlayerWeapon] ([Player_Id], [Weapons_Id]) VALUES (4, 4)
INSERT [dbo].[PlayerWeapon] ([Player_Id], [Weapons_Id]) VALUES (5, 4)
INSERT [dbo].[PlayerWeapon] ([Player_Id], [Weapons_Id]) VALUES (5, 5)
INSERT [dbo].[PlayerWeapon] ([Player_Id], [Weapons_Id]) VALUES (6, 1)

