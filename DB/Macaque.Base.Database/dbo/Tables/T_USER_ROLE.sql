﻿CREATE TABLE [dbo].[T_USER_ROLE] (
    [ID]           INT          IDENTITY (1, 1) NOT NULL,
    [USER_ID]      INT          NOT NULL,
    [ROLE_CODE]    VARCHAR (50) NOT NULL,
    [IS_DELETED]   BIT          CONSTRAINT [DF_T_USER_ROLE_IS_DELETED_1] DEFAULT ((0)) NOT NULL,
    [CREATED_BY]   VARCHAR (50) CONSTRAINT [DF_T_USER_ROLE_CREATED_BY_1] DEFAULT ('SYSTEM') NOT NULL,
    [CREATED_DATE] DATETIME     CONSTRAINT [DF_T_USER_ROLE_CREATED_DATE_1] DEFAULT (getdate()) NOT NULL,
    [UPDATED_BY]   VARCHAR (50) CONSTRAINT [DF_T_USER_ROLE_UPDATED_BY_1] DEFAULT ('SYSTEM') NOT NULL,
    [UPDATED_DATE] DATETIME     CONSTRAINT [DF_T_USER_ROLE_UPDATED_DATE_1] DEFAULT (getdate()) NOT NULL,
    [TIME_STAMP]   ROWVERSION   NOT NULL,
    [VERSION_NO]   BIGINT       CONSTRAINT [DF_T_USER_ROLE_VERSION_NO_1] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_T_USER_ROLE] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_T_USER_ROLE_T_ROLE] FOREIGN KEY ([ROLE_CODE]) REFERENCES [dbo].[T_ROLE] ([ROLE_CODE]),
    CONSTRAINT [FK_T_USER_ROLE_T_USER_ROLE] FOREIGN KEY ([USER_ID]) REFERENCES [dbo].[T_USER] ([ID])
);

