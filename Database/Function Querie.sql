use [Database phase 1 backup]

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

-- trips
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'trips';

-- trips_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'trips_data';

-- user_approval_logs
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'user_approval_logs';

-- users
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'users';

-- admins
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'admins';

-- admins_realistic
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'admins_realistic';

-- bookings
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'bookings';

-- bookings_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'bookings_data';

-- digital_passes
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'digital_passes';

-- digital_passes_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'digital_passes_data';

-- guide_languages
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'guide_languages';

-- guide_languages_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'guide_languages_data';

-- guide_services
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'guide_services';

-- guide_services_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'guide_services_data';

-- hotel_services
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'hotel_services';

-- hotel_services_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'hotel_services_data';

-- location
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'location';

-- location_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'location_data';

-- Preferences
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Preferences';

-- preferences_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'preferences_data';

-- service_provider
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'service_provider';

-- service_provider_realistic
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'service_provider_realistic';

-- service_review_logs
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'service_review_logs';

-- service_reviews
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'service_reviews';

-- service_reviews_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'service_reviews_data';

-- services
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'services';

-- services_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'services_data';

-- TestingTable
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'TestingTable';

-- tour_operator
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'tour_operator';

-- tour_operator_realistic
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'tour_operator_realistic';

-- transactions
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'transactions';

-- transactions_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'transactions_data';

-- transport_services
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'transport_services';

-- travelers
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'travelers';

-- travelers_realistic
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'travelers_realistic';

-- trip_location
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'trip_location';

-- trip_location_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'trip_location_data';

-- trip_review_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'trip_review_data';

-- trip_review_logs
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'trip_review_logs';

-- trip_reviews
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'trip_reviews';

-- trip_service_data
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'trip_service_data';

-- trip_services
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'trip_services';

-------------Traveller Login
CREATE PROCEDURE LoginUser
    @Email VARCHAR(100),
    @PasswordHash VARCHAR(255)
AS
BEGIN
    -- Check if user exists and password matches
    SELECT 
        reg_no,
        contact_email,
        user_role,
        user_status,
        user_profile_image,
        user_profile_description,
        last_login
    FROM users
    WHERE contact_email = @Email
      AND password_hash = @PasswordHash;
END
-----------------------
CREATE PROCEDURE SearchTrips
    @Destination VARCHAR(100) = NULL,
    @StartDate DATE = NULL,
    @EndDate DATE = NULL,
    @MinPrice DECIMAL(10,2) = NULL,
    @MaxPrice DECIMAL(10,2) = NULL,
    @Category VARCHAR(50) = NULL,
    @MinGroupSize INT = NULL
AS
BEGIN
    SELECT 
        t.trip_id,
        t.title,
        t.descirption,
        t.price_per_person,
        t.capacity,
        t.start_date,
        t.end_date,
        t.category,
        l.destination_name
    FROM trips t
    JOIN trip_location tl ON t.trip_id = tl.trip_id
    JOIN location l ON tl.location_id = l.dest_id
    WHERE 
        t.status = 'active'
        AND (@Destination IS NULL OR l.destination_name LIKE '%' + @Destination + '%')
        AND (@StartDate IS NULL OR t.start_date >= @StartDate)
        AND (@EndDate IS NULL OR t.end_date <= @EndDate)
        AND (@MinPrice IS NULL OR t.price_per_person >= @MinPrice)
        AND (@MaxPrice IS NULL OR t.price_per_person <= @MaxPrice)
        AND (@Category IS NULL OR t.category = @Category)
        AND (@MinGroupSize IS NULL OR t.capacity >= @MinGroupSize);
END

-----------------------------------
CREATE PROCEDURE GetTravelerDashboard
    @TravelerID VARCHAR(50)
AS
BEGIN
    SELECT 
        b.booking_id,
        b.book_date,
        b.booking_status,
        t.trip_id,
        t.title AS trip_title,
        t.profileTrip_image_url,
        t.start_date,
        t.end_date,
        t.category,
        t.descirption AS cancellation_policy,
        loc.destination_name,
        loc.city,
        loc.country
    FROM bookings b
    INNER JOIN trips t ON b.trip_id = t.trip_id
    LEFT JOIN trip_location tl ON t.trip_id = tl.trip_id
    LEFT JOIN location loc ON tl.location_id = loc.dest_id
    WHERE 
        b.traveler_id = @TravelerID
        AND t.start_date > GETDATE()
        AND t.status = 'active';
END

-----------------------------------
CREATE PROCEDURE GetTravelerDigitalPasses
    @TravelerID VARCHAR(50)
AS
BEGIN
    SELECT 
        dp.pass_id,
        dp.date_generated,
        dp.valid_till,
        dp.document_type,
        dp.file_url,
        dp.booking_id,
        dp.service_id,
        s.service_description AS service_title,
        hs.room_type,
        hs.amenities,
        t.title AS trip_title
    FROM digital_passes dp
    INNER JOIN bookings b ON dp.booking_id = b.booking_id
    LEFT JOIN services s ON dp.service_id = s.service_id
    LEFT JOIN hotel_services hs ON dp.service_id = hs.service_id
    LEFT JOIN trips t ON b.trip_id = t.trip_id
    WHERE b.traveler_id = @TravelerID;
END

----------------------------
CREATE PROCEDURE SubmitTripReview
    @TripID NVARCHAR(50),
    @TravelerID NVARCHAR(50),
    @Rating TINYINT,
    @Description NVARCHAR(MAX)
AS
BEGIN
    -- Check if traveler booked the trip
    IF EXISTS (
        SELECT 1 FROM bookings
        WHERE trip_id = @TripID AND traveler_id = @TravelerID AND booking_status = 'confirmed'
    )
    BEGIN
        INSERT INTO trip_reviews (review_id, trip_id, traveler_id, rating, description, review_date, flag_status)
        VALUES (NEWID(), @TripID, @TravelerID, @Rating, @Description, GETDATE(), 'active');
    END
    ELSE
    BEGIN
        RAISERROR('Traveler has not booked this trip or booking not confirmed.', 16, 1);
    END
END


------------------------------------
CREATE PROCEDURE GetTravelerHistory
    @TravelerID NVARCHAR(50)
AS
BEGIN
    SELECT 
        t.trip_id,
        t.title,
        t.start_date,
        t.end_date,
        b.book_date,
        b.booking_status
    FROM bookings b
    INNER JOIN trips t ON b.trip_id = t.trip_id
    WHERE 
        b.traveler_id = @TravelerID 
        AND b.booking_status IN ('completed', 'attended')  -- adjust if needed
    ORDER BY t.start_date DESC;
END



--------------------------------------
CREATE PROCEDURE CreateTrip
    @TripID NVARCHAR(50),
    @Title NVARCHAR(255),
    @Description TEXT,
    @Capacity INT,
    @Duration INT,
    @Category NVARCHAR(100),
    @Status NVARCHAR(50),
    @PricePerPerson DECIMAL(10, 2),
    @StartLocID NVARCHAR(50),
    @StartDate DATE,
    @EndDate DATE,
    @OperatorID NVARCHAR(50),
    @ProfileImageURL NVARCHAR(500)
AS
BEGIN
    INSERT INTO trips (
        trip_id, title, descirption, capacity, duration,
        category, status, price_per_person, start_loc_id,
        start_date, end_date, operator_id, profileTrip_image_url
    )
    VALUES (
        @TripID, @Title, @Description, @Capacity, @Duration,
        @Category, @Status, @PricePerPerson, @StartLocID,
        @StartDate, @EndDate, @OperatorID, @ProfileImageURL
    );
END

-----------------------------------------
CREATE PROCEDURE UpdateTrip
    @TripID NVARCHAR(50),
    @Title NVARCHAR(255),
    @Description TEXT,
    @Capacity INT,
    @Duration INT,
    @Category NVARCHAR(100),
    @Status NVARCHAR(50),
    @PricePerPerson DECIMAL(10, 2),
    @StartLocID NVARCHAR(50),
    @StartDate DATE,
    @EndDate DATE,
    @ProfileImageURL NVARCHAR(500)
AS
BEGIN
    UPDATE trips
    SET 
        title = @Title,
        descirption = @Description,
        capacity = @Capacity,
        duration = @Duration,
        category = @Category,
        status = @Status,
        price_per_person = @PricePerPerson,
        start_loc_id = @StartLocID,
        start_date = @StartDate,
        end_date = @EndDate,
        profileTrip_image_url = @ProfileImageURL
    WHERE trip_id = @TripID;
END


--------------------------------------------
CREATE PROCEDURE DeleteTrip
    @TripID NVARCHAR(50)
AS
BEGIN
    DELETE FROM trips WHERE trip_id = @TripID;
END

------------------------------------------------
CREATE PROCEDURE ViewAllTripsForOperator
    @OperatorID NVARCHAR(50)
AS
BEGIN
    SELECT 
        trip_id,
        title,
        descirption,
        capacity,
        duration,
        category,
        status,
        price_per_person,
        start_loc_id,
        start_date,
        end_date,
        profileTrip_image_url
    FROM trips
    WHERE operator_id = @OperatorID
    ORDER BY start_date;  -- Optional. Umair sort it by start_date or other criteria if you want
END

------------------------------------
CREATE PROCEDURE EditTripDetails
	@OperatorID NVARCHAR(50),
    @TripID NVARCHAR(50),
    @Title NVARCHAR(255),
    @Description TEXT,
    @Capacity INT,
    @Duration INT,
    @Category NVARCHAR(100),
    @Status NVARCHAR(50),
    @PricePerPerson DECIMAL(10, 2),
    @StartLocID NVARCHAR(50),
    @StartDate DATE,
    @EndDate DATE,
    @ProfileImageURL NVARCHAR(500)
AS
BEGIN
    UPDATE trips
    SET 
        title = @Title,
        descirption = @Description,
        capacity = @Capacity,
        duration = @Duration,
        category = @Category,
        status = @Status,
        price_per_person = @PricePerPerson,
        start_loc_id = @StartLocID,
        start_date = @StartDate,
        end_date = @EndDate,
        profileTrip_image_url = @ProfileImageURL
    WHERE trip_id = @TripID AND operator_id = @OperatorID;  -- Ensure operator can only update their own trips
END
-------------------------------------
CREATE PROCEDURE AssignServiceToBooking
    @BookingID NVARCHAR(50),
    @ServiceID NVARCHAR(50),
    @DocumentType NVARCHAR(50),       -- e.g., 'hotel_voucher', 'activity_pass'
    @FileURL NVARCHAR(255),           -- can be NULL if not yet uploaded
    @ValidDays INT = 7                -- optional, default valid for 7 days
AS
BEGIN
    -- Validate if booking exists
    IF NOT EXISTS (
        SELECT 1 FROM bookings WHERE booking_id = @BookingID
    )
    BEGIN
        RAISERROR('Invalid Booking ID', 16, 1);
        RETURN;
    END

    -- Validate if service exists
    IF NOT EXISTS (
        SELECT 1 FROM services WHERE service_id = @ServiceID
    )
    BEGIN
        RAISERROR('Invalid Service ID', 16, 1);
        RETURN;
    END

    INSERT INTO digital_passes (
        pass_id,
        date_generated,
        valid_till,
        document_type,
        file_url,
        booking_id,
        service_id
    )
    VALUES (
        NEWID(),
        GETDATE(),
        DATEADD(DAY, @ValidDays, GETDATE()),
        @DocumentType,
        @FileURL,
        @BookingID,
        @ServiceID
    );
END
-------------------------------------------
CREATE PROCEDURE GetBookingsByTripOrTraveler
    @TripID NVARCHAR(50) = NULL,
    @TravelerID NVARCHAR(50) = NULL
AS
BEGIN
    SELECT 
        b.booking_id,
        b.book_date,
        b.booking_status,
        b.traveler_id,
        b.trip_id,
        t.title AS trip_title,
        t.start_date,
        t.end_date
    FROM bookings b
    JOIN trips t ON b.trip_id = t.trip_id
    WHERE 
        (@TripID IS NULL OR b.trip_id = @TripID) AND
        (@TravelerID IS NULL OR b.traveler_id = @TravelerID);
END
------------------------------------------------
CREATE PROCEDURE GetUpcomingTrips
    @DaysAhead INT = 3
AS
BEGIN
    SELECT 
        b.booking_id,
        b.traveler_id,
        b.trip_id,
        t.title,
        t.start_date
    FROM bookings b
    JOIN trips t ON b.trip_id = t.trip_id
    WHERE 
        t.start_date BETWEEN GETDATE() AND DATEADD(DAY, @DaysAhead, GETDATE()) AND
        b.booking_status = 'confirmed';
END
-------------------------------------------------
CREATE PROCEDURE CancelBookingWithRefund
    @BookingID NVARCHAR(50),
    @RefundAmount DECIMAL(10,2) = NULL,
    @PerformedBy NVARCHAR(50) = NULL
AS
BEGIN
    -- Update booking status
    UPDATE bookings
    SET booking_status = 'cancelled'
    WHERE booking_id = @BookingID;
END
--------------------------------------------
CREATE PROCEDURE GetPerformanceAnalytics
    @OperatorID NVARCHAR(50)
AS
BEGIN
    SELECT 
        t.trip_id,
        t.title,
        COUNT(b.booking_id) AS total_bookings,
        SUM(CASE 
            WHEN tr.amount IS NOT NULL THEN tr.amount
            ELSE t.price_per_person
        END) AS total_revenue,
        AVG(CAST(r.rating AS FLOAT)) AS avg_rating
    FROM trips t
    LEFT JOIN bookings b ON t.trip_id = b.trip_id
    LEFT JOIN transactions tr ON b.booking_id = tr.booking_id 
    LEFT JOIN trip_reviews r ON t.trip_id = r.trip_id
    WHERE t.operator_id = @OperatorID
    GROUP BY t.trip_id, t.title, t.price_per_person;
END
-----------------------------------------
CREATE PROCEDURE UpdateUserApprovalStatus
    @RegNo NVARCHAR(50),
    @NewStatus NVARCHAR(20)  -- 'approved' or 'rejected'
AS
BEGIN
    UPDATE users
    SET user_status = @NewStatus
    WHERE reg_no = @RegNo;
END
------------------------------------------
CREATE PROCEDURE GetTourCategories
AS
BEGIN
    SELECT DISTINCT category
    FROM trips
    WHERE category IS NOT NULL;
END
---------------------------------------------
CREATE FUNCTION fn_admin_total_revenue()
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @total_revenue DECIMAL(18, 2)

    SELECT @total_revenue = SUM(CAST(amount AS DECIMAL(18, 2)))
    FROM transactions
    WHERE status IS NULL OR status NOT IN ('Refunded', 'Cancelled') -- adjust as needed

    RETURN ISNULL(@total_revenue, 0)
END
---------------------------------------------
CREATE FUNCTION fn_admin_booking_trends()
RETURNS TABLE
AS
RETURN
(
    SELECT 
        FORMAT(book_date, 'yyyy-MM') AS booking_month,
        COUNT(*) AS total_bookings
    FROM bookings
    GROUP BY FORMAT(book_date, 'yyyy-MM')
);
---------------------------------------------
CREATE FUNCTION fn_admin_user_operator_count()
RETURNS TABLE
AS
RETURN
(
    SELECT
        (SELECT COUNT(*) FROM users WHERE user_status = 'Approved') AS approved_users
);

------------------------------------------------
CREATE FUNCTION fn_admin_flagged_reviews()
RETURNS TABLE
AS
RETURN
(
    SELECT 'Trip Review' AS review_type, review_id, trip_id AS related_id, traveler_id AS user_id, rating, description, review_date
    FROM trip_reviews
    WHERE flag_status = 'Flagged'

    UNION ALL

    SELECT 'Service Review', Review_id, Service_id, User_id, Rating, Description, Review_date
    FROM service_reviews
    WHERE Flag_status = 'Flagged'
);
----------------------------------------------
CREATE PROCEDURE sp_service_accept_reject_assignment
    @service_id NVARCHAR(50),
    @booking_id NVARCHAR(50),
    @response NVARCHAR(10)  -- 'Accept' or 'Reject'
AS
BEGIN
    UPDATE digital_passes
    SET document_type = @response -- assuming you're using this column to store status
    WHERE service_id = @service_id AND booking_id = @booking_id;
END
--------------------------------------------------
CREATE FUNCTION fn_provider_list_services
(
    @provider_id NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT s.service_id, s.service_type, s.service_description, h.room_type, h.amenities
    FROM services s
    LEFT JOIN hotel_services h ON s.service_id = h.service_id
    WHERE s.provider_id = @provider_id
);
--------------------------------------------------
CREATE PROCEDURE sp_provider_confirm_booking
    @service_id NVARCHAR(50),
    @booking_id NVARCHAR(50),
    @confirmation_status NVARCHAR(20) -- e.g., 'Confirmed', 'Declined'
AS
BEGIN
    -- Update digital pass or a custom service_booking_status table
    UPDATE digital_passes
    SET document_type = @confirmation_status
    WHERE service_id = @service_id AND booking_id = @booking_id;
END
---------------to view bookings------------
CREATE FUNCTION fn_provider_view_bookings
(
    @service_id NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT dp.booking_id, dp.date_generated, dp.valid_till, b.traveler_id, b.book_date
    FROM digital_passes dp
    INNER JOIN bookings b ON dp.booking_id = b.booking_id
    WHERE dp.service_id = @service_id
);
--------------------------------------------
CREATE FUNCTION fn_provider_occupancy_summary
(
    @service_id NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        dp.service_id,
        COUNT(DISTINCT dp.booking_id) AS total_bookings,
        MIN(dp.date_generated) AS first_booking,
        MAX(dp.valid_till) AS last_booking
    FROM digital_passes dp
    WHERE dp.service_id = @service_id
    GROUP BY dp.service_id
);

---------------------------------------------

CREATE FUNCTION fn_provider_feedback_summary
(
    @service_id NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        AVG(CAST(r.rating AS FLOAT)) AS avg_rating,
        COUNT(*) AS total_reviews
    FROM service_reviews r
    WHERE r.service_id = @service_id AND r.flag_status != 'Flagged'
);
--------------------------------------------
CREATE FUNCTION fn_provider_revenue_summary
(
    @service_id NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        SUM(CAST(t.amount AS DECIMAL(18, 2))) AS total_revenue,
        COUNT(*) AS transactions_count
    FROM transactions t
    INNER JOIN digital_passes dp ON t.booking_id = dp.booking_id
    WHERE dp.service_id = @service_id
);







