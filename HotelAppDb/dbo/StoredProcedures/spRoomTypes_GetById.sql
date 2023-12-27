CREATE PROCEDURE [dbo].[spRoomTypes_GetById]
	@id int
AS
begin
set nocount on;
	SELECT [Id], [Title], [Description], [Price] 
	from dbo.RoomTypes
	where Id = @id;
end
