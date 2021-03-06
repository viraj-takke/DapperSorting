USE [EquiCustomer]
GO
/****** Object:  StoredProcedure [dbo].[Customer_Create]    Script Date: 18-11-2021 09:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Customer_Create]
	@Id int,
	@Name nvarchar(50),
	@Email nvarchar(150),
	@City nvarchar(50),
	@Address nvarchar(50)
		 
as begin
	insert into Customer
	(
		Name,
		Email,
		City,
		Address
	)
    values
	(
		@Name,
		@Email,
		@City,
		@Address
	)

	select SCOPE_IDENTITY() InsertedId
end

GO


/****** Object:  StoredProcedure [dbo].[Customer_Get]    Script Date: 18-11-2021 09:29:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Customer_Get]
	@Id int
as begin
	select 
		Id,
		Name,
		Email,
		City,
		Address 
	from 
		Customer
	where 
		Id = @Id
end

GO


/****** Object:  StoredProcedure [dbo].[Customer_GetAll]    Script Date: 18-11-2021 09:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Customer_GetAll]
	@Id int = null,
	@Search nvarchar(50) = null,
	@OrderBy varchar(100) = 'name',
	@IsDescending bit = 0
as begin
	select 
		Id,
		Name,
		Email,
		City,
		Address	
	from 
		Customer
	where
		Id = coalesce(@Id, Id)
		and
		(
			(@Search is null or @Search = '')
			or
			(
				@Search is not null
				and
				(
					Name like '%' + @Search + '%'
					or
					Email like '%' + @Search + '%'
					or
					City like '%' + @Search + '%'
					or
					Address like '%' + @Search + '%'
				)
			)
		)
	order by
		case when @OrderBy = 'name' and @IsDescending = 0 then Name end asc
		, case when @OrderBy = 'name' and @IsDescending = 1 then Name end desc
		, case when @OrderBy = 'Email' and @IsDescending = 0 then Email end asc
		, case when @OrderBy = 'Email' and @IsDescending = 1 then Email end desc
		, case when @OrderBy = 'City' and @IsDescending = 0 then City end asc
		, case when @OrderBy = 'City' and @IsDescending = 1 then City end desc
		, case when @OrderBy = 'Address' and @IsDescending = 0 then Address end asc
		, case when @OrderBy = 'Address' and @IsDescending = 1 then Address end desc
end

GO


/****** Object:  StoredProcedure [dbo].[Customer_Create]    Script Date: 18-11-2021 09:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Customer_Create]
	@Id int,
	@Name nvarchar(50),
	@Email nvarchar(150),
	@City nvarchar(50),
	@Address nvarchar(50)
		 
as begin
	insert into Customer
	(
		Name,
		Email,
		City,
		Address
	)
    values
	(
		@Name,
		@Email,
		@City,
		@Address
	)

	select SCOPE_IDENTITY() InsertedId
end
go



/****** Object:  StoredProcedure [dbo].[Customer_Update]    Script Date: 18-11-2021 09:31:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Customer_Update]
	@Id int,
	@Name nvarchar(50),
	@Email nvarchar(150),
	@City nvarchar(50),
	@Address nvarchar(50)
as begin
	update 
		Customer
	set
		Name = @Name,
		Email = @Name,
		City = @City,
		Address = @Address 
	where 
		Id=@Id
end
GO



/****** Object:  StoredProcedure [dbo].[Customer_Delete]    Script Date: 18-11-2021 09:33:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Customer_Delete]
	@Id int
as begin
	delete 
	from 
		Customer
	where 
		Id = @Id
end