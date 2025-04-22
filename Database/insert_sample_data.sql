insert into travelers
select * from travelers_realistic

insert into admins
select * from admins_realistic

insert into tour_operator
select * from tour_operator_realistic

insert into service_provider
select reg_no, provider_name, provider_location from service_provider_realistic

insert into location 
select * from location_data


insert into trips
select * from trips_data

insert into bookings 
select * from bookings_data

insert into transactions    
select * from transactions_data

insert into preferences
select * from preferences_data

insert into trip_location
select * from trip_location_data

insert into trip_reviews
select * from trip_review_data

INSERT INTO user_approval_logs (log_id, user_id, admin_id, log_time, action, reason)
SELECT
    'UAL-' + RIGHT('000000' + CAST(ABS(CHECKSUM(NEWID())) % 1000000 AS VARCHAR), 6) AS log_id, -- Generate random log_id
    users.reg_no AS user_id,
    'AD-' + RIGHT('000000' + CAST((ABS(CHECKSUM(NEWID())) % 50 + 1) AS VARCHAR), 6) AS admin_id, -- Random admin_id within range
    DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, GETDATE()) AS log_time, -- Random log_time in the past year
    users.user_status AS action, -- Use user_status for the action
    NULL AS reason -- Set reason to NULL
FROM 
    users
WHERE 
    users.reg_no IN (
        SELECT reg_no FROM travelers
        UNION
        SELECT reg_no FROM tour_operator
        UNION
        SELECT reg_no FROM service_provider
    )
    AND users.user_status != 'pending' -- Skip users with 'pending' status
    AND EXISTS (
        SELECT 1 FROM admins WHERE admins.reg_no BETWEEN 'AD-000001' AND 'AD-000050'
    );


	INSERT INTO trip_review_logs (log_id, review_id, admin_id, log_time, action, reason)
SELECT
    'TRL-' + RIGHT('000000' + CAST(ROW_NUMBER() OVER (ORDER BY NEWID()) AS VARCHAR), 6) AS log_id, -- Sequential log_id
    'TRVW-' + RIGHT('000000' + CAST((ABS(CHECKSUM(NEWID())) % 50 + 1) AS VARCHAR), 6) AS review_id, -- Random review_id
    'AD-' + RIGHT('000000' + CAST((ABS(CHECKSUM(NEWID())) % 50 + 1) AS VARCHAR), 6) AS admin_id, -- Random admin_id within range
    DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 365, GETDATE()) AS log_time, -- Random log_time in the past year
    CASE WHEN ABS(CHECKSUM(NEWID())) % 2 = 0 THEN 'clear' ELSE 'flagged' END AS action, -- Random action
    NULL AS reason -- Set reason to NULL
FROM 
    (SELECT TOP 50 ROW_NUMBER() OVER (ORDER BY NEWID()) AS seq FROM sys.objects) AS temp; -- Generate 50 rows

	select * from trip_review_logs


insert into services
select * from services_data
