Hii welcome to my github repository, this is project where i have build the Employee Management systerm in asp.net mvc using web apis.

to run this app follow below steps

1. open solution and start the project (make both the project as a start up project if it does not connect).
2. add local instance of data base and add two tables Employee and Admin (name should be exact match).
3. run this script in your data base
for employee table run below code
*****************************************************************
USE <your db_name> -- (enter your database name here)
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 30-11-2023 12:53:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Status] [nvarchar](10) NULL,
	[Skills] [nvarchar](255) NULL,
	[Department] [nvarchar](10) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
******************************************************************
for admin table run below code

******************************************************************
USE <your dbname>
GO

/****** Object:  Table [dbo].[Admin]    Script Date: 30-11-2023 12:54:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
*************************************************************************************
