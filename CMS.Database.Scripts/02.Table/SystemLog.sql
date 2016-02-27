-- =============================================
-- Description:	系统日志表
-- =============================================
IF NOT EXISTS(SELECT 1 FROM sys.objects WHERE [name]='SystemLog' AND [type]='U')
BEGIN
	CREATE TABLE [dbo].[SystemLog]
	(
		[Id] NUMERIC NOT NULL PRIMARY KEY IDENTITY, 
		[Level] NVARCHAR(20) NOT NULL, 
		[Content] NVARCHAR(MAX) NOT NULL, 
		[Created] DATETIME NOT NULL
	)
END
GO
