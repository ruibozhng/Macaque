﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT [dbo].[T_CODE] ON 

INSERT [dbo].[T_CODE] ([ID], [CATEGORY], [CODE], [CODE_DESC]) VALUES (1, N'GRADES', N'L1', N'Level 1')
INSERT [dbo].[T_CODE] ([ID], [CATEGORY], [CODE], [CODE_DESC]) VALUES (2, N'GRADES', N'L2', N'Level 2')
SET IDENTITY_INSERT [dbo].[T_CODE] OFF
INSERT [dbo].[T_FUNCTION] ([FUNCTION_CODE], [FUNCTION_DESC]) VALUES (N'USER_ADD', N'Add new user')
INSERT [dbo].[T_FUNCTION] ([FUNCTION_CODE], [FUNCTION_DESC]) VALUES (N'USER_DEL', N'Delete user')
INSERT [dbo].[T_FUNCTION] ([FUNCTION_CODE], [FUNCTION_DESC]) VALUES (N'USER_EDIT', N'Edit user')
INSERT [dbo].[T_FUNCTION] ([FUNCTION_CODE], [FUNCTION_DESC]) VALUES (N'USER_LIST', N'Search user')
INSERT [dbo].[T_FUNCTION] ([FUNCTION_CODE], [FUNCTION_DESC]) VALUES (N'USER_VIEW', N'View user detail ')
INSERT [dbo].[T_ROLE] ([ROLE_CODE], [ROLE_DESC]) VALUES (N'ADM', N'Admin')
INSERT [dbo].[T_ROLE] ([ROLE_CODE], [ROLE_DESC]) VALUES (N'PUB', N'Public')
SET IDENTITY_INSERT [dbo].[T_ROLE_FUNCTION] ON 

INSERT [dbo].[T_ROLE_FUNCTION] ([ID], [ROLE_CODE], [FUNCTION_CODE]) VALUES (1, N'ADM', N'USER_ADD')
INSERT [dbo].[T_ROLE_FUNCTION] ([ID], [ROLE_CODE], [FUNCTION_CODE]) VALUES (2, N'ADM', N'USER_EDIT')
INSERT [dbo].[T_ROLE_FUNCTION] ([ID], [ROLE_CODE], [FUNCTION_CODE]) VALUES (3, N'ADM', N'USER_DEL')
INSERT [dbo].[T_ROLE_FUNCTION] ([ID], [ROLE_CODE], [FUNCTION_CODE]) VALUES (4, N'ADM', N'USER_LIST')
INSERT [dbo].[T_ROLE_FUNCTION] ([ID], [ROLE_CODE], [FUNCTION_CODE]) VALUES (5, N'ADM', N'USER_VIEW')
INSERT [dbo].[T_ROLE_FUNCTION] ([ID], [ROLE_CODE], [FUNCTION_CODE]) VALUES (7, N'PUB', N'USER_LIST')
SET IDENTITY_INSERT [dbo].[T_ROLE_FUNCTION] OFF
SET IDENTITY_INSERT [dbo].[T_USER] ON 

INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (1, N'admin', N'Admin', N'123456', N'M', N'87654322', N'abc@abc.com', N'L1', 0, N'admin', CAST(N'2015-01-23 19:58:31.843' AS DateTime), N'admin', CAST(N'2015-01-24 08:51:35.557' AS DateTime), 9)
INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (3, N'craig', N'Craig', N'123', N'M', N'87654321', N'abc@abc.com', N'L1', 0, N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), N'admin', CAST(N'2015-01-25 18:30:14.067' AS DateTime), 2)
INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (4, N'jack', N'Jackie', N'123', N'M', N'123', N'abc', N'L1', 0, N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), N'admin', CAST(N'2015-01-25 18:30:35.457' AS DateTime), 3)
INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (5, N'sam', N'Sam', N'123', N'M', N'87654321', N'abc@abc.com', N'L2', 0, N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), N'admin', CAST(N'2015-02-02 16:26:17.083' AS DateTime), 2)
INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (6, N'peter', N'Peter', N'123', N'M', N'87654321', N'abc@abc.com', N'5', 0, N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), 1)
INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (7, N'alex', N'Alex', N'123', N'M', N'123456', N'abc@abc.com', N'6', 0, N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), N'admin', CAST(N'2015-01-25 16:42:23.753' AS DateTime), 3)
INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (8, N'jerry', N'Jerry', N'123', N'M', N'87654321', N'abc@abc.com', N'7', 0, N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), 1)
INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (9, N'Test', N'Test', N'Test', N'F', N'123', N'123', N'L2', 1, N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), N'admin', CAST(N'2015-01-24 09:16:00.963' AS DateTime), 2)
INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (10, N'hh', N'gg', N'ff', N'M', N'1223', N'1212', N'L1', 1, N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), 1)
INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (11, N'gg', N'ggg', N'ggg', N'M', N'ggg', N'ggg', N'L2', 1, N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), N'SYSTEM', CAST(N'2015-01-23 15:45:33.793' AS DateTime), 1)
INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (12, N'hello', N'hello', N'hello', N'M', N'hello', N'hello', N'L1', 1, N'admin', CAST(N'2015-01-24 09:16:24.847' AS DateTime), N'admin', CAST(N'2015-01-24 09:16:24.847' AS DateTime), 1)
INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (13, N'abc', N'abc', N'abc', N'abc123', N'abc', N'abc', N'abc', 0, N'admin', CAST(N'2015-01-25 16:48:50.040' AS DateTime), N'admin', CAST(N'2015-01-25 18:40:23.973' AS DateTime), 3)
INSERT [dbo].[T_USER] ([ID], [USER_ID], [USER_NAME], [USER_PWD], [GENDER], [MOBILE_NUMBER], [EMAIL_ADDRESS], [GRADE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (14, N'eva', N'eva', N'123', N'F', N'123', N'123', N'L1', 0, N'admin', CAST(N'2015-02-02 16:25:29.000' AS DateTime), N'admin', CAST(N'2015-02-02 16:25:29.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[T_USER] OFF
SET IDENTITY_INSERT [dbo].[T_USER_ROLE] ON 

INSERT [dbo].[T_USER_ROLE] ([ID], [USER_ID], [ROLE_CODE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (1, 1, N'ADM', 0, N'SYSTEM', CAST(N'2015-01-23 22:19:13.410' AS DateTime), N'admin', CAST(N'2015-01-23 22:42:28.200' AS DateTime), 3)
INSERT [dbo].[T_USER_ROLE] ([ID], [USER_ID], [ROLE_CODE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (2, 1, N'PUB', 0, N'SYSTEM', CAST(N'2015-01-23 22:19:13.410' AS DateTime), N'admin', CAST(N'2015-01-24 08:51:35.637' AS DateTime), 7)
INSERT [dbo].[T_USER_ROLE] ([ID], [USER_ID], [ROLE_CODE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (3, 9, N'PUB', 0, N'admin', CAST(N'2015-01-24 09:16:00.990' AS DateTime), N'admin', CAST(N'2015-01-24 09:16:00.990' AS DateTime), 1)
INSERT [dbo].[T_USER_ROLE] ([ID], [USER_ID], [ROLE_CODE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (4, 12, N'PUB', 0, N'admin', CAST(N'2015-01-24 09:16:24.883' AS DateTime), N'admin', CAST(N'2015-01-24 09:16:24.883' AS DateTime), 1)
INSERT [dbo].[T_USER_ROLE] ([ID], [USER_ID], [ROLE_CODE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (5, 3, N'ADM', 0, N'admin', CAST(N'2015-01-25 18:30:14.233' AS DateTime), N'admin', CAST(N'2015-01-25 18:30:14.233' AS DateTime), 1)
INSERT [dbo].[T_USER_ROLE] ([ID], [USER_ID], [ROLE_CODE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (6, 4, N'PUB', 0, N'admin', CAST(N'2015-01-25 18:30:35.480' AS DateTime), N'admin', CAST(N'2015-01-25 18:30:35.480' AS DateTime), 1)
INSERT [dbo].[T_USER_ROLE] ([ID], [USER_ID], [ROLE_CODE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (7, 14, N'PUB', 0, N'admin', CAST(N'2015-02-02 16:25:29.420' AS DateTime), N'admin', CAST(N'2015-02-02 16:25:29.420' AS DateTime), 1)
INSERT [dbo].[T_USER_ROLE] ([ID], [USER_ID], [ROLE_CODE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (8, 5, N'ADM', 0, N'admin', CAST(N'2015-02-02 16:26:17.127' AS DateTime), N'admin', CAST(N'2015-02-02 16:26:17.127' AS DateTime), 1)
INSERT [dbo].[T_USER_ROLE] ([ID], [USER_ID], [ROLE_CODE], [IS_DELETED], [CREATED_BY], [CREATED_DATE], [UPDATED_BY], [UPDATED_DATE], [VERSION_NO]) VALUES (9, 5, N'PUB', 0, N'admin', CAST(N'2015-02-02 16:26:17.137' AS DateTime), N'admin', CAST(N'2015-02-02 16:26:17.137' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[T_USER_ROLE] OFF