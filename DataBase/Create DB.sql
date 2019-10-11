CREATE TABLE Country(
	IdCountry int identity (1,1) primary key,
	Name varchar(200) not null,
	Comment varchar(300)
)

CREATE TABLE State(
	IdState int identity (1,1) primary key,
	Name varchar(200) not null,
	Comment varchar(300),
	IdCountry int foreign key references Country(IdCountry)
)


CREATE TABLE City(
	IdCity int identity (1,1) primary key,
	Name varchar(200) not null,
	Comment varchar(300),
	IdState int foreign key references State(IdState)
)

CREATE TABLE Client(
	IdClient int identity(1,1) primary key,
	Nit varchar(200) not null,
	FullName varchar(200) not null,
	Address varchar(200) not null,
	Phone varchar(15) not null,
	IdCity int foreign key references City(IdCity) not null,
	CreditLimit int not null,
	AvailableCredit int not null,
	VisitsPercentage int
)

CREATE TABLE SaleRepresentative(
	IdSRepresentative int identity(1,1) primary key not null,
	Name varchar(200) not null,
	Phone varchar (15)
)

CREATE TABLE Visit(
	IdVisit int identity (1,1) primary key,
	IdClient int foreign key references Client(IdClient) not null,
	VisitDate Datetime not null,
	IdSRepresentative int foreign key references SaleRepresentative(IdSRepresentative) not null,
	Net int,
	VisitTotal int,
	Description varchar(300)
)