create database library_manager
go

use library_manager
go

--

create table Author
(
	AuthorID varchar(10) primary key, 
	AuthorName nvarchar(50) not null,
	DoB date not null
)
go

create table PublishingCompany
(
	PublishingCompanyID varchar(10) primary key, 
	PublishingCompanyName nvarchar(50) not null,
	Address nvarchar(100) not null,
	Hotline int not null,
	Email varchar(50) not null,
)

create table BookCategory
(
	BookCategoryID varchar(10) primary key,
	BookCategoryName nvarchar(50) not null
)
go

create table Book
(
	BookID varchar(10) primary key,
	BookTitle nvarchar(50) not null,
	AuthorID varchar(10) not null,
	PublishingCompanyID varchar(10) not null,
	BookCategoryID varchar(10) not null,
	PublishingYear int not null,
	Price int not null

	foreign key(AuthorID) references Author(AuthorID),
	foreign key(PublishingCompanyID) references PublishingCompany(PublishingCompanyID),
	foreign key(BookCategoryID) references BookCategory(BookCategoryID)
)
go

create table _User
(
	UserID varchar(10) primary key,
	UserName nvarchar(50) not null,
	DoB date not null,
	Address nvarchar(100) not null,
	Email varchar(50) not null,
	PhoneNumber int not null,

)
go

create table Bill
(
	BillID varchar(10) primary key,
	UserID varchar(10) not null,
	BookID varchar(10) not null,
	BookLoanDay date not null,
	BookReturnDay date not null,
	Note nvarchar(100) ,

	foreign key(UserID) references _User(UserID),
	foreign key(BookID) references Book(BookID)
)
go


create table Account
(
	UserName varchar(100) primary key,
	PassWord varchar(100) not null DEFAULT 0,	

)
go

select * from PublishingCompany

INSERT INTO Account ([UserName],[PassWord]) VALUES ('admin','admin')

INSERT INTO Author ([AuthorID], [AuthorName],[DoB]) VALUES ('A0001',N'Khá Văn Bảnh','12/12/1919' )
INSERT INTO Author ([AuthorID], [AuthorName],[DoB]) VALUES ('A0002',N'Anh Dũng','12/02/1929' )
INSERT INTO Author ([AuthorID], [AuthorName],[DoB]) VALUES ('A0003',N'Đăng Khoa','02/12/1939' )
INSERT INTO Author ([AuthorID], [AuthorName],[DoB]) VALUES ('A0004',N'Đăng Khoa Khoa','12/21/1939' )

INSERT INTO PublishingCompany ([PublishingCompanyID], [PublishingCompanyName] ,[Address], [Hotline], [Email]) VALUES ('PC0001',N'abc',N'hà nội',123456,'abc@mail.com')
INSERT INTO PublishingCompany ([PublishingCompanyID], [PublishingCompanyName] ,[Address], [Hotline], [Email]) VALUES ('PC0002',N'abcd',N'nội hà',123465,'abcd@mail.com')
INSERT INTO PublishingCompany ([PublishingCompanyID], [PublishingCompanyName] ,[Address], [Hotline], [Email]) VALUES ('PC0003',N'abcde',N'hà hoi',124356,'abce@mail.com')

INSERT INTO BookCategory ([BookCategoryID], [BookCategoryName]) VALUES ('BC0001',N'Hentai')
INSERT INTO BookCategory ([BookCategoryID], [BookCategoryName]) VALUES ('BC0002',N'truyện tranh')
INSERT INTO BookCategory ([BookCategoryID], [BookCategoryName]) VALUES ('BC0003',N'truyện cổ tích')

INSERT INTO Book ([BookID], [BookTitle] ,[AuthorID], [PublishingCompanyID], [BookCategoryID], [PublishingYear], [Price]) VALUES ('B0001', N'Đắc Nhân Tâm','A0001','PC0001', 'BC0001',2000,6868 )
INSERT INTO Book ([BookID], [BookTitle] ,[AuthorID], [PublishingCompanyID], [BookCategoryID], [PublishingYear], [Price]) VALUES ('B0002', N'Nhà giả kim','A0002','PC0002', 'BC0002',2001,6886 )
INSERT INTO Book ([BookID], [BookTitle] ,[AuthorID], [PublishingCompanyID], [BookCategoryID], [PublishingYear], [Price]) VALUES ('B0003', N'Đời thay đổi khi chúng ta thay đổi','A0003','PC0003', 'BC0003',2002,6868 )

INSERT INTO _User ([UserID], [UserName], [DoB] ,[Address], [Email], [PhoneNumber]) VALUES ('U0001', N'Khá Bảnh', '01/01/2001', N'nội hà', 'KhaBanh@gmail.com', 022102 )
INSERT INTO _User ([UserID], [UserName], [DoB] ,[Address], [Email], [PhoneNumber]) VALUES ('U0002', N'Bảnh', '01/02/2003', N'nội hà', 'Banh@gmail.com', 022103 )
INSERT INTO _User ([UserID], [UserName], [DoB] ,[Address], [Email], [PhoneNumber]) VALUES ('U0003', N'Bảnh Khá', '02/03/2004', N'nội hà', 'BanhKha@gmail.com', 022104 )

INSERT INTO Bill ([BillID], [UserID], [BookID] ,[BookLoanDay], [BookReturnDay], [Note]) VALUES ('M0001','U0001','B0001', '02/03/2021', '06/03/2021 ', N'nhìn mặt uy tín')

go

CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS 
BEGIN
	SELECT * FROM Account WHERE UserName = @userName
END
GO

EXEC dbo.USP_GetAccountByUserName @userName = 'admin' -- varchar(100)

go

CREATE PROC USP_Login
@UserName varchar(100), @PassWord varchar(100)
AS
BEGIN
	SELECT * FROM Account WHERE UserName = @UserName AND PassWord = @PassWord
END
GO
select * from Account where UserName ='' and PassWord ='' or 'admin'='admin'--! // SQL Injection
go


/*
 INSERT Book ( BookTitle, AuthorID, PublishingCompanyID, BookCategoryID, PublishingYear, Price) VALUES  ('{0}', N'{1}', '{2}', '{4}', '{5}', '{6}') */

 -- tim` kiem' thong tin gan` dung'
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
go
SELECT * FROM dbo.Book WHERE dbo.fuConvertToUnsign1(BookTitle) LIKE N'%' + dbo.fuConvertToUnsign1(N'y') + '%'

select * from _User
