USE [DbContext]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 28/03/2025 0:42:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnergyIndicator]    Script Date: 28/03/2025 0:42:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnergyIndicator](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](max) NOT NULL,
	[CDEEBC_NetProduction] [float] NOT NULL,
	[CCAC_AutoGas] [float] NOT NULL,
	[CDEEBC_ElectricDemand] [float] NOT NULL,
	[CDEEBC_DispProd] [float] NOT NULL,
 CONSTRAINT [PK_EnergyIndicator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Simulacio]    Script Date: 28/03/2025 0:42:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Simulacio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipusEnergia] [nvarchar](max) NOT NULL,
	[Parametre] [float] NOT NULL,
	[Rati] [float] NOT NULL,
	[Cost] [float] NOT NULL,
	[Preu] [float] NOT NULL,
 CONSTRAINT [PK_Simulacio] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WaterConsumption]    Script Date: 28/03/2025 0:42:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WaterConsumption](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[RegionCode] [int] NOT NULL,
	[Region] [nvarchar](max) NOT NULL,
	[Population] [int] NOT NULL,
	[DomesticConsumption] [float] NOT NULL,
	[EconomicActivitiesConsumption] [float] NOT NULL,
	[TotalConsumption] [float] NOT NULL,
	[DomesticConsumptionPerCapita] [float] NOT NULL,
 CONSTRAINT [PK_WaterConsumption] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
