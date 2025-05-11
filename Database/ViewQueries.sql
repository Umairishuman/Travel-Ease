use [Database phase 1 backup]

SELECT 
    t.name AS table_name,
    c.name AS column_name,
    ty.name AS data_type
FROM 
    sys.tables AS t
INNER JOIN 
    sys.columns AS c ON t.object_id = c.object_id
INNER JOIN 
    sys.types AS ty ON c.user_type_id = ty.user_type_id
ORDER BY 
    t.name, c.column_id;


CREATE VIEW trip_booking_revenue_report AS
SELECT
    t.trip_id,
    t.title AS trip_title,
    t.category AS trip_category,  -- Category of the trip (Adventure, Cultural, Leisure)
    t.capacity AS trip_capacity,  -- Solo or Group capacity
    t.duration AS trip_duration,  -- Duration of the trip
    COUNT(b.booking_id) AS total_bookings,  -- Total number of confirmed bookings
    SUM(t.price_per_person) * COUNT(b.booking_id) AS total_revenue,  -- Total revenue based on price per person
    AVG(t.price_per_person) AS average_booking_value,  -- Average revenue per booking (price per person)
    (SUM(CASE WHEN b.booking_status = 'Canceled' THEN 1 ELSE 0 END) / COUNT(b.booking_id)) * 100 AS cancellation_rate,  -- Cancellation rate
    MONTH(b.book_date) AS booking_month,  -- Month of the booking
    DAY(b.book_date) AS booking_day  -- Day of the booking
FROM
    trips t
JOIN
    bookings b ON t.trip_id = b.trip_id
WHERE
    b.booking_status = 'Confirmed'
GROUP BY
    t.trip_id, t.title, t.category, t.capacity, t.duration, MONTH(b.book_date), DAY(b.book_date);

select * from trip_booking_revenue_report
------------------------------------------------------


CREATE VIEW traveler_age_nationality_distribution AS
SELECT 
    travelers.nationality, 
    floor(DATEDIFF(YEAR, travelers.date_of_birth,GETDATE()) / 365) AS age,
    COUNT(*) AS traveler_count
FROM travelers
GROUP BY travelers.nationality, FLOOR(DATEDIFF(YEAR,travelers.date_of_birth,GETDATE()) / 365)


drop view traveler_age_nationality_distribution
select * from traveler_age_nationality_distribution


-- 2. Create View for Preferred Trip Types (Most booked categories)
CREATE VIEW preferred_trip_types AS
SELECT
    trips.category AS trip_type,
    COUNT(bookings.booking_id) AS total_bookings
FROM bookings
JOIN trips ON bookings.trip_id = trips.trip_id
GROUP BY trips.category

select * from preferred_trip_types
order by total_bookings desc	

-- 3. Create View for Preferred Destinations (Most booked destinations)
CREATE VIEW preferred_destinations AS
SELECT
    location.destination_name,
    COUNT(trip_location.trip_id) AS total_bookings
FROM trip_location
JOIN location ON trip_location.location_id = location.dest_id
JOIN bookings ON bookings.trip_id = trip_location.trip_id
GROUP BY location.destination_name

select * from preferred_destinations
ORDER BY total_bookings DESC;

-- 4. Create View for Spending Habits (Average budget per traveler)
CREATE VIEW traveler_spending_habits AS
SELECT 
    travelers.reg_no,
    AVG(transactions.amount) AS average_spending
FROM travelers
JOIN bookings ON bookings.traveler_id = travelers.reg_no
JOIN transactions ON transactions.booking_id = bookings.booking_id
GROUP BY travelers.reg_no

select * from traveler_spending_habits
ORDER BY average_spending DESC;
--------------------------------------------------------------------------


create view avg_operator_rating as
select 
    o.reg_no,
    o.operator_name as operator_name,
    avg(r.rating) as avg_rating
from tour_operator o
join trips t on o.reg_no = t.operator_id
join trip_reviews r on t.trip_id = r.trip_id
group by o.reg_no, o.operator_name;

select * from avg_operator_rating


create view operator_total_revenue as
select 
    o.reg_no,
    o.operator_name as operator_name,
    sum(t.price_per_person)* COUNT(b.booking_id) as total_revenue
from tour_operator o
join trips t on o.reg_no = t.operator_id
join bookings b on t.trip_id = b.trip_id
group by o.reg_no, o.operator_name;

select * from operator_total_revenue

-------------------------------------------------



create view hotel_occupancy_rate as
select 
    hs.service_id,
    sp.provider_name,
    count(dp.pass_id) * 100.0 / nullif(s.capacity, 0) as approx_occupancy_rate
from hotel_services hs
join services s on hs.service_id = s.service_id
join service_provider sp on s.provider_id = sp.reg_no
left join digital_passes dp on hs.service_id = dp.service_id
where s.service_type = 'hotel'
group by hs.service_id, sp.provider_name, s.capacity;

select * from hotel_occupancy_rate


create view guide_service_ratings as
select 
    gs.service_id,
    gs.guide_name,
    avg(sr.rating) as avg_rating
from guide_services gs
join service_reviews sr on gs.service_id = sr.service_id
group by gs.service_id, gs.guide_name;

select * from guide_service_ratings


------------------check this one please---------------------
create view transport_performance_placeholder as
select 
    ts.service_id,
    ts.vehicle_type,
    'On-time performance data not available in current schema' as message
from transport_services ts;

select * from transport_performance_placeholder


------------------------------------------------------------
create view most_booked_destinations as
select 
    l.city,
    l.region,
    count(b.booking_id) as total_bookings
from bookings b
join trips t on b.trip_id = t.trip_id
join trip_location tl on t.trip_id = tl.trip_id
join location l on tl.location_id = l.dest_id
group by l.city, l.region

select * from most_booked_destinations
order by total_bookings desc;


create view seasonal_booking_trends as
select 
    datename(month, b.book_date) as booking_month,
    count(b.booking_id) as total_bookings
from bookings b
group by datename(month, b.book_date), month(b.book_date)

select * from seasonal_booking_trends


create view destination_satisfaction_scores as
select 
    l.city,
    l.region,
    avg(tr.rating) as avg_rating
from trip_reviews tr
join trips t on tr.trip_id = t.trip_id
join trip_location tl on t.trip_id = tl.trip_id
join location l on tl.location_id = l.dest_id
group by l.city, l.region;

select * from destination_satisfaction_scores


create view emerging_destinations as
select 
    l.city,
    l.region,
    count(case when b.book_date >= dateadd(month, -3, getdate()) then 1 end) as recent_bookings,
    count(case when b.book_date between dateadd(month, -6, getdate()) and dateadd(month, -3, getdate()) then 1 end) as previous_bookings,
    count(case when b.book_date >= dateadd(month, -3, getdate()) then 1 end) * 1.0 /
    nullif(count(case when b.book_date between dateadd(month, -6, getdate()) and dateadd(month, -3, getdate()) then 1 end), 0) as growth_ratio
from bookings b
join trips t on b.trip_id = t.trip_id
join trip_location tl on t.trip_id = tl.trip_id
join location l on tl.location_id = l.dest_id
group by l.city, l.region
having count(case when b.book_date >= dateadd(month, -3, getdate()) then 1 end) > 
       count(case when b.book_date between dateadd(month, -6, getdate()) and dateadd(month, -3, getdate()) then 1 end);

select * from emerging_destinations
-------------------------------------------------------------

create view abandonment_rate as
select 
    count(case when booking_status != 'confirmed' then 1 end) * 100.0 / 
    nullif(count(*), 0) as abandonment_percentage
from bookings;

select * from abandonment_rate


create view abandoned_booking_reasons as
select 
    reason_type,
    count(*) as occurrences
from (
    -- No payment = Payment failure
    select 'payment_failure' as reason_type
    from bookings b
    left join transactions t on b.booking_id = t.booking_id
    where b.booking_status != 'confirmed' and t.transaction_id is null

    union all

    -- Price > threshold = price issue (assuming 1000 as threshold)
    select 'high_price' as reason_type
    from bookings b
    join trips t on b.trip_id = t.trip_id
    where b.booking_status != 'confirmed' and t.price_per_person > 1000

    union all

    -- Too many abandoned on same day = complexity issue
    select 'complex_process' as reason_type
    from bookings
    where booking_status != 'confirmed'
    group by book_date
    having count(*) > 5
) as reasons
group by reason_type;

select * from abandoned_booking_reasons


create view abandoned_recovery_rate as
select 
    count(distinct b1.booking_id) as abandoned,
    count(distinct b2.booking_id) as recovered,
    count(distinct b2.booking_id) * 100.0 / 
    nullif(count(distinct b1.booking_id), 0) as recovery_percentage
from bookings b1
left join bookings b2 
    on b1.traveler_id = b2.traveler_id
    and b2.booking_status = 'confirmed'
    and b2.book_date > b1.book_date
where b1.booking_status != 'confirmed';

select * from abandoned_recovery_rate


create view potential_revenue_loss as
select 
    sum(t.price_per_person) as estimated_lost_revenue
from bookings b
join trips t on b.trip_id = t.trip_id
where b.booking_status != 'confirmed';

select * from potential_revenue_loss


----------------------------------------------
create view new_user_registrations as
select 
    format(users.created_date, 'yyyy-MM') as month,
    users.user_role,
    count(*) as total_registered
from users
group by format(created_date, 'yyyy-MM'),users.user_role;

select * from new_user_registrations


create view monthly_active_users as
select 
    format(book_date, 'yyyy-MM') as month,
    u.user_role,
    count(distinct b.traveler_id) as active_users
from bookings b
join users u on b.traveler_id = u.reg_no
where u.user_role in ('traveler', 'tour_operator')
group by format(book_date, 'yyyy-MM'), u.user_role;

select * from monthly_active_users


create view monthly_partnership_growth as
select 
    format(created_date, 'yyyy-MM') as month,
    user_role,
    count(*) as new_partners
from users
where user_role in ('tour_operator', 'service_provider')
group by format(created_date, 'yyyy-MM'), user_role;

select * from monthly_partnership_growth

---------------check this one--------------
create view regional_expansion as
select 
    format(trips.start_date, 'yyyy-MM') as month,
    count(distinct trips.title) as new_destinations
from trips
group by format(trips.start_date, 'yyyy-MM');

select * from regional_expansion


----------------------------------------------
create view payment_success_failure_rate as
select 
    format(transaction_date, 'yyyy-MM') as month,
    status,
    count(*) as total_transactions
from transactions
group by format(transaction_date, 'yyyy-MM'), status;

select * from payment_success_failure_rate


create view chargeback_rate as
select 
    format(transaction_date, 'yyyy-MM') as month,
    count(case when transactions.status = 'failed' then 1 end) as chargebacks,
    count(*) as total_transactions,
    round(100.0 * count(case when transactions.status = 'failed' then 1 end) / count(*), 2) as chargeback_percentage
from transactions
group by format(transaction_date, 'yyyy-MM');

select * from chargeback_rate