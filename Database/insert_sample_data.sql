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

INSERT INTO hotel_services (service_id, room_type, amenities)
SELECT 
    service_id,
    CASE 
        WHEN ABS(CHECKSUM(NEWID())) % 6 = 0 THEN 'single'
        WHEN ABS(CHECKSUM(NEWID())) % 6 = 1 THEN 'double'
        WHEN ABS(CHECKSUM(NEWID())) % 6 = 2 THEN 'suite'
        WHEN ABS(CHECKSUM(NEWID())) % 6 = 3 THEN 'deluxe'
        WHEN ABS(CHECKSUM(NEWID())) % 6 = 4 THEN 'family'
        ELSE 'studio'
    END AS room_type,
    NULL AS amenities
FROM 
    services
WHERE 
    service_type = 'hotel';

insert into hotel_services
select * from hotel_services_data

INSERT INTO transport_services (service_id, vehicle_type, ac_available)
SELECT 
    service_id,
    CASE 
        WHEN ABS(CHECKSUM(NEWID())) % 6 = 0 THEN 'bus'
        WHEN ABS(CHECKSUM(NEWID())) % 6 = 1 THEN 'car'
        WHEN ABS(CHECKSUM(NEWID())) % 6 = 2 THEN 'bike'
        WHEN ABS(CHECKSUM(NEWID())) % 6 = 3 THEN 'van'
        WHEN ABS(CHECKSUM(NEWID())) % 6 = 4 THEN 'truck'
        ELSE 'suv'
    END AS vehicle_type,
    CASE 
        WHEN ABS(CHECKSUM(NEWID())) % 2 = 0 THEN 1
        ELSE 0
    END AS ac_available
FROM 
    services
WHERE 
    service_type = 'transport';

select * from transport_services

INSERT INTO guide_services (service_id, years_of_experience, certification_status)
SELECT 
    service_id,
    ABS(CHECKSUM(NEWID())) % 21 AS years_of_experience, -- Random experience from 0 to 20 years
    CASE 
        WHEN ABS(CHECKSUM(NEWID())) % 2 = 0 THEN 1
        ELSE 0
    END AS certification_status -- Random certification status (1 or 0)
FROM 
    services
WHERE 
    service_type = 'guide';

insert into guide_services
select * from guide_services_data

INSERT INTO service_reviews (review_id, user_id, service_id, rating, description, review_date, flag_status, isEdited)
SELECT * FROM service_reviews_data

INSERT INTO trip_services (trip_id, service_id) 
SELECT trip_id, service_id FROM trip_service_data

INSERT INTO digital_passes
SELECT * FROM digital_passes_data

insert into guide_languages
select * from guide_languages_data

INSERT INTO service_review_logs (log_id, review_id, admin_id, log_time, action, reason)
SELECT 
    'TRL-' + RIGHT('000000' + CAST(ROW_NUMBER() OVER (ORDER BY review_id) AS VARCHAR), 6) AS log_id, -- Generate sequential log_id
    review_id,
    'AD-' + RIGHT('000000' + CAST(ABS(CHECKSUM(NEWID())) % 50 + 1 AS VARCHAR), 6) AS admin_id, -- Random admin from AD-000001 to AD-000050
    GETDATE() AS log_time, -- Current date and time
    'flagged' AS action, -- Set action as flagged
    NULL AS reason -- Reason is null
FROM 
    service_reviews
WHERE 
    flag_status = 'flagged';


