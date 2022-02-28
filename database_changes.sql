--will put all database changes here

create database onlineLoanManagementSystem

use onlineLoanManagementSystem

create table tblLogin ( loginId int identity primary key, userName varchar(50), password varchar(50) )

create table tblRegister (regId int identity primary key, fullName varchar (100), userName varchar(50), password varchar(50))
create table tblLogin ( loginId int identity primary key, userName varchar(50), password varchar(50))
drop table tblCustomer
create table tblCustomer ( CId int identity primary key, Name varchar(100) , Email varchar(50), Phone varchar(50), Address Varchar(300))
create table tblLoan_Master ( LoanId int identity primary key, LoanTypeId int, CId int)
create table tblLoanType ( LoanTypeId int identity primary key, LoanType varchar(100), Duration varchar(50), Rate float )
create table tblEmi ( EmiId int identity primary key, CId int, Emi_Amount decimal, Interest_Amount decimal, Total_Amount decimal)

create table tblCompany (CompanyId int identity primary key, CompanyName varchar (100), StartDate DateTime, Trunover varchar (100),OwenerName varchar (100))


create table tblLoanApplication (loanApplicationId int identity primary key, CompanyId int, LoanTypeId int, LoanId int, loginId int, status varchar(50))


create table tblUploadDocument ( documentId int identity primary key, loanApplicationId int, documentType varchar(50), documentName varchar(50))

alter table tblLogin add empType varchar(10)






======================

select * from tblLogin where userName='' and password=''

insert into tblLogin values('kailash1@gmail.com', 'kailash', 'admin')

update tblLogin set empType='customer'

select * from tblLoanType

insert into tblLoanType values('Personal Loan','5 years', 10)

update tblLoanType set Loantype='abc loan', Duration='5 kd', Rate='343' where loantypeid=1

