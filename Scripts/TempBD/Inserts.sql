USE [TempBD]
GO
SET IDENTITY_INSERT [Admin].[Roles] ON 

INSERT [Admin].[Roles] ([Roleid], [Description]) VALUES (1, N'Admin')
INSERT [Admin].[Roles] ([Roleid], [Description]) VALUES (2, N'Operator')
SET IDENTITY_INSERT [Admin].[Roles] OFF
SET IDENTITY_INSERT [Admin].[Users] ON 

INSERT [Admin].[Users] ([Userid], [Name], [FirstLastName], [SecondLastName], [InsertDate], [Salary], [BreakFast], [Savings], [isActive], [Roleid], [Password], [UserLogin]) VALUES (2, N'System', N'Last Name', N'S Name', CAST(N'2021-03-17T21:50:33.030' AS DateTime), CAST(10.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), 1, 1, N'rH2d+dRodGaOCVq7opcrT+bbuAY=', N'admin')
INSERT [Admin].[Users] ([Userid], [Name], [FirstLastName], [SecondLastName], [InsertDate], [Salary], [BreakFast], [Savings], [isActive], [Roleid], [Password], [UserLogin]) VALUES (3, N'Juan', N'Perez', N'Perez', CAST(N'2021-03-17T22:08:41.607' AS DateTime), CAST(20.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)), 1, 2, N'BdGej0rVFpTpG9keH7/wzUA2g+U=', N'Juan')
SET IDENTITY_INSERT [Admin].[Users] OFF
