import csv
import random

def generate_location_id(continent_code, num):
    """
    Generates a location ID based on the continent code and a 6-digit number.

    Args:
        continent_code (str): The continent code (e.g., 'ASI', 'AFR', 'EUR').
        num (int): A 6-digit number.

    Returns:
        str: The generated location ID.
    """
    return f"{continent_code}-{num:06d}"

def generate_location_data(num_records=10):
    """
    Generates location data for each continent with realistic destination names,
    and returns it as a list of dictionaries.

    Args:
        num_records (int, optional): The number of records to generate for each continent. Defaults to 10.

    Returns:
        list: A list of dictionaries, where each dictionary represents a location record.
    """
    continents = {
        "ASI": "Asia",
        "AFR": "Africa",
        "EUR": "Europe",
        "NAM": "North America",
        "SAM": "South America",
        "OCE": "Oceania",
        "ANT": "Antarctica"
    }

    countries_by_continent = {
        "ASI": ["China", "India", "Japan", "South Korea", "Vietnam", "Thailand", "Malaysia", "Singapore", "Indonesia", "Pakistan"],
        "AFR": ["Nigeria", "Egypt", "South Africa", "Kenya", "Morocco", "Ghana", "Algeria", "Tanzania", "Ethiopia", "Angola"],
        "EUR": ["Germany", "France", "United Kingdom", "Italy", "Spain", "Netherlands", "Sweden", "Switzerland", "Poland", "Ukraine"],
        "NAM": ["United States", "Canada", "Mexico", "Cuba", "Jamaica", "Haiti", "Dominican Republic", "Puerto Rico", "Guatemala", "Panama"],
        "SAM": ["Brazil", "Argentina", "Colombia", "Peru", "Chile", "Venezuela", "Ecuador", "Bolivia", "Paraguay", "Uruguay"],
        "OCE": ["Australia", "New Zealand", "Fiji", "Papua New Guinea", "Hawaii", "Guam", "Micronesia", "Vanuatu", "Solomon Islands", "Marshall Islands"],
        "ANT": ["McMurdo Station", "Amundsen-Scott Station", "Vostok Station", "Palmer Station", "Esperanza Base", "Base San Martín",  "Orcadas Base", "Casey Station", "Mawson Station", "Davis Station"]
    }
    cities_by_continent = {
        "ASI": ["Beijing", "Mumbai", "Tokyo", "Seoul", "Hanoi", "Bangkok", "Kuala Lumpur", "Singapore", "Jakarta", "Karachi"],
        "AFR": ["Lagos", "Cairo", "Johannesburg", "Nairobi", "Casablanca", "Accra", "Algiers", "Dar es Salaam", "Addis Ababa", "Luanda"],
        "EUR": ["Berlin", "Paris", "London", "Rome", "Madrid", "Amsterdam", "Stockholm", "Zurich", "Warsaw", "Kyiv"],
        "NAM": ["New York", "Toronto", "Mexico City", "Havana", "Kingston", "Port-au-Prince", "Santo Domingo", "San Juan", "Guatemala City", "Panama City"],
        "SAM": ["Rio de Janeiro", "Buenos Aires", "Bogota", "Lima", "Santiago", "Caracas", "Quito", "La Paz", "Asuncion", "Montevideo"],
        "OCE": ["Sydney", "Auckland", "Suva", "Port Moresby", "Honolulu", "Hagatna", "Palikir", "Port Vila", "Honiara", "Majuro"],
        "ANT": ["McMurdo Station", "Amundsen-Scott Station", "Vostok Station","Palmer Station", "Esperanza Base", "Base San Martín", "Orcadas Base", "Casey Station", "Mawson Station", "Davis Station"]
    }

    # Realistic destination names
    destinations_by_country_city = {
        "China": {
            "Beijing": ["Forbidden City", "Great Wall of China", "Temple of Heaven"],
            "Shanghai": ["The Bund", "Yu Garden", "Oriental Pearl Tower"],
            "Xi'an": ["Terracotta Army", "City Wall of Xi'an", "Giant Wild Goose Pagoda"],
        },
        "India": {
            "Mumbai": ["Gateway of India", "Chhatrapati Shivaji Maharaj Terminus", "Elephanta Caves"],
            "Delhi": ["Red Fort", "Qutub Minar", "India Gate"],
            "Agra": ["Taj Mahal", "Agra Fort", "Fatehpur Sikri"],
        },
        "Japan": {
            "Tokyo": ["Tokyo Tower", "Senso-ji Temple", "Shibuya Crossing"],
            "Kyoto": ["Kinkaku-ji (Golden Pavilion)", "Fushimi Inari Shrine", "Arashiyama Bamboo Grove"],
            "Osaka": ["Osaka Castle", "Dotonbori", "Universal Studios Japan"],
        },
        "South Korea": {
            "Seoul": ["Gyeongbokgung Palace", "N Seoul Tower", "Bukchon Hanok Village"],
            "Busan": ["Haeundae Beach", "Gamcheon Culture Village", "Taejongdae Park"],
        },
        "Vietnam": {
            "Hanoi": ["Hoan Kiem Lake", "Ha Long Bay", "Temple of Literature"],
            "Ho Chi Minh City": ["Cu Chi Tunnels", "Notre-Dame Cathedral", "Ben Thanh Market"],
        },
        "Thailand": {
            "Bangkok": ["Wat Arun", "Grand Palace", "Chatuchak Weekend Market"],
            "Chiang Mai": ["Doi Suthep Temple", "Elephant Nature Park", "Old City"],
        },
        "Malaysia": {
            "Kuala Lumpur": ["Petronas Twin Towers", "Batu Caves", "KL Tower"],
            "Penang": ["George Town", "Penang Hill", "Batu Ferringhi"],
        },
        "Singapore": {
            "Singapore": ["Gardens by the Bay", "Marina Bay Sands", "Sentosa Island"],
        },
        "Indonesia": {
            "Jakarta": ["Monas (National Monument)", "Istiqlal Mosque", "Taman Mini Indonesia Indah"],
            "Bali": ["Ubud", "Kuta Beach", "Tanah Lot Temple"],
        },
        "Pakistan": {
            "Karachi": ["Mazar-e-Quaid", "Clifton Beach", "Frere Hall"],
            "Lahore": ["Badshahi Mosque", "Lahore Fort", "Shalimar Bagh"],
        },
        "Nigeria": {
            "Lagos": ["Lekki Conservation Centre", "National Museum Lagos", "Freedom Park"],
            "Abuja": ["Zuma Rock", "Millennium Park", "National Mosque"],
        },
        "Egypt": {
            "Cairo": ["Giza Necropolis", "Egyptian Museum", "Khan el-Khalili"],
            "Luxor": ["Karnak Temple", "Valley of the Kings", "Luxor Temple"],
        },
        "South Africa": {
            "Johannesburg": ["Apartheid Museum", "Gold Reef City", "Constitution Hill"],
            "Cape Town": ["Table Mountain", "Robben Island", "Victoria & Alfred Waterfront"],
        },
        "Kenya": {
            "Nairobi": ["Nairobi National Park", "David Sheldrick Wildlife Trust", "Bomas of Kenya"],
            "Mombasa": ["Fort Jesus", "Diani Beach", "Old Town"],
        },
        "Morocco": {
            "Marrakech": ["Jemaa el-Fna", "Bahia Palace", "Saadian Tombs"],
            "Fes": ["Fes el Bali", "Chouara tanneries", "Al-Attarine Madrasa"],
        },
        "Ghana": {
            "Accra": ["Independence Square", "Kwame Nkrumah Mausoleum", "Cape Coast Castle"],
        },
        "Algeria": {
            "Algiers": ["Kasbah of Algiers", "Martyrs' Memorial", "Jardin d'essai du Hamma"],
        },
        "Tanzania": {
            "Dar es Salaam": ["National Museum of Tanzania", "Kariakoo Market", "Bongoyo Island"],
            "Zanzibar City": ["Stone Town", "Spice Farms", "Prison Island"],
        },
        "Ethiopia": {
            "Addis Ababa": ["Bole", "Meskel Square", "Holy Trinity Cathedral"],
        },
        "Angola": {
            "Luanda": ["Marginal", "Fortress of São Miguel", "Ilha do Cabo"],
        },
        "Germany": {
            "Berlin": ["Brandenburg Gate", "Reichstag Building", "East Side Gallery"],
            "Munich": ["Marienplatz", "Neuschwanstein Castle", "Oktoberfest"],
        },
        "France": {
            "Paris": ["Eiffel Tower", "Louvre Museum", "Notre-Dame Cathedral"],
            "Nice": ["Promenade des Anglais", "Castle Hill", "Cours Saleya Market"],
        },
        "United Kingdom": {
            "London": ["Buckingham Palace", "Tower of London", "British Museum"],
            "Edinburgh": ["Edinburgh Castle", "Royal Mile", "Arthur's Seat"],
        },
        "Italy": {
            "Rome": ["Colosseum", "Vatican City", "Trevi Fountain"],
            "Florence": ["Uffizi Gallery", "Ponte Vecchio", "Duomo"],
        },
        "Spain": {
            "Madrid": ["Royal Palace of Madrid", "Prado Museum", "Retiro Park"],
            "Barcelona": ["Sagrada Familia", "Park Güell", "Gothic Quarter"],
        },
        "Netherlands": {
            "Amsterdam": ["Anne Frank House", "Rijksmuseum", "Van Gogh Museum"],
        },
        "Sweden": {
            "Stockholm": ["Vasa Museum", "Gamla Stan", "Skansen"],
        },
        "Switzerland": {
            "Zurich": ["Lake Zurich", "Bahnhofstrasse", "Grossmünster"],
            "Geneva": ["Lake Geneva", "Jet d'Eau", "Palais des Nations"],
        },
        "Poland": {
            "Warsaw": ["Old Town Warsaw", "Royal Castle", "Warsaw Uprising Museum"],
            "Krakow": ["Wawel Castle", "Main Market Square", "Auschwitz-Birkenau Memorial and Museum"],
        },
        "Ukraine": {
            "Kyiv": ["Saint Sophia's Cathedral", "Kyiv Pechersk Lavra", "Maidan Nezalezhnosti"],
        },
        "United States": {
            "New York": ["Statue of Liberty", "Empire State Building", "Central Park"],
            "Los Angeles": ["Hollywood Walk of Fame", "Getty Center", "Santa Monica Pier"],
            "Chicago": ["Willis Tower", "Millennium Park", "Navy Pier"],
        },
        "Canada": {
            "Toronto": ["CN Tower", "Royal Ontario Museum", "Niagara Falls"],
            "Vancouver": ["Stanley Park", "Granville Island", "Gastown"],
        },
        "Mexico": {
            "Mexico City": ["Zocalo", "Templo Mayor", "Frida Kahlo Museum"],
            "Cancun": ["Chichen Itza", "Playa Delfines", "Xcaret Park"],
        },
        "Cuba": {
            "Havana": ["Old Havana", "El Malecón", "Plaza de la Revolución"],
        },
        "Jamaica": {
            "Kingston": ["Bob Marley Museum", "Port Royal", "Blue Mountains"],
        },
        "Haiti": {
            "Port-au-Prince": ["National Palace", "Citadelle Laferrière", "Barbancourt Rum Distillery"],
        },
        "Dominican Republic": {
            "Santo Domingo": ["Zona Colonial", "Alcázar de Colón", "The Three Eyes National Park"],
        },
        "Puerto Rico": {
            "San Juan": ["Old San Juan", "El Morro", "Condado Beach"],
        },
        "Guatemala": {
            "Guatemala City": ["Tikal National Park", "Lake Atitlán", "Antigua Guatemala"],
        },
        "Panama": {
            "Panama City": ["Panama Canal", "Casco Viejo", "Biomuseo"],
        },
        "Brazil": {
            "Rio de Janeiro": ["Christ the Redeemer", "Copacabana Beach", "Sugarloaf Mountain"],
            "São Paulo": ["Avenida Paulista", "Ibirapuera Park", "MASP"],
        },
        "Argentina": {
            "Buenos Aires": ["Recoleta Cemetery", "Plaza de Mayo", "Teatro Colón"],
            "Mendoza": ["Aconcagua", "Wine Route", "San Rafael"],
        },
        "Colombia": {
            "Bogota": ["La Candelaria", "Monserrate", "Gold Museum"],
            "Medellin": ["Comuna 13", "Guatapé", "Plaza Botero"],
        },
        "Peru": {
            "Lima": ["Miraflores", "Plaza de Armas", "Larco Museum"],
            "Cusco": ["Machu Picchu", "Sacred Valley", "Ollantaytambo"],
        },
        "Chile": {
            "Santiago": ["San Cristobal Hill", "Plaza de Armas", "La Chascona"],
            "Valparaíso": ["La Sebastiana", "Cerro Alegre", "Paseo 21 de Mayo"],
        },
        "Venezuela": {
            "Caracas": ["El Ávila National Park", "Plaza Bolívar", "Panteón Nacional"],
        },
        "Ecuador": {
            "Quito": ["Mitad del Mundo", "Historic Center of Quito", "Teleférico Quito"],
            "Galapagos Islands": ["Santa Cruz Island", "San Cristobal Island", "Isabela Island"],
        },
        "Bolivia": {
            "La Paz": ["Lake Titicaca", "Salar de Uyuni", "Death Road"],
        },
        "Paraguay": {
            "Asuncion": ["Costanera de Asunción", "Palacio de los López", "Manzana de la Rivera"],
        },
        "Uruguay": {
            "Montevideo": ["Ciudad Vieja", "Rambla of Montevideo", "Mercado del Puerto"],
        },
        "Australia": {
            "Sydney": ["Sydney Opera House", "Sydney Harbour Bridge", "Bondi Beach"],
            "Melbourne": ["Great Ocean Road", "Royal Botanic Gardens Victoria", "Yarra River"],
        },
        "New Zealand": {
            "Auckland": ["Sky Tower", "Auckland Domain", "Waitakere Ranges"],
            "Queenstown": ["Lake Wakatipu", "The Remarkables", "Adventure Activities"],
        },
        "Fiji": {
            "Suva": ["Fiji Museum", "Thurston Gardens", "Colo-i-Suva Forest Park"],
        },
        "Papua New Guinea": {
            "Port Moresby": ["National Museum and Art Gallery", "Varirata National Park", "Ela Beach"],
        },
        "Hawaii": {
            "Honolulu": ["Waikiki Beach", "Pearl Harbor", "Diamond Head"],
        },
        "Guam": {
            "Hagatna": ["Two Lovers Point", "Pacific War Museum", "Tumon Bay"],
        },
        "Micronesia": {
            "Palikir":  ["Nan Madol", "Kepirohi Waterfall", "Pohnpei Surf Club"],
        },
        "Vanuatu": {
            "Port Vila": ["Hideaway Island", "Mele Cascades", "Efate"],
        },
        "Solomon Islands": {
            "Honiara": ["Guadalcanal American Memorial", "National Museum", "Botanical Garden"],
        },
        "Marshall Islands": {
            "Majuro": ["Alele Museum", "Laura Village", "Kalalin Pass"],
        },
        "Antarctica": {
            "McMurdo Station": ["Ross Island", "Mount Erebus", "Scott's Hut"],
            "Amundsen-Scott Station": ["South Pole", "Amundsen-Scott South Pole Station"],
            "Vostok Station": ["Lake Vostok", "East Antarctic Ice Sheet"],
            "Palmer Station": ["Anvers Island", "Palmer Basin"],
            "Esperanza Base": ["Hope Bay", "Lamaire Channel"],
            "Base San Martín": ["San Martín Base", "Marguerite Bay"],
            "Orcadas Base": ["Laurie Island", "Scotia Sea"],
            "Casey Station": ["Vincennes Bay", "Bailey Peninsula"],
            "Mawson Station": ["Holme Bay", "Framnes Mountains"],
            "Davis Station": ["Vestfold Hills", "Prydz Bay"],
        }
    }

    data = []
    for continent_code, continent_name in continents.items():
        for i in range(num_records):
            record_id = generate_location_id(continent_code, i + 1)
            country = countries_by_continent[continent_code][i]
            city = cities_by_continent[continent_code][i]

            # Get a realistic destination name
            if country in destinations_by_country_city and city in destinations_by_country_city[country]:
                destination_name = random.choice(destinations_by_country_city[country][city])
            else:
                destination_name = f"{continent_name} Destination {i+1}"  # Fallback

            data.append({
                "dest_id": record_id,
                "destination_name": destination_name,
                "city": city,
                "region": continent_name,
                "country": country
            })
    return data

def write_to_csv(data, filename="location_data.csv"):
    """
    Writes the generated location data to a CSV file.

    Args:
        data (list): A list of dictionaries, where each dictionary represents a location record.
        filename (str, optional): The name of the CSV file to write to. Defaults to "location_data.csv".
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
    location_data = generate_location_data(num_records=10)
    write_to_csv(location_data)
