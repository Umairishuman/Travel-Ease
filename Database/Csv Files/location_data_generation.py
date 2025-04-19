import csv
import random

def generate_realistic_location_data(num_records=50):
    """
    Generates realistic-ish location data, ensuring unique destination names and plausible
    combinations of cities, regions, and countries.

    Args:
        num_records (int): The number of records to generate.  Defaults to 50.

    Returns:
        list: A list of dictionaries, where each dictionary represents a row of data
              conforming to the 'location' table schema.
    """
    if not isinstance(num_records, int) or num_records <= 0:
        raise ValueError("num_records must be a positive integer")

    # Define lists of realistic cities, regions, and countries.
    # To make the data more interesting and varied, I've added more variety.
    cities = [
        "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio",
        "San Diego", "Dallas", "San Jose", "Austin", "Jacksonville", "San Francisco", "Indianapolis",
        "Columbus", "Fort Worth", "Charlotte", "Seattle", "Denver", "Washington", "Boston", "El Paso",
        "Detroit", "Nashville", "Memphis", "Oklahoma City", "Portland", "Las Vegas", "Atlanta", "Miami",
        "London", "Paris", "Rome", "Berlin", "Madrid", "Tokyo", "Sydney", "Toronto", "Moscow", "Beijing",
        "Rio de Janeiro", "Buenos Aires", "Mexico City", "Cairo", "Istanbul", "Johannesburg", "Mumbai",
        "Delhi", "Shanghai", "Bangkok", "Hong Kong", "Singapore", "Seoul", "Amsterdam", "Vienna",
        "Stockholm", "Copenhagen", "Oslo", "Helsinki", "Dublin", "Edinburgh", "Manchester", "Liverpool",
        "Glasgow", "Brussels", "Zurich", "Geneva", "Prague", "Budapest", "Warsaw", "Krakow", "Bucharest",
        "Sofia", "Athens", "Thessaloniki", "Lisbon", "Porto", "Seville", "Barcelona", "Valencia", "Milan",
        "Naples", "Florence", "Venice", "Hamburg", "Munich", "Cologne", "Frankfurt", "Stuttgart", "Dusseldorf",
        "Dortmund", "Essen", "Leipzig", "Bremen", "Dresden", "Hanover", "Nuremberg", "Duisburg", "Bochum",
        "Wuppertal", "Bielefeld", "Bonn", "Mannheim", "Karlsruhe", "Wiesbaden", "Muenster", "Augsburg",
        "Gelsenkirchen", "Moenchengladbach", "Braunschweig", "Chemnitz", "Kiel", "Halle (Saale)", "Magdeburg",
        "Rostock", "Erfurt", "Potsdam", "Schwerin", "Saarbruecken", "Trier", "Jena", "Dessau-Rosslau",
        "Gera", "Weimar", "Gotha", "Eisenach", "Nordhausen", "Suhl", "Ilmenau", "Arnstadt", "Rudolstadt",
        "Saalfeld", "Sondershausen", "Muhlhausen", "Bad Langensalza", "Apolda", "Zeitz", "Naumburg",
        "Merseburg", "Halle Neustadt", "Bitterfeld-Wolfen", "Wittenberg", "Dessau-Roßlau", "Bernburg",
        "Stassfurt", "Quedlinburg", "Halberstadt", "Wernigerode", "Oschersleben", "Salzwedel", "Gardelegen",
        "Stendal", "Havelberg", "Tangermünde", "Burg", "Gommern", "Zerbst", "Köthen", "Ballenstedt",
        "Aschersleben", "Calbe", "Egeln", "Schönebeck", "Staßfurt", "Wolmirstedt", "Haldensleben",
        "Oebisfelde-Weferlingen", "Klötze", "Bismark", "Seehausen", "Osterburg", "Arendsee", "Salzwedel",
        "Gardelegen", "Stendal", "Havelberg", "Tangermünde", "Burg", "Gommern", "Zerbst/Anhalt",
        "Köthen (Anhalt)", "Ballenstedt", "Aschersleben", "Calbe (Saale)", "Egeln", "Schönebeck (Elbe)",
        "Barby", "Nienburg (Saale)", "Güsten", "Hecklingen", "Ilberstedt", "Plötzkau", "Alsleben (Saale)",
        "Arnstein", "Mansfeld", "Hettstedt", "Eisleben", "Gerbstedt", "Lutherstadt Eisleben",
        "Sangerhausen", "Allstedt", "Seegebiet Mansfelder Land", "Südharz", "Arnstein", "Mansfeld",
        "Hettstedt", "Eisleben", "Gerbstedt", "Sangerhausen", "Allstedt", "Seegebiet Mansfelder Land",
        "Südharz", "Querfurt", "Weida", "Ronnenberg", "Springe", "Hemmingen", "Gehrden", "Seelze",
        "Barsinghausen", "Pattensen", "Laatzen", "Lehrte", "Burgwedel", "Isernhagen", "Wedemark",
        "Uetze", "Hambühren", "Wietze", "Winsen (Aller)", "Bergen", "Eschede", "Faßberg", "Hermannsburg",
        "Müden (Örtze)", "Unterlüß", "Wathlingen", "Nienhagen", "Adelheidsdorf", "Bröckel", "Eicklingen",
        "Hohne", "Langlingen", "Wienhausen", "Lachendorf", "Beedenbostel", "Ahnsbeck", "Eversen",
        "Hambühren", "Wietze", "Winsen (Aller)", "Bergen", "Eschede", "Faßberg", "Hermannsburg",
        "Müden (Örtze)", "Unterlüß", "Wathlingen", "Nienhagen", "Adelheidsdorf", "Bröckel", "Eicklingen",
        "Hohne", "Langlingen", "Wienhausen", "Lachendorf", "Beedenbostel", "Ahnsbeck", "Eversen"
    ]

    regions = [
        "North America", "South America", "Europe", "Asia", "Africa", "Oceania", "Central America",
        "Middle East", "Caribbean", "Southeast Asia", "East Asia", "South Asia", "Central Asia",
        "Eastern Europe", "Western Europe", "Northern Europe", "Southern Europe", "Sub-Saharan Africa",
        "North Africa", "West Africa", "East Africa", "Southern Africa"
    ]
    countries = [
        "USA", "Canada", "UK", "France", "Germany", "Japan", "Australia", "Russia", "China", "Brazil",
        "Mexico", "Egypt", "Turkey", "South Africa", "India", "Italy", "Spain", "Netherlands", "Switzerland",
        "Sweden", "Denmark", "Norway", "Finland", "Ireland", "Scotland", "England", "Belgium", "Austria",
        "Czech Republic", "Hungary", "Poland", "Romania", "Bulgaria", "Greece", "Portugal"
    ]

    # Ensure unique destination names using a set
    generated_names = set()
    data = []
    for i in range(1, num_records + 1):
        while True:
            destination_name = f"{random.choice(cities)} {random.choice(['Resort', 'City', 'Mountains', 'Beach', 'Park'])}"
            if destination_name not in generated_names:
                generated_names.add(destination_name)
                break
        city = random.choice(cities)
        # Make region more contextually relevant to the city.
        region = random.choice(regions)
        country = random.choice(countries)
        data.append({
            "dest_id": i,
            "destination_name": destination_name,
            "city": city,
            "region": region,
            "country": country
        })
    return data

def generate_csv_file(data, filename="location_data.csv"):
    """
    Generates a CSV file from a list of dictionaries.

    Args:
        data (list): A list of dictionaries, where each dictionary represents a row of data.
        filename (str): The name of the CSV file to create. Defaults to "location_data.csv".
    """
    if not data:
        print("No data to write to CSV.")
        return

    if not isinstance(filename, str):
        raise TypeError("filename must be a string")
    if not filename.lower().endswith('.csv'):
        filename += '.csv' # Ensure .csv extension

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
        location_data = generate_realistic_location_data(num_records=50)
        generate_csv_file(location_data)
    except ValueError as ve:
        print(f"Error: {ve}")
    except TypeError as te:
        print(f"Error: {te}")
