CREATE PROCEDURE [dbo].[SearchMovieGenre]
(
	@Search VARCHAR(172) = ''
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].[Movies] AS m
	WHERE m.Genre LIKE '%'+ @Search + '%'

END
GO