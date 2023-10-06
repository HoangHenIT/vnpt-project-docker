create database vnptauth
use vnptauth
DROP DATABASE vnpt_auth

drop table employer

create table roles(
	role_id int not null identity(1,1) primary key,
	role_name nvarchar(200)
)

create table employers(
	employer_id int not null identity(1,1) primary key,
	full_name nvarchar(100),
	name_profile nvarchar(100),
	job_name nvarchar(100),
	company nvarchar(100),
	email nvarchar(100),
	number_phone varchar(11),
	mobile varchar(11),
	username nvarchar(100),
	password nvarchar(100),
	address nvarchar(500),
	role_id int,
	active bit,  --1 true, 0 false	
	link_website nvarchar(200),
	link_git nvarchar(200),
	link_facebook nvarchar(200),
	foreign key (role_id) references roles(role_id)
)
create table historylogins(
	history_id int not null identity(1,1) primary key,
	employer_id int,
	datetime_login datetime,
	system_login nvarchar(100),
	username nvarchar(100),
	foreign key (employer_id) references employers(employer_id)
)
create table categorymenu(
	category_id int not null identity(1,1) primary key,
	category_name nvarchar(200),
	category_level int, --0 menu char, 1 - menu lv1
	category_link nvarchar(500),
	category_icon nvarchar(500),
	category_note nvarchar(500),
	category_active bit, 
	craeteday datetime,
)
create table rolepermissions(
	role_id int,
	category_id int,
	craeteday datetime,
	foreign key (role_id) references Roles(role_id),
	foreign key (category_id) references categorymenu(category_id)
)
create table employerpermissions(
	role_id int,
	employer_id int,
	craeteday datetime,
	foreign key (role_id) references Roles(role_id),
	foreign key (employer_id) references employers(employer_id)
)

drop table grouppermission
drop table roles

