CREATE TABLE [dbo].[Device] (
    [DeviceId]    INT           IDENTITY (1, 1) NOT NULL,
    [SerialNo]    NVARCHAR (50) NOT NULL,
    [ModelId]     INT           NOT NULL,
    [DateCreated] DATETIME2 (0) CONSTRAINT [DF_Device___DateCreated] DEFAULT (getdate()) NOT NULL,
    [DateUpdated] DATETIME2 (0) NULL,
    [HardwareSerial] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED ([DeviceId] ASC),
    CONSTRAINT [Device_Model_FK] FOREIGN KEY ([ModelId]) REFERENCES [dbo].[Model] ([ModelId])
);


GO
CREATE TRIGGER [dbo].[TR_device_InsertUpdateDelete] ON [dbo].[Device]
		   AFTER INSERT, UPDATE, DELETE
		AS
		BEGIN
			SET NOCOUNT ON;
			IF TRIGGER_NESTLEVEL() > 3 RETURN;

			UPDATE [dbo].[Device] SET [dbo].[Device].[DateUpdated] = CONVERT (DATETIMEOFFSET(3), SYSUTCDATETIME())
			FROM INSERTED
			WHERE INSERTED.[DeviceId] = [dbo].[Device].[DeviceId]
		END