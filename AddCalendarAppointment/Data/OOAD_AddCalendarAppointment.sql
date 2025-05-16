use OOAD_AddCalendarAppointment

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(200) NOT NULL,
    Location NVARCHAR(200),
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    IsGroup BIT DEFAULT 0,
    CreatedBy INT NOT NULL,
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
);


CREATE TABLE AppointmentParticipants (
    AppointmentID INT NOT NULL,
    UserID INT NOT NULL,
    PRIMARY KEY (AppointmentID, UserID),
    FOREIGN KEY (AppointmentID) REFERENCES Appointments(AppointmentID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);


CREATE TABLE Reminders (
    ReminderID INT PRIMARY KEY IDENTITY(1,1),
    AppointmentID INT NOT NULL,
    Message NVARCHAR(250),
    ReminderTime DATETIME NOT NULL,
    FOREIGN KEY (AppointmentID) REFERENCES Appointments(AppointmentID)
);


