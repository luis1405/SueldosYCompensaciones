USE [SueldosYCompensaciones]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 13/02/2023 12:13:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entregas]    Script Date: 13/02/2023 12:13:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entregas](
	[IdEntrega] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[IdMes] [int] NOT NULL,
	[CantidadEntregas] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Impuestos]    Script Date: 13/02/2023 12:13:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impuestos](
	[IdImpuesto] [int] IDENTITY(1,1) NOT NULL,
	[SalarioLimite] [money] NOT NULL,
	[PorcentajeImpuesto] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Impuestos] PRIMARY KEY CLUSTERED 
(
	[IdImpuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 13/02/2023 12:13:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SueldosYCompensaciones]    Script Date: 13/02/2023 12:13:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SueldosYCompensaciones](
	[IdSueldoCompensacion] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NOT NULL,
	[SueldoBase] [money] NOT NULL,
	[HorasXJornada] [int] NOT NULL,
	[DiasXSemana] [int] NOT NULL,
	[CompensacionXEntrega] [money] NOT NULL,
	[BonoXHora] [money] NOT NULL,
	[PorcentajeValesDespensa] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_SueldosYCompensaciones] PRIMARY KEY CLUSTERED 
(
	[IdSueldoCompensacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([IdEmpleado], [IdRol], [Nombre]) VALUES (1, 1, N'Juan Garcia')
INSERT [dbo].[Empleados] ([IdEmpleado], [IdRol], [Nombre]) VALUES (2, 2, N'Pedro Reyes')
INSERT [dbo].[Empleados] ([IdEmpleado], [IdRol], [Nombre]) VALUES (3, 3, N'Ana Lopez')
SET IDENTITY_INSERT [dbo].[Empleados] OFF
GO
SET IDENTITY_INSERT [dbo].[Entregas] ON 

INSERT [dbo].[Entregas] ([IdEntrega], [IdEmpleado], [IdMes], [CantidadEntregas]) VALUES (1, 1, 1, 6)
INSERT [dbo].[Entregas] ([IdEntrega], [IdEmpleado], [IdMes], [CantidadEntregas]) VALUES (2, 2, 1, 8)
INSERT [dbo].[Entregas] ([IdEntrega], [IdEmpleado], [IdMes], [CantidadEntregas]) VALUES (4, 3, 1, 8)
SET IDENTITY_INSERT [dbo].[Entregas] OFF
GO
SET IDENTITY_INSERT [dbo].[Impuestos] ON 

INSERT [dbo].[Impuestos] ([IdImpuesto], [SalarioLimite], [PorcentajeImpuesto]) VALUES (1, 0.0000, CAST(9 AS Decimal(18, 0)))
INSERT [dbo].[Impuestos] ([IdImpuesto], [SalarioLimite], [PorcentajeImpuesto]) VALUES (2, 10000.0000, CAST(3 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Impuestos] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([IdRol], [Descripcion]) VALUES (1, N'Chofer')
INSERT [dbo].[Roles] ([IdRol], [Descripcion]) VALUES (2, N'Cargador')
INSERT [dbo].[Roles] ([IdRol], [Descripcion]) VALUES (3, N'Auxiliar')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[SueldosYCompensaciones] ON 

INSERT [dbo].[SueldosYCompensaciones] ([IdSueldoCompensacion], [IdRol], [SueldoBase], [HorasXJornada], [DiasXSemana], [CompensacionXEntrega], [BonoXHora], [PorcentajeValesDespensa]) VALUES (1, 1, 30.0000, 8, 6, 5.0000, 10.0000, CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[SueldosYCompensaciones] ([IdSueldoCompensacion], [IdRol], [SueldoBase], [HorasXJornada], [DiasXSemana], [CompensacionXEntrega], [BonoXHora], [PorcentajeValesDespensa]) VALUES (2, 2, 30.0000, 8, 6, 5.0000, 5.0000, CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[SueldosYCompensaciones] ([IdSueldoCompensacion], [IdRol], [SueldoBase], [HorasXJornada], [DiasXSemana], [CompensacionXEntrega], [BonoXHora], [PorcentajeValesDespensa]) VALUES (3, 3, 30.0000, 8, 6, 5.0000, 0.0000, CAST(4 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[SueldosYCompensaciones] OFF
GO
