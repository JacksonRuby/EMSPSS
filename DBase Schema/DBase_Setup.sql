CREATE DATABASE EMS_PSS;

CREATE TABLE SystemUser
(
    UserID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    CompanyID INTEGER NOT NULL,
    LastName VARCHAR(65) NULL,
    FirstName VARCHAR(65) NOT NULL,
    IsAdmin BIT NOT NULL,
    UserName VARCHAR(65) NOT NULL,
    Password VARCHAR(256) NOT NULL,
);

INSERT INTO SystemUser VALUES(1, 'Admin', 'Admin', 1, 'Admin', '3NU32EF9lZQS+b8W7A+e/R4vPCYx33ZsPVE19n6nOU4=');
INSERT INTO SystemUser VALUES(1, '1', 'General', 0, 'general1', '2jA975MwZO1aoP44CIriwrdof+Fz/JnR9A8+sd3Vi/0=');
INSERT INTO SystemUser VALUES(1, '2', 'General', 0, 'general2', '0Zug4e2cVeiiNf0xBgZ979r9tUq6VmdcFzMGJJWAb3c=');
INSERT INTO SystemUser VALUES(1, 'And', 'fred', 0, 'fredAnd', 'hG5cjJREvUwn2FEYCCsX/F6xfTmPb16MAqkDD5w/RNQ=');

CREATE TABLE Company
(
    CompanyID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    CompanyName VARCHAR(65) NOT NULL
);

INSERT INTO Company VALUES ('Bob''s Fish and Tackle');
INSERT INTO Company VALUES ('VeraCorp Inc');
INSERT INTO Company VALUES ('FF-Frech Fruit Corp');
INSERT INTO Company VALUES ('Joe''s Gas and Feed');

CREATE TABLE Employee
(
	EmployeeID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	EmployedWithCompanyID BIGINT FOREIGN KEY REFERENCES Company(CompanyID),
	EmployeeType VARCHAR(30) NOT NULL,
	LastName VARCHAR(65) NOT NULL,
	FirstName VARCHAR(65) NOT NULL,
	SocialInsuranceNumber NUMERIC(9,0) NOT NULL,
	DateOfBirth DATE NOT NULL,
	ReasonForLeaving nvarchar NULL,
	DateOfHire DATE NULL,
	DateOfTermination DATE NULL,
	RecordComplete BIT NOT NULL,
	Salary MONEY NULL,
	HourlyRate MONEY NULL,
	ContractStartDate DATE NULL,
	ContractEndDate DATE NULL,
	FixedContractRate MONEY NULL,
	PiecePay MONEY NULL,
	Active INTEGER NOT NULL
);

INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, DateOfHire, RecordComplete, Salary, Active) VALUES (1, 'full time', 'Smith', 'Bob', 555111228, '06-20-1945', '01-01-2005', 1, 45000.50, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, DateOfHire, RecordComplete, Salary, Active) VALUES (2, 'full time', 'Budelman', 'Larry', 851222125, '08-30-1958', '03-15-2015', 1, 120560.00, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, DateOfHire, RecordComplete, Salary, Active) VALUES (3, 'full time', 'Findley', 'Frank', 995642352, '', '03-15-1990', 0, 0, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, DateOfHire, DateOfTermination, RecordComplete, Salary, Active) VALUES (1, 'full time', 'Sminth', 'Darryl', 193456787, '02-29-1960', '12-05-2008', '01-27-2016', 1, 32768.00, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, DateOfHire, RecordComplete, HourlyRate, Active) VALUES (4, 'part time', 'Smith', 'Darryl', 193456787, '02-29-1960', '11-25-2010', 1, 10.25, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, DateOfHire, RecordComplete, HourlyRate, Active) VALUES (2, 'part time', 'Struthers', 'Sally', 654852458, '07-03-1971', '02-14-2005', 1, 12.56, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, DateOfHire, RecordComplete, HourlyRate, Active) VALUES (4, 'part time', 'Martin', 'Ted', 546511247, '07-26-1995', '12-20-2012', 0, 0, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, DateOfHire, DateOfTermination, RecordComplete, HourlyRate, Active) VALUES (2, 'part time', 'Kramdon', 'Alice', 876543216, '09-11-1950', '03-15-1990', '02-14-2009', 1, 7.56, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, DateOfHire, RecordComplete, PiecePay, Active) VALUES (3, 'seasonal', 'Joad', 'Tom', 325440550, '10-20-1980', '01-01-2016', 1, 2.35, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, DateOfHire, RecordComplete, PiecePay, Active) VALUES (3, 'seasonal', 'Joad', 'Pa', 540654654, '01-10-1950', '01-01-2016', 1, 3.10, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, DateOfHire, RecordComplete, PiecePay, Active) VALUES (3, 'seasonal', 'Joad', 'Al', 252352133, '04-20-1987', '', 0, 3.10, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, DateOfHire, RecordComplete, PiecePay, Active) VALUES (3, 'seasonal', 'Joad', 'Noah', 984372367, '09-22-1975', '09-01-2013', 1, 1.56, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, ContractStartDate, ContractEndDate, RecordComplete, FixedContractRate, Active) VALUES (2, 'contract', '', 'poneSDLC', 586554859, '05-05-1958', '11-01-2002', '05-30-2016', 1, 650000.00, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, ContractStartDate, ContractEndDate, RecordComplete, FixedContractRate, Active) VALUES (2, 'contract', '', 'proFO-Code Inc', 058488370, '03-28-2005', '11-01-2012', '10-31-2016', 1, 75000.00, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, ContractStartDate, ContractEndDate, RecordComplete, FixedContractRate, Active) VALUES (2, 'contract', '', 'Sally''s Cleaning Services Ltd', 102545449, '06-15-2010', '', '', 0, 20000.00, 1);
INSERT INTO Employee (EmployedWithCompanyID, EmployeeType, LastName, FirstName, SocialInsuranceNumber, DateOfBirth, ContractStartDate, ContractEndDate, RecordComplete, FixedContractRate, Active) VALUES (2, 'contract', '', 'poneSDLC', 586554859, '05-05-1958', '11-01-1992', '05-30-1998', 1, 250000.0, 1);


CREATE TABLE Audit
(
    LogID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeChanged BIGINT NOT NULL FOREIGN KEY REFERENCES Employee(EmployeeID),
    UserUD BIGINT NOT NULL FOREIGN KEY REFERENCES SystemUser(UserID),
    TimeStamp VARCHAR(10) NOT NULL,
    PreviousValue NVARCHAR NOT NULL,
    NewValue NVARCHAR NOT NULL,
    Message NVARCHAR NOT NULL
);

CREATE TABLE Timesheet
(
    TimesheetID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeID BIGINT NOT NULL FOREIGN KEY REFERENCES Employee(EmployeeID),
    TimesheetYear INTEGER NOT NULL,
    PayPeriod INTEGER NOT NULL,
    DayOfTheWeek INTEGER NOT NULL,
    HoursWorked INTEGER NULL,
    PiecesFinished INTEGER NULL
);

CREATE TABLE Seasons
(
    EmployeeID BIGINT NOT NULL FOREIGN KEY REFERENCES Employee(EmployeeID),
    Season INT NOT NULL,
    SeasonYear INT NOT NULL
);