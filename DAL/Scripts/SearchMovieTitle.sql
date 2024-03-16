ALTER PROCEDURE [dbo].[SearchMovieTitle]
(
	@Search VARCHAR(60) = ''
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].[Movies] AS m
	WHERE m.Title LIKE '%'+ @Search + '%'

END
GO