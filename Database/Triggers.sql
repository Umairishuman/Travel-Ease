CREATE TRIGGER tr_service_review_status_change
ON service_reviews
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Only proceed if flag_status was actually changed
    IF UPDATE(flag_status)
    BEGIN
        DECLARE @next_log_id VARCHAR(20);
        
        -- Generate the next log ID (TRL-000001 format)
        DECLARE @max_id INT;
        SELECT @max_id = ISNULL(MAX(CAST(SUBSTRING(log_id, 5, 6) AS INT)), 0) 
        FROM service_review_logs;
        
        SET @next_log_id = 'TRL-' + RIGHT('000000' + CAST(@max_id + 1 AS VARCHAR(6)), 6);
        
        -- Insert records for all updated rows where flag_status changed
        INSERT INTO service_review_logs (
            log_id,
            review_id,
            admin_id,
            log_time,
            action,
            reason
        )
        SELECT 
            @next_log_id,
            i.review_id,
            -- You'll need to replace this with the actual admin who made the change
            -- This could come from session context or application logic
            'ADM-000001', -- Placeholder admin ID - adjust as needed
            GETDATE(),
            i.flag_status,
            'Status changed by system' -- Default reason, can be modified
        FROM 
            inserted i
            JOIN deleted d ON i.review_id = d.review_id
        WHERE 
            i.flag_status <> d.flag_status;
    END
END;


--------------------------------------------------------------------

CREATE TRIGGER tr_user_status_change
ON users
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Only proceed if user_status was actually changed
    IF UPDATE(user_status)
    BEGIN
        -- Create a temporary table to hold the new log IDs
        DECLARE @id_table TABLE (
            row_num INT IDENTITY(1,1),
            reg_no VARCHAR(20),
            new_status VARCHAR(50)
        );
        
        -- Insert all changed records into the temp table
        INSERT INTO @id_table (reg_no, new_status)
        SELECT 
            i.reg_no,
            i.user_status
        FROM 
            inserted i
            JOIN deleted d ON i.reg_no = d.reg_no
        WHERE 
            i.user_status <> d.user_status;
        
        -- Get the next available base ID
        DECLARE @base_id INT;
        SELECT @base_id = ISNULL(MAX(CAST(SUBSTRING(log_id, 5, 6) AS INT)), 0) 
        FROM user_approval_logs;
        
        -- Insert all records with properly sequenced IDs
        INSERT INTO user_approval_logs (
            log_id,
            user_id,
            admin_id,
            log_time,
            action,
            reason
        )
        SELECT 
            'UAL-' + RIGHT('000000' + CAST(@base_id + row_num AS VARCHAR(6)), 6),
            reg_no,
            'AD-000001', -- Placeholder admin ID - adjust as needed
            GETDATE(),
            new_status,
            CASE 
                WHEN new_status = 'rejected' THEN 'User registration rejected'
                WHEN new_status = 'accepted' THEN 'User registration approved'
                WHEN new_status = 'pending' THEN 'User status reset to pending'
                ELSE 'Status changed by system'
            END
        FROM 
            @id_table;
    END
END;


--------------------------------------------------------------------------------------

CREATE TRIGGER tr_trip_review_status_change
ON trip_reviews
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Only proceed if flag_status was actually changed
    IF UPDATE(flag_status)
    BEGIN
        -- Create a temporary table to hold the changes with sequential IDs
        DECLARE @changes TABLE (
            row_num INT IDENTITY(1,1),
            review_id VARCHAR(20),
            new_status VARCHAR(50)
        );
        
        -- Insert all changed records into the temp table
        INSERT INTO @changes (review_id, new_status)
        SELECT 
            i.review_id,
            i.flag_status
        FROM 
            inserted i
            JOIN deleted d ON i.review_id = d.review_id
        WHERE 
            i.flag_status <> d.flag_status;
        
        -- Get the next available base ID
        DECLARE @base_id INT;
        SELECT @base_id = ISNULL(MAX(CAST(SUBSTRING(log_id, 5, 6) AS INT)), 0) 
        FROM trip_review_logs;
        
        -- Insert all records with properly sequenced IDs
        INSERT INTO trip_review_logs (
            log_id,
            review_id,
            admin_id,
            log_time,
            action,
            reason
        )
        SELECT 
            'TRL-' + RIGHT('000000' + CAST(@base_id + row_num AS VARCHAR(6)), 6),
            review_id,
            -- Replace with actual admin ID from your application context
            'AD-000001', -- Placeholder admin ID
            GETDATE(),
            new_status,
            CASE 
                WHEN new_status = 'flagged' THEN 'Review flagged by system'
                WHEN new_status = 'clear' THEN 'Review cleared by admin'
                ELSE 'Status changed by system'
            END
        FROM 
            @changes;
    END
END;