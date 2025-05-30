/****** Object:  Table [dbo].[Gender]    Script Date: 3/1/2025 6:49:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[GenderID] [int] IDENTITY(1,1) NOT NULL,
	[GenderDescription] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 3/1/2025 6:49:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[GenderID] [int] NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Height] [decimal](18, 0) NOT NULL,
	[Weight] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Gender] FOREIGN KEY([GenderID])
REFERENCES [dbo].[Gender] ([GenderID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Gender]
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudent]    Script Date: 3/1/2025 6:49:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[DeleteStudent]
	@StudentId int
AS
BEGIN
SET NOCOUNT ON
DELETE FROM Students
WHERE
	@StudentId = ID
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllGenders]    Script Date: 3/1/2025 6:49:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetAllGenders]
AS
BEGIN
SET NOCOUNT ON
SELECT * FROM Gender
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllStudents]    Script Date: 3/1/2025 6:49:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetAllStudents]
AS
BEGIN
SET NOCOUNT ON
SELECT
	*
FROM
	Students
END;
GO
/****** Object:  StoredProcedure [dbo].[GetGenderById]    Script Date: 3/1/2025 6:49:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetGenderById]
	@GenderId INT
AS
BEGIN
SET NOCOUNT ON
SELECT
	*
FROM
	Gender
WHERE
	@GenderId = GenderId
END;
GO
/****** Object:  StoredProcedure [dbo].[GetStudentById]    Script Date: 3/1/2025 6:49:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[GetStudentById]
	@StudentId INT
AS
BEGIN
SET NOCOUNT ON
SELECT
	 ID
	,Name
	,GenderID
	,DateOfBirth
	,Height
	,Weight
FROM
	Students
WHERE
	@StudentId = ID
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudent]    Script Date: 3/1/2025 6:49:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[UpdateStudent]
	@StudentId int,
    @Name nvarchar(50),
    @GenderId int,
    @DateOfBirth datetime,
    @Height decimal(18,2),
    @Weight decimal(18,2)
AS
BEGIN
SET NOCOUNT ON

BEGIN TRY
        -- Check if the student exists
        IF NOT EXISTS (SELECT 1 FROM Students WHERE ID = @StudentId)
        BEGIN
            PRINT 'Error: Student ID not found.';
            RETURN;
        END

        UPDATE Students
        SET
            Name = @Name,
            GenderId = @GenderId,
            DateOfBirth = @DateOfBirth,
            Height = @Height,
            Weight = @Weight
        WHERE ID = @StudentId;

        PRINT 'Update successful.';
    END TRY
    BEGIN CATCH
        PRINT 'Error occurred: ' + ERROR_MESSAGE();
    END CATCH
END;
GO
