USE [CellRecharges]
GO

/****** Object:  Table [dbo].[Process]    Script Date: 18/07/2017 17:04:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Process](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cost] [float] NOT NULL,
	[CellPhoneNumber] [varchar](20) NOT NULL,
	[Type] [varchar](1) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Process] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Process] ADD  CONSTRAINT [DF_Process_Date]  DEFAULT (getdate()) FOR [Date]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Recharge / Consumption cost' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Process', @level2type=N'COLUMN',@level2name=N'Cost'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cell phone number. Example: 3112345432' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Process', @level2type=N'COLUMN',@level2name=N'CellPhoneNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of process: "R" for Recharge. "C" for Consumption' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Process', @level2type=N'COLUMN',@level2name=N'Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Process date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Process', @level2type=N'COLUMN',@level2name=N'Date'
GO


