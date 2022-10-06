# MyForum

To create needed tables in your local Forum database run the following:
CREATE TABLE [dbo].[Posts] (
    [Pid]      INT           IDENTITY (1, 1) NOT NULL,
    [Date]     DATETIME      NULL,
    [Title]    VARCHAR (50)  NULL,
    [Content]  TEXT          NULL,
    [UserName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Pid] ASC)
);

CREATE TABLE [dbo].[Comments] (
    [Cid]      INT           IDENTITY (1, 1) NOT NULL,
    [Pid]      INT           NOT NULL,
    [Date]     DATETIME      NULL,
    [Content]  TEXT          NULL,
    [UserName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Cid] ASC),
    FOREIGN KEY ([Pid]) REFERENCES [dbo].[Posts] ([Pid])
);
