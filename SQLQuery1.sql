create table categorymenu(
	category_id int not null identity(1,1) primary key,
	category_name nvarchar(200),
	category_level int, --0 menu char, 1 - menu lv1
	category_link nvarchar(500),
	category_icon nvarchar(500),
	category_note nvarchar(500),
	category_active bit, 
	createday datetime,
	category_cha_id int,
	position int
)
create table grouppermission(
	role_id int,
	category_id int,
	craeteday datetime,
	foreign key (role_id) references Roles(role_id),
	foreign key (category_id) references categorymenu(category_id)
)

select * from categorymenu
drop table grouppermission;
drop table categorymenu;