USE [test]
GO
/****** Object:  StoredProcedure [dbo].[ScheduleInterview]    Script Date: 18/02/2020 11:52:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ScheduleInterview]
	@id INTEGER,
	@name VARCHAR(50),
	@user  VARCHAR(20),
	@email VARCHAR(20),
	@address VARCHAR(100),
	@tel VARCHAR(20),
	@webSite VARCHAR(20),
	@company VARCHAR(100),
	@typeInterview INTEGER,
	@datetime DATETIME,
	@msg VARCHAR(200) OUTPUT
AS
	DECLARE  @count INTEGER
	DECLARE  @date DATE
	DECLARE  @time TIME
              
	SET @date= CAST(RIGHT('0'+CAST(DATEPART(year, @datetime) as varchar(4)),4 ) + '-' +
					RIGHT('0'+CAST(DATEPART(month, @datetime)as varchar(2)),2) + '-' +
					RIGHT('0'+CAST(DATEPART(day, @datetime)as varchar(2)),2) AS DATE)


	SET @time= CAST(RIGHT('0'+CAST(DATEPART(hour, @datetime) as varchar(2)),2) +':'+
					RIGHT('0'+CAST(DATEPART(minute, @datetime)as varchar(2)),2) AS TIME)

	SELECT @count=COUNT(*)
	FROM Interview 
	WHERE [time]>DATEADD(MINUTE,-20,@time) AND [time]<DATEADD(MINUTE,20,@time)

	IF @count=1
		BEGIN
				SELECT  [user].code,
	 					[user].[name],
						[user].[user],
						[user].email,
						[user].[address],
						[user].tel,
						[user].webSite,
						[user].company,
						interType.[name] as interview
				FROM Interview as inter
				INNER JOIN Scheduled as  [user] ON (inter.[user]=[user].code)
				INNER JOIN InterviewType AS interType ON (interType.id=inter.type)
				WHERE [time]>DATEADD(MINUTE,-20,@time) AND [time]<DATEADD(MINUTE,20,@time)

				SET @msg='Existe una persona pendiente de entrevista en este horario.'
				RETURN 0
		END
	ELSE
		BEGIN

			INSERT INTO Scheduled (
								code,
								[name],
								[user],
								email,
								[address],
								tel,
								webSite,
								company
							 ) 
			VALUES (@id,@name,@user,@email,@address,@tel,@webSite,@company)

			INSERT INTO Interview ( 
									[user],
									[type],
									[date],
									[time]
								 ) 
			VALUES (@id,@typeInterview,@date,@time)
			SET @msg='El usuario fué agendado con éxito.'
			RETURN 1
	
		END
