--will put all database changes here

create database onlineLoanManagementSystem

use onlineLoanManagementSystem

create table tblLogin ( loginId int identity primary key, userName varchar(50), password varchar(50) )