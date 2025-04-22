import csv
import random

def generate_service_provider_languages_data():
    """
    Generates data for service provider IDs and their supported languages.

    Returns:
        list: A list of dictionaries, where each dictionary contains 'reg_no' and 'language'.
    """
    service_provider_ids = [
        "SRV-000000", "SRV-000001", "SRV-000002", "SRV-000003", "SRV-000004",
        "SRV-000005", "SRV-000010", "SRV-000011", "SRV-000012", "SRV-000013",
        "SRV-000014", "SRV-000015", "SRV-000020", "SRV-000021", "SRV-000022",
        "SRV-000023", "SRV-000024", "SRV-000025", "SRV-000030", "SRV-000031"
    ]
    languages = ["English", "Spanish", "French", "German", "Italian", "Chinese", "Japanese", "Russian", "Arabic", "Hindi",
                 "Portuguese", "Dutch", "Swedish", "Turkish", "Korean", "Thai", "Vietnamese", "Indonesian", "Malay", "Swahili"]
    data = []
    for reg_no in service_provider_ids:
        num_languages = random.randint(2, 4)
        chosen_languages = random.sample(languages, num_languages)
        for language in chosen_languages:  # Iterate through each language
            data.append({
                "reg_no": reg_no,
                "language": language  # Each language gets its own row.
            })
    return data

def generate_csv_file(data, filename="service_provider_languages.csv"):
    """
    Generates a CSV file from a list of dictionaries.

    Args:
        data (list): A list of dictionaries, where each dictionary contains 'reg_no' and 'language'.
        filename (str): The name of the CSV file to create.
    """
    if not data:
        print("No data to write to CSV.")
        return

    if not isinstance(filename, str):
        raise TypeError("filename must be a string")
    if not filename.lower().endswith('.csv'):
        filename += '.csv'

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
        service_provider_languages_data = generate_service_provider_languages_data()
        generate_csv_file(service_provider_languages_data)
    except TypeError as e:
        print(f"Error: {e}")
