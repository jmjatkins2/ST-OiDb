CREATE TABLE [dbo].[Calibration] (
    [CalibrationId] INT           IDENTITY (1, 1) NOT NULL,
    [DeviceId]      INT           NOT NULL,
    [LowFreq]       FLOAT (53)    NOT NULL,
    [HighFreq]      FLOAT (53)    NOT NULL,
    [Tone]          FLOAT (53)    NOT NULL,
    [RefLevel]      FLOAT (53)    NOT NULL,
    [DateCreated]   DATETIME2 (0) CONSTRAINT [DF_Calibration___DateCreated] DEFAULT (getdate()) NOT NULL,
    [RefDevice] NVARCHAR(50) NULL , 
    [CalType] INT NULL  , 
    [Operator] NVARCHAR(50) NULL , 
    [RefSerial] NVARCHAR(50) NULL , 
    CONSTRAINT [PK_calibration] PRIMARY KEY CLUSTERED ([CalibrationId] ASC),
    CONSTRAINT [FK_Calibration_Device] FOREIGN KEY ([DeviceId]) REFERENCES [dbo].[Device] ([DeviceId])
);

