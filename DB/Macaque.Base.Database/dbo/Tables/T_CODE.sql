﻿CREATE TABLE [dbo].[T_CODE] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [CATEGORY]  VARCHAR (50)  NOT NULL,
    [CODE]      VARCHAR (50)  NOT NULL,
    [CODE_DESC] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_T_CODE] PRIMARY KEY CLUSTERED ([ID] ASC)
);

