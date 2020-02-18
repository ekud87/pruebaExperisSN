create table InterviewType
(
	id integer identity(1,1) not null,
	[name] varchar(100) not null,
	constraint PK_InterviewType primary key(id)
)

create table Interview
(	
	id integer identity(1,1) not null,
	[user] integer not null,
	[type] integer not null,
	[date] date not null,
	[time] time not null,
	constraint PK_Interview primary key ([user],[type],[date],[time]),
	constraint FK_Interview_InterviewType foreign key ([type]) references InterviewType
)

create table TechnologyType(
	id integer identity(1,1) not null,
	[name] varchar(100) not null,
	constraint PK_TechnologyType primary key (id)
)

create table Technology(
	id integer identity(1,1) not null,
	[name] varchar(100) not null,
	[type] integer not null,
	constraint PK_Technology primary key (id),
	constraint FK_technology_type foreign key ([type]) references TechnologyType
)

create table TechnologyOrder (
	technology integer not null,
	[order] integer not null,
	constraint PK_TechnologyOrder primary key (technology,[order]),
	constraint FK_TechnologyOrder_technology foreign key (technology) references Technology
)
create table Scheduled(
	id integer identity(1,1) not null,
	code integer not null,
	[name] varchar(100) not null,
	[user] varchar(50) not null,
	email varchar(20) not null,
	[address] varchar (100) not null,
	tel varchar(50) not null,
	webSite varchar(50) not null,
	company varchar(100) not null,
	constraint PK_Users primary key (id)
)