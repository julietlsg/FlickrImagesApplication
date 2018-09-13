# FlickrImagesApplication
The following Queries shuld ne ran on the local SQL Instance 


------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[tblImageDetail] (
    [id]               NVARCHAR (255) NOT NULL,
    [ImageName]        NVARCHAR (255) NULL,
    [ImageData]        NVARCHAR (MAX) NULL,
    [ImageDescription] NVARCHAR (MAX) NULL,
    [ImageDate]        DATETIME2 (7)  NULL,
    [ImageLocation]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_tblImageDetail] PRIMARY KEY CLUSTERED ([id] ASC)
);
------------------------------------------------------------------------------

CREATE PROC usp_GetImageById
@ImageLocation nvarchar(Max)
AS 
BEGIN 
select ImageData from tblImageDetail where @ImageLocation = ImageLocation

End
---------------------------------------------------------------------------------------------------


CREATE PROC [dbo].[usp_UploadImage]
@ImgID nvarchar(255),
@ImgName nvarchar(255),
@ImageData nvarchar(Max),
@ImageDescription nvarchar(Max),
@ImageDate datetime,
@ImageLocation nvarchar(Max)

AS 
BEGIN 

SET NOCOUNT ON;

DECLARE @ErrMsg AS VARCHAR(MAX) = '' 
DECLARE @ErrorSeverity INT = 18
DECLARE @ObjectName VARCHAR(255) = 'Image'
DECLARE @Qty AS BIGINT = 0 
DECLARE @ID AS INT = 0 
DECLARE @crlf AS CHAR(2) = CHAR(13) + CHAR(10) 
DECLARE @RETVAL AS INT = 0 



INSERT INTO tblImageDetail(id,ImageName,ImageData, ImageDescription,ImageDate,ImageLocation)
VALUES (@ImgID,@ImgName,@ImageData,@ImageDescription,@ImageDate,@ImageLocation )
		 

END
