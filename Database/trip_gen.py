import csv
import random
from datetime import timedelta, date

def generate_trips_data(num_records=50):
    """
    Generates data for the 'trips' table with specified constraints.

    Args:
        num_records (int): The number of records to generate. Defaults to 50.

    Returns:
        list: A list of dictionaries, where each dictionary represents a row of data
              conforming to the 'trips' table schema.
    """
    if not isinstance(num_records, int) or num_records <= 0:
        raise ValueError("num_records must be a positive integer")

    data = []
    for i in range(1, num_records + 1):
        start_date = date(2025, random.randint(1, 12), random.randint(1, 28))
        duration = random.randint(3, 14)  # Duration of the trip in days
        end_date = start_date + timedelta(days=duration)
        operator_id = f"OP-{i:06d}"  # Operator IDs from OP-000001 to OP-000050

        data.append({
            "trip_id": i,
            "title": f"{'Adventure' if i % 3 == 0 else 'Cultural' if i % 2 == 0 else 'Leisure'} Tour",
            "descirption": "This is a generic description for a wonderful trip.  Enjoy the sights and sounds!",
            "image_url": f"https://example.com/trip{i}.jpg",  # Placeholder image URL
            "capacity": random.randint(10, 30),
            "duration": duration,
            "category": random.choice(['adventure', 'cultural', 'leisure']),
            "status": random.choice(['active', 'completed', 'cancelled']),
            "price_per_person": round(random.uniform(500, 3000), 2),
            "start_loc_id": random.randint(1, 50),  # start_loc_id should be 1-50
            "start_date": start_date.strftime('%Y-%m-%d'),
            "end_date": end_date.strftime('%Y-%m-%d'),
            "operator_id": operator_id,
        })
    return data

def generate_csv_file(data, filename="trips_data.csv"):
    """
    Generates a CSV file from a list of dictionaries.

    Args:
        data (list): A list of dictionaries, where each dictionary represents a row of data.
        filename (str): The name of the CSV file to create. Defaults to "trips_data.csv".
    """
    if not data:
        print("No data to write to CSV.")
        return

    if not isinstance(filename, str):
        raise TypeError("filename must be a string")
    if not filename.lower().endswith('.csv'):
        filename += '.csv'  # Ensure .csv extension

    # Extract the headers from the first dictionary in the data list.
    headers = list(data[0].keys())

    try:
        with open(filename, mode='w', newline='', encoding='utf-8') as csvfile:
            writer = csv.DictWriter(csvfile, fieldnames=headers)
            writer.writeheader()
            writer.writerows(data)
        print(f"CSV file '{filename}' successfully generated.")
    except Exception as e:
        print(f"An error occurred while writing to the CSV file: {e}")

if __name__ == "__main__":
    try:
        trips_data = generate_trips_data(num_records=50)
        generate_csv_file(trips_data)
    except ValueError as ve:
        print(f"Error: {ve}")
    except TypeError as te:
        print(f"Error: {te}")
