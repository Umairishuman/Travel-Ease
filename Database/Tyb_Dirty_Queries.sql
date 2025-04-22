CREATE TABLE trip_services (
	trip_id VARCHAR(20),
	FOREIGN KEY (trip_id) REFERENCES trips(trip_id),
	service_id VARCHAR(20),
	FOREIGN KEY (service_id) REFERENCES services(service_id),
	PRIMARY KEY (trip_id, service_id)
)
SELECT * FROM trip_services
SELECT * FROM services

-- IMPORT CSV FLAT FILE INTO trip_services_data THEN
INSERT INTO trip_services (trip_id, service_id) 
SELECT trip_id, service_id FROM trip_service_data

DROP TABLE trip_service_data

CREATE TABLE service_reviews (
	review_id VARCHAR(20) PRIMARY KEY CHECK (
            review_id LIKE 'SRVW-[0-9][0-9][0-9][0-9][0-9][0-9]'
    ),
	user_id VARCHAR(20),
	FOREIGN KEY (user_id) REFERENCES travelers(reg_no),
	service_id VARCHAR(20),
	FOREIGN KEY (service_id) REFERENCES services(service_id),
	rating INT CHECK (rating BETWEEN 1 AND 5) NOT NULL,
	description TEXT,
	review_date DATE NOT NULL,
	flag_status VARCHAR(20) CHECK (flag_status IN ('clear', 'flagged')) NOT NULL,
	isEdited BIT NOT NULL,
)

SELECT * FROM service_reviews

INSERT INTO service_reviews (review_id, user_id, service_id, rating, description, review_date, flag_status, isEdited)
SELECT * FROM service_reviews_data

SELECT * FROM bookings

CREATE TABLE digital_passes (
    pass_id VARCHAR(20) PRIMARY KEY CHECK (
        pass_id LIKE 'ETK-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
        pass_id LIKE 'HTL-[0-9][0-9][0-9][0-9][0-9][0-9]' OR
        pass_id LIKE 'ACT-[0-9][0-9][0-9][0-9][0-9][0-9]'
	),
    date_generated DATETIME NOT NULL,
    valid_till DATETIME NOT NULL,
    document_type VARCHAR(20) NOT NULL CHECK (document_type IN ('e-ticket', 'hotel voucher', 'activity pass')),
    file_url VARCHAR(50),
	booking_id VARCHAR(20) NOT NULL,
    FOREIGN KEY (booking_id) REFERENCES bookings(booking_id),
    service_id VARCHAR(20),
    FOREIGN KEY (service_id) REFERENCES services(service_id)
)
DROP TABLE digital_passes
ALTER TABLE digital_passes
ALTER COLUMN file_url VARCHAR(50)

SELECT * FROM digital_passes
SELECT * FROM digital_passes_data

INSERT INTO digital_passes
SELECT * FROM digital_passes_data