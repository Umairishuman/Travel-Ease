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
    contact_phone VARCHAR(15) NOT NULL CHECK (contact_phone LIKE '+%[0-9]%' OR contact_phone LIKE '0%[0-9]%'),
    user_status VARCHAR(50) NOT NULL CHECK (user_status IN ('active', 'inactive', 'pending', 'deleted'))
    user_role VARCHAR(50) NOT NULL CHECK (user_role IN ('traveler', 'admin', 'tour_operator', 'service_provider')),
    user_profile_image VARCHAR(255) NULL,
    user_profile_description TEXT NULL,

)


CREATE TABLE travelers (
    reg_no VARCHAR(20) PRIMARY KEY,
    FOREIGN KEY (reg_no) REFERENCES users(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,
    
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    nationality VARCHAR(50) NOT NULL,
    cnic VARCHAR(15) NOT NULL,
    date_of_birth DATE NOT NULL
)

CREATE TABLE admins (
    reg_no VARCHAR(20) PRIMARY KEY,
    FOREIGN KEY (reg_no) REFERENCES users(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,
    
    admin_name VARCHAR(100) NOT NULL,
    last_action_timestamp DATETIME
)

CREATE TABLE tour_operator (
    reg_no VARCHAR(20) PRIMARY KEY,
    FOREIGN KEY (reg_no) REFERENCES users(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,
    
    operator_name VARCHAR(100) NOT NULL,
    business_address VARCHAR(255) NOT NULL,
    website_url VARCHAR(100)
)

CREATE TABLE service_provider (
    reg_no VARCHAR(20) PRIMARY KEY,
    FOREIGN KEY (reg_no) REFERENCES users(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,
    
    provider_name VARCHAR(100) NOT NULL,
    provider_location VARCHAR(100) NOT NULL,
    provider_type VARCHAR(50) NOT NULL CHECK (provider_type IN ('hotel', 'transport', 'guide'))
)

CREATE TABLE location (
    dest_id INT PRIMARY KEY IDENTITY(1,1),
    destination_name VARCHAR(100) NOT NULL,
    region VARCHAR(100) NOT NULL,
    country VARCHAR(100) NOT NULL
)

CREATE TABLE trips (
    trip_id INT PRIMARY KEY IDENTITY(1,1),
    title VARCHAR(100) NOT NULL,
    descirption TEXT NOT NULL,
    image_url VARCHAR(255),
    capacity INT NOT NULL,
    duration INT NOT NULL,
    category VARCHAR(50) NOT NULL CHECK (category IN ('adventure', 'cultural', 'leisure')),
    status VARCHAR(50) NOT NULL CHECK (status IN ('active', 'completed', 'cancelled')),
    price_per_person DECIMAL(10, 2) NOT NULL,
    
    start_loc_id INT NOT NULL,
    FOREIGN KEY (start_loc_id) REFERENCES location(dest_id) ON DELETE CASCADE ON UPDATE CASCADE,
   
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    
    operator_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (operator_id) REFERENCES tour_operator(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,
)

CREATE TABLE bookings (
    booking_id INT PRIMARY KEY IDENTITY(1,1),
    book_date DATETIME NOT NULL,
    booking_status VARCHAR(50) NOT NULL CHECK (booking_status IN ('confirmed', 'pending', 'cancelled')),
    
    traveler_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (traveler_id) REFERENCES travelers(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,
    
    trip_id INT NOT NULL,
    FOREIGN KEY (trip_id) REFERENCES trips(trip_id) ON DELETE CASCADE ON UPDATE CASCADE,
    
    transaction_id INT,
    FOREIGN KEY (transaction_id) REFERENCES transactions(transaction_id) ON DELETE CASCADE ON UPDATE CASCADE,
)

CREATE TABLE transactions (
    transaction_id INT PRIMARY KEY IDENTITY(1,1),
    amount DECIMAL(10, 2) NOT NULL,
    transaction_date DATETIME NOT NULL,
    payment_method VARCHAR(50) NOT NULL CHECK (payment_method IN ('credit_card', 'debit_card', 'paypal', 'bank_transfer')),
    booking_id INT NOT NULL,
    FOREIGN KEY (booking_id) REFERENCES bookings(booking_id) ON DELETE CASCADE ON UPDATE CASCADE,
    status VARCHAR(50) NOT NULL CHECK (status IN ('success', 'failed', 'pending')),
)

CREATE TABLE Preferences (
    traveler_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (traveler_id) REFERENCES travelers(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,
    
    destination_id INT NOT NULL,
    FOREIGN KEY (destination_id) REFERENCES location(dest_id) ON DELETE CASCADE ON UPDATE CASCADE,
    
    PRIMARY KEY (traveler_id, destination_id),
    
    preference_level INT NOT NULL CHECK (preference_level BETWEEN 1 AND 5),
)

CREATE TABLE trip_location (
    trip_id INT NOT NULL,
    FOREIGN KEY (trip_id) REFERENCES trips(trip_id) ON DELETE CASCADE ON UPDATE CASCADE,
    location_id INT NOT NULL,
    FOREIGN KEY (location_id) REFERENCES location(dest_id) ON DELETE CASCADE ON UPDATE CASCADE,
    
    destination_order INT NOT NULL CHECK (destination_order > 0 AND destination_order <= 10),

    PRIMARY KEY (trip_id, location_id, destination_order),
)

CREATE TABLE services (
    service_id INT PRIMARY KEY IDENTITY(1,1),
    service_type VARCHAR(50) NOT NULL CHECK (service_type IN ('hotel', 'transport', 'guide')),
    service_description TEXT NOT NULL,
    price DECIMAL(10, 2) NOT NULL
    
    provider_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (provider_id) REFERENCES service_provider(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,
)

CREATE TABLE trip_services (
    trip_id INT NOT NULL,
    FOREIGN KEY (trip_id) REFERENCES trips(trip_id) ON DELETE CASCADE ON UPDATE CASCADE,
    
    service_id INT NOT NULL,
    FOREIGN KEY (service_id) REFERENCES services(service_id) ON DELETE CASCADE ON UPDATE CASCADE,
    
    PRIMARY KEY (trip_id, service_id)
)

CREATE TABLE digital_passes (
    pass_id INT PRIMARY KEY IDENTITY(1,1),
    date_generated DATETIME NOT NULL,
    valid_till DATETIME NOT NULL,
    document_type VARCHAR(50) NOT NULL CHECK (document_type IN ('e-ticket', 'hotel voucher', 'activity pass', 'transport voucher')),
    booking_id INT NOT NULL,
    FOREIGN KEY (booking_id) REFERENCES bookings(booking_id) ON DELETE CASCADE ON UPDATE CASCADE,
    service_id INT,
    FOREIGN KEY (service_id) REFERENCES services(service_id) ON DELETE CASCADE ON UPDATE CASCADE,
)

CREATE TABLE trip_reviews (
    review_id INT PRIMARY KEY IDENTITY(1, 1),
    
    trip_id INT NOT NULL,
    FOREIGN KEY (trip_id) REFERENCES trips(trip_id) ON DELETE CASCADE ON UPDATE CASCADE,
    
    traveler_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (traveler_id) REFERENCES travelers(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,
    
    rating INT NOT NULL CHECK (rating BETWEEN 1 AND 5),
    description TEXT,
    review_date DATETIME DEFAULT GETDATE(),
    flag_status VARCHAR(50) NOT NULL CHECK (flag_status IN ('clear', 'flagged')) DEFAULT 'clear',
)

CREATE TABLE service_reviews(
    review_id INT PRIMARY KEY IDENTITY(1, 1),
    
    service_id INT NOT NULL,
    FOREIGN KEY (service_id) REFERENCES services(service_id) ON DELETE CASCADE ON UPDATE CASCADE,
    
    traveler_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (traveler_id) REFERENCES travelers(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,
    
    rating INT NOT NULL CHECK (rating BETWEEN 1 AND 5),
    description TEXT,
    review_date DATETIME DEFAULT GETDATE(),
    flag_status VARCHAR(50) NOT NULL CHECK (flag_status IN ('clear', 'flagged')) DEFAULT 'clear',
)

CREATE TABLE user_approval_logs(
    log_id INT PRIMARY KEY IDENTITY(1, 1),

    user_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,

    admin_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (admin_id) REFERENCES admins(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,

    log_time DATETIME DEFAULT GETDATE() NOT NULL,
    action VARCHAR(50) NOT NULL CHECK (action IN ('approved', 'rejected')),

    reason TEXT NULL
)
CREATE TABLE trip_review_logs(
    log_id INT PRIMARY KEY IDENTITY(1, 1),

    review_id INT NOT NULL,
    FOREIGN KEY (review_id) REFERENCES trip_reviews(review_id) ON DELETE CASCADE ON UPDATE CASCADE,

    admin_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (admin_id) REFERENCES admins(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,

    log_time DATETIME DEFAULT GETDATE() NOT NULL,
    action VARCHAR(50) NOT NULL CHECK (action IN ('clear', 'flagged')),

    reason TEXT NULL
)

CREATE TABLE service_review_logs(
    log_id INT PRIMARY KEY IDENTITY(1, 1),

    review_id INT NOT NULL,
    FOREIGN KEY (review_id) REFERENCES service_reviews(review_id) ON DELETE CASCADE ON UPDATE CASCADE,

    admin_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (admin_id) REFERENCES admins(reg_no) ON DELETE CASCADE ON UPDATE CASCADE,

    log_time DATETIME DEFAULT GETDATE() NOT NULL,
    action VARCHAR(50) NOT NULL CHECK (action IN ('clear', 'flagged')),

    reason TEXT NULL
)