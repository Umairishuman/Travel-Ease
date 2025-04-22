import csv
import random

def generate_trip_location_data(num_trips=50):
    """
    Generates data for the trip_location table.

    Args:
        num_trips (int, optional): The number of trips. Defaults to 50.

    Returns:
        list: A list of dictionaries, where each dictionary represents a trip_location record.
    """
    trip_ids = [f"TRIP-{i:06d}" for i in range(1, num_trips + 1)]  # TRIP-000001 to TRIP-000050
    continents = ['ASI', 'AFR', 'EUR', 'NAM', 'SAM', 'OCE', 'ANT']
    trip_location_data = []

    for trip_id in trip_ids:
        # Determine the number of locations for this trip (1 to 4, as you specified)
        num_locations = random.randint(1, 4)
        
        # To ensure unique locations per trip, we'll track used location_ids
        used_location_ids = set()

        for order in range(1, num_locations + 1):
            while True:
                continent = random.choice(continents)
                location_number = random.randint(1, 10)
                location_id = f"{continent}-{location_number:06d}"
                
                if location_id not in used_location_ids:
                    used_location_ids.add(location_id)
                    break # Exit the while loop, we found a unique location

            trip_location_data.append({
                "trip_id": trip_id,
                "location_id": location_id,
                "destination_order": order,
            })
    return trip_location_data

def write_to_csv(data, filename="trip_location_data.csv"):
    """
    Writes the generated trip_location data to a CSV file.

    Args:
        data (list): A list of dictionaries, where each dictionary represents a trip_location record.
        filename (str, optional): The name of the CSV file to write to. Defaults to "trip_location_data.csv".
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
    trip_location_data = generate_trip_location_data(num_trips=50)
    write_to_csv(trip_location_data)
