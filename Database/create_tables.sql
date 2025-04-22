CREATE TABLE users (
    reg_no VARCHAR(20) PRIMARY KEY CHECK (
            reg_no LIKE 'TR-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
            reg_no LIKE 'OP-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
            reg_no LIKE 'SP-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
            reg_no LIKE 'AD-[0-9][0-9][0-9][0-9][0-9][0-9]'
        ),
    
    password_hash VARCHAR(255) NOT NULL,
    created_date DATETIME DEFAULT GETDATE() NOT NULL,
    last_login DATETIME,
    contact_email VARCHAR(100) NOT NULL UNIQUE CHECK (contact_email LIKE '%_@__%.__%'),
    contact_phone VARCHAR(15) NOT NULL CHECK (
            contact_phone LIKE '+%[0-9]%' OR 
            contact_phone LIKE '0%[0-9]%' OR 
            contact_phone LIKE '92%[0-9]%' OR
            contact_phone LIKE '3%[0-9]%' 
        ),
    user_status VARCHAR(50) NOT NULL CHECK (user_status IN ('rejected', 'accepted', 'p\ending')),
    user_role VARCHAR(50) NOT NULL CHECK (user_role IN ('traveler', 'admin', 'tour_operator', 'service_provider')),
    user_profile_image VARCHAR(255) NULL,
    user_profile_description TEXT NULL,

)

select * from users



select * from users

CREATE TABLE travelers (
    reg_no VARCHAR(20) PRIMARY KEY,
    FOREIGN KEY (reg_no) REFERENCES users(reg_no) ,
    
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    nationality VARCHAR(50) NOT NULL,
    cnic VARCHAR(15) NOT NULL CHECK (cnic LIKE '%[0-9]%'),
    date_of_birth DATE NOT NULL
)

CREATE TABLE admins (
    reg_no VARCHAR(20) PRIMARY KEY,
    FOREIGN KEY (reg_no) REFERENCES users(reg_no) ,
    
    admin_name VARCHAR(100) NOT NULL,
    last_action_timestamp DATETIME
)

CREATE TABLE tour_operator (
    reg_no VARCHAR(20) PRIMARY KEY,
    FOREIGN KEY (reg_no) REFERENCES users(reg_no) ,
    
    operator_name VARCHAR(100) NOT NULL,
    business_address VARCHAR(255) NOT NULL,
    website_url VARCHAR(100)
)

CREATE TABLE service_provider (
    reg_no VARCHAR(20) PRIMARY KEY,
    FOREIGN KEY (reg_no) REFERENCES users(reg_no) ,
    
    provider_name VARCHAR(100) NOT NULL,
    provider_location VARCHAR(100) NOT NULL,
)

CREATE TABLE location (
    dest_id VARCHAR(20) PRIMARY KEY CHECK (
        dest_id LIKE 'ASI-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
        dest_id LIKE 'AFR-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
        dest_id LIKE 'EUR-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
        dest_id LIKE 'NAM-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
        dest_id LIKE 'SAM-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
        dest_id LIKE 'OCE-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
        dest_id LIKE 'ANT-[0-9][0-9][0-9][0-9][0-9][0-9]'
        ),
    destination_name VARCHAR(100) NOT NULL,
    city VARCHAR(100) NOT NULL,
    region VARCHAR(100) NOT NULL CHECK (
        region IN 
        ('Asia', 'Africa', 'Europe', 'North America', 'South America', 'Oceania', 'Antarctica')
        ),
    country VARCHAR(100) NOT NULL
)
CREATE TABLE trips (
    trip_id VARCHAR(20) PRIMARY KEY CHECK (
        trip_id LIKE 'TRIP-[0-9][0-9][0-9][0-9][0-9][0-9]'
    ),
    title VARCHAR(100) NOT NULL,
    descirption TEXT NOT NULL,
    capacity INT NOT NULL,
    duration INT NOT NULL,
    category VARCHAR(50) NOT NULL CHECK (category IN ('adventure', 'cultural', 'leisure', 'wildlife', 'historical', 'beach', 'mountain', 'cruise')),   
    status VARCHAR(50) NOT NULL CHECK (status IN ('active', 'completed', 'cancelled')),
    price_per_person DECIMAL(10, 2) NOT NULL,
    
    start_loc_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (start_loc_id) REFERENCES location(dest_id) ,
   
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    
    operator_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (operator_id) REFERENCES tour_operator(reg_no) ,

    profileTrip_image_url VARCHAR(255)
)

CREATE TABLE bookings (
    booking_id VARCHAR(20) PRIMARY KEY CHECK (
        booking_id LIKE 'BOOK-[0-9][0-9][0-9][0-9][0-9][0-9]'
    ),
    book_date DATETIME NOT NULL,
    booking_status VARCHAR(50) NOT NULL CHECK (booking_status IN ('confirmed', 'pending', 'cancelled', 'abandoned')),
    
    traveler_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (traveler_id) REFERENCES travelers(reg_no),
    
    trip_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (trip_id) REFERENCES trips(trip_id)

)
CREATE TABLE transactions (
    transaction_id VARCHAR(20) PRIMARY KEY CHECK (
        transaction_id LIKE 'TXN-[0-9][0-9][0-9][0-9][0-9][0-9]'
    ),
    amount DECIMAL(10, 2) NOT NULL,
    transaction_date DATETIME NOT NULL,
    payment_method VARCHAR(50) NOT NULL CHECK (payment_method IN ('credit_card', 'debit_card', 'paypal', 'bank_transfer')),
    booking_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (booking_id) REFERENCES bookings(booking_id),
    status VARCHAR(50) NOT NULL CHECK (status IN ('success', 'failed', 'pending')),
    sending_account_number VARCHAR(50) NOT NULL
)

CREATE TABLE Preferences (
    traveler_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (traveler_id) REFERENCES travelers(reg_no),
    
    destination_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (destination_id) REFERENCES location(dest_id),
    
    PRIMARY KEY (traveler_id, destination_id),
    
    preference_level INT NOT NULL CHECK (preference_level BETWEEN 1 AND 5)
)

CREATE TABLE trip_location (
    trip_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (trip_id) REFERENCES trips(trip_id) ,
    location_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (location_id) REFERENCES location(dest_id) ,
    
    destination_order INT NOT NULL CHECK (destination_order > 0 AND destination_order <= 10),

    PRIMARY KEY (trip_id, location_id, destination_order)
)

CREATE TABLE trip_reviews (
    review_id VARCHAR(20) PRIMARY KEY CHECK (
        review_id LIKE 'TRVW-[0-9][0-9][0-9][0-9][0-9][0-9]'
    ),
    
    trip_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (trip_id) REFERENCES trips(trip_id),
    
    traveler_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (traveler_id) REFERENCES travelers(reg_no),
    
    rating INT NOT NULL CHECK (rating BETWEEN 1 AND 5),
    description TEXT,
    review_date DATETIME DEFAULT GETDATE(),
    flag_status VARCHAR(50) NOT NULL CHECK (flag_status IN ('clear', 'flagged')) DEFAULT 'clear'
)

CREATE TABLE user_approval_logs(
    log_id VARCHAR(20) PRIMARY KEY CHECK (log_id LIKE 'UAL-[0-9][0-9][0-9][0-9][0-9][0-9]'),

    user_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(reg_no),

    admin_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (admin_id) REFERENCES admins(reg_no),

    log_time DATETIME DEFAULT GETDATE() NOT NULL,
    action VARCHAR(50) NOT NULL CHECK (action IN ('approved', 'rejected')),

    reason TEXT NULL
)


CREATE TABLE trip_review_logs(
    log_id VARCHAR(20) PRIMARY KEY CHECK (log_id LIKE 'TRL-[0-9][0-9][0-9][0-9][0-9][0-9]'),

    review_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (review_id) REFERENCES trip_reviews(review_id),

    admin_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (admin_id) REFERENCES admins(reg_no),

    log_time DATETIME DEFAULT GETDATE() NOT NULL,
    action VARCHAR(50) NOT NULL CHECK (action IN ('clear', 'flagged')),

    reason TEXT NULL
)






CREATE TABLE services (
    service_id VARCHAR(20) PRIMARY KEY CHECK (
        service_id LIKE 'SRV-[0-9][0-9][0-9][0-9][0-9][0-9]'
    ),
    service_type VARCHAR(50) NOT NULL CHECK (service_type IN ('hotel', 'transport', 'guide', 'activity', 'other')),
    
    service_description TEXT NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    
    provider_id VARCHAR(20) NOT NULL,
    -- people that the service can handle
    capacity INT NOT NULL CHECK (capacity > 0),

    FOREIGN KEY (provider_id) REFERENCES service_provider(reg_no)
)

CREATE TABLE hotel_services (
    service_id VARCHAR(20) PRIMARY KEY,
    FOREIGN KEY (service_id) REFERENCES services(service_id),

    room_type VARCHAR(255) NOT NULL CHECK (room_type IN ('single', 'double', 'suite', 'deluxe', 'family', 'studio')),
    amenities TEXT
);

CREATE TABLE transport_services (
    service_id VARCHAR(20) PRIMARY KEY NOT NULL,
        FOREIGN KEY (service_id) REFERENCES services(service_id),

        vehicle_type VARCHAR(50) NOT NULL CHECK (vehicle_type IN ('bus', 'car', 'bike', 'van', 'truck', 'suv')),
        seating_capacity INT NOT NULL,
        ac_available BIT ,
        route_description TEXT 
);

CREATE TABLE guide_services (
    service_id VARCHAR(20) PRIMARY KEY,
    FOREIGN KEY (service_id) REFERENCES services(service_id),

    guide_name VARCHAR(100) NOT NULL,
    years_of_experience INT,
    certification_status BIT
);
CREATE TABLE guide_languages (
    service_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (service_id) REFERENCES services(service_id),

    language VARCHAR(50) NOT NULL,
    PRIMARY KEY (service_id, language)
)



CREATE TABLE trip_services (
    trip_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (trip_id) REFERENCES trips(trip_id),
    
    service_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (service_id) REFERENCES services(service_id) ,
    
    PRIMARY KEY (trip_id, service_id)
)

CREATE TABLE digital_passes (
    pass_id VARCHAR(20) PRIMARY KEY CHECK (
        pass_id LIKE 'ETK-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
        pass_id LIKE 'HTL-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
        pass_id LIKE 'ACT-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
    date_generated DATETIME NOT NULL,
    valid_till DATETIME NOT NULL,
    document_type VARCHAR(50) NOT NULL CHECK (document_type IN ('e-ticket', 'hotel voucher', 'activity pass')),
    booking_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (booking_id) REFERENCES bookings(booking_id),
    service_id VARCHAR(20),
    FOREIGN KEY (service_id) REFERENCES services(service_id)
)


CREATE TABLE service_reviews(
    review_id VARCHAR(20) PRIMARY KEY CHECK (
        review_id LIKE 'SRVW-[0-9][0-9][0-9][0-9][0-9][0-9]'
    ),
    
    service_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (service_id) REFERENCES services(service_id),
    
    traveler_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (traveler_id) REFERENCES travelers(reg_no),
    
    rating INT NOT NULL CHECK (rating BETWEEN 1 AND 5),
    description TEXT,
    review_date DATETIME DEFAULT GETDATE(),
    flag_status VARCHAR(50) NOT NULL CHECK (flag_status IN ('clear', 'flagged')) DEFAULT 'clear',
)


CREATE TABLE service_review_logs(
    log_id VARCHAR(20) PRIMARY KEY CHECK (log_id LIKE 'TRL-[0-9][0-9][0-9][0-9][0-9][0-9]'),


    review_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (review_id) REFERENCES service_reviews(review_id),

    admin_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (admin_id) REFERENCES admins(reg_no),

    log_time DATETIME DEFAULT GETDATE() NOT NULL,
    action VARCHAR(50) NOT NULL CHECK (action IN ('clear', 'flagged')),

    reason TEXT NULL
)