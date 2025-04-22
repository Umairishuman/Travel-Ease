import csv
import random

def generate_preferences_data(num_records=50):
    """
    Generates data for the Preferences table, ensuring each traveler has 3-5 preferences.

    Args:
        num_records (int, optional): The number of preference records to generate.  This is now a *minimum* number.
            The actual number of records will be between 3*number of users and 5*number of users
            Defaults to 50.

    Returns:
        list: A list of dictionaries, where each dictionary represents a preference record.
    """
    traveler_ids = [f"TR-{i:06d}" for i in range(1, 51)]  # TR-000001 to TR-000050
    continents = ['ASI', 'AFR', 'EUR', 'NAM', 'SAM', 'OCE', 'ANT']
    preferences_data = []

    for traveler_id in traveler_ids:
        num_preferences = random.randint(3, 5)  # Each traveler has 3-5 preferences
        for _ in range(num_preferences): # changed the loop
            continent = random.choice(continents)
            destination_number = random.randint(1, 10)
            destination_id = f"{continent}-{destination_number:06d}"
            preference_level = random.randint(1, 5)

            preferences_data.append({
                "traveler_id": traveler_id,
                "destination_id": destination_id,
                "preference_level": preference_level,
            })
    return preferences_data

def write_to_csv(data, filename="preferences_data.csv"):
    """
    Writes the generated preferences data to a CSV file.

    Args:
        data (list): A list of dictionaries, where each dictionary represents a preference record.
        filename (str, optional): The name of the CSV file to write to. Defaults to "preferences_data.csv".
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
    preferences_data = generate_preferences_data(num_records=50) # changed num_records
    write_to_csv(preferences_data)
