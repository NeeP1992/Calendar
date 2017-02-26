CREATE TABLE [dbo].[Event] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Text]       VARCHAR (500) NOT NULL,
    [EventStart] DATETIME      NOT NULL,
    [EventEnd]   DATETIME      NOT NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([Id] ASC)
);

