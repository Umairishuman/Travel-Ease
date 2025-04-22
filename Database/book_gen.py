import csv
import random
from datetime import datetime, timedelta

def generate_bookings_data(num_records=50):
    """
    Generates data for the bookings table.

    Args:
        num_records (int, optional): The number of booking records to generate. Defaults to 50.

    Returns:
        list: A list of dictionaries, where each dictionary represents a booking record.
    """
    booking_status_options = ['confirmed', 'pending', 'cancelled', 'abandoned']
    traveler_ids = [f"TR-{i:06d}" for i in range(1, 51)]  # TR-000001 to TR-000050
    trip_ids = [f"TRIP-{i:06d}" for i in range(1, 51)]    # TRIP-000001 to TRIP-000050

    bookings_data = []
    for i in range(num_records):
        booking_id = f"BOOK-{i+1:06d}"
        book_date = datetime.now() - timedelta(days=random.randint(1, 365))  # Random date in the past year
        booking_status = random.choice(booking_status_options)
        traveler_id = random.choice(traveler_ids)
        trip_id = random.choice(trip_ids)

        bookings_data.append({
            "booking_id": booking_id,
            "book_date": book_date.strftime('%Y-%m-%d %H:%M:%S'),
            "booking_status": booking_status,
            "traveler_id": traveler_id,
            "trip_id": trip_id,
        })
    return bookings_data

def write_to_csv(data, filename="bookings_data.csv"):
    """
    Writes the generated bookings data to a CSV file.

    Args:
        data (list): A list of dictionaries, where each dictionary represents a booking record.
        filename (str, optional): The name of the CSV file to write to. Defaults to "bookings_data.csv".
    """
    if not data:
        print("No data to write to CSV.")
        return

    fieldnames = data[0].keys()
    try:
        with open(filename, mode='w', newline='', encoding='utf-8') as csvfile:
            writer = csv.DictWriter(csvfile, fieldnames=fieldnames)
            writer.writeheader()
            writer.writerows(data)
        print(f"Data successfully written to {filename}")
    except Exception as e:
        print(f"An error occurred while writing to CSV: {e}")

if __name__ == "__main__":
    bookings_data = generate_bookings_data(num_records=50)
    write_to_csv(bookings_data)
