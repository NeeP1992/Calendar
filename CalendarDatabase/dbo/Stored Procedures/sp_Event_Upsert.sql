CREATE PROCEDURE [dbo].[sp_Event_Upsert]
	@Id int output,
    @Text varchar(500),
    @EventStart datetime,
    @EventEnd datetime
AS
BEGIN
		
	BEGIN
		IF EXISTS (SELECT * FROM [Event] WHERE Id = @Id)
			BEGIN
				UPDATE [Event] SET
					[Text] = @Text,
					[EventStart] = @EventStart,
					[EventEnd] = @EventEnd
				WHERE Id = @Id

				Select @Id
			END
		ELSE
			BEGIN
				INSERT INTO [Event]
				(
					[Text],
					[EventStart],
					[EventEnd]
				)
				VALUES
				(
					@Text,
					@EventStart,
					@EventEnd
				)

				Select SCOPE_IDENTITY()
			END
	END

END