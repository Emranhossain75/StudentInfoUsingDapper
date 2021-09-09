CREATE TABLE [dbo].[StudentInfo] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (50) NULL,
    [Gender] VARCHAR (50) NULL,
    [Salary] VARCHAR (50) NULL,
    [Age]    INT          NULL,
    CONSTRAINT [PK_StudentInfo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

