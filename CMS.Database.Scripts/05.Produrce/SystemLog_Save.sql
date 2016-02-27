IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[SystemLog_Save]')
                    AND type IN ( N'P', N'PC' ) )
    DROP PROCEDURE [dbo].[SystemLog_Save]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	保存系统日志
-- =============================================
CREATE PROCEDURE SystemLog_Save
    (
      @Level [nvarchar](20) ,
      @Content [nvarchar](max) ,
      @Created [datetime]
    )
AS
    BEGIN
        SET NOCOUNT ON;        INSERT  INTO SystemLog
                ( [Level], [Content], [Created] )
        VALUES  ( @Level, @Content, @Created )
    END
GO