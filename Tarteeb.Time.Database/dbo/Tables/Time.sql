﻿CREATE TABLE [dbo].[Time]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TaskId] INT NOT NULL DEFAULT 0, 
    [Comment] NVARCHAR(250) NULL, 
    [Date] DATETIME NOT NULL DEFAULT GETDATE(), 
    [WorkHour] FLOAT NULL

)