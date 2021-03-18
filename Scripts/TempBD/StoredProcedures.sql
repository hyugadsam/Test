USE [TempBD]
GO
/****** Object:  StoredProcedure [Admin].[st_GetUsers]    Script Date: 18/03/2021 12:26:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [Admin].[st_GetUsers]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP (1000) [Userid]
      ,[Name]
      ,[FirstLastName]
      ,[SecondLastName]
      ,[InsertDate]
      ,[Salary]
      ,[BreakFast]
      ,[Savings]
      ,[isActive]
      ,[Roleid]
      ,[Password]
      ,[UserLogin]
  FROM [TempBD].[Admin].[Users]

END
GO
/****** Object:  StoredProcedure [Admin].[st_isUserValid]    Script Date: 18/03/2021 12:26:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [Admin].[st_isUserValid]
	@UserLogin nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP (1000) [Userid]
      ,[Name]
      ,[FirstLastName]
      ,[SecondLastName]
      ,[InsertDate]
      ,[Salary]
      ,[BreakFast]
      ,[Savings]
      ,[isActive]
      ,[Roleid]
      ,[Password]
      ,[UserLogin]
  FROM [TempBD].[Admin].[Users] where [UserLogin] = @UserLogin

END
GO
/****** Object:  StoredProcedure [Admin].[St_SaveUser]    Script Date: 18/03/2021 12:26:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Admin].[St_SaveUser]
	-- Add the parameters for the stored procedure here
	@Userid int
    ,@Name nvarchar(50)
    ,@FirstLastName nvarchar(50)
    ,@SecondLastName nvarchar(50)
    ,@InsertDate datetime
    ,@Salary decimal(10,2)
    ,@BreakFast decimal(10,2)
    ,@Savings decimal(10,2)
    ,@isActive bit
    ,@Roleid int
    ,@Password nvarchar(250)
    ,@UserLogin  nvarchar(50)
	,@HasError bit output
AS
BEGIN Try
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Set @HasError = 1;

	If ISNULL(@Userid, 0) > 0
	Begin
		UPDATE [Admin].[Users]
			SET [Name] = @Name
				,[FirstLastName] = @FirstLastName
				,[SecondLastName] = @SecondLastName
				,[InsertDate] = @InsertDate
				,[Salary] = @Salary
				,[BreakFast] = @BreakFast
				,[Savings] = @Savings
				,[isActive] = @isActive
				,[Roleid] = @Roleid
				,[Password] = @Password
				,[UserLogin] = @UserLogin
			WHERE Userid=@Userid

			Set @HasError=0
	End
	Else
	Begin
		INSERT INTO [Admin].[Users]
           ([Name]
           ,[FirstLastName]
           ,[SecondLastName]
           ,[InsertDate]
           ,[Salary]
           ,[BreakFast]
           ,[Savings]
           ,[isActive]
           ,[Roleid]
           ,[Password]
           ,[UserLogin])
     VALUES
           (@Name
			,@FirstLastName
			,@SecondLastName
			,@InsertDate
			,@Salary
			,@BreakFast
			,@Savings
			,@isActive
			,@Roleid
			,@Password
			,@UserLogin)
		If @@IDENTITY > 0
			Set @HasError = 0
	End
	
    
END Try
Begin Catch
	--Error Managment
	print(ERROR_MESSAGE())
End Catch
GO
/****** Object:  StoredProcedure [Finance].[st_GeneratePaysheets]    Script Date: 18/03/2021 12:26:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Finance].[st_GeneratePaysheets]
	-- Add the parameters for the stored procedure here
	@Date DateTime
AS
BEGIN Try
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare @StartDate DateTime,
			@EndDate DateTime,
			@Now DateTime

	SELECT @EndDate = EOMONTH(@Date), @StartDate = DATEADD(month, DATEDIFF(month, 0, @Date), 0), @Now = GETDATE()

	Insert into [Finance].[Paysheets] ([Userid],[Salary],[BreakFast],[Savings],[StartDate],[EndDate],[InsertDate])
	SELECT [Userid],[Salary],[BreakFast],[Savings],@StartDate,@EndDate,@Now FROM [Admin].[Users] where isActive = 1

	
END Try
Begin Catch
--Manage Error
	print(ERROR_MESSAGE())
End Catch
GO
/****** Object:  StoredProcedure [Finance].[st_GetPaysheetByid]    Script Date: 18/03/2021 12:26:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [Finance].[st_GetPaysheetByid]
	@Paysheetid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	SELECT TOP (1000) [Paysheetid]
      ,a.[Userid] as Userid
	  ,[Name]
      ,[FirstLastName]
      ,[SecondLastName]
      ,b.[Salary] as [Salary]
      ,b.[BreakFast]
      ,b.[Savings]
      ,[StartDate]
      ,[EndDate]
      ,b.[Salary] - b.[BreakFast] - b.[Savings] as Deposit
  FROM [Finance].[Paysheets] a
  join [Admin].[Users] b on a.[Userid] = b.[Userid] and a.[Paysheetid] = @Paysheetid
  
  
END

GO
/****** Object:  StoredProcedure [Finance].[st_GetPaysheets]    Script Date: 18/03/2021 12:26:28 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Finance].[st_GetPaysheets]
	@Userid int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	SELECT TOP (1000) [Paysheetid]
      ,a.[Userid] as Userid
	  ,[Name]
      ,[FirstLastName]
      ,[SecondLastName]
      ,b.[Salary] as [Salary]
      ,b.[BreakFast]
      ,b.[Savings]
      ,[StartDate]
      ,[EndDate]
      ,b.[Salary] - b.[BreakFast] - b.[Savings] as Deposit
  FROM [Finance].[Paysheets] a
  join [Admin].[Users] b on a.[Userid] = b.[Userid] and a.[Userid] = ISNULL(@Userid, a.[Userid])
  
  
END

GO
