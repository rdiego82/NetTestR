USE [CellRecharges]
GO

/****** Object:  Table [dbo].[CostPerSecond]    Script Date: 18/07/2017 17:04:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CostPerSecond](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cost] [float] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_CostPerSecond] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CostPerSecond] ADD  CONSTRAINT [DF_CostPerSecond_Date]  DEFAULT (getdate()) FOR [Date]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cost per second. Example 2000' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CostPerSecond', @level2type=N'COLUMN',@level2name=N'Cost'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'parametrization date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CostPerSecond', @level2type=N'COLUMN',@level2name=N'Date'
GO


