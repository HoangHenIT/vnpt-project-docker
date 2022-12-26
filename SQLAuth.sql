create database vnpt_auth
use vnpt_auth
DROP DATABASE vnpt_auth

drop table employer

create table roles(
	role_id int not null identity(1,1) primary key,
	role_name nvarchar(200)
)

create table employer(
	employer_id int not null identity(1,1) primary key,
	full_name nvarchar(100),
	email nvarchar(100),
	number_phone varchar(11),
	username nvarchar(100),
	password nvarchar(100),
	role_id int,
	active bit,  --1 true, 0 false	
	foreign key (role_id) references roles(role_id)

)